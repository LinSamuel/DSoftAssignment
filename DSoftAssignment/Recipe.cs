using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    class Recipe
    {
        List<Ingredient> ingredientList = new List<Ingredient>();

        public Recipe()
        {

        }

        public void addRecipeIngredient(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                ingredientList.Add(ingredient);
            }
        }
        
    }
}
