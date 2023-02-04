using Application.Common.Caching;
using Application.Common.DynamicEvaluator;
using Application.Common.Persistence;
using Domain.Entities.NewWorld.AbilityData;
using Domain.Entities.NewWorld.AffixStatData;
using Domain.Entities.NewWorld.ConsumableItemDefinitions;
using Domain.Entities.NewWorld.DamageData;
using Domain.Entities.NewWorld.SpellData;
using Domain.Entities.NewWorld.StatusEffectData;
using DynamicExpresso;
using System.Dynamic;

namespace Infrastructure.DynamicEvaluator
{

    public class DynamicEvaluator : IDynamicEvaluator
    {
        private readonly Interpreter interpreter;
        private readonly ICacheService cacheService;

        private readonly IReadRepository<AIAbilityTable> aIAbilityTableRepository;
        private readonly IReadRepository<AttributeThresholdAbilityTable> attributeThresholdAbilityTable;
        private readonly IReadRepository<BlunderbussAbilityTable> blunderbussAbilityTable;
        private readonly IReadRepository<BowAbilityTable> bowAbilityTable;
        private readonly IReadRepository<FireMagicAbilityTable> fireMagicAbilityTable;
        private readonly IReadRepository<GlobalAbilityTable> globalAbilityTable;
        private readonly IReadRepository<GreatAxeAbilityTable> greatAxeAbilityTable;
        private readonly IReadRepository<GreatswordAbilityTable> greatswordAbilityTable;
        private readonly IReadRepository<HatchetAbilityTable> hatchetAbilityTable;
        private readonly IReadRepository<IceMagicAbilityTable> iceMagicAbilityTable;
        private readonly IReadRepository<LifeMagicAbilityTable> lifeMagicAbilityTable;
        private readonly IReadRepository<MusketAbilityTable> musketAbilityTable;
        private readonly IReadRepository<RapierAbilityTable> rapierAbilityTable;
        private readonly IReadRepository<RuneAbilityTable> runeAbilityTable;
        private readonly IReadRepository<SpearAbilityTable> spearAbilityTable;
        private readonly IReadRepository<SwordAbilityTable> swordAbilityTable;
        private readonly IReadRepository<VoidGauntletAbilityTable> voidGauntletAbilityTable;
        private readonly IReadRepository<WarHammerAbilityTable> warHammerAbilityTable;

        private readonly IReadRepository<StatusEffects> statusEffectsRepository;

        private readonly IReadRepository<DamageTable> damageRepository;

        private readonly IReadRepository<SpellDataTable> spellDataRepository;

        private readonly IReadRepository<ConsumableItemDefinitions> consumableItemsRepository;

        private readonly IReadRepository<AffixStatDataTable> affixStatRepository;

        public DynamicEvaluator(ICacheService cacheService, IReadRepository<AIAbilityTable> aIAbilityTableRepository, IReadRepository<AttributeThresholdAbilityTable> attributeThresholdAbilityTable, IReadRepository<BlunderbussAbilityTable> blunderbussAbilityTable, IReadRepository<BowAbilityTable> bowAbilityTable, IReadRepository<FireMagicAbilityTable> fireMagicAbilityTable, IReadRepository<GlobalAbilityTable> globalAbilityTable, IReadRepository<GreatAxeAbilityTable> greatAxeAbilityTable, IReadRepository<GreatswordAbilityTable> greatswordAbilityTable, IReadRepository<HatchetAbilityTable> hatchetAbilityTable, IReadRepository<IceMagicAbilityTable> iceMagicAbilityTable, IReadRepository<LifeMagicAbilityTable> lifeMagicAbilityTable, IReadRepository<MusketAbilityTable> musketAbilityTable, IReadRepository<RapierAbilityTable> rapierAbilityTable, IReadRepository<RuneAbilityTable> runeAbilityTable, IReadRepository<SpearAbilityTable> spearAbilityTable, IReadRepository<SwordAbilityTable> swordAbilityTable, IReadRepository<VoidGauntletAbilityTable> voidGauntletAbilityTable, IReadRepository<WarHammerAbilityTable> warHammerAbilityTable, IReadRepository<StatusEffects> statusEffectsRepository, IReadRepository<DamageTable> damageRepository, IReadRepository<SpellDataTable> spellDataRepository, IReadRepository<ConsumableItemDefinitions> consumableItemsRepository, IReadRepository<AffixStatDataTable> affixStatRepository)
        {
            this.interpreter = new Interpreter();
            this.cacheService = cacheService;
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
            this.statusEffectsRepository = statusEffectsRepository;
            this.damageRepository = damageRepository;
            this.spellDataRepository = spellDataRepository;
            this.consumableItemsRepository = consumableItemsRepository;
            this.affixStatRepository = affixStatRepository;

            //LoadVariables();
        }

        public async Task<object> EvaluateExpression(string expression)
        {
            await LoadVariables();
            return interpreter.Eval(expression);
        }

        private async Task LoadVariables()
        {
            try
            {
                var cachedValues = cacheService.Get<Dictionary<string, ExpandoObject>>("ExpandoObjectCache");
                if (cachedValues == null)
                {
                    var aIAbilityTable = await aIAbilityTableRepository.ListAsync();
                    var attributeThresholdAbility = await attributeThresholdAbilityTable.ListAsync();
                    var blunderbussAbility = await blunderbussAbilityTable.ListAsync();
                    var bowAbility = await bowAbilityTable.ListAsync();
                    var fireMagicAbility = await fireMagicAbilityTable.ListAsync();
                    var globalAbility = await globalAbilityTable.ListAsync();
                    var greatAxeAbility = await greatAxeAbilityTable.ListAsync();
                    var greatswordAbility = await greatswordAbilityTable.ListAsync();
                    var hatchetAbility = await hatchetAbilityTable.ListAsync();
                    var iceMagicAbility = await iceMagicAbilityTable.ListAsync();
                    var lifeMagicAbility = await lifeMagicAbilityTable.ListAsync();
                    var musketAbility = await musketAbilityTable.ListAsync();
                    var rapierAbility = await rapierAbilityTable.ListAsync();
                    var runeAbility = await runeAbilityTable.ListAsync();
                    var spearAbility = await spearAbilityTable.ListAsync();
                    var swordAbility = await swordAbilityTable.ListAsync();
                    var voidGauntletAbility = await voidGauntletAbilityTable.ListAsync();
                    var warHammerAbility = await warHammerAbilityTable.ListAsync();

                    //Affix
                    var affixData = await affixStatRepository.ListAsync();

                    //Status Effects
                    var statusEffects = await statusEffectsRepository.ListAsync();

                    //Damage Data
                    var damageData = await damageRepository.ListAsync();

                    //Spell Data
                    var spellData = await spellDataRepository.ListAsync();

                    //ConsumableItemDefinitions
                    var consumableDefs = await consumableItemsRepository.ListAsync();

                    var expandoList = new Dictionary<string, ExpandoObject>();

                    expandoList.Add("AIAbilityTable", GenerateExpandos(aIAbilityTable));
                    expandoList.Add("AttributeThresholdAbilityTable", GenerateExpandos(attributeThresholdAbility));
                    expandoList.Add("BlunderbussAbilityTable", GenerateExpandos(blunderbussAbility));
                    expandoList.Add("BowAbilityTable", GenerateExpandos(bowAbility));
                    expandoList.Add("FireMagicAbilityTable", GenerateExpandos(fireMagicAbility));
                    expandoList.Add("GlobalAbilityTable", GenerateExpandos(globalAbility));
                    //ALT
                    expandoList.Add("Type_AbilityData", GenerateExpandos(globalAbility));
                    expandoList.Add("GreatAxeAbilityTable", GenerateExpandos(greatAxeAbility));
                    expandoList.Add("GreatswordAbilityTable", GenerateExpandos(greatswordAbility));
                    expandoList.Add("HatchetAbilityTable", GenerateExpandos(hatchetAbility));
                    expandoList.Add("IceMagicAbilityTable", GenerateExpandos(iceMagicAbility));
                    expandoList.Add("LifeMagicAbilityTable", GenerateExpandos(lifeMagicAbility));
                    expandoList.Add("MusketAbilityTable", GenerateExpandos(musketAbility));
                    expandoList.Add("RapierAbilityTable", GenerateExpandos(rapierAbility));
                    expandoList.Add("RuneAbilityTable", GenerateExpandos(runeAbility));
                    expandoList.Add("SpearAbilityTable", GenerateExpandos(spearAbility));
                    expandoList.Add("SwordAbilityTable", GenerateExpandos(swordAbility));
                    expandoList.Add("VoidGauntletAbilityTable", GenerateExpandos(voidGauntletAbility));
                    expandoList.Add("WarHammerAbilityTable", GenerateExpandos(warHammerAbility));
                    expandoList.Add("Type_StatusEffectData", GenerateExpandos(statusEffects, "StatusID"));

                    //Affix Data
                    expandoList.Add("AffixStatDataTable", GenerateExpandos(affixData, "StatusID"));

                    //Damage data
                    expandoList.Add("DamageTable", GenerateExpandos(damageData, "DamageID"));

                    //Spell data
                    var spellDataTypes = spellData.Select(x => x.ItemType).Distinct();
                    foreach (var spellType in spellDataTypes)
                    {
                        expandoList.Add($"SpellDataTable_{spellType}", GenerateExpandos(spellData.Where(x => x.ItemType == spellType).ToList(), "SpellID"));
                    }
                    //expandoList.Add("SpellDataTable_GreatAxe", GenerateExpandos(spellDataTable_GreatAxe, "SpellID"));
                    //expandoList.Add("SpellDataTable_IceMagic", GenerateExpandos(spellDataTable_IceMagic, "SpellID"));
                    //expandoList.Add("SpellDataTable_Runes", GenerateExpandos(spellDataTable_Runes, "SpellID"));

                    //ConsumableItemDefinitions
                    expandoList.Add("ConsumableItemDefinitions", GenerateExpandos(consumableDefs, "ConsumableID"));



                    cacheService.Set("ExpandoObjectCache", expandoList, TimeSpan.FromDays(5));

                    cachedValues = expandoList;
                }

                foreach (var expandoObject in cachedValues)
                {
                    interpreter.SetVariable(expandoObject.Key, expandoObject.Value);
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private ExpandoObject GenerateExpandos<T>(List<T> obj, string IDProp = "AbilityID")
        {
            dynamic statusPerksExpando = new ExpandoObject();

            foreach (var status in obj)
            {
                var propValue = status.GetType().GetProperty(IDProp).GetValue(status).ToString();
                AddProperty(statusPerksExpando, propValue, new ExpandoObject());

                var statusProps = status.GetType().GetProperties();

                foreach (var props in statusProps)
                {
                    var statusPropPerksExpando = statusPerksExpando as IDictionary<string, object>;
                    var expandoDic2 = statusPropPerksExpando[propValue] as ExpandoObject;

                    AddProperty(expandoDic2, props.Name, ChangeType(props.GetValue(status), props.PropertyType));
                }

            }

            return statusPerksExpando;
        }

        public void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }
    }
}
