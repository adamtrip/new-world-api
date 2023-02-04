using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld
{
    public class MasterItemDefinition : AuditableEntity, IAggregateRoot
    {
        [MaxLength(80)]
        public string? ItemID { get; set; }

        [MaxLength(80)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? ItemType { get; set; }

        [MaxLength(50)]
        public string? ItemTypeDisplayName { get; set; }

        [MaxLength(120)]
        public string? Description { get; set; }

        [MaxLength(120)]
        public string? ItemClass { get; set; }

        [MaxLength(50)]
        public string? TradingCategory { get; set; }

        [MaxLength(50)]
        public string? TradingFamily { get; set; }

        [MaxLength(50)]
        public string? TradingGroup { get; set; }

        [MaxLength(50)]
        public int? BindOnPickup { get; set; }

        [MaxLength(10)]
        public string? BindOnEquip { get; set; }

        public int? GearScoreOverride { get; set; }

        public int? MinGearScore { get; set; }

        public int? MaxGearScore { get; set; }

        public int? Tier { get; set; }

        [MaxLength(80)]
        public string? ItemStatsRef { get; set; }

        [MaxLength(50)]
        public string? GrantsHWMBump { get; set; }

        [MaxLength(50)]
        public string? IgnoreNameChanges { get; set; }

        [MaxLength(50)]
        public string? IgnoreHWMScaling { get; set; }

        public int? CanHavePerks { get; set; }

        public int? CanReplaceGem { get; set; }

        [MaxLength(100)]
        public string? Perk1 { get; set; }

        [MaxLength(100)]
        public string? Perk2 { get; set; }

        [MaxLength(100)]
        public string? Perk3 { get; set; }

        [MaxLength(100)]
        public string? Perk4 { get; set; }

        [MaxLength(100)]
        public string? Perk5 { get; set; }

        [MaxLength(100)]
        public string? PerkBucket1 { get; set; }

        [MaxLength(100)]
        public string? PerkBucket2 { get; set; }

        [MaxLength(100)]
        public string? PerkBucket3 { get; set; }

        [MaxLength(100)]
        public string? PerkBucket4 { get; set; }

        [MaxLength(100)]
        public string? PerkBucket5 { get; set; }

        public int? ForceRarity { get; set; }

        [MaxLength(10)]
        public string? RequiredLevel { get; set; }

        public int? UseTypeAffix { get; set; }

        public int? UseMaterialAffix { get; set; }

        public int? UseMagicAffix { get; set; }

        [MaxLength(150)]
        public string? IconCaptureGroup { get; set; }

        [MaxLength(50)]
        public string? UiItemClass { get; set; }

        [MaxLength(50)]
        public string? ArmorAppearanceM { get; set; }

        [MaxLength(50)]
        public string? ArmorAppearanceF { get; set; }

        [MaxLength(50)]
        public string? WeaponAppearanceOverride { get; set; }

        [MaxLength(50)]
        public string? ConfirmDestroy { get; set; }
        public int? ConfirmBeforeUse { get; set; }
        public int? ConsumeOnUse { get; set; }

        [MaxLength(150)]
        public string? PrefabPath { get; set; }

        [MaxLength(120)]
        public string? HousingTags { get; set; }

        [MaxLength(150)]
        public string? IconPath { get; set; }

        [MaxLength(150)]
        public string? HiResIconPath { get; set; }
        public int? MaxStackSize { get; set; }
        public int? DeathDropPercentage { get; set; }
        public int? Nonremovable { get; set; }

        [MaxLength(50)]
        public string? IsMissionItem { get; set; }
        public int? IsUniqueItem { get; set; }
        public int? IsRequiredItem { get; set; }

        [MaxLength(50)]
        public string? ContainerLevel { get; set; }

        [MaxLength(50)]
        public string? ContainerGS { get; set; }

        [MaxLength(50)]
        public string? ExceedMinIndex { get; set; }

        [MaxLength(50)]
        public string? ExceedMaxIndex { get; set; }
        public int? IsSalvageable { get; set; }

        [MaxLength(50)]
        public string? SalvageResources { get; set; }
        public int? IsRepairable { get; set; }
        public double? RepairDustModifier { get; set; }

        [MaxLength(50)]
        public string? RepairRecipe { get; set; }

        [MaxLength(50)]
        public string? CraftingRecipe { get; set; }

        [MaxLength(50)]
        public string? RepairGameEventID { get; set; }

        [MaxLength(50)]
        public string? SalvageGameEventID { get; set; }

        [MaxLength(150)]
        public string? SalvageAchievement { get; set; }

        [MaxLength(50)]
        public string? RepairTypes { get; set; }

        [MaxLength(120)]
        public string? IngredientCategories { get; set; }

        [MaxLength(50)]
        public string? IngredientBonusPrimary { get; set; }

        [MaxLength(50)]
        public string? IngredientBonusSecondary { get; set; }

        [MaxLength(50)]
        public string? IngredientGearScoreBaseBonus { get; set; }

        [MaxLength(50)]
        public string? IngredientGearScoreMaxBonus { get; set; }

        [MaxLength(50)]
        public string? ExtraBonusItemChance { get; set; }
        public int? Durability { get; set; }
        public double? DurabilityDmgOnDeath { get; set; }
        public int? DestroyOnBreak { get; set; }
        public double? Weight { get; set; }

        [MaxLength(50)]
        public string? AcquisitionNotificationId { get; set; }

        [MaxLength(80)]
        public string? AudioPickup { get; set; }

        [MaxLength(80)]
        public string? AudioPlace { get; set; }

        [MaxLength(80)]
        public string? AudioUse { get; set; }

        [MaxLength(80)]
        public string? AudioCreated { get; set; }

        [MaxLength(80)]
        public string? AudioDestroyed { get; set; }

        [MaxLength(50)]
        public string? MannequinTag { get; set; }

        [MaxLength(50)]
        public string? SoundTableID { get; set; }

        [MaxLength(50)]
        public string? WarboardGatherStat { get; set; }

        [MaxLength(50)]
        public string? WarboardDepositStat { get; set; }
        public string? Notes { get; set; }
        public string? HideInLootTicker { get; set; }

        [MaxLength(400)]
        public string? SalvageLootTags { get; set; }

        [MaxLength(50)]
        public string? EventId { get; set; }

        [MaxLength(50)]
        public string? AttributionId { get; set; }

        [MaxLength(50)]
        public string? HeartgemRuneTooltipTitle { get; set; }

        [MaxLength(100)]
        public string? HeartgemTooltipBackgroundImage { get; set; }
        public int? HideFromRewardOpenPopup { get; set; }

        [MaxLength(50)]
        public string? SalvageEntitlementId { get; set; }

        [MaxLength(50)]
        public string? ParentItemId_DVT { get; set; }

        [MaxLength(50)]
        public string? IgnoreParentColumns_DVT { get; set; }
        public string? MasterName { get; set; }
        public string? MasterDescription { get; set; }
        public bool IsDepricated { get; set; }
        public string ItemFileType { get; set; }
    }
}
