using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.NewWorld;
using Domain.Entities.NewWorld.AbilityData;
using Domain.Entities.NewWorld.AffixStatData;
using Domain.Entities.NewWorld.ConsumableItemDefinitions;
using Domain.Entities.NewWorld.DamageData;
using Domain.Entities.NewWorld.PerkBucketData;
using Domain.Entities.NewWorld.SpellData;
using Domain.Entities.NewWorld.StatusEffectData;
using Domain.Entities.NewWorld.WeaponItemDefinitions;
using Domain.Entities.NewWorld.PerkData;

namespace Infrastructure.Persistence.Configuration
{
    public class MasterItemDefinitionConfig : IEntityTypeConfiguration<MasterItemDefinition>
    {
        public void Configure(EntityTypeBuilder<MasterItemDefinition> builder)
        {
            builder.HasIndex(x => x.GearScoreOverride).IsUnique(false);
            builder.HasIndex(x => x.MasterName).IsUnique(false);
            builder.HasIndex(x => x.Tier).IsUnique(false);
            builder.HasIndex(x => x.ItemID).IsUnique(false);
            builder.ToTable("MasterItemDefinitions", SchemaNames.NewWorld);
        }
            
    }

    public class ItemPerkConfig : IEntityTypeConfiguration<ItemPerk>
    {
        public void Configure(EntityTypeBuilder<ItemPerk> builder) =>
            builder
                .ToTable("ItemPerks", SchemaNames.NewWorld);
    }

    public class LocalesConfig : IEntityTypeConfiguration<Locales>
    {
        public void Configure(EntityTypeBuilder<Locales> builder) =>
            builder
                .ToTable("Locales", SchemaNames.NewWorld);
    }

    public class AIAbilityTableConfig : IEntityTypeConfiguration<AIAbilityTable>
    {
        public void Configure(EntityTypeBuilder<AIAbilityTable> builder) =>
            builder
                .ToTable("AIAbilityTable", SchemaNames.NewWorld);
    }

    public class AttributeThresholdAbilityTableConfig : IEntityTypeConfiguration<AttributeThresholdAbilityTable>
    {
        public void Configure(EntityTypeBuilder<AttributeThresholdAbilityTable> builder) =>
            builder
                .ToTable("AttributeThresholdAbilityTable", SchemaNames.NewWorld);
    }

    public class BlunderbussAbilityTableConfig : IEntityTypeConfiguration<BlunderbussAbilityTable>
    {
        public void Configure(EntityTypeBuilder<BlunderbussAbilityTable> builder) =>
            builder
                .ToTable("BlunderbussAbilityTable", SchemaNames.NewWorld);
    }

    public class BowAbilityTableConfig : IEntityTypeConfiguration<BowAbilityTable>
    {
        public void Configure(EntityTypeBuilder<BowAbilityTable> builder) =>
            builder
                .ToTable("BowAbilityTable", SchemaNames.NewWorld);
    }

    public class FireMagicAbilityTableConfig : IEntityTypeConfiguration<FireMagicAbilityTable>
    {
        public void Configure(EntityTypeBuilder<FireMagicAbilityTable> builder) =>
            builder
                .ToTable("FireMagicAbilityTable", SchemaNames.NewWorld);
    }

    public class GlobalAbilityTableConfig : IEntityTypeConfiguration<GlobalAbilityTable>
    {
        public void Configure(EntityTypeBuilder<GlobalAbilityTable> builder) =>
            builder
                .ToTable("GlobalAbilityTable", SchemaNames.NewWorld);
    }

    public class GreatAxeAbilityTableConfig : IEntityTypeConfiguration<GreatAxeAbilityTable>
    {
        public void Configure(EntityTypeBuilder<GreatAxeAbilityTable> builder) =>
            builder
                .ToTable("GreatAxeAbilityTable", SchemaNames.NewWorld);
    }

    public class GreatswordAbilityTableConfig : IEntityTypeConfiguration<GreatswordAbilityTable>
    {
        public void Configure(EntityTypeBuilder<GreatswordAbilityTable> builder) =>
            builder
                .ToTable("GreatswordAbilityTable", SchemaNames.NewWorld);
    }

    public class HatchetAbilityTableConfig : IEntityTypeConfiguration<HatchetAbilityTable>
    {
        public void Configure(EntityTypeBuilder<HatchetAbilityTable> builder) =>
            builder
                .ToTable("HatchetAbilityTable", SchemaNames.NewWorld);
    }

    public class IceMagicAbilityTableConfig : IEntityTypeConfiguration<IceMagicAbilityTable>
    {
        public void Configure(EntityTypeBuilder<IceMagicAbilityTable> builder) =>
            builder
                .ToTable("IceMagicAbilityTable", SchemaNames.NewWorld);
    }

    public class LifeMagicAbilityTableConfig : IEntityTypeConfiguration<LifeMagicAbilityTable>
    {
        public void Configure(EntityTypeBuilder<LifeMagicAbilityTable> builder) =>
            builder
                .ToTable("LifeMagicAbilityTable", SchemaNames.NewWorld);
    }

    public class MusketAbilityTableConfig : IEntityTypeConfiguration<MusketAbilityTable>
    {
        public void Configure(EntityTypeBuilder<MusketAbilityTable> builder) =>
            builder
                .ToTable("MusketAbilityTable", SchemaNames.NewWorld);
    }

    public class RapierAbilityTableConfig : IEntityTypeConfiguration<RapierAbilityTable>
    {
        public void Configure(EntityTypeBuilder<RapierAbilityTable> builder) =>
            builder
                .ToTable("RapierAbilityTable", SchemaNames.NewWorld);
    }

    public class RuneAbilityTableConfig : IEntityTypeConfiguration<RuneAbilityTable>
    {
        public void Configure(EntityTypeBuilder<RuneAbilityTable> builder) =>
            builder
                .ToTable("RuneAbilityTable", SchemaNames.NewWorld);
    }

    public class SpearAbilityTableConfig : IEntityTypeConfiguration<SpearAbilityTable>
    {
        public void Configure(EntityTypeBuilder<SpearAbilityTable> builder) =>
            builder
                .ToTable("SpearAbilityTable", SchemaNames.NewWorld);
    }

    public class SwordAbilityTableConfig : IEntityTypeConfiguration<SwordAbilityTable>
    {
        public void Configure(EntityTypeBuilder<SwordAbilityTable> builder) =>
            builder
                .ToTable("SwordAbilityTable", SchemaNames.NewWorld);
    }

    public class VoidGauntletAbilityTableConfig : IEntityTypeConfiguration<VoidGauntletAbilityTable>
    {
        public void Configure(EntityTypeBuilder<VoidGauntletAbilityTable> builder) =>
            builder
                .ToTable("VoidGauntletAbilityTable", SchemaNames.NewWorld);
    }

    public class WarHammerAbilityTableConfig : IEntityTypeConfiguration<WarHammerAbilityTable>
    {
        public void Configure(EntityTypeBuilder<WarHammerAbilityTable> builder) =>
            builder
                .ToTable("WarHammerAbilityTable", SchemaNames.NewWorld);
    }

    public class AffixStatDataTableConfig : IEntityTypeConfiguration<AffixStatDataTable>
    {
        public void Configure(EntityTypeBuilder<AffixStatDataTable> builder) =>
            builder
                .ToTable("AffixStatDataTable", SchemaNames.NewWorld);
    }

    public class ConsumableItemDefinitionsConfig : IEntityTypeConfiguration<ConsumableItemDefinitions>
    {
        public void Configure(EntityTypeBuilder<ConsumableItemDefinitions> builder) =>
            builder
                .ToTable("ConsumableItemDefinitions", SchemaNames.NewWorld);
    }

    public class DamageTableConfig : IEntityTypeConfiguration<DamageTable>
    {
        public void Configure(EntityTypeBuilder<DamageTable> builder) =>
            builder
                .ToTable("DamageTable", SchemaNames.NewWorld);
    }

    public class PerkBucketsConfig : IEntityTypeConfiguration<PerkBuckets>
    {
        public void Configure(EntityTypeBuilder<PerkBuckets> builder)
        {
            builder
                .HasMany(x => x.Perks)
                .WithOne(x => x.PerkBuckets);

            builder
                .ToTable("PerkBuckets", SchemaNames.NewWorld);
        }

    }

    public class PerkBucketPerksConfig : IEntityTypeConfiguration<PerkBucketPerk>
    {
        public void Configure(EntityTypeBuilder<PerkBucketPerk> builder) =>
            builder
                .ToTable("PerkBucketPerks", SchemaNames.NewWorld);
    }

    public class SpellDataTable_GreatAxeConfig : IEntityTypeConfiguration<SpellDataTable>
    {
        public void Configure(EntityTypeBuilder<SpellDataTable> builder) =>
            builder
                .ToTable("SpellDataTable", SchemaNames.NewWorld);
    }

    public class StatusEffectsConfig : IEntityTypeConfiguration<StatusEffects>
    {
        public void Configure(EntityTypeBuilder<StatusEffects> builder) =>
            builder
                .ToTable("StatusEffects", SchemaNames.NewWorld);
    }

    public class WeaponItemDefinitionsConfig : IEntityTypeConfiguration<WeaponItemDefinitions>
    {
        public void Configure(EntityTypeBuilder<WeaponItemDefinitions> builder) =>
            builder
                .ToTable("WeaponItemDefinitions", SchemaNames.NewWorld);
    }
}
