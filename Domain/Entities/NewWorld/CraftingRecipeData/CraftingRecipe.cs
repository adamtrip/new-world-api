using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.CraftingRecipeData
{
    public class CraftingRecipe : AuditableEntity, IAggregateRoot
    {
        [MaxLength(50)]
        public string? RecipeID { get; set; }

        [MaxLength(50)]
        public string? FirstCraftAchievementId { get; set; }

        [MaxLength(50)]
        public string? RecipeNameOverride { get; set; }

        [MaxLength(50)]
        public string? CraftingCategory { get; set; }

        [MaxLength(50)]
        public string? CraftingGroup { get; set; }

        [MaxLength(50)]
        public string? AdditionalFilterText { get; set; }

        [MaxLength(50)]
        public string? RecipeTags { get; set; }

        [MaxLength(50)]
        public string? DisplayIngredients { get; set; }
        public bool? bKnownByDefault { get; set; }
        public bool? bListedByDefault { get; set; }
        public bool? CraftAll { get; set; }
        public bool? IsRefining { get; set; }
        public bool? IsProcedural { get; set; }

        [MaxLength(50)]
        public string? MaxPerkItemsAllowed { get; set; }

        [MaxLength(50)]
        public string? PerkItemsBucketPush { get; set; }

        [MaxLength(50)]
        public string? ExpertiseBumpChanceOverride { get; set; }

        [MaxLength(50)]
        public string? IsExpertiseBasedGS { get; set; }

        [MaxLength(50)]
        public string? HWMProgressionID { get; set; }

        [MaxLength(50)]
        public bool? IsTemporary { get; set; }
        public int? CraftingFee { get; set; }
        public int? UseCraftingTax { get; set; }

        [MaxLength(50)]
        public string? Tradeskill { get; set; }
        public int? RecipeLevel { get; set; }

        [MaxLength(50)]
        public string? StationType1 { get; set; }

        [MaxLength(50)]
        public string? StationType2 { get; set; }

        [MaxLength(50)]
        public string? StationType3 { get; set; }

        [MaxLength(50)]
        public string? StationType4 { get; set; }
        public int? CraftingTime { get; set; }
        public int? OutputQty { get; set; }

        [MaxLength(50)]
        public string? ItemID { get; set; }

        [MaxLength(50)]
        public string? SkipGrantItems { get; set; }

        [MaxLength(50)]
        public string? SkipGrantItemsDesc { get; set; }

        [MaxLength(50)]
        public string? SkipGrantItemsTitle { get; set; }

        [MaxLength(50)]
        public string? SkipGrantItemsBody { get; set; }
        public int? BaseGearScore { get; set; }
        public int? BaseTier { get; set; }

        [MaxLength(50)]
        public string? ProceduralTierID1 { get; set; }

        [MaxLength(50)]
        public string? ProceduralTierID2 { get; set; }

        [MaxLength(50)]
        public string? ProceduralTierID3 { get; set; }

        [MaxLength(50)]
        public string? ProceduralTierID4 { get; set; }

        [MaxLength(50)]
        public string? ProceduralTierID5 { get; set; }

        [MaxLength(50)]
        public string? RequiredAchievementID { get; set; }
        public string? UnlockedAchievementID { get; set; }
        public string? UnlockedAchievementBlocksRecrafting { get; set; }
        public string? Ingredient1 { get; set; }
        public string? Type1 { get; set; }
        public string? Ingredient2 { get; set; }
        public string? Type2 { get; set; }
        public string? Ingredient3 { get; set; }
        public string? Type3 { get; set; }
        public string? Ingredient4 { get; set; }
        public string? Type4 { get; set; }
        public string? Ingredient5 { get; set; }
        public string? Type5 { get; set; }
        public string? Ingredient6 { get; set; }
        public string? Type6 { get; set; }
        public string? Ingredient7 { get; set; }
        public string? Type7 { get; set; }
        public int? Qty1 { get; set; }
        public int? Qty2 { get; set; }
        public int? Qty3 { get; set; }
        public int? Qty4 { get; set; }
        public string? Qty5 { get; set; }
        public string? Qty6 { get; set; }
        public string? Qty7 { get; set; }
        public string? GameEventID { get; set; }
        public bool? GameEventValidation { get; set; }
        public string? CooldownSeconds { get; set; }
        public string? CooldownQuantity { get; set; }
        public string? GearScoreBonus { get; set; }
        public string? GearScoreReduction { get; set; }
        public string? BonusItemChance { get; set; }
        public string? BonusItemChanceIncrease { get; set; }
        public string? BonusItemChanceDecrease { get; set; }
        public int? AttributeCost { get; set; }
        public int? PerkCost { get; set; }
        public int? GemSlotCost { get; set; }
        public string? IconPath { get; set; }

        public string MasterName { get; set; }
        public string MasterDescription { get; set; }
    }
}
