using Application.NewWorld.AffixStatData;
using System.ComponentModel.DataAnnotations;

namespace Application.NewWorld.PerkData
{
    public sealed class ItemPerkDto
    {
        public Guid Id { get; set; }
        public string? PerkID { get; set; }

        public string? PerkType { get; set; }

        public string? ConditionEvent { get; set; }

        public string? ItemClass { get; set; }

        public string? ExcludeItemClass { get; set; }
        public int? Channel { get; set; }

        public string? ExclusiveLabels { get; set; }

        public string? DeprecatedPerkId { get; set; }

        public double? ScalingPerGearScore { get; set; }

        public string? ItemClassGSBonus { get; set; }

        public string? DisplayName { get; set; }

        public string? Description { get; set; }

        public string? GroupName { get; set; }

        public string? Tier { get; set; }

        public string? ExcludeFromTradingPost { get; set; }

        public string? AppliedPrefix { get; set; }

        public string? AppliedSuffix { get; set; }

        public string? NamePriority { get; set; }

        public string? IconPath { get; set; }

        public string? Affix { get; set; }

        public string? EquipAbility { get; set; }
        public string? DayPhases { get; set; }
        public string? FishingWaterType { get; set; }
        public string? TerritoryId { get; set; }
        [MaxLength(50)]
        public string? CombatStatus { get; set; }
        public string? WeaponTag { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }
        public string? MasterName { get; set; }
        public string? MasterDescription { get; set; }
        public bool IsDeprecated { get; set; } = false;

        public AffixStatDataDto? AffixStatData { get; set; }
    }

    public sealed class ItemPerkForBucketDto
    {
        public string? PerkID { get; set; }
        public string? ItemClass { get; set; }
    }
}
