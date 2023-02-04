﻿using Newtonsoft.Json;

namespace Domain.Entities.NewWorld.WeaponItemDefinitions
{
    public class WeaponItemDefinitions : AuditableEntity, IAggregateRoot
    {
        public string WeaponID { get; set; }
        public string BaseWeaponID { get; set; }

        [JsonProperty("DEV Prio")]
        public int? DEVPrio { get; set; }
        public string PrimaryUse { get; set; }
        public string IconPath { get; set; }
        public int? MaxStackSize { get; set; }
        public string EquipType { get; set; }
        public string DamageStatMultiplier { get; set; }
        public string WeaponMasteryCategoryId { get; set; }
        public int? TierNumber { get; set; }
        public int? BaseDamage { get; set; }
        public double? CritChance { get; set; }
        public double? CritDamageMultiplier { get; set; }
        public int? BaseStaggerDamage { get; set; }
        public double? CritStaggerDamageMultiplier { get; set; }
        public string ReticleName { get; set; }
        public string ReticleTargetName { get; set; }
        public int? ReticleRayCastDistance { get; set; }
        public string AmmoType { get; set; }
        public int? MaxLoadedAmmo { get; set; }
        public double? AutoReloadAmmoSeconds { get; set; }
        public string AmmoMesh { get; set; }
        public string MannequinTag { get; set; }
        public string OffHandMannequinTag { get; set; }
        public string MeshOverride { get; set; }
        public string SkinOverride1 { get; set; }
        public string MaterialOverride1 { get; set; }
        public string SkinOverride2 { get; set; }
        public string MaterialOverride2 { get; set; }
        public string SkinOverride3 { get; set; }
        public string MaterialOverride3 { get; set; }
        public string SkinOverride4 { get; set; }
        public string MaterialOverride4 { get; set; }
        public string FireJoint { get; set; }
        public string DamageTableRow { get; set; }
        public string TooltipPrimaryAttackData { get; set; }
        public string TooltipAlternateAttackData { get; set; }
        public string AnimDbPath { get; set; }
        public string GatheringTypes { get; set; }
        public double? GatheringMultiplier { get; set; }
        public double? GatheringEfficiency { get; set; }
        public double? MinGatherEFF { get; set; }
        public double? MaxGatherEFF { get; set; }
        public string AudioPickup { get; set; }
        public string AudioPlace { get; set; }

        [JsonProperty("Primary Hand")]
        public string PrimaryHand { get; set; }
        public string EquipmentCategories { get; set; }
        public int? RequiredStrength { get; set; }
        public int? RequiredDexterity { get; set; }
        public int? RequiredIntelligence { get; set; }
        public int? RequiredFocus { get; set; }
        public double? ScalingStrength { get; set; }
        public double? ScalingDexterity { get; set; }
        public double? ScalingIntelligence { get; set; }
        public double? ScalingFocus { get; set; }
        public string Resistances { get; set; }
        public string Weaknesses { get; set; }
        public string StatBonuses { get; set; }
        public string StatMultipliers { get; set; }
        public string EquipmentCategoryMultiplier { get; set; }
        public string AttackGameEventID { get; set; }
        public double? PhysicalArmorSetScaleFactor { get; set; }
        public double? ElementalArmorSetScaleFactor { get; set; }
        public double? ArmorRatingScaleFactor { get; set; }
        public double? WeightOverride { get; set; }
        public int? BlockStaminaDamage { get; set; }
        public int? BlockStability { get; set; }
        public int? DeflectionRating { get; set; }
        public string BLAStandard { get; set; }
        public double? BLASiege { get; set; }
        public double? BLAStrike { get; set; }
        public double? BLASlash { get; set; }
        public double? BLAThrust { get; set; }
        public double? BLAArcane { get; set; }
        public double? BLAFire { get; set; }
        public double? BLAIce { get; set; }
        public double? BLANature { get; set; }
        public double? BLALightning { get; set; }
        public double? BLACorruption { get; set; }
        public double? ABAPoison { get; set; }
        public double? ABADisease { get; set; }
        public double? ABABleed { get; set; }
        public double? ABAFrostbite { get; set; }
        public double? ABACurse { get; set; }
        public string RangedAttackProfile { get; set; }
        public string AttachedSpellData { get; set; }
        public string Appearance { get; set; }
        public string FemaleAppearance { get; set; }
        public bool? CanBlockRanged { get; set; }
        public string ManaCostId { get; set; }
        public string WeaponEffectId { get; set; }
        public int? BaseAccuracy { get; set; }
        public string SoundTableID { get; set; }
    }
}
