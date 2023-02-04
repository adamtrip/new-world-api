using Application.Common.Reflection;
using Application.NewWorld.Locale;
using Domain.Entities.NewWorld;

namespace Application.NewWorld.MasterItemDefinitions
{
    public record ImportMasterItemDefinitionsRequest : IRequest<string>;

    public class ImportMasterItemDefinitionsRequestHandler : IRequestHandler<ImportMasterItemDefinitionsRequest, string>
    {
        private readonly IRepository<MasterItemDefinition> repository;
        private readonly IReadRepository<MasterItemDefinition> readRepository;
        private readonly ISerializerService serializerService;
        private readonly IMediator mediator;

        public ImportMasterItemDefinitionsRequestHandler(IRepository<MasterItemDefinition> repository, ISerializerService serializerService, IReadRepository<MasterItemDefinition> readRepository, IMediator mediator)
        {
            this.repository = repository;
            this.serializerService = serializerService;
            this.readRepository = readRepository;
            this.mediator = mediator;
        }

        public async ValueTask<string> Handle(ImportMasterItemDefinitionsRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "MasterItemDefinitions"));
            var items = new List<MasterItemDefinition>();
            var itemsToInsert = new List<MasterItemDefinition>();
            var itemsToUpdate = new List<MasterItemDefinition>();
            var currentList = await readRepository.ListAsync();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                var masterItemType = fileName.Split('_')[1];
                var objectData = new List<MasterItemDefinition>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<MasterItemDefinition>>(json);
                }

                objectData.ForEach(x => x.ItemFileType = masterItemType);
                objectData.ForEach(x => x.IsDepricated = fileName.Contains("Depricated", StringComparison.InvariantCultureIgnoreCase) ? true : false);

                items.AddRange(objectData);
            }

            //Load the item descriptions already
            //foreach (var item in items)
            //{
            //    item.MasterName = await mediator.Send(new GetItemLocalesRequest(item.Name, null, item.ItemID));
            //    item.MasterDescription = await mediator.Send(new GetItemLocalesRequest(item.Description, null, item.ItemID, SearchType.Description));
            //    item.IconPath = item.IconPath?.Replace("lyshineui", "");
            //    Reflection.CopyProperties(item, currentList.FirstOrDefault(x => x.ItemID == item.ItemID));
            //}

            items = await mediator.Send(new GetItemsLocalesRequest(items), cancellationToken);

            items.ForEach(z => Reflection.CopyProperties(z, currentList.FirstOrDefault(x => x.ItemID == z.ItemID)));

            itemsToInsert = items.Where(x => !currentList.Select(x => x.ItemID).Contains(x.ItemID)).ToList();
            itemsToUpdate = currentList.Where(x => items.Select(x => x.ItemID).Contains(x.ItemID)).ToList();

            if (itemsToInsert.Any())
            {
                var count = 0;
                var bulkItems = new List<MasterItemDefinition>();
                foreach (var itemToInsert in itemsToInsert)
                {
                    if (count == 1000)
                    {
                        await repository.AddRangeAsync(bulkItems);
                        bulkItems.Clear();
                        count = 0;
                    }
                    bulkItems.Add(itemToInsert);
                    count++;
                }

                await repository.AddRangeAsync(bulkItems);
            }

            if (itemsToUpdate.Any())
            {
                var count = 0;
                var bulkItems = new List<MasterItemDefinition>();
                foreach (var itemToInsert in itemsToUpdate)
                {
                    if (count == 1000)
                    {
                        await repository.UpdateRangeAsync(bulkItems);
                        bulkItems.Clear();
                        count = 0;
                    }
                    bulkItems.Add(itemToInsert);
                    count++;
                }

                await repository.UpdateRangeAsync(bulkItems);
            }
            //if (itemsToUpdate.Any()) await repository.UpdateRangeAsync(itemsToUpdate, cancellationToken);

            return AppDomain.CurrentDomain.BaseDirectory;
        }

    }
}
