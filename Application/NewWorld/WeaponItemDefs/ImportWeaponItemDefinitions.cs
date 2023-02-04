using Domain.Entities.NewWorld.WeaponItemDefinitions;

namespace Application.NewWorld.WeaponItemDefs
{
    public record ImportWeaponItemDefinitionsRequest(bool Update) : IRequest;

    public class ImportWeaponItemDefinitionsRequestHandler : IRequestHandler<ImportWeaponItemDefinitionsRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<WeaponItemDefinitions> repository;

        public ImportWeaponItemDefinitionsRequestHandler(ISerializerService serializerService, IRepository<WeaponItemDefinitions> repository)
        {
            this.serializerService = serializerService;
            this.repository = repository;
        }

        public async ValueTask<Unit> Handle(ImportWeaponItemDefinitionsRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "WeaponItemDefinitions"));
            var items = new List<WeaponItemDefinitions>();
            foreach (var file in files.Where(x => x.Contains("WeaponItemDefinitions.json")))
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<WeaponItemDefinitions>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<WeaponItemDefinitions>>(json);
                }
                items.AddRange(objectData);
            }

            var existingWeaponItemDefinitions = await repository.ListAsync();
            var newWeaponItemDefinitions = items.Where(x => !existingWeaponItemDefinitions.Select(x => x.WeaponID).Contains(x.WeaponID)).ToList();
            var updateWeaponItemDefinitions = existingWeaponItemDefinitions.Where(x => !items.Select(x => x.WeaponID).Contains(x.WeaponID)).ToList();

            if (newWeaponItemDefinitions.Any())
                await repository.AddRangeAsync(newWeaponItemDefinitions, cancellationToken);

            if (updateWeaponItemDefinitions.Any() && request.Update)
                await repository.UpdateRangeAsync(updateWeaponItemDefinitions, cancellationToken);

            return default!;
        }
    }
}
