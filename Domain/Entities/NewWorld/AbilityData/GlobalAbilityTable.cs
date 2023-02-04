﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.AbilityData
{
    public class GlobalAbilityTable : AuditableEntity, IAggregateRoot
    {
        public string AbilityID { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string UICategory { get; set; }
        public string Icon { get; set; }
        public string StatusEffectIcon { get; set; }
        public string Sound { get; set; }
        public string TelegraphStatusEffect { get; set; }
        public string TelegraphCountOffset { get; set; }
        public string OnEquipStatusEffect { get; set; }
        public string EquipWhenUnsheathed { get; set; }
        public string WeaponTag { get; set; }
        public string RequiredAbilityId { get; set; }
        public string RequiredEquippedAbilityId { get; set; }
        public string TreeId { get; set; }
        public string TreeRowPosition { get; set; }
        public string TreeColumnPosition { get; set; }
        public bool? IsActiveAbility { get; set; }
        public bool? IsGlobalAbility { get; set; }
        public bool? IsStackableAbility { get; set; }
        public bool? CanBeUnapplied { get; set; }
        public string ScalingStrength { get; set; }
        public string ScalingDexterity { get; set; }
        public string ScalingIntelligence { get; set; }
        public string ScalingSpirit { get; set; }
        public string ScalingConstitution { get; set; }
        public bool? OnEventPassiveConditionsPass { get; set; }
        public bool? OnKill { get; set; }
        public bool? OnExecuted { get; set; }
        public bool? OnHit { get; set; }
        public bool? OnBlockedHit { get; set; }
        public bool? OnHitBehind { get; set; }
        public bool? OnCrit { get; set; }
        public bool? OnCritTaken { get; set; }
        public bool? OnHeadShot { get; set; }
        public bool? OnLegShot { get; set; }
        public bool? OnHitTaken { get; set; }
        public bool? OnBlockedHitTaken { get; set; }
        public bool? OnBlockBreak { get; set; }
        public bool? OnTargetBlockBreak { get; set; }
        public bool? OnDeath { get; set; }
        public bool? OnDeathsDoor { get; set; }
        public bool? OnHasDied { get; set; }
        public bool? OnAttachedSpellTargetDied { get; set; }
        public bool? OnHealed { get; set; }
        public string OnSelfDamage { get; set; }
        public bool? OnProjPassedThrough { get; set; }
        public bool? OnContributedKill { get; set; }
        public string OnHealthChanged { get; set; }
        public bool? OnUsedConsumable { get; set; }
        public bool? OnGatheringComplete { get; set; }
        public bool? OnHitTakenWhileInvulnerable { get; set; }
        public string OnWeaponSwap { get; set; }
        public bool? OnStatusEffectApplied { get; set; }
        public string OnInActionLongEnough { get; set; }
        public bool? OnTargetStatusEffectRemoved { get; set; }
        public string OnEventConditionalActivationChance { get; set; }
        public string GatheringTradeskill { get; set; }
        public string EquipLoadCategory { get; set; }
        public string ExcludeFromGameModes { get; set; }
        public bool? RequireReaction { get; set; }
        public int? NumSuccessfulHits { get; set; }
        public int? NumConsecutiveHits { get; set; }
        public int? MaxConsecutiveHits { get; set; }
        public bool? ResetConsecutiveOnSuccess { get; set; }
        public string IgnoreResetConsecutiveOnDeath { get; set; }
        public bool? DisableConsecutivePotency { get; set; }
        public bool? TrackHitCount { get; set; }
        public int? MaxTrackedHitCounts { get; set; }
        public int? NumberOfTrackedHits { get; set; }
        public string NumberOfHitsComparisonType { get; set; }
        public string ResetTrackedOnSuccess { get; set; }
        public string AbilityIdToCheckForTrackedHits { get; set; }
        public bool? DamageIsRanged { get; set; }
        public bool? DamageIsMelee { get; set; }
        public string AllowSelfDamageForHitEvents { get; set; }
        public string ForceShowNameTag { get; set; }
        public bool? HasGritActive { get; set; }
        public bool? TargetHasGritActive { get; set; }
        public string DamageTableRow { get; set; }
        public string RemoteDamageTableRow { get; set; }
        public string RangedAttackName { get; set; }
        public string AttackType { get; set; }
        public string IgnoreDisabledAttackTypes { get; set; }
        public string DamageTypes { get; set; }
        public string DamageCategory { get; set; }
        public bool? IsInCombatState { get; set; }
        public bool? IsNotInCombatState { get; set; }
        public string CheckOwnedStatusEffects { get; set; }
        public string StatusEffect { get; set; }
        public int? StatusEffectStackSize { get; set; }
        public string StatusEffectComparison { get; set; }
        public string StatusEffectCategories { get; set; }
        public string DontHaveStatusEffect { get; set; }
        public string StatusEffectBeingApplied { get; set; }
        public bool? CheckStatusEffectsOnTargetOwned { get; set; }
        public string TargetStatusEffect { get; set; }
        public string TargetStatusEffectCategory { get; set; }
        public int? TargetStatusEffectStackSize { get; set; }
        public string TargetStatusEffectComparison { get; set; }
        public string TargetCollisionFilters { get; set; }
        public string MyMarker { get; set; }
        public string TargetMarker { get; set; }
        public int? MyHealthPercent { get; set; }
        public string MyComparisonType { get; set; }
        public int? MyStaminaPercent { get; set; }
        public string MyStaminaComparisonType { get; set; }
        public string MyManaPercent { get; set; }
        public string MyManaComparisonType { get; set; }
        public int? TargetHealthPercent { get; set; }
        public string TargetComparisonType { get; set; }
        public int? DistFromDefender { get; set; }
        public string DistComparisonType { get; set; }
        public string MaxNumAroundMe { get; set; }
        public int? NumAroundMe { get; set; }
        public string NumAroundComparisonType { get; set; }
        public string AbilityOnCooldownOptions { get; set; }
        public string AbilitiesOnCooldown { get; set; }
        public string AbilityCooldownComparisonType { get; set; }
        public string AttachedTargetSpellIds { get; set; }
        public string AbilityList { get; set; }
        public string AbilityTrigger { get; set; }
        public string IsConsumableIds { get; set; }
        public string IsNotConsumableIds { get; set; }
        public string InAction { get; set; }
        public double? InActionTime { get; set; }
        public string AfterAction { get; set; }
        public int? LoadedAmmoCount { get; set; }
        public string LoadedAmmoCountComparisonType { get; set; }
        public string AttackerVitalsCategory { get; set; }
        public string TargetVitalsCategory { get; set; }
        public double? BaseDamage { get; set; }
        public string SetHealthOnFatalDamageTaken { get; set; }
        public double? BaseDamageReduction { get; set; }
        public double? CritDamageReduction { get; set; }
        public double? BlockDamage { get; set; }
        public double? BlockDamageReduction { get; set; }
        public double? CritDamage { get; set; }
        public double? CritChance { get; set; }
        public double? HeadshotDamage { get; set; }
        public double? HitFromBehindDamage { get; set; }
        public string? staggerdamage { get; set; }
        public string StaggerDamageReduction { get; set; }
        public string HitRateDmg { get; set; }
        public string HitRateDmgReduction { get; set; }
        public string HealthDamageMitigation { get; set; }
        public double? ThreatDamage { get; set; }
        public double? ArmorPenetration { get; set; }
        public string CritArmorPenetration { get; set; }
        public double? HeadshotArmorPenetration { get; set; }
        public double? HitFromBehindArmorPenetration { get; set; }
        public string PhysicalArmor { get; set; }
        public string PhysicalArmorMaxHealthMod { get; set; }
        public string ElementalArmor { get; set; }
        public string LinearlyScaleToDistance { get; set; }
        public double? RefundAmmoPercentChance { get; set; }
        public double? RefundConsumablePercentChance { get; set; }
        public double? GiveAzothPercentChance { get; set; }
        public int? Azoth { get; set; }
        public double? Knockback { get; set; }
        public double? WeaponAccuracy { get; set; }
        public string Health { get; set; }
        public string HealthPenaltyPerStackRemoved { get; set; }
        public double? DmgPctToHealth { get; set; }
        public double? HealScalingValueMultiplier { get; set; }
        public double? MaxHealth { get; set; }
        public double? Mana { get; set; }
        public string ManaRate { get; set; }
        public double? MaxMana { get; set; }
        public string ManaCostList { get; set; }
        public string ManaCostMult { get; set; }
        public int? Stamina { get; set; }
        public string DamageTableRowOverride { get; set; }
        public string StatusEffectDamageTableRowOverride { get; set; }
        public bool? ForceStatusEffectDamageTableRow { get; set; }
        public string RangedAttackNameOverride { get; set; }
        public string DamageTableStatusEffectOverride { get; set; }
        public string EnableCrit { get; set; }
        public bool? EnableTaunt { get; set; }
        public string CanBlockRangedOverride { get; set; }
        public string PerStatusEffectOnSelf { get; set; }
        public string PerStatusEffectOnSelfMax { get; set; }
        public bool? PerStatusEffectOnTarget { get; set; }
        public int? PerStatusEffectOnTargetMax { get; set; }
        public string DisableApplyPerStatusEffectStack { get; set; }
        public string DisableScalePerTargetSEStack { get; set; }
        public string ForceTakeStaminaDamage { get; set; }
        public string StaminaCostList { get; set; }
        public string StaminaCostFlatMod { get; set; }
        public string CastSpell { get; set; }
        public bool? DisableCastSpellDurability { get; set; }
        public string SelfApplyStatusEffect { get; set; }
        public string OtherApplyStatusEffect { get; set; }
        public string SelfApplyStatusEffectDurations { get; set; }
        public string OtherApplyStatusEffectDurations { get; set; }
        public bool? DoNotUnequipSelfAppliedSE { get; set; }
        public bool? UseMinAttackInfoForSelfAppliedSE { get; set; }
        public int? ModifySelfApplyStatusEffectDuration { get; set; }
        public int? NumStatusEffectsToTransfer { get; set; }
        public string StatusEffectCategoryToTransfer { get; set; }
        public string SetPotencyAsCount { get; set; }
        public string MultiplyRemovedByPotency { get; set; }
        public string OnlyChangeOwnedStatusEffects { get; set; }
        public int? NumStatusEffectsToRemove { get; set; }
        public int? NumTargetStatusEffectsToRemove { get; set; }
        public string? NumStatusEffectStacksToRemove { get; set; }
        public string RemoveStatusEffects { get; set; }
        public string StatusEffectsList { get; set; }
        public string StatusEffectCategoriesList { get; set; }
        public string RemoveTargetStatusEffectsList { get; set; }
        public string RemoveTargetStatusEffectCats { get; set; }
        public string? ConsumeTargetStatusEffectMult { get; set; }
        public double? StatusEffectDurationReduction { get; set; }
        public string StatusEffectDurationCats { get; set; }
        public int? StatusEffectDurationMod { get; set; }
        public double? StatusEffectDurationMult { get; set; }
        public string TargetStatusEffectDurationList { get; set; }
        public string TargetStatusEffectDurationCats { get; set; }
        public string TargetStatusEffectDurationMod { get; set; }
        public double? TargetStatusEffectDurationMult { get; set; }
        public double? ActivationCooldown { get; set; }
        public double? Duration { get; set; }
        public string CooldownId { get; set; }
        public string CDRImmediatelyOptions { get; set; }
        public string ResetCooldownTimers { get; set; }
        public double? CooldownTimer { get; set; }
        public string NumFreeCooldownsPerUse { get; set; }
        public string ConsumableCooldownForReset { get; set; }
        public string ResetConsumableCooldowns { get; set; }
        public string MaxHitCountMultiplier { get; set; }
        public string SetMannequinTag { get; set; }
        public string SetMannequinTagStatus { get; set; }
        public string RepairDustYieldMod { get; set; }
        public string ToolDurabilityLossMod { get; set; }
        public string FastTravelInnCooldownMod { get; set; }
        public string FastTravelAzothCostMod { get; set; }
    }
}