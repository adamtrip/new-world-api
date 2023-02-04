﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.SpellData
{
    public class SpellDataTable : AuditableEntity, IAggregateRoot
    {
        public string? SpellID { get; set; }
        public string? StatusEffects { get; set; }
        public string? StatusEffectDurations { get; set; }
        public string? Revive { get; set; }
        public string? Siphon { get; set; }
        public string? AttachToOwner { get; set; }
        public string? StickWhenAttached { get; set; }
        public string? StoreOffsetWhenStuckToGDE { get; set; }
        public string? UseDirectTargetAsAttachOwner { get; set; }
        public string? SpawnSecondaryOnElapsed { get; set; }
        public string? SpawnSecondaryOnCollision { get; set; }
        public string? EndOnCasterDeath { get; set; }
        public string? IgnoreTargetIfAtDeathsDoor { get; set; }
        public string? IgnoreTargetIfDead { get; set; }
        public string? UseCameraTargetLock { get; set; }
        public string? TrackNumInVolume { get; set; }
        public string? ClearOnExit { get; set; }
        public string? ClearOnEnd { get; set; }
        public string? ManaCost { get; set; }
        public bool? UseStatusEffectDuration { get; set; }
        public int? Duration { get; set; }
        public string? DurationScaling { get; set; }
        public string? Height { get; set; }
        public string? Length { get; set; }
        public double? Radius { get; set; }
        public string? InnerRadius { get; set; }
        public string? RadiusScaling { get; set; }
        public string? MaxRadiusScaling { get; set; }
        public double? CastDistance { get; set; }
        public string? CastHeight { get; set; }
        public string? CastRadius { get; set; }
        public string? ConeAngle { get; set; }
        public string? ConeWidth { get; set; }
        public double? ChannelTime { get; set; }
        public string? ChainDelayDuration { get; set; }
        public string? MaxChainNum { get; set; }
        public string? UseChainCasterPaperdoll { get; set; }
        public string? SpawnBeamCasterJoint { get; set; }
        public string? NumToSpawn { get; set; }
        public string? NumToSpawnBeforeFail { get; set; }
        public string? SpawnRate { get; set; }
        public string? SpawnAngle { get; set; }
        public string? SecondarySpellProjectileLaunchAngles { get; set; }
        public string? SecondaryProjectileLaunchMinZSpeeds { get; set; }
        public string? SecondaryProjectileLaunchMaxZSpeeds { get; set; }
        public double? SecondaryProjectileLaunchZOffset { get; set; }
        public bool? IgnoreRotationForSecondaryProjectileLaunchZSpd { get; set; }
        public string? ScaleWithCharacterBoundingBox { get; set; }
        public string? ScaleWithDynamicScale { get; set; }
        public string? TargetTypes { get; set; }
        public string? SpellTypes { get; set; }
        public string? CastingTypes { get; set; }
        public string? HitAiTarget { get; set; }
        public string? OverrideTargetForAiThreat { get; set; }
        public string? ShapeTypes { get; set; }
        public string? DamageType { get; set; }
        public string? CheckObstructions { get; set; }
        public bool? IgnoreOverheadCollision { get; set; }
        public string? IgnoreStructures { get; set; }
        public string? IgnoreSelf { get; set; }
        public bool? IsUnaffiliated { get; set; }
        public string? WeaponSlotOverride { get; set; }
        public string? RangedAttackProfile { get; set; }
        public string? RangedAttackName { get; set; }
        public string? FireJointName { get; set; }
        public string? ProjPosOffsetX { get; set; }
        public string? ProjPosOffsetY { get; set; }
        public string? ProjPosOffsetZ { get; set; }
        public string? ProjRotOffsetX { get; set; }
        public string? ProjRotOffsetY { get; set; }
        public string? ProjRotOffsetZ { get; set; }
        public string? CharRelPosOffsetX { get; set; }
        public string? CharRelPosOffsetY { get; set; }
        public string? CharRelPosOffsetZ { get; set; }
        public string? CharRelRotOffsetX { get; set; }
        public string? CharRelRotOffsetY { get; set; }
        public string? CharRelRotOffsetZ { get; set; }
        public string? ProjRaycastOrientation { get; set; }
        public string? BaseDamage { get; set; }
        public string? DamageTable { get; set; }
        public string? DamageTableRow { get; set; }
        public string? AbilityId { get; set; }
        public string? TargetAbilityCondition { get; set; }
        public string? BeamEffect { get; set; }
        public string? IndicatorVFX { get; set; }
        public string? SpellPrefabPath { get; set; }
        public string? SecondaryPrefabPath { get; set; }
        public string? SecondarySpellID { get; set; }
        public string? TertiaryPrefabPath { get; set; }
        public string? TertiarySpellID { get; set; }
        public string? AmmoSlot { get; set; }
        public string? SpawnSecondaryOnPassthrough { get; set; }
        public string? ItemType { get; set; }
    }
}