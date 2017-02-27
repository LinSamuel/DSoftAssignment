using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    class Recipe
    {
        string name = "";
        List<RecipeIngredient> ingredientList = new List<RecipeIngredient>();

        public Recipe()
        {

        }

        public Recipe(string name)
        {
            if (name != null)
            {
                this.name = name;
            }
        }

        public void addRecipeIngredient(RecipeIngredient ingredient)
        {
            if (ingredient != null)
            {
                ingredientList.Add(ingredient);
            }
        }
        
    }
}
