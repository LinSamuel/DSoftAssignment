using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    // Class that respresents a recipe ingredient. It holds 2 attributes, the ingredient name, and the quantity of the respective ingredient
    class RecipeIngredient
    {
        private Ingredient ingredient;
        private Decimal amount;

        public RecipeIngredient(Ingredient ingredient, Decimal amount)
        {
            this.ingredient = ingredient;
            this.amount = amount;
        }

        public Ingredient getIngredient()
        {
            return this.ingredient;
        }

        public Decimal getAmount()
        {
            return this.amount;
        }
    }
}
