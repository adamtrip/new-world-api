using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.ConsumableItemDefinitions
{
    public class ConsumableItemDefinitions : AuditableEntity, IAggregateRoot
    {
        public string ConsumableID { get; set; }
        public string AddStatusEffects { get; set; }
        public int? StatusEffectMod { get; set; }
        public int? DurationOverrides { get; set; }
        public int? MinDurationModifier { get; set; }
        public int? MaxDurationModifier { get; set; }
        public int? DurationScaleFactor { get; set; }
        public int? MinPotencyModifier { get; set; }
        public double? MaxPotencyModifier { get; set; }
        public int? PotencyScaleFactor { get; set; }
        public string RemoveStatusEffects { get; set; }
        public string RemoveStatusEffectCategories { get; set; }
        public string DisplayStatusEffect { get; set; }
        public int? UseCount { get; set; }
        public string WeaponUseCount { get; set; }
        public bool? DisableUseInCombat { get; set; }
        public string AfflictionDamage { get; set; }
        public string BaseDamageModifier { get; set; }
        public string BaseDamageType { get; set; }
        public string DamageType { get; set; }
        public string Damage { get; set; }
        public string DMGVitalsCategory { get; set; }
        public string OnUseAffliction { get; set; }
        public string StatMultipliers { get; set; }
        public string RequiredItemClass { get; set; }
        public string MannequinTag { get; set; }
        public string EquipAbility { get; set; }
        public int? CooldownDuration { get; set; }
        public string CooldownId { get; set; }
    }
}
