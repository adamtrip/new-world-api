using Application.Common.Reflection;
using Domain.Entities.NewWorld.SpellData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.SpellData
{
    public record ImportSpellDataRequest : IRequest;
    public class ImportSpellDataRequestHandler : IRequestHandler<ImportSpellDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<SpellDataTable> repository;

        public ImportSpellDataRequestHandler(ISerializerService serializerService, IRepository<SpellDataTable> repository)
        {
            this.serializerService = serializerService;
            this.repository = repository;
        }

        public async ValueTask<Unit> Handle(ImportSpellDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "SpellData"));
                var items = new List<SpellDataTable>();
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file).Split(".")[0];
                    //var masterItemType = fileName.Split('_')[1];
                    var objectData = new List<SpellDataTable>();
                    using (StreamReader r = new StreamReader(file))
                    {
                        string json = r.ReadToEnd();
                        objectData = serializerService.Deserialize<List<SpellDataTable>>(json);
                    }

                    if (fileName.Contains("_"))
                    {
                        var masterItemType = fileName.Split('_')[1];
                        objectData.ForEach(x => x.ItemType = masterItemType);
                    }

                    items.AddRange(objectData);
                }

                var existingConsumableItemDefinitions = await repository.ListAsync();
                var newConsumableItemDefinitions = items.Where(x => !existingConsumableItemDefinitions.Select(x => x.SpellID).Contains(x.SpellID)).ToList();
                var updateConsumableItemDefinitions = existingConsumableItemDefinitions.Where(x => !items.Select(x => x.SpellID).Contains(x.SpellID)).ToList();

                existingConsumableItemDefinitions.ForEach(x => Reflection.CopyProperties(items.FirstOrDefault(c => c.SpellID == x.SpellID), x));

                if (newConsumableItemDefinitions.Any()) await repository.AddRangeAsync(newConsumableItemDefinitions, cancellationToken);
                if (updateConsumableItemDefinitions.Any()) await repository.UpdateRangeAsync(updateConsumableItemDefinitions, cancellationToken);

            }
            catch (Exception ex)
            {

                throw;
            }
            return default!;
        }
    }
}
