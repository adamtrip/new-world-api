using Application.Common.Reflection;
using Domain.Entities.NewWorld.AbilityData;
using System.Collections;

namespace Application.NewWorld.AbilityData
{
    public record ImportAbilityDataRequest : IRequest;

    public class ImportAbilityDataRequestHandler : IRequestHandler<ImportAbilityDataRequest>
    {
        private readonly ISerializerService serializerService;
        private readonly IRepository<AIAbilityTable> aIAbilityTableRepository;
        private readonly IRepository<AttributeThresholdAbilityTable> attributeThresholdAbilityTable;
        private readonly IRepository<BlunderbussAbilityTable> blunderbussAbilityTable;
        private readonly IRepository<BowAbilityTable> bowAbilityTable;
        private readonly IRepository<FireMagicAbilityTable> fireMagicAbilityTable;
        private readonly IRepository<GlobalAbilityTable> globalAbilityTable;
        private readonly IRepository<GreatAxeAbilityTable> greatAxeAbilityTable;
        private readonly IRepository<GreatswordAbilityTable> greatswordAbilityTable;
        private readonly IRepository<HatchetAbilityTable> hatchetAbilityTable;
        private readonly IRepository<IceMagicAbilityTable> iceMagicAbilityTable;
        private readonly IRepository<LifeMagicAbilityTable> lifeMagicAbilityTable;
        private readonly IRepository<MusketAbilityTable> musketAbilityTable;
        private readonly IRepository<RapierAbilityTable> rapierAbilityTable;
        private readonly IRepository<RuneAbilityTable> runeAbilityTable;
        private readonly IRepository<SpearAbilityTable> spearAbilityTable;
        private readonly IRepository<SwordAbilityTable> swordAbilityTable;
        private readonly IRepository<VoidGauntletAbilityTable> voidGauntletAbilityTable;
        private readonly IRepository<WarHammerAbilityTable> warHammerAbilityTable;

        public ImportAbilityDataRequestHandler(ISerializerService serializerService, IRepository<AIAbilityTable> aIAbilityTableRepository, IRepository<AttributeThresholdAbilityTable> attributeThresholdAbilityTable, IRepository<BlunderbussAbilityTable> blunderbussAbilityTable, IRepository<BowAbilityTable> bowAbilityTable, IRepository<FireMagicAbilityTable> fireMagicAbilityTable, IRepository<GlobalAbilityTable> globalAbilityTable, IRepository<GreatAxeAbilityTable> greatAxeAbilityTable, IRepository<GreatswordAbilityTable> greatswordAbilityTable, IRepository<HatchetAbilityTable> hatchetAbilityTable, IRepository<IceMagicAbilityTable> iceMagicAbilityTable, IRepository<LifeMagicAbilityTable> lifeMagicAbilityTable, IRepository<MusketAbilityTable> musketAbilityTable, IRepository<RapierAbilityTable> rapierAbilityTable, IRepository<RuneAbilityTable> runeAbilityTable, IRepository<SpearAbilityTable> spearAbilityTable, IRepository<SwordAbilityTable> swordAbilityTable, IRepository<VoidGauntletAbilityTable> voidGauntletAbilityTable, IRepository<WarHammerAbilityTable> warHammerAbilityTable)
        {
            this.serializerService = serializerService;
            this.aIAbilityTableRepository = aIAbilityTableRepository;
            this.attributeThresholdAbilityTable = attributeThresholdAbilityTable;
            this.blunderbussAbilityTable = blunderbussAbilityTable;
            this.bowAbilityTable = bowAbilityTable;
            this.fireMagicAbilityTable = fireMagicAbilityTable;
            this.globalAbilityTable = globalAbilityTable;
            this.greatAxeAbilityTable = greatAxeAbilityTable;
            this.greatswordAbilityTable = greatswordAbilityTable;
            this.hatchetAbilityTable = hatchetAbilityTable;
            this.iceMagicAbilityTable = iceMagicAbilityTable;
            this.lifeMagicAbilityTable = lifeMagicAbilityTable;
            this.musketAbilityTable = musketAbilityTable;
            this.rapierAbilityTable = rapierAbilityTable;
            this.runeAbilityTable = runeAbilityTable;
            this.spearAbilityTable = spearAbilityTable;
            this.swordAbilityTable = swordAbilityTable;
            this.voidGauntletAbilityTable = voidGauntletAbilityTable;
            this.warHammerAbilityTable = warHammerAbilityTable;
        }

        public async ValueTask<Unit> Handle(ImportAbilityDataRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var objectList = new Dictionary<Type, IList>();
                var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSONFiles", "NewWorld", "AbilityData"));
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file).Split(".")[0];
                    var type = Type.GetType("Domain.Entities.NewWorld.AbilityData." + fileName + ", Domain", true);
                    var objectData = new object();
                    using (StreamReader r = new StreamReader(file))
                    {
                        string json = r.ReadToEnd();
                        objectData = serializerService.Deserialize(json, typeof(List<>).MakeGenericType(new[] { type }));
                    }
                    IList objectList1 = objectData as IList;
                    objectList.Add(type, objectList1);
                }

                //AIAbilityTable
                var existingAIAbilityTable = await aIAbilityTableRepository.ListAsync();
                var itemsAIAbilityTable = objectList[typeof(AIAbilityTable)].Cast<AIAbilityTable>();
                var newAIAbilityTable = itemsAIAbilityTable.Where(x => !existingAIAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateAIAbilityTable = existingAIAbilityTable.Where(x => itemsAIAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingAIAbilityTable.ForEach(x => Reflection.CopyProperties(itemsAIAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newAIAbilityTable.Any()) await aIAbilityTableRepository.AddRangeAsync(newAIAbilityTable);
                if (updateAIAbilityTable.Any()) await aIAbilityTableRepository.UpdateRangeAsync(updateAIAbilityTable);

                //AttributeThresholdAbilityTable
                var existingAttributeThresholdAbilityTable = await attributeThresholdAbilityTable.ListAsync();
                var itemsAttributeThresholdAbilityTable = objectList[typeof(AttributeThresholdAbilityTable)].Cast<AttributeThresholdAbilityTable>();
                var newAttributeThresholdAbilityTable = itemsAttributeThresholdAbilityTable.Where(x => !existingAttributeThresholdAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateAttributeThresholdAbilityTable = existingAttributeThresholdAbilityTable.Where(x => itemsAttributeThresholdAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingAttributeThresholdAbilityTable.ForEach(x => Reflection.CopyProperties(itemsAttributeThresholdAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newAttributeThresholdAbilityTable.Any()) await attributeThresholdAbilityTable.AddRangeAsync(newAttributeThresholdAbilityTable);
                if (updateAttributeThresholdAbilityTable.Any()) await attributeThresholdAbilityTable.UpdateRangeAsync(updateAttributeThresholdAbilityTable);


                //BlunderbussAbilityTable
                var existingBlunderbussAbilityTable = await blunderbussAbilityTable.ListAsync();
                var itemsBlunderbussAbilityTable = objectList[typeof(BlunderbussAbilityTable)].Cast<BlunderbussAbilityTable>();
                var newBlunderbussAbilityTable = itemsBlunderbussAbilityTable.Where(x => !existingBlunderbussAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateBlunderbussAbilityTable = existingBlunderbussAbilityTable.Where(x => itemsBlunderbussAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingBlunderbussAbilityTable.ForEach(x => Reflection.CopyProperties(itemsBlunderbussAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newBlunderbussAbilityTable.Any()) await blunderbussAbilityTable.AddRangeAsync(newBlunderbussAbilityTable);
                if (updateBlunderbussAbilityTable.Any()) await blunderbussAbilityTable.UpdateRangeAsync(updateBlunderbussAbilityTable);


                //BowAbilityTable
                var existingBowAbilityTable = await bowAbilityTable.ListAsync();
                var itemsBowAbilityTable = objectList[typeof(BowAbilityTable)].Cast<BowAbilityTable>();
                var newBowAbilityTable = itemsBowAbilityTable.Where(x => !existingBowAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateBowAbilityTable = existingBowAbilityTable.Where(x => itemsBowAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingBowAbilityTable.ForEach(x => Reflection.CopyProperties(itemsBowAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newBowAbilityTable.Any()) await bowAbilityTable.AddRangeAsync(newBowAbilityTable);
                if (updateBowAbilityTable.Any()) await bowAbilityTable.UpdateRangeAsync(updateBowAbilityTable);


                //FireMagicAbilityTable
                var existingFireMagicAbilityTable = await fireMagicAbilityTable.ListAsync();
                var itemsFireMagicAbilityTable = objectList[typeof(FireMagicAbilityTable)].Cast<FireMagicAbilityTable>();
                var newFireMagicAbilityTable = itemsFireMagicAbilityTable.Where(x => !existingFireMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateFireMagicAbilityTablee = existingFireMagicAbilityTable.Where(x => itemsFireMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingFireMagicAbilityTable.ForEach(x => Reflection.CopyProperties(itemsFireMagicAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newFireMagicAbilityTable.Any()) await fireMagicAbilityTable.AddRangeAsync(newFireMagicAbilityTable);
                if (updateFireMagicAbilityTablee.Any()) await fireMagicAbilityTable.UpdateRangeAsync(updateFireMagicAbilityTablee);


                //GlobalAbilityTable
                var existingGlobalAbilityTable = await globalAbilityTable.ListAsync();
                var itemsGlobalAbilityTable = objectList[typeof(GlobalAbilityTable)].Cast<GlobalAbilityTable>();
                var newGlobalAbilityTable = itemsGlobalAbilityTable.Where(x => !existingGlobalAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateGlobalAbilityTable = existingGlobalAbilityTable.Where(x => itemsGlobalAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingGlobalAbilityTable.ForEach(x => Reflection.CopyProperties(itemsGlobalAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newGlobalAbilityTable.Any()) await globalAbilityTable.AddRangeAsync(newGlobalAbilityTable);
                if (updateGlobalAbilityTable.Any()) await globalAbilityTable.UpdateRangeAsync(updateGlobalAbilityTable);


                //GreatAxeAbilityTable
                var existingGreatAxeAbilityTable = await greatAxeAbilityTable.ListAsync();
                var itemsGreatAxeAbilityTable = objectList[typeof(GreatAxeAbilityTable)].Cast<GreatAxeAbilityTable>();
                var newGreatAxeAbilityTable = itemsGreatAxeAbilityTable.Where(x => !existingGreatAxeAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateGreatAxeAbilityTable = existingGreatAxeAbilityTable.Where(x => itemsGreatAxeAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingGreatAxeAbilityTable.ForEach(x => Reflection.CopyProperties(itemsGreatAxeAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newGreatAxeAbilityTable.Any()) await greatAxeAbilityTable.AddRangeAsync(newGreatAxeAbilityTable);
                if (updateGreatAxeAbilityTable.Any()) await greatAxeAbilityTable.UpdateRangeAsync(updateGreatAxeAbilityTable);


                //GreatswordAbilityTable
                var existingGreatswordAbilityTable = await greatswordAbilityTable.ListAsync();
                var itemsGreatswordAbilityTable = objectList[typeof(GreatswordAbilityTable)].Cast<GreatswordAbilityTable>();
                var newGreatswordAbilityTable = itemsGreatswordAbilityTable.Where(x => !existingGreatswordAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateGreatswordAbilityTable = existingGreatswordAbilityTable.Where(x => itemsGreatswordAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingGreatswordAbilityTable.ForEach(x => Reflection.CopyProperties(itemsGreatswordAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newGreatswordAbilityTable.Any()) await greatswordAbilityTable.AddRangeAsync(newGreatswordAbilityTable);
                if (updateGreatswordAbilityTable.Any()) await greatswordAbilityTable.UpdateRangeAsync(updateGreatswordAbilityTable);


                //HatchetAbilityTable
                var existingHatchetAbilityTable = await hatchetAbilityTable.ListAsync();
                var itemsHatchetAbilityTable = objectList[typeof(HatchetAbilityTable)].Cast<HatchetAbilityTable>();
                var newHatchetAbilityTable = itemsHatchetAbilityTable.Where(x => !existingHatchetAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateHatchetAbilityTable = existingHatchetAbilityTable.Where(x => itemsHatchetAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingHatchetAbilityTable.ForEach(x => Reflection.CopyProperties(itemsHatchetAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newHatchetAbilityTable.Any()) await hatchetAbilityTable.AddRangeAsync(newHatchetAbilityTable);
                if (updateHatchetAbilityTable.Any()) await hatchetAbilityTable.UpdateRangeAsync(updateHatchetAbilityTable);


                //IceMagicAbilityTable
                var existingIceMagicAbilityTable = await iceMagicAbilityTable.ListAsync();
                var itemsIceMagicAbilityTable = objectList[typeof(IceMagicAbilityTable)].Cast<IceMagicAbilityTable>();
                var newIceMagicAbilityTable = itemsIceMagicAbilityTable.Where(x => !existingIceMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateIceMagicAbilityTable = existingIceMagicAbilityTable.Where(x => itemsIceMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingIceMagicAbilityTable.ForEach(x => Reflection.CopyProperties(itemsIceMagicAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newIceMagicAbilityTable.Any()) await iceMagicAbilityTable.AddRangeAsync(newIceMagicAbilityTable);
                if (updateIceMagicAbilityTable.Any()) await iceMagicAbilityTable.UpdateRangeAsync(updateIceMagicAbilityTable);


                //LifeMagicAbilityTable
                var existingLifeMagicAbilityTable = await lifeMagicAbilityTable.ListAsync();
                var itemsLifeMagicAbilityTable = objectList[typeof(LifeMagicAbilityTable)].Cast<LifeMagicAbilityTable>();
                var newLifeMagicAbilityTable = itemsLifeMagicAbilityTable.Where(x => !existingLifeMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateLifeMagicAbilityTable = existingLifeMagicAbilityTable.Where(x => itemsLifeMagicAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingLifeMagicAbilityTable.ForEach(x => Reflection.CopyProperties(itemsLifeMagicAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newLifeMagicAbilityTable.Any()) await lifeMagicAbilityTable.AddRangeAsync(newLifeMagicAbilityTable);
                if (updateLifeMagicAbilityTable.Any()) await lifeMagicAbilityTable.UpdateRangeAsync(updateLifeMagicAbilityTable);


                //MusketAbilityTable
                var existingMusketAbilityTable = await musketAbilityTable.ListAsync();
                var itemsMusketAbilityTable = objectList[typeof(MusketAbilityTable)].Cast<MusketAbilityTable>();
                var newMusketAbilityTable = itemsMusketAbilityTable.Where(x => !existingMusketAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateMusketAbilityTable = existingMusketAbilityTable.Where(x => itemsMusketAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingMusketAbilityTable.ForEach(x => Reflection.CopyProperties(itemsMusketAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newMusketAbilityTable.Any()) await musketAbilityTable.AddRangeAsync(newMusketAbilityTable);
                if (updateMusketAbilityTable.Any()) await musketAbilityTable.UpdateRangeAsync(updateMusketAbilityTable);


                //RapierAbilityTable
                var existingRapierAbilityTable = await rapierAbilityTable.ListAsync();
                var itemsRapierAbilityTable = objectList[typeof(RapierAbilityTable)].Cast<RapierAbilityTable>();
                var newRapierAbilityTable = itemsRapierAbilityTable.Where(x => !existingRapierAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateRapierAbilityTable = existingRapierAbilityTable.Where(x => itemsRapierAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingRapierAbilityTable.ForEach(x => Reflection.CopyProperties(itemsRapierAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newRapierAbilityTable.Any()) await rapierAbilityTable.AddRangeAsync(newRapierAbilityTable);
                if (updateRapierAbilityTable.Any()) await rapierAbilityTable.UpdateRangeAsync(updateRapierAbilityTable);


                //RuneAbilityTable
                var existingRuneAbilityTable = await runeAbilityTable.ListAsync();
                var itemsRuneAbilityTable = objectList[typeof(RuneAbilityTable)].Cast<RuneAbilityTable>();
                var newRuneAbilityTable = itemsRuneAbilityTable.Where(x => !existingRuneAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateRuneAbilityTable = existingRuneAbilityTable.Where(x => itemsRuneAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingRuneAbilityTable.ForEach(x => Reflection.CopyProperties(itemsRuneAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newRuneAbilityTable.Any()) await runeAbilityTable.AddRangeAsync(newRuneAbilityTable);
                if (updateRuneAbilityTable.Any()) await runeAbilityTable.UpdateRangeAsync(updateRuneAbilityTable);


                //SpearAbilityTable
                var existingSpearAbilityTable = await spearAbilityTable.ListAsync();
                var itemsSpearAbilityTable = objectList[typeof(SpearAbilityTable)].Cast<SpearAbilityTable>();
                var newSpearAbilityTable = itemsSpearAbilityTable.Where(x => !existingSpearAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateSpearAbilityTable = existingSpearAbilityTable.Where(x => itemsSpearAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingSpearAbilityTable.ForEach(x => Reflection.CopyProperties(itemsSpearAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newSpearAbilityTable.Any()) await spearAbilityTable.AddRangeAsync(newSpearAbilityTable);
                if (updateSpearAbilityTable.Any()) await spearAbilityTable.UpdateRangeAsync(updateSpearAbilityTable);


                //SwordAbilityTable
                var existingSwordAbilityTable = await swordAbilityTable.ListAsync();
                var itemsSwordAbilityTable = objectList[typeof(SwordAbilityTable)].Cast<SwordAbilityTable>();
                var newSwordAbilityTable = itemsSwordAbilityTable.Where(x => !existingSwordAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateSwordAbilityTable = existingSwordAbilityTable.Where(x => itemsSwordAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingSwordAbilityTable.ForEach(x => Reflection.CopyProperties(itemsSwordAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newSwordAbilityTable.Any()) await swordAbilityTable.AddRangeAsync(newSwordAbilityTable);
                if (updateSwordAbilityTable.Any()) await swordAbilityTable.UpdateRangeAsync(updateSwordAbilityTable);


                //VoidGauntletAbilityTable
                var existingVoidGauntletAbilityTable = await voidGauntletAbilityTable.ListAsync();
                var itemsVoidGauntletAbilityTable = objectList[typeof(VoidGauntletAbilityTable)].Cast<VoidGauntletAbilityTable>();
                var newVoidGauntletAbilityTable = itemsVoidGauntletAbilityTable.Where(x => !existingVoidGauntletAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateVoidGauntletAbilityTable = existingVoidGauntletAbilityTable.Where(x => itemsVoidGauntletAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingVoidGauntletAbilityTable.ForEach(x => Reflection.CopyProperties(itemsVoidGauntletAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newVoidGauntletAbilityTable.Any()) await voidGauntletAbilityTable.AddRangeAsync(newVoidGauntletAbilityTable);
                if (updateVoidGauntletAbilityTable.Any()) await voidGauntletAbilityTable.UpdateRangeAsync(updateVoidGauntletAbilityTable);


                //WarHammerAbilityTable
                var existingWarHammerAbilityTable = await warHammerAbilityTable.ListAsync();
                var itemsWarHammerAbilityTable = objectList[typeof(WarHammerAbilityTable)].Cast<WarHammerAbilityTable>();
                var newWarHammerAbilityTable = itemsWarHammerAbilityTable.Where(x => !existingWarHammerAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));
                var updateWarHammerAbilityTable = existingWarHammerAbilityTable.Where(x => itemsWarHammerAbilityTable.Select(z => z.AbilityID).Contains(x.AbilityID));

                existingWarHammerAbilityTable.ForEach(x => Reflection.CopyProperties(itemsWarHammerAbilityTable.FirstOrDefault(c => c.AbilityID == x.AbilityID), x));

                if (newWarHammerAbilityTable.Any()) await warHammerAbilityTable.AddRangeAsync(newWarHammerAbilityTable);
                if (updateWarHammerAbilityTable.Any()) await warHammerAbilityTable.UpdateRangeAsync(updateWarHammerAbilityTable);
            }
            catch (Exception ex)
            {

                throw;
            }

            return default!;
        }
    }
}
