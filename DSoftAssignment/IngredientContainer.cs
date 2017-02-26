using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    class IngredientContainer
    {
        //Dictionary with Ingredient name string keys and Ingredient Object values
        Dictionary<String, Ingredient> IngredientDict = new Dictionary<String, Ingredient>();


        public IngredientContainer()
        {

        }

        public void addIngredient(Ingredient theIngredient)
        {
            //Only add ingredient to dictionary if it doesn't already exist, won't overwrite if ingredient already exists
            if (!IngredientDict.ContainsKey(theIngredient.getName()))
            {
                IngredientDict.Add(theIngredient.getName(), theIngredient);
                
            }
        }

        public void printDict()
        {
            foreach (KeyValuePair<string, Ingredient> kvp in this.IngredientDict)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }
        }
    }
}
