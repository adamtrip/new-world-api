﻿using Application.NewWorld.PerkBucketData;
using Application.NewWorld.PerkData;
using Application.NewWorld.WeaponItemDefs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.MasterItemDefinitions
{
    public class MasterItemDefinitionDto
    {
        public Guid Id { get; set; }
        public string? ItemID { get; set; }
        public string? Name { get; set; }
        public string? ItemType { get; set; }
        public string? ItemTypeDisplayName { get; set; }
        public string? Description { get; set; }
        public string? ItemClass { get; set; }
        public string? TradingCategory { get; set; }
        public string? TradingFamily { get; set; }
        public string? TradingGroup { get; set; }
        public int? BindOnPickup { get; set; }
        public string? BindOnEquip { get; set; }
        public int? GearScoreOverride { get; set; }
        public int? MinGearScore { get; set; }
        public int? MaxGearScore { get; set; }
        public int? Tier { get; set; }
        public string? ItemStatsRef { get; set; }
        public string? GrantsHWMBump { get; set; }
        public string? IgnoreNameChanges { get; set; }
        public string? IgnoreHWMScaling { get; set; }
        public int? CanHavePerks { get; set; }
        public int? CanReplaceGem { get; set; }
        public string? Perk1 { get; set; }
        public string? Perk2 { get; set; }
        public string? Perk3 { get; set; }
        public string? Perk4 { get; set; }
        public string? Perk5 { get; set; }
        public ItemPerkDto? ItemPerk1 { get; set; }
        public ItemPerkDto? ItemPerk2 { get; set; }
        public ItemPerkDto? ItemPerk3 { get; set; }
        public ItemPerkDto? ItemPerk4 { get; set; }
        public ItemPerkDto? ItemPerk5 { get; set; }
        public string? PerkBucket1 { get; set; }
        public string? PerkBucket2 { get; set; }
        public string? PerkBucket3 { get; set; }
        public string? PerkBucket4 { get; set; }
        public string? PerkBucket5 { get; set; }
        public PerkBucketDataDto? ItemPerkBucket1 { get; set; }
        public PerkBucketDataDto? ItemPerkBucket2 { get; set; }
        public PerkBucketDataDto? ItemPerkBucket3 { get; set; }
        public PerkBucketDataDto? ItemPerkBucket4 { get; set; }
        public PerkBucketDataDto? ItemPerkBucket5 { get; set; }
        public int? ForceRarity { get; set; }
        public string? RequiredLevel { get; set; }
        public int? UseTypeAffix { get; set; }
        public int? UseMaterialAffix { get; set; }
        public int? UseMagicAffix { get; set; }
        public string? IconCaptureGroup { get; set; }
        public string? UiItemClass { get; set; }
        public string? ArmorAppearanceM { get; set; }
        public string? ArmorAppearanceF { get; set; }
        public string? WeaponAppearanceOverride { get; set; }
        public string? ConfirmDestroy { get; set; }
        public int? ConfirmBeforeUse { get; set; }
        public int? ConsumeOnUse { get; set; }
        public string? PrefabPath { get; set; }
        public string? HousingTags { get; set; }
        public string? IconPath { get; set; }
        public string? HiResIconPath { get; set; }
        public int? MaxStackSize { get; set; }
        public int? DeathDropPercentage { get; set; }
        public int? Nonremovable { get; set; }
        public string? IsMissionItem { get; set; }
        public int? IsUniqueItem { get; set; }
        public int? IsRequiredItem { get; set; }
        public string? ContainerLevel { get; set; }
        public string? ContainerGS { get; set; }
        public string? ExceedMinIndex { get; set; }
        public string? ExceedMaxIndex { get; set; }
        public int? IsSalvageable { get; set; }
        public string? SalvageResources { get; set; }
        public int? IsRepairable { get; set; }
        public double? RepairDustModifier { get; set; }
        public string? RepairRecipe { get; set; }
        public string? CraftingRecipe { get; set; }
        public string? RepairGameEventID { get; set; }
        public string? SalvageGameEventID { get; set; }
        public string? SalvageAchievement { get; set; }
        public string? RepairTypes { get; set; }
        public string? IngredientCategories { get; set; }
        public string? IngredientBonusPrimary { get; set; }
        public string? IngredientBonusSecondary { get; set; }
        public string? IngredientGearScoreBaseBonus { get; set; }
        public string? IngredientGearScoreMaxBonus { get; set; }
        public string? ExtraBonusItemChance { get; set; }
        public int? Durability { get; set; }
        public double? DurabilityDmgOnDeath { get; set; }
        public int? DestroyOnBreak { get; set; }
        public double? Weight { get; set; }
        public string? AcquisitionNotificationId { get; set; }
        public string? AudioPickup { get; set; }
        public string? AudioPlace { get; set; }
        public string? AudioUse { get; set; }
        public string? AudioCreated { get; set; }
        public string? AudioDestroyed { get; set; }
        public string? MannequinTag { get; set; }
        public string? SoundTableID { get; set; }
        public string? WarboardGatherStat { get; set; }
        public string? WarboardDepositStat { get; set; }
        public string? Notes { get; set; }
        public string? HideInLootTicker { get; set; }
        public string? SalvageLootTags { get; set; }
        public string? EventId { get; set; }
        public string? AttributionId { get; set; }
        public string? HeartgemRuneTooltipTitle { get; set; }
        public string? HeartgemTooltipBackgroundImage { get; set; }
        public int? HideFromRewardOpenPopup { get; set; }
        public string? SalvageEntitlementId { get; set; }
        public string? ParentItemId_DVT { get; set; }
        public string? IgnoreParentColumns_DVT { get; set; }
        public string? MasterName { get; set; }
        public string? MasterDescription { get; set; }
        public bool? IsDepricated { get; set; }
        public WeaponItemDefinitionDto? WeaponItemDefinition { get; set; }
    }
}
