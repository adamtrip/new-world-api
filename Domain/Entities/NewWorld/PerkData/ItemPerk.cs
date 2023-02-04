using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.NewWorld.PerkData
{
    public class ItemPerk : AuditableEntity, IAggregateRoot
    {

        [MaxLength(50)]
        public string? PerkID { get; set; }

        [MaxLength(50)]
        public string? PerkType { get; set; }

        [MaxLength(50)]
        public string? ConditionEvent { get; set; }

        [MaxLength(50)]
        public string? ItemClass { get; set; }

        [MaxLength(50)]
        public string? ExcludeItemClass { get; set; }
        public int? Channel { get; set; }

        [MaxLength(50)]
        public string? ExclusiveLabels { get; set; }

        [MaxLength(50)]
        public string? DeprecatedPerkId { get; set; }

        [MaxLength(50)]
        public double? ScalingPerGearScore { get; set; }

        [MaxLength(50)]
        public string? ItemClassGSBonus { get; set; }

        [MaxLength(50)]
        public string? DisplayName { get; set; }

        [MaxLength(50)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? GroupName { get; set; }

        [MaxLength(50)]
        public string? Tier { get; set; }

        [MaxLength(50)]
        public string? ExcludeFromTradingPost { get; set; }

        [MaxLength(50)]
        public string? AppliedPrefix { get; set; }

        [MaxLength(50)]
        public string? AppliedSuffix { get; set; }

        [MaxLength(50)]
        public string? NamePriority { get; set; }

        [MaxLength(50)]
        public string? IconPath { get; set; }

        [MaxLength(50)]
        public string? Affix { get; set; }

        [MaxLength(50)]
        public string? EquipAbility { get; set; }

        [MaxLength(50)]
        public string? DayPhases { get; set; }

        [MaxLength(50)]
        public string? FishingWaterType { get; set; }

        [MaxLength(50)]
        public string? TerritoryId { get; set; }

        [MaxLength(50)]
        public string? CombatStatus { get; set; }

        [MaxLength(50)]
        public string? WeaponTag { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }
        public string? MasterName { get; set; }
        public string? MasterDescription { get; set; }
        public bool IsDeprecated { get; set; } = false;
    }
}
