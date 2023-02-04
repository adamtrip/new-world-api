﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.AffixStatData
{
    public class AffixStatDataDto
    {
        public Guid Id { get; set; }
        public string StatusID { get; set; }
        public double? BaseDamageModifier { get; set; }
        public bool? DisableDurabilityLoss { get; set; }
        public double? DurabilityMod { get; set; }
        public string AfflictionDamage { get; set; }
        public double? StaminaDamageModifier { get; set; }
        public string StaminaCostID { get; set; }
        public string StaminaCostMultiplier { get; set; }
        public string EffectDurationMultiplier { get; set; }
        public string EffectModMultiplier { get; set; }
        public double? UseCountMultiplier { get; set; }
        public double? Encumbrance { get; set; }
        public string AfflictionMultiplier { get; set; }
        public double? WeightMultiplier { get; set; }
        public double? GatheringEfficiency { get; set; }
        public string AppendToTooltip { get; set; }
        public string BaseDamageType { get; set; }
        public string DamageType { get; set; }
        public double? DamagePercentage { get; set; }
        public string AdditionalDamage { get; set; }
        public bool? IsAdditiveDamage { get; set; }
        public string StatusEffect { get; set; }
        public string HealMod { get; set; }
        public string HealthRate { get; set; }
        public double? MaxHealthMod { get; set; }
        public double? StaminaRate { get; set; }
        public double? MaxStaminaMod { get; set; }
        public double? ManaRate { get; set; }
        public double? MaxManaMod { get; set; }
        public string MoveSpeedMod { get; set; }
        public double? FastTravelEncumbranceMod { get; set; }
        public double? FishRarityRollModifier { get; set; }
        public string SummerFishRarityRollModifier { get; set; }
        public double? FishSizeRollModifier { get; set; }
        public double? MaxCastDistance { get; set; }
        public double? FishingLineStrength { get; set; }
        public string AttributeModifiers { get; set; }
        public double? MODConstitution { get; set; }
        public double? MODFocus { get; set; }
        public double? MODStrength { get; set; }
        public double? MODDexterity { get; set; }
        public double? MODIntelligence { get; set; }
        public string UseWeaponAttributeScaling { get; set; }
        public bool? PreferHigherScaling { get; set; }
        public int? ScalingStrength { get; set; }
        public int? ScalingDexterity { get; set; }
        public double? ScalingIntelligence { get; set; }
        public double? ScalingFocus { get; set; }
        public double? ABSStandard { get; set; }
        public double? ABSSiege { get; set; }
        public double? ABSStrike { get; set; }
        public double? ABSSlash { get; set; }
        public double? ABSThrust { get; set; }
        public double? ABSArcane { get; set; }
        public double? ABSIce { get; set; }
        public double? ABSNature { get; set; }
        public double? ABSFire { get; set; }
        public double? ABSLightning { get; set; }
        public double? ABSCorruption { get; set; }
        public string ABSVitalsCategory { get; set; }
        public double? RESBlight { get; set; }
        public double? RESCurse { get; set; }
        public double? RESPoison { get; set; }
        public double? BLAStandard { get; set; }
        public double? BLASiege { get; set; }
        public double? BLAStrike { get; set; }
        public double? BLASlash { get; set; }
        public double? BLAThrust { get; set; }
        public double? BLAArcane { get; set; }
        public double? BLAFire { get; set; }
        public string BLAIce { get; set; }
        public string BLANature { get; set; }
        public double? BLALightning { get; set; }
        public double? BLACorruption { get; set; }
        public double? ABAPoison { get; set; }
        public double? ABADisease { get; set; }
        public double? ABABleed { get; set; }
        public double? ABAFrostbite { get; set; }
        public double? ABACurse { get; set; }
        public string WKNStandard { get; set; }
        public string WKNSiege { get; set; }
        public string WKNStrike { get; set; }
        public string WKNSlash { get; set; }
        public string WKNThrust { get; set; }
        public string WKNArcane { get; set; }
        public string WKNFire { get; set; }
        public string WKNIce { get; set; }
        public string WKNNature { get; set; }
        public string WKNLightning { get; set; }
        public string WKNCorruption { get; set; }
        public string DMGStandard { get; set; }
        public string DMGSiege { get; set; }
        public double? DMGStrike { get; set; }
        public double? DMGSlash { get; set; }
        public double? DMGThrust { get; set; }
        public double? DMGArcane { get; set; }
        public double? DMGFire { get; set; }
        public double? DMGIce { get; set; }
        public double? DMGNature { get; set; }
        public double? DMGLightning { get; set; }
        public double? DMGCorruption { get; set; }
        public string DMGVitalsCategory { get; set; }
        public double? AFAPoison { get; set; }
        public string AFADisease { get; set; }
        public string AFABleed { get; set; }
        public string AFAFrostbite { get; set; }
        public double? AFACurse { get; set; }
        public double? AFABlight { get; set; }
        public string WeaponEffectType { get; set; }
        public int? MP_OpeningNotesPerfect { get; set; }
        public int? MP_IgnoreMissedNotes { get; set; }
        public int? MP_RakeReduction { get; set; }
        public double? MP_GroupXPBonus { get; set; }
        public double? MP_SoloXPBonus { get; set; }
        public double? MP_FinalNotePerfectXPBonus { get; set; }
    }
}