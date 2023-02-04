using Application.Common.Reflection;
using Domain.Entities.NewWorld.StatusEffectData;

namespace Application.NewWorld.StatusEffectData
{
    public record ImportStatusEffectRequest : IRequest;

    public class ImportStatusEffectRequestHandler : IRequestHandler<ImportStatusEffectRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<StatusEffects> repository;

        public ImportStatusEffectRequestHandler(ISerializerService serializerService, IRepository<StatusEffects> repository)
        {
            this.serializerService = serializerService;
            this.repository = repository;
        }

        public async ValueTask<Unit> Handle(ImportStatusEffectRequest request, CancellationToken cancellationToken)
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "StatusEffectData"));
            var items = new List<StatusEffects>();
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                //var masterItemType = fileName.Split('_')[1];
                var objectData = new List<StatusEffects>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<List<StatusEffects>>(json);
                }

                items.AddRange(objectData);
            }

            var existingStatusEffects = await repository.ListAsync();
            var newStatusEffects = items.Where(x => !existingStatusEffects.Select(z => z.StatusID).Contains(x.StatusID));
            var updateStatusEffects = existingStatusEffects.Where(x => items.Select(z => z.StatusID).Contains(x.StatusID));

            existingStatusEffects.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.StatusID == x.StatusID), x));

            if (newStatusEffects.Any()) await repository.AddRangeAsync(newStatusEffects);
            if (updateStatusEffects.Any()) await repository.UpdateRangeAsync(updateStatusEffects);

            return default!;
        }
    }
}
