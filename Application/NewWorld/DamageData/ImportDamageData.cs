using Application.Common.Reflection;
using Domain.Entities.NewWorld.DamageData;

namespace Application.NewWorld.DamageData
{
    public record ImportDamageDataRequest : IRequest;
    public class ImportDamageDataRequestHandler : IRequestHandler<ImportDamageDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<DamageTable> repository;

        public ImportDamageDataRequestHandler(ISerializerService serializerService, IRepository<DamageTable> repository)
        {
            this.serializerService = serializerService;
            this.repository = repository;
        }

        public async ValueTask<Unit> Handle(ImportDamageDataRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "DamageData"));
            var items = new List<DamageTable>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                if (fileName != "DamageTable") continue;
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<DamageTable>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<DamageTable>>(json);
                }

                items.AddRange(objectData);
            }

            var existingDamageData = await repository.ListAsync();
            var newDamageData = items.Where(x => !existingDamageData.Select(z => z.DamageID).Contains(x.DamageID));
            var updateDamageData = existingDamageData.Where(x => items.Select(z => z.DamageID).Contains(x.DamageID));

            existingDamageData.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.DamageID == x.DamageID), x));

            if (newDamageData.Any()) await repository.AddRangeAsync(newDamageData);
            if (updateDamageData.Any()) await repository.UpdateRangeAsync(updateDamageData);

            return default!;
        }
    }
}
