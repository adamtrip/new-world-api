using Application.Common.Reflection;
using Domain.Entities.NewWorld.ConsumableItemDefinitions;

namespace Application.NewWorld.ConsumableItem
{
    public record ImportConsumableItemDefinitionsRequest : IRequest;

    public class ImportConsumableItemDefinitionsRequestHandler : IRequestHandler<ImportConsumableItemDefinitionsRequest>
    {
        private readonly IRepository<ConsumableItemDefinitions> repository;
        private readonly ISerializerService serializerService;

        public ImportConsumableItemDefinitionsRequestHandler(IRepository<ConsumableItemDefinitions> repository, ISerializerService serializerService)
        {
            this.repository = repository;
            this.serializerService = serializerService;
        }

        public async ValueTask<Unit> Handle(ImportConsumableItemDefinitionsRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "ConsumableItemDefinitions"));
            var items = new List<ConsumableItemDefinitions>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<ConsumableItemDefinitions>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<ConsumableItemDefinitions>>(json);
                }

                items.AddRange(objectData);
            }

            var existingConsumableItemDefinitions = await repository.ListAsync();
            var newConsumableItemDefinitions = items.Where(x => !existingConsumableItemDefinitions.Select(x => x.ConsumableID).Contains(x.ConsumableID)).ToList();
            var updateConsumableItemDefinitions = existingConsumableItemDefinitions.Where(x => !items.Select(x => x.ConsumableID).Contains(x.ConsumableID)).ToList();

            existingConsumableItemDefinitions.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.ConsumableID == x.ConsumableID), x));

            if (newConsumableItemDefinitions.Any()) await repository.AddRangeAsync(newConsumableItemDefinitions, cancellationToken);
            if (updateConsumableItemDefinitions.Any()) await repository.UpdateRangeAsync(updateConsumableItemDefinitions, cancellationToken);

            return default!;
        }
    }
}
