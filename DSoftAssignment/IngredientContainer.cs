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

        //Empty constructor
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

        public Ingredient getIngredient(String name)
        {
            try
            {
                return IngredientDict[name];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
                return null;
            }

            //if (IngredientDict.TryGetValue(name, out value))
            //{
            //    Console.WriteLine("For key = \"tif\", value = {0}.", value);
            //}
            //else
            //{
            //    Console.WriteLine("Key = \"tif\" is not found.");
            //}
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
