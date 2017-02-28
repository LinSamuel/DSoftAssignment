using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSoftAssignment.Tests
{
    [TestClass]
    public class ParseHandlerTest
    {
        

        [TestMethod]
        public void ValidIngredientStringParseSuccess()
        {
            // Arrange
            string input = "- 1 clove of organic garlic = $0.67";
            IngredientType ingredType = IngredientType.Produce;
            Ingredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseIngredientLine(input, ingredType);

            // Assert
            Assert.IsNotNull(theIngredient);
            Assert.IsTrue(theIngredient.getIsOrganic());
            Assert.IsTrue(theIngredient.getIsProduce());
            Assert.AreEqual(theIngredient.getName(), "garlic");
            Assert.AreEqual(theIngredient.getCost(), 0.67m);
        }

        [TestMethod]
        public void ValidIngredientStringParseSuccessPantry()
        {
            // Arrange
            string input = "- 1 teaspoon of salt = $0.16";
            IngredientType ingredType = IngredientType.Pantry;
            Ingredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseIngredientLine(input, ingredType);

            // Assert
            Assert.IsNotNull(theIngredient);
            Assert.IsFalse(theIngredient.getIsOrganic());
            Assert.IsFalse(theIngredient.getIsProduce());
            Assert.AreEqual(theIngredient.getName(), "salt");
            Assert.AreEqual(theIngredient.getCost(), 0.16m);
        }

        [TestMethod]
        public void EmptyIngredientStringParseFail()
        {
            // Arrange
            string input = "";
            IngredientType ingredType = IngredientType.Produce;
            Ingredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseIngredientLine(input, ingredType);

            // Assert
            Assert.IsNull(theIngredient);
        }

        [TestMethod]
        public void InvalidInputStringParseFail()
        {
            // Arrange
            string input = "!@#$%^&";
            IngredientType ingredType = IngredientType.Produce;
            Ingredient theIngredient;
            // Act

            theIngredient = ParseHandler.parseIngredientLine(input, ingredType);

            // Assert
            Assert.IsNull(theIngredient);
        }

        
    }
}
