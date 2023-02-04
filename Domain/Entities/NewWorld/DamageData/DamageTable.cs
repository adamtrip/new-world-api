using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.DamageData
{
    public class DamageTable : AuditableEntity, IAggregateRoot
    {
        public string DamageID { get; set; }
        public string WeaponCategory { get; set; }
        public int? IgnoreInvulnerable { get; set; }
        public int? NoReaction { get; set; }
        public bool? IsRanged { get; set; }
        public bool? IsAbility { get; set; }
        public string AttackType { get; set; }
        public string DamageType { get; set; }
        public string Affliction { get; set; }
        public int? AddAffliction { get; set; }
        public string AfflictionPercent { get; set; }
        public string StatusEffect { get; set; }
        public string EffectOnlyOnDamage { get; set; }
        public string SurfaceImpactEffect { get; set; }
        public string DeflectDamageID { get; set; }
        public bool? CanCrit { get; set; }
        public bool? Unblockable { get; set; }
        public bool? AttackDealsNoDurability { get; set; }
        public bool? NoHeadshot { get; set; }
        public bool? NoBackstab { get; set; }
        public bool? NoLegShots { get; set; }
        public bool? CancelTargetHoming { get; set; }
        public double? DmgCoef { get; set; }
        public double? DmgCoefHead { get; set; }
        public double? DmgCoefCrit { get; set; }
        public int? DurabilityCostOverride { get; set; }
        public int? PowerLevel { get; set; }
        public int? BlockPowerLevel { get; set; }
        public int? CritPowerLevel { get; set; }
        public int? HitStun { get; set; }
        public int? BlockHitStun { get; set; }
        public int? CritHitStun { get; set; }
        public int? ImpactDistanceX { get; set; }
        public double? ImpactDistanceY { get; set; }
        public int? ImpactDistanceZ { get; set; }
        public double? ImpactDecayRate { get; set; }
        public int? BlockImpactDistanceX { get; set; }
        public double? BlockImpactDistanceY { get; set; }
        public int? BlockImpactDistanceZ { get; set; }
        public double? BlockImpactDecayRate { get; set; }
        public int? CritImpactDistanceX { get; set; }
        public double? CritImpactDistanceY { get; set; }
        public int? CritImpactDistanceZ { get; set; }
        public double? CritImpactDecayRate { get; set; }
        public double? AddDmg { get; set; }
        public double? StaggerDmgModifier { get; set; }
        public double? StaggerResistModifier { get; set; }
        public int? CritStaggerDmgModifier { get; set; }
        public double? HitRateDmgModifier { get; set; }
        public double? MaxHitRateDmgMod { get; set; }
        public string CameraShakeID { get; set; }
        public string TargetCameraShakeID { get; set; }
        public string BlockCameraShakeID { get; set; }
        public string BlockTargetCameraShakeID { get; set; }
        public string CritCameraShakeID { get; set; }
        public string CritTargetCameraShakeID { get; set; }
        public int? ImpactRating { get; set; }
        public double? BlockStaminaDmgMod { get; set; }
        public double? BlockAbsorptionModifier { get; set; }
        public int? LOSCheckVerticalAngleOffset { get; set; }
        public int? StunBreakoutIncrement { get; set; }
        public double? ThreatMultiplier { get; set; }
        public int? AddThreat { get; set; }
        public bool? IsTaunt { get; set; }
        public int? TauntDuration { get; set; }
        public double? TauntThreatBoostPercentage { get; set; }
        public int? TauntMinimumThreatValue { get; set; }
        public bool? UseAttackerPosForReaction { get; set; }
        public double? AttackRuneCharge { get; set; }
        public double? AttackBlockedRuneCharge { get; set; }
        public double? HitRuneCharge { get; set; }
        public double? HitBlockedRuneCharge { get; set; }
    }
}
