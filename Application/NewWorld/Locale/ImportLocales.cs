using Application.Common.Interfaces;
using Application.NewWorld.MasterItemDefinitions;
using Domain.Entities.NewWorld;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.Locale
{
    public record ImportLocalesRequest : IRequest<string>;
    public class ImportLocalesRequestHandler : IRequestHandler<ImportLocalesRequest, string>
    {
        private readonly IRepository<Locales> repository;
        private readonly ISerializerService serializerService;

        public ImportLocalesRequestHandler(IRepository<Locales> repository, ISerializerService serializerService)
        {
            this.repository = repository;
            this.serializerService = serializerService;
        }

        public async ValueTask<string> Handle(ImportLocalesRequest request, CancellationToken cancellationToken)
        {
            var currentLocales = await repository.ListAsync();
            var newItems = new List<Locales>();
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "Locale"));
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                var objectData = new DS_ItemDefinitionsMasterLoc();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    objectData = serializerService.Deserialize<DS_ItemDefinitionsMasterLoc>(json);
                }

                newItems.AddRange(objectData.resources.@string.Adapt<IEnumerable<Locales>>());
            }
            newItems.ForEach(x => x.ISO = "en-EN");

            //var itemsToInsert = newItems.Where(x => !currentLocales.Select(x => x.Key).Contains(x.Key)).ToList();
            var itemsToInsert = newItems.Except(currentLocales, new LocalesComparer()).ToList();

            //var itemsToUpdate = currentLocales.Where(x => newItems.Select(x => x.Key).Contains(x.Key)).ToList();
            var itemsToUpdate = currentLocales.Intersect(newItems, new LocalesComparer()).ToList();

            //if (itemsToInsert.Any())
            //{
            //    var count = 0;
            //    var bulkItems = new List<Locales>();
            //    foreach (var itemToInsert in itemsToInsert)
            //    {
            //        if (count == 1000)
            //        {
            //            await repository.AddRangeAsync(bulkItems);
            //            bulkItems.Clear();
            //            count = 0;
            //        }
            //        bulkItems.Add(itemToInsert);
            //        count++;
            //    }

            //    await repository.AddRangeAsync(bulkItems);
            //}
            ////await repository.AddRangeAsync(itemsToInsert);
            //if (itemsToUpdate.Any())
            //{
            //    var count = 0;
            //    var bulkItems = new List<Locales>();
            //    foreach (var itemToUpdate in itemsToUpdate)
            //    {
            //        if (count == 1000)
            //        {
            //            await repository.UpdateRangeAsync(bulkItems);
            //            bulkItems.Clear();
            //            count = 0;
            //        }
            //        bulkItems.Add(itemToUpdate);
            //        count++;
            //    }

            //    await repository.UpdateRangeAsync(bulkItems);
            //}

            if (itemsToInsert.Any())
            {
                var count = 0;
                var bulkItems = new List<Locales>();
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
                var bulkItems = new List<Locales>();
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

            return "";
        }
    }

    internal class DS_ItemDefinitionsMasterLoc
    {
        public DS_ItemDefinitionsResources resources { get; set; }
    }

    internal class DS_ItemDefinitionsResources
    {
        public List<DS_ItemDefinitionsItems> @string { get; set; }
    }

    internal class DS_ItemDefinitionsItems
    {
        public string Key { get; set; }
        public string Text { get; set; }
    }

    public class LocalesComparer : IEqualityComparer<Locales>
    {
        public bool Equals(Locales x, Locales y)
        {
            // Return true if the Id properties are equal
            return x.Key == y.Key;
        }

        public int GetHashCode(Locales obj)
        {
            // Return the hash code of the Id property
            return obj.Key.GetHashCode();
        }
    }

}
