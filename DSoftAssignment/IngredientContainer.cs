using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    /*
     * Class representing an IngredientContainer, a wrapper around a dictionary that have ingredient string name keys
     * and Ingredient values. Used when trying to extract information when building recipes
     * 
     * */
    public class IngredientContainer
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

        // Returns the Keys (the names of the ingredients) of the dictionary (for findIngredient function in ParseHandler)
        public Dictionary<string, Ingredient>.KeyCollection getContainerKeys()
        {
            return this.IngredientDict.Keys;
        }

        //Getters
        public Ingredient getIngredient(String name)
        {
            try
            {
                return IngredientDict[name];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }

        }
    }
}
