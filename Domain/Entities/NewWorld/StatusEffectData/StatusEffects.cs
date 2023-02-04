﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.StatusEffectData
{
    public class StatusEffects : AuditableEntity, IAggregateRoot
    {
        public string? StatusID { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? WindowHeader { get; set; }
        public int? RankSorting { get; set; }
        public string? EffectCategories { get; set; }
        public string? PlaceholderIcon { get; set; }
        public string? ShowInUITray { get; set; }
        public bool? ShowTextInDamageNumbers { get; set; }
        public string? FxScriptOn { get; set; }
        public string? FxScriptOff { get; set; }
        public string? ShouldRefreshFxScript { get; set; }
        public string? WeaponEffectType { get; set; }
        public string? Notification { get; set; }
        public string? DisableTelemetry { get; set; }
        public string? IsClientPredicted { get; set; }
        public string? PotencyPerLevel { get; set; }
        public bool? HideHudDurationNumbers { get; set; }
        public double? BaseDuration { get; set; }
        public double? TickRate { get; set; }
        public string? DelayInitialTick { get; set; }
        public string? TickCondition { get; set; }
        public string? OnTickStatusEffect { get; set; }
        public string? KeepOnTickEffectOnEnd { get; set; }
        public string? StopOnHitCount { get; set; }
        public string? HitCondition { get; set; }
        public string? RequireReaction { get; set; }
        public string? OnStackStatusEffect { get; set; }
        public string? AddOnStackSize { get; set; }
        public string? AddOnStackSizeComparison { get; set; }
        public string? HealThreatMultiplier { get; set; }
        public string? ScaleAmountOverTime { get; set; }
        public string? ScaleAmountOverTimeMin { get; set; }
        public string? ScaleAmountOverTimeMax { get; set; }
        public string? DamageSkipsDeathsDoor { get; set; }
        public double? Health { get; set; }
        public double? HealthMin { get; set; }
        public double? HealthModifierPercent { get; set; }
        public double? HealthModifierDamageBased { get; set; }
        public string? UseHealScalingValue { get; set; }
        public double? HealScalingValueMultiplier { get; set; }
        public double? StaminaDamageModifier { get; set; }
        public double? ManaModifierDamageBased { get; set; }
        public string? DamageType { get; set; }
        public double? CritChanceModifier { get; set; }
        public double? CritDamageModifier { get; set; }
        public string? OnEndStatusEffect { get; set; }
        public bool? DontApplyOnEndEffectOnRemove { get; set; }
        public string? CastSpell { get; set; }
        public string? TargetOwnsSpell { get; set; }
        public string? UseSourceWeaponForSpell { get; set; }
        public double? FromAlchemy { get; set; }
        public double? FromSpell { get; set; }
        public string? NoHealthRegen { get; set; }
        public double? HealMod { get; set; }
        public double? MaxHealthMod { get; set; }
        public double? HealthRate { get; set; }
        public double? CoreTempMod { get; set; }
        public double? TempMod { get; set; }
        public double? Stamina { get; set; }
        public double? StaminaRate { get; set; }
        public double? Mana { get; set; }
        public double? ManaRate { get; set; }
        public double? Food { get; set; }
        public double? FoodBurn { get; set; }
        public double? Drink { get; set; }
        public double? DrinkBurn { get; set; }
        public double? Encumbrance { get; set; }
        public string? ItemClassWeightMods { get; set; }
        public string? XPIncreases { get; set; }
        public double? AzothMod { get; set; }
        public double? FactionReputationMod { get; set; }
        public double? FactionTokensMod { get; set; }
        public double? EXPLogging { get; set; }
        public double? EXPMining { get; set; }
        public double? EXPHarvesting { get; set; }
        public double? EXPSkinning { get; set; }
        public double? EXPSmelting { get; set; }
        public string? EXPWoodworking { get; set; }
        public double? EXPLeatherworking { get; set; }
        public double? EXPWeaving { get; set; }
        public double? EXPStonecutting { get; set; }
        public double? GrantSanctuary { get; set; }
        public int? NoSprint { get; set; }
        public int? NoRun { get; set; }
        public int? NoDodge { get; set; }
        public int? NoNav { get; set; }
        public int? Silenced { get; set; }
        public int? Stunned { get; set; }
        public string? RemoveOnDeath { get; set; }
        public string? RemoveOnDeathsDoor { get; set; }
        public string? RemoveOnRespawn { get; set; }
        public string? RemoveOnGameModeExit { get; set; }
        public string? IgnoreDiminishingReturns { get; set; }
        public string? OnlyChangeOwnedStatusEffects { get; set; }
        public string? Afflictions { get; set; }
        public string? OnHitAffixes { get; set; }
        public string? EquipAbility { get; set; }
        public string? UseSourceWeaponForAbilityEffect { get; set; }
        public string? IsNegative { get; set; }
        public string? RespecTradeskills { get; set; }
        public string? RespecAttributes { get; set; }
        public string? EffectDurationMods { get; set; }
        public string? EffectPotencyMods { get; set; }
        public string? RemoveStatusEffects { get; set; }
        public string? RemoveStatusEffectCategories { get; set; }
        public double? GlobalRollMod { get; set; }
        public string? FishingLineStrength { get; set; }
        public string? FishSizeRollModifier { get; set; }
        public double? MODConstitution { get; set; }
        public double? MODFocus { get; set; }
        public double? MODStrength { get; set; }
        public double? MODDexterity { get; set; }
        public double? MODIntelligence { get; set; }
        public double? MGSArcana { get; set; }
        public double? MGSWeaponsmithing { get; set; }
        public double? MGSJewelcrafting { get; set; }
        public double? MGSEngineering { get; set; }
        public double? MGSArmoring { get; set; }
        public double? MaxGSArcana { get; set; }
        public double? MaxGSWeaponsmithing { get; set; }
        public double? MaxGSJewelcrafting { get; set; }
        public double? MaxGSEngineering { get; set; }
        public double? MaxGSArmoring { get; set; }
        public double? ROLCooking { get; set; }
        public double? ROLWeaving { get; set; }
        public double? ROLStonecutting { get; set; }
        public double? ROLSmelting { get; set; }
        public double? ROLLeatherworking { get; set; }
        public double? ROLWoodworking { get; set; }
        public double? ROLLogging { get; set; }
        public double? ROLMining { get; set; }
        public double? ROLSkinning { get; set; }
        public double? ROLHarvesting { get; set; }
        public double? ROLFishing { get; set; }
        public double? MULTLogging { get; set; }
        public double? MULTMining { get; set; }
        public double? MULTSkinning { get; set; }
        public double? MULTHarvesting { get; set; }
        public double? MULTFishing { get; set; }
        public double? EFFLogging { get; set; }
        public double? EFFMining { get; set; }
        public double? EFFSkinning { get; set; }
        public double? EFFHarvesting { get; set; }
        public double? INSLogging { get; set; }
        public double? INSMining { get; set; }
        public double? INSSkinning { get; set; }
        public double? INSHarvesting { get; set; }
        public double? ABSStandard { get; set; }
        public double? ABSSiege { get; set; }
        public double? ABSStrike { get; set; }
        public double? ABSSlash { get; set; }
        public double? ABSThrust { get; set; }
        public double? ABSArcane { get; set; }
        public double? ABSFire { get; set; }
        public double? ABSIce { get; set; }
        public double? ABSNature { get; set; }
        public double? ABSLightning { get; set; }
        public double? ABSCorruption { get; set; }
        public string? ABSVitalsCategory { get; set; }
        public double? RESPoison { get; set; }
        public double? RESDisease { get; set; }
        public double? RESBleed { get; set; }
        public double? RESFrostbite { get; set; }
        public double? RESCurse { get; set; }
        public double? RESBlight { get; set; }
        public double? BLAStandard { get; set; }
        public double? BLASiege { get; set; }
        public double? BLAStrike { get; set; }
        public double? BLASlash { get; set; }
        public double? BLAThrust { get; set; }
        public double? BLAArcane { get; set; }
        public double? BLAFire { get; set; }
        public double? BLAIce { get; set; }
        public double? BLALightning { get; set; }
        public double? BLACorruption { get; set; }
        public double? ABAPoison { get; set; }
        public double? ABADisease { get; set; }
        public double? ABABleed { get; set; }
        public double? ABAFrostbite { get; set; }
        public double? ABACurse { get; set; }
        public double? ABABlight { get; set; }
        public double? WKNStandard { get; set; }
        public double? WKNSiege { get; set; }
        public double? WKNStrike { get; set; }
        public double? WKNSlash { get; set; }
        public double? WKNThrust { get; set; }
        public double? WKNArcane { get; set; }
        public double? WKNFire { get; set; }
        public double? WKNIce { get; set; }
        public double? WKNNature { get; set; }
        public double? WKNLightning { get; set; }
        public double? WKNCorruption { get; set; }
        public double? DMGStandard { get; set; }
        public double? DMGSiege { get; set; }
        public double? DMGStrike { get; set; }
        public double? DMGSlash { get; set; }
        public double? DMGThrust { get; set; }
        public double? DMGArcane { get; set; }
        public double? DMGFire { get; set; }
        public double? DMGIce { get; set; }
        public double? DMGNature { get; set; }
        public double? DMGLightning { get; set; }
        public double? DMGCorruption { get; set; }
        public string? DMGVitalsCategory { get; set; }
        public double? AFAPoison { get; set; }
        public double? AFADisease { get; set; }
        public double? AFABleed { get; set; }
        public double? AFAFrostbite { get; set; }
        public double? AFACurse { get; set; }
        public double? AFABlight { get; set; }
        public string? StackDuration { get; set; }
        public double? DurationMax { get; set; }
        public string? InheritDuration { get; set; }
        public string? InheritTotalDuration { get; set; }
        public string? RefreshDuration { get; set; }
        public int? StackMax { get; set; }
        public double? InitialStackSize { get; set; }
        public string? RemoveUnappliedStacks { get; set; }
        public double? PotencyMax { get; set; }
        public string? DontReplaceStack { get; set; }
        public double? MoveSpeedMod { get; set; }
        public double? SprintSpeedMod { get; set; }
        public string? FastTravelEncumbranceMod { get; set; }
        public string? GameEventId { get; set; }
        public string? HealRewardGameEventId { get; set; }
        public string? HealRewardThreshold { get; set; }
        public string? WeaponMasteryCategoryId { get; set; }
        public int? UIPriority { get; set; }
        public int? UiNameplatePriority { get; set; }
        public string? ShowInNameplates { get; set; }
        public string? ShowTextInNameplates { get; set; }
        public string? OverrideOtherNameplateText { get; set; }
        public string? HidesOtherStatusEffectIcons { get; set; }
        public string? DynamicModelScaleFactor { get; set; }
        public string? DynamicModelScaleRampTimeSecs { get; set; }
        public string? SpawnSlice { get; set; }
        public string? DisableSupportContributionRewards { get; set; }
        public string? BlockMultipleEffectsFromSameSource { get; set; }
        public string? AllowSelfOnlyAsSourceForAbilities { get; set; }
        public string? IgnoreInvulnerable { get; set; }

        [JsonProperty("NotCombatAction ")]
        public string? NotCombatAction { get; set; }
        public string? UseLightweightReplication { get; set; }
        public string? SourceRuneChargeOnApply { get; set; }
        public string? SourceRuneChargeOnTick { get; set; }
        public string? SourceRuneChargeOnHealthChangeOnly { get; set; }
        public bool? IgnoreFxScriptWhenPotencyIsZero { get; set; }
        public bool? ReapplyAfterPersistenceReload { get; set; }
        public bool? IsTrueDamage { get; set; }
        public bool? ShowUiDamageNumbersOnHeal { get; set; }
        public double? XPIncreasesTooltip { get; set; }
        public double? TerritoryStandingMod { get; set; }
        public int? ABSAcid { get; set; }
        public double? DMGVitalsCategory_Tooltip { get; set; }
        public bool? DisableAllPerks { get; set; }
        public string? DisableAllPerksExceptionLabels { get; set; }
        public bool? PreventPassiveAbilitiesOnEquip { get; set; }
        public string? GrantedSkinId { get; set; }
        public double? ApplicationCooldown { get; set; }
        public double? HealthModifierBasePercent { get; set; }
        public double? EXPFishing { get; set; }
        public string? LootTags { get; set; }
        public string? ItemLootVolumeMods { get; set; }
        public int? NonConsumableHealMod { get; set; }
        public string? PotencyPerGearScore { get; set; }
        public string? DurationScalingPerGearScore { get; set; }
        public bool? DisableCastSpellDurability { get; set; }
        public string? SlotToFillWeaponDamageInfo { get; set; }
        public bool? ForceReplicateToRemotes { get; set; }
        public string? OnDeathStatusEffect { get; set; }
        public bool? DontApplyOnEndEffectOnTimeOutDeath { get; set; }
    }
}
