using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSoftAssignment.Tests
{
    [TestClass]
    public class CalculationsTest
    {
        Recipe testRecipe;
        [TestInitialize]
        public void TestInitialize()
        {
            testRecipe = new Recipe();
            Ingredient ingred1 = new Ingredient("garlic", IngredientType.Produce, 0.67m, true);
            Ingredient ingred2 = new Ingredient("chicken breast", IngredientType.Meat, 2.19m, false);
            Ingredient ingred3 = new Ingredient("vinegar", IngredientType.Pantry, 1.26m, false);
            Ingredient ingred4 = new Ingredient("olive oil", IngredientType.Pantry, 1.92m, true);
            RecipeIngredient recipeIngred1 = new RecipeIngredient(ingred1, 1);
            RecipeIngredient recipeIngred2 = new RecipeIngredient(ingred2, 4);
            RecipeIngredient recipeIngred3 = new RecipeIngredient(ingred3, 0.5m);
            RecipeIngredient recipeIngred4 = new RecipeIngredient(ingred4, 0.5m);

            testRecipe.addRecipeIngredient(recipeIngred1);
            testRecipe.addRecipeIngredient(recipeIngred2);
            testRecipe.addRecipeIngredient(recipeIngred3);
            testRecipe.addRecipeIngredient(recipeIngred4);
        }
        [TestMethod]
        public void CalculateSalesTaxTest()
        {
            Decimal answer = 0;

            answer = testRecipe.calculateSalesTax();

            Assert.AreEqual(0.91m, answer);
        }

        [TestMethod]
        public void CalculateDiscountTest()
        {
            Decimal answer = 0;

            answer = testRecipe.calculateDiscount();

            Assert.AreEqual(0.09m, Math.Round(answer, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod]
        public void CalculateRawTotalCostTest()
        {
            Decimal answer = 0;

            answer = testRecipe.calculateRawTotalCost();

            Assert.AreEqual(11.02m, Math.Round(answer, 2, MidpointRounding.AwayFromZero));
        }
    }
}
