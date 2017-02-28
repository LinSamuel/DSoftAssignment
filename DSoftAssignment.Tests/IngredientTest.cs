using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSoftAssignment.Tests
{
    [TestClass]
    public class IngredientTest
    {
        [TestMethod]
        public void IngredientSuccessfullyMade()
        {
            // Arrange
            string name = "garlic";
            IngredientType type = IngredientType.Produce;
            Decimal cost = 0.67m;
            Boolean isOrganic = true;
            Ingredient temp = new Ingredient(name, type, cost, isOrganic);

            // Act
            

            // Assert
        }
    }
}
