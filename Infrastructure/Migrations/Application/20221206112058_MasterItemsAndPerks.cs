using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Application
{
    /// <inheritdoc />
    public partial class MasterItemsAndPerks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NewWorld");

            migrationBuilder.CreateTable(
                name: "ItemPerks",
                schema: "NewWorld",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerkID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PerkType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConditionEvent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcludeItemClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Channel = table.Column<int>(type: "int", nullable: true),
                    ExclusiveLabels = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeprecatedPerkId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ScalingPerGearScore = table.Column<double>(type: "float", maxLength: 50, nullable: true),
                    ItemClassGSBonus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Tier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExcludeFromTradingPost = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppliedPrefix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AppliedSuffix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NamePriority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Affix = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EquipAbility = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DayPhases = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FishingWaterType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TerritoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CombatStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WeaponTag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MasterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPerks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterItemDefinitions",
                schema: "NewWorld",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemType = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ItemTypeDisplayName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ItemClass = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    TradingCategory = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    TradingFamily = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    TradingGroup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    BindOnPickup = table.Column<int>(type: "int", maxLength: 25, nullable: true),
                    BindOnEquip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GearScoreOverride = table.Column<int>(type: "int", nullable: true),
                    MinGearScore = table.Column<int>(type: "int", nullable: true),
                    MaxGearScore = table.Column<int>(type: "int", nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: true),
                    ItemStatsRef = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    GrantsHWMBump = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IgnoreNameChanges = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IgnoreHWMScaling = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CanHavePerks = table.Column<int>(type: "int", nullable: true),
                    CanReplaceGem = table.Column<int>(type: "int", nullable: true),
                    Perk1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Perk2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Perk3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Perk4 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Perk5 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PerkBucket1 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PerkBucket2 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PerkBucket3 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PerkBucket4 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    PerkBucket5 = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ForceRarity = table.Column<int>(type: "int", nullable: true),
                    RequiredLevel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UseTypeAffix = table.Column<int>(type: "int", nullable: true),
                    UseMaterialAffix = table.Column<int>(type: "int", nullable: true),
                    UseMagicAffix = table.Column<int>(type: "int", nullable: true),
                    IconCaptureGroup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    UiItemClass = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ArmorAppearanceM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ArmorAppearanceF = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    WeaponAppearanceOverride = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ConfirmDestroy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ConfirmBeforeUse = table.Column<int>(type: "int", nullable: true),
                    ConsumeOnUse = table.Column<int>(type: "int", nullable: true),
                    PrefabPath = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    HousingTags = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HiResIconPath = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MaxStackSize = table.Column<int>(type: "int", nullable: true),
                    DeathDropPercentage = table.Column<int>(type: "int", nullable: true),
                    Nonremovable = table.Column<int>(type: "int", nullable: true),
                    IsMissionItem = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsUniqueItem = table.Column<int>(type: "int", nullable: true),
                    IsRequiredItem = table.Column<int>(type: "int", nullable: true),
                    ContainerLevel = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ContainerGS = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ExceedMinIndex = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ExceedMaxIndex = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IsSalvageable = table.Column<int>(type: "int", nullable: true),
                    SalvageResources = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsRepairable = table.Column<int>(type: "int", nullable: true),
                    RepairDustModifier = table.Column<double>(type: "float", nullable: true),
                    RepairRecipe = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    CraftingRecipe = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RepairGameEventID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SalvageGameEventID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SalvageAchievement = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RepairTypes = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IngredientCategories = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IngredientBonusPrimary = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IngredientBonusSecondary = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IngredientGearScoreBaseBonus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IngredientGearScoreMaxBonus = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ExtraBonusItemChance = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Durability = table.Column<int>(type: "int", nullable: true),
                    DurabilityDmgOnDeath = table.Column<double>(type: "float", nullable: true),
                    DestroyOnBreak = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    AcquisitionNotificationId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AudioPickup = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AudioPlace = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AudioUse = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AudioCreated = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AudioDestroyed = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MannequinTag = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SoundTableID = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    WarboardGatherStat = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    WarboardDepositStat = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HideInLootTicker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalvageLootTags = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    EventId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AttributionId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    HeartgemRuneTooltipTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    HeartgemTooltipBackgroundImage = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    HideFromRewardOpenPopup = table.Column<int>(type: "int", nullable: true),
                    SalvageEntitlementId = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ParentItemIdDVT = table.Column<string>(name: "ParentItemId_DVT", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    IgnoreParentColumnsDVT = table.Column<string>(name: "IgnoreParentColumns_DVT", type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MasterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDepricated = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterItemDefinitions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPerks",
                schema: "NewWorld");

            migrationBuilder.DropTable(
                name: "MasterItemDefinitions",
                schema: "NewWorld");
        }
    }
}
