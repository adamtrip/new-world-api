using Application.Common.Reflection;
using Domain.Entities.NewWorld.AffixStatData;

namespace Application.NewWorld.AffixStatData
{
    public record ImportAffixStatDataRequest : IRequest;

    public class ImportAffixStatDataRequestHandler : IRequestHandler<ImportAffixStatDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<AffixStatDataTable> repository;

        public ImportAffixStatDataRequestHandler(ISerializerService serializerService, IRepository<AffixStatDataTable> repository)
        {
            this.serializerService = serializerService;
            this.repository = repository;
        }

        public async ValueTask<Unit> Handle(ImportAffixStatDataRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "AffixStatData"));
            var items = new List<AffixStatDataTable>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<AffixStatDataTable>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<AffixStatDataTable>>(json);
                }

                items.AddRange(objectData);
            }

            var existingAffixStatDataTable = await repository.ListAsync();
            var newAffixStatDataTable = items.Where(x => !existingAffixStatDataTable.Select(x => x.StatusID).Contains(x.StatusID)).ToList();
            var updateAffixStatDataTable = existingAffixStatDataTable.Where(x => !items.Select(x => x.StatusID).Contains(x.StatusID)).ToList();

            existingAffixStatDataTable.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.StatusID == x.StatusID), x));

            if (newAffixStatDataTable.Any()) await repository.AddRangeAsync(newAffixStatDataTable, cancellationToken);
            if (updateAffixStatDataTable.Any()) await repository.UpdateRangeAsync(updateAffixStatDataTable, cancellationToken);

            return default!;
        }
    }
}
