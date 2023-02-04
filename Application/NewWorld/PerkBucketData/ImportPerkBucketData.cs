using Application.Common.Reflection;
using Domain.Entities.NewWorld.PerkBucketData;

namespace Application.NewWorld.PerkBucketData
{
    public record ImportPerkBucketDataRequest : IRequest;
    public class ImportPerkBucketDataRequestHandler : IRequestHandler<ImportPerkBucketDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<PerkBuckets> perkBucketRepository;
        private readonly IRepository<PerkBucketPerk> perkBucketPerkRepository;

        public ImportPerkBucketDataRequestHandler(ISerializerService serializerService, IRepository<PerkBuckets> perkBucketRepository, IRepository<PerkBucketPerk> perkBucketPerkRepository)
        {
            this.serializerService = serializerService;
            this.perkBucketRepository = perkBucketRepository;
            this.perkBucketPerkRepository = perkBucketPerkRepository;
        }

        public async ValueTask<Unit> Handle(ImportPerkBucketDataRequest request, CancellationToken cancellationToken)
        {
            var objectList = new Dictionary<string, List<PerkBuckets>>();
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "PerkBucketData"));
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file).Split(".")[0];
                var jsonData = new List<PerkImportDto>();
                using (StreamReader r = new StreamReader(file))
                {
                    string json = r.ReadToEnd();
                    jsonData = serializerService.Deserialize<List<PerkImportDto>>(json);
                }
                var perkList = new List<PerkBuckets>();
                foreach (var item in jsonData)
                {
                    if (!item.PerkBucketID.EndsWith("_Weights"))
                    {
                        var perkBucket = new PerkBuckets()
                        {
                            PerkBucketID = item.PerkBucketID,
                            IgnoreExclusiveLabelWeights = item.IgnoreExclusiveLabelWeights,
                            PerkChance = item.PerkChance,
                            PerkType = item.PerkType,
                            CURRENTLIMIT = item.CURRENTLIMIT,
                            Perks = new List<PerkBucketPerk>()
                        };

                        var itemWeight = jsonData.Find(x => x.PerkBucketID == item.PerkBucketID + "_Weights");

                        for (var i = 1; i <= 500; i++)
                        {

                            var numPerk = item.GetType().GetProperty("Perk" + i).GetValue(item).ToString();

                            var perkWeight = itemWeight.GetType().GetProperty("Perk" + i).GetValue(itemWeight).ToString();
                            perkBucket.Perks.Add(new PerkBucketPerk() { PerkId = numPerk, PerkNumber = i, Weight = perkWeight });
                        }
                        perkList.Add(perkBucket);
                    }
                }

                objectList.Add(fileName, perkList);

            }
            var obj = objectList.SelectMany(x => x.Value).ToList();
            var item2 = obj.SelectMany(x => x.Perks).Where(x => x.PerkId.StartsWith("[")).ToList();

            foreach (var item in obj)
            {
                while (item.Perks.Where(x => x.PerkId.StartsWith("[")).Count() > 0)
                {
                    foreach (var itemm in item.Perks)
                    {
                        if (itemm.PerkId.StartsWith("[PBID]"))
                        {
                            var newPerkBucket = obj.FirstOrDefault(x => x.PerkBucketID == itemm.PerkId.Replace("[PBID]", ""));
                            //newPerkBucket.Perks.RemoveAll(x => string.IsNullOrEmpty(x.PerkId));
                            if (newPerkBucket.Perks.Any(x => x.PerkId.StartsWith("[PBID]")))
                            {
                                foreach (var perk in newPerkBucket.Perks.Where(x => x.PerkId.StartsWith("[PBID]")))
                                {
                                    newPerkBucket.Perks = obj.FirstOrDefault(x => x.PerkBucketID == perk.PerkId.Replace("[PBID]", ""))?.Perks ?? new();
                                }
                            }
                            else
                            {
                                item.Perks = newPerkBucket.Perks;
                            }
                        }
                    }
                }
            }



            var item1 = obj.SelectMany(x => x.Perks).Where(x => x.PerkId.StartsWith("[")).ToList();

            var existingPerkBucketData = await perkBucketRepository.ListAsync();
            var newPerkBucketData = obj.Where(x => !existingPerkBucketData.Select(z => z.PerkBucketID).Contains(x.PerkBucketID));
            var updatePerkBucketData = existingPerkBucketData.Where(x => obj.Select(z => z.PerkBucketID).Contains(x.PerkBucketID));

            existingPerkBucketData.ForEach(x => Reflection.CopyProperties(obj.FirstOrDefault(c => c.PerkBucketID == x.PerkBucketID), x));

            if (newPerkBucketData.Any()) await perkBucketRepository.AddRangeAsync(newPerkBucketData);
            if (updatePerkBucketData.Any()) await perkBucketRepository.UpdateRangeAsync(updatePerkBucketData);

            return default!;
        }

        private List<PerkBucketDataPerksDto> ResolvePerkBucket(List<PerkBucketDataDto> obj, List<PerkBucketDataPerksDto> perks)
        {
            var newPerks = new List<PerkBucketDataPerksDto>();
            var i = 0;
            while (perks.Any(x => x.PerkId.StartsWith("[PBID]")))
            {
                var perk = perks[i];
                if (perk.PerkId.StartsWith("[PBID]"))
                {
                    var newPerkBucket = obj.FirstOrDefault(x => x.PerkBucketID == perk.PerkId.Replace("[PBID]", ""));
                    perks = newPerkBucket.Perks;
                    i = 0;
                }
                else
                {
                    newPerks.Add(perk);
                    i++;
                }
            }
            return newPerks;
        }
    }
}
