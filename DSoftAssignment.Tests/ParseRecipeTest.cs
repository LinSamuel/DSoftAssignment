using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSoftAssignment.Tests
{
    [TestClass]
    public class ParseRecipeTest
    {
        IngredientContainer testContainer;
        [TestInitialize]
        public void TestInitialize()
        {
            testContainer = new IngredientContainer();
            Ingredient ingred1 = new Ingredient("garlic", IngredientType.Produce, 0.67m, true);
            Ingredient ingred2 = new Ingredient("lemon", IngredientType.Produce, 2.03m, false);
            Ingredient ingred3 = new Ingredient("corn", IngredientType.Produce, 0.87m, false);
            Ingredient ingred4 = new Ingredient("olive oil", IngredientType.Pantry, 1.92m, true);
            Ingredient ingred5 = new Ingredient("salt", IngredientType.Pantry, 0.16m, false);
            Ingredient ingred6 = new Ingredient("pepper", IngredientType.Pantry, 0.17m, false);
            testContainer.addIngredient(ingred1);
            testContainer.addIngredient(ingred2);
            testContainer.addIngredient(ingred3);
            testContainer.addIngredient(ingred4);
            testContainer.addIngredient(ingred5);
            testContainer.addIngredient(ingred6);
        }

        [TestMethod]
        public void ValidRecipeStringParseSuccess()
        {
            // Arrange
            string input = "- 3/4 cup olive oil";
            RecipeIngredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseRecipeLine(input, testContainer);
            
            // Assert
            Assert.IsNotNull(theIngredient);
            Assert.IsTrue(theIngredient.getIngredient().getIsOrganic());
            Assert.IsFalse(theIngredient.getIngredient().getIsProduce());
            Assert.AreEqual(theIngredient.getIngredient().getName(), "olive oil");
            Assert.AreEqual(theIngredient.getAmount(), 0.75m);
        }


        [TestMethod]
        public void EmptyRecipeStringParseFail()
        {
            // Arrange
            string input = "";
            IngredientType ingredType = IngredientType.Produce;
            RecipeIngredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseRecipeLine(input, testContainer);

            // Assert
            Assert.IsNull(theIngredient);
        }

        [TestMethod]
        public void InvalidInputRecipeStringParseFail()
        {
            // Arrange
            string input = "!@#$%^&";
            IngredientType ingredType = IngredientType.Produce;
            RecipeIngredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseRecipeLine(input, testContainer);

            // Assert
            Assert.IsNull(theIngredient);
        }

        [TestMethod]
        public void FindIngredientInContainerTest()
        {
            string input = "- 1/2 cup olive oil";
            Ingredient returnedIngredient;

            returnedIngredient = ParseHandler.findIngredient(input, testContainer);

            Assert.IsNotNull(returnedIngredient);
            Assert.IsTrue(returnedIngredient.getIsOrganic());
            Assert.IsFalse(returnedIngredient.getIsProduce());
            Assert.AreEqual(returnedIngredient.getName(), "olive oil");
        }

        [TestMethod]
        public void FindFakeIngredientInContainerFail()
        {
            string input = "fake ingredient";
            Ingredient returnedIngredient;

            returnedIngredient = ParseHandler.findIngredient(input, testContainer);

            Assert.IsNull(returnedIngredient);
        }

        [TestMethod]
        public void ParseNumberCorrectly()
        {
            string input = "4";
            double answer = -1;

            answer = ParseHandler.measurementConversion(input);

            Assert.AreEqual(answer, 4);
        }

        [TestMethod]
        public void ParseFractionCorrectly()
        {
            string input = "3/4";
            double answer = -1;

            answer = ParseHandler.measurementConversion(input);

            Assert.AreEqual(answer, 0.75);
        }

        [TestMethod]
        public void ParseNumberAndFractionCorrectly()
        {
            string input = "4 1/4";
            double answer = -1;

            answer = ParseHandler.measurementConversion(input);

            Assert.AreEqual(answer, 4.25);
        }


    }
}
