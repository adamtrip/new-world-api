using Newtonsoft.Json;

namespace Domain.Entities.NewWorld.AbilityData
{
    public class RapierAbilityTable : AuditableEntity, IAggregateRoot
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
        public string WeaponTag { get; set; }
        public string RequiredAbilityId { get; set; }
        public int? TreeId { get; set; }
        public int? TreeRowPosition { get; set; }
        public int? TreeColumnPosition { get; set; }
        public bool? IsActiveAbility { get; set; }
        public bool? IsGlobalAbility { get; set; }
        public string ScalingStrength { get; set; }
        public string ScalingDexterity { get; set; }
        public string ScalingIntelligence { get; set; }
        public string ScalingSpirit { get; set; }
        public string ScalingConstitution { get; set; }
        public bool? OnKill { get; set; }
        public bool? OnExecuted { get; set; }
        public bool? OnHit { get; set; }
        public bool? OnBlockedHit { get; set; }
        public bool? OnCrit { get; set; }
        public bool? OnHeadShot { get; set; }
        public bool? OnLegShot { get; set; }
        public bool? OnHitTaken { get; set; }
        public bool? OnBlockBreak { get; set; }
        public bool? OnTargetBlockBreak { get; set; }
        public bool? OnDeath { get; set; }
        public bool? OnDeathsDoor { get; set; }
        public bool? OnHitTakenWhileInvulnerable { get; set; }
        public bool? RequireReaction { get; set; }
        public int? NumSuccessfulHits { get; set; }
        public int? NumConsecutiveHits { get; set; }
        public int? MaxConsecutiveHits { get; set; }
        public bool? ResetConsecutiveOnSuccess { get; set; }
        public bool? TrackHitCount { get; set; }
        public int? MaxTrackedHitCounts { get; set; }
        public int? NumberOfTrackedHits { get; set; }
        public string NumberOfHitsComparisonType { get; set; }
        public string DamageIsRanged { get; set; }
        public bool? DamageIsMelee { get; set; }
        public string ForceShowNameTag { get; set; }
        public string TargetHasGritActive { get; set; }
        public string DamageTableRow { get; set; }
        public string RemoteDamageTableRow { get; set; }
        public string RangedAttackName { get; set; }
        public string AttackType { get; set; }
        public string DamageTypes { get; set; }
        public string StatusEffect { get; set; }
        public string StatusEffectCategories { get; set; }
        public string TargetStatusEffect { get; set; }
        public string TargetStatusEffectCategory { get; set; }
        public string? TargetStatusEffectStackSize { get; set; }
        public string TargetStatusEffectComparison { get; set; }
        public string TargetCollisionFilters { get; set; }
        public string TargetMarker { get; set; }
        public int? MyHealthPercent { get; set; }
        public string MyComparisonType { get; set; }
        public int? MyStaminaPercent { get; set; }
        public string MyStaminaComparisonType { get; set; }
        public int? TargetHealthPercent { get; set; }
        public string TargetComparisonType { get; set; }
        public int? DistFromDefender { get; set; }
        public string DistComparisonType { get; set; }
        public string NumAroundMe { get; set; }
        public string NumAroundComparisonType { get; set; }
        public string AbilityList { get; set; }
        public string AbilityTrigger { get; set; }
        public string InAction { get; set; }
        public double? InActionTime { get; set; }
        public string AfterAction { get; set; }
        public double? BaseDamage { get; set; }
        public string BaseDamageReduction { get; set; }
        public double? BlockDamage { get; set; }
        public string BlockDamageReduction { get; set; }
        public string CritDamage { get; set; }
        public string CritChance { get; set; }
        public string HeadshotDamage { get; set; }

        [JsonProperty("stagger damage")]
        public string? staggerdamage { get; set; }
        public string StaggerDamageReduction { get; set; }
        public string HitRateDmg { get; set; }
        public string HitRateDmgReduction { get; set; }
        public string HealthDamageMitigation { get; set; }
        public string ThreatDamage { get; set; }
        public string ArmorPenetration { get; set; }
        public string PhysicalArmor { get; set; }
        public string ElementalArmor { get; set; }
        public string LinearlyScaleToDistance { get; set; }
        public string Knockback { get; set; }
        public string WeaponAccuracy { get; set; }
        public string Health { get; set; }
        public string DmgPctToHealth { get; set; }
        public string MaxHealth { get; set; }
        public string Mana { get; set; }
        public string MaxMana { get; set; }
        public string DamageTableRowOverride { get; set; }
        public string StatusEffectDamageTableRowOverride { get; set; }
        public string RangedAttackNameOverride { get; set; }
        public string DamageTableStatusEffectOverride { get; set; }
        public string EnableCrit { get; set; }
        public string PerStatusEffectOnTarget { get; set; }
        public string DisableScalePerTargetSEStack { get; set; }
        public string ForceTakeStaminaDamage { get; set; }
        public string CastSpell { get; set; }
        public string SelfApplyStatusEffect { get; set; }
        public string OtherApplyStatusEffect { get; set; }
        public string SetPotencyAsCount { get; set; }
        public string MultiplyRemovedByPotency { get; set; }
        public string RemoveStatusEffects { get; set; }
        public string StatusEffectsList { get; set; }
        public string StatusEffectCategoriesList { get; set; }
        public string RemoveTargetStatusEffectsList { get; set; }
        public double? ConsumeTargetStatusEffectMult { get; set; }
        public string StatusEffectDurationReduction { get; set; }
        public string TargetStatusEffectDurationList { get; set; }
        public int? TargetStatusEffectDurationMod { get; set; }
        public string? ActivationCooldown { get; set; }
        public int? Duration { get; set; }
        public string CooldownId { get; set; }
        public string CDRImmediatelyOptions { get; set; }
        public string ResetCooldownTimers { get; set; }
        public double? CooldownTimer { get; set; }
        public string NumFreeCooldownsPerUse { get; set; }
        public int? MaxHitCountMultiplier { get; set; }
        public string SetMannequinTag { get; set; }

    }
}
