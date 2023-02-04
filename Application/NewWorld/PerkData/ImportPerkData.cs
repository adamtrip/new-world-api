using Application.Common.Reflection;
using Application.NewWorld.Locale;
using Domain.Entities.NewWorld;
using Domain.Entities.NewWorld.PerkData;

namespace Application.NewWorld.PerkData
{
    public record ImportPerkDataRequest : IRequest;

    public class ImportPerkDataRequestHandler : IRequestHandler<ImportPerkDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<ItemPerk> repository;
        private readonly IRepository<Locales> localesRepository;
        private readonly IMediator mediator;

        public ImportPerkDataRequestHandler(ISerializerService serializerService, IRepository<ItemPerk> repository, IRepository<Locales> localesRepository, IMediator mediator)
        {
            this.serializerService = serializerService;
            this.repository = repository;
            this.localesRepository = localesRepository;
            this.mediator = mediator;
        }

        public async ValueTask<Unit> Handle(ImportPerkDataRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "PerkData"));
            var items = new List<ItemPerk>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<ItemPerk>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<ItemPerk>>(json);
                }

                if (file.Contains("Deprecated")) objectData.ForEach(x => x.IsDeprecated = true);

                items.AddRange(objectData);
            }

            foreach (var item in items)
            {
                item.MasterName = await mediator.Send(new GetItemLocalesRequest(item.DisplayName, null, null, SearchType.Name), cancellationToken);

                var localedDescription = await mediator.Send(new GetItemLocalesRequest(item.Description, null, null, SearchType.Description), cancellationToken);
                item.MasterDescription = await mediator.Send(new CalculatePerkDescriptionRequest(localedDescription, item.ItemClassGSBonus, item.ScalingPerGearScore), cancellationToken);

                item.IconPath = item.IconPath?.Replace("lyshineui", "");
            }

            var existingPerkData = await repository.ListAsync();
            var newPerkData = items.Where(x => !existingPerkData.Select(z => z.PerkID).Contains(x.PerkID));
            var updatePerkData = existingPerkData.Where(x => items.Select(z => z.PerkID).Contains(x.PerkID));

            existingPerkData.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.PerkID == x.PerkID), x));

            if (newPerkData.Any()) await repository.AddRangeAsync(newPerkData);
            if (updatePerkData.Any()) await repository.UpdateRangeAsync(updatePerkData);

            return default!;
        }
    }
}
