using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    /*
     * Main program that holds the entry point for this assigment
     * */
    class CostCalculator
    {
        string[] fileInput = new string[]{};

        /**
        * Function gets input from file
        */
        public static string[] getInput()
        {
            GetCurrDirectoryClass helper = new GetCurrDirectoryClass();
            string theDirectory = helper.getCurrDirectory();
            return System.IO.File.ReadAllLines(theDirectory + @"\input.txt");
        }
        static void Main(string[] args)
        {
            /* Assumption: Input is organized in the following format, ingredients first, then recipes:
             * 
             * "Ingredients" header
             * 
             * Ingredient category (Either Product, Meat/poultry, and Pantry)
             * 
             * Unit of ingredient = Corresponding Price
             * (e.g. - 1 clove of organic garlic = $0.67)
             * 
             * "Recipe Headers"
             * List of ingredients for the recipe underneath
             * (e.g. - 3/4 cup olive oil)
             * 
             * */

            //Holds the lines from the input.txt file
            string[] fileLines;
            
            try {
                fileLines = getInput();
            }
            catch (Exception)
            {
                Console.WriteLine("Can not find input.txt file, program will close now.");
                Console.ReadKey();
                return;
            }
            IngredientContainer ingredientContainer = new IngredientContainer();

            // Boolean flag signifying if the input has reached the recipe portion (the latter half)
            Boolean recipeSection = false;

            //Boolean flag representing on whether or not the beginning of a new recipe has started
            Boolean newRecipe = false;

            //Variable representing the current ingredient type being read in as input, initialize with 'other' placeholder
            IngredientType currentType = IngredientType.Other;

            // Recipe placeholder for the current recipe being populated
            Recipe currRecipe = new Recipe();
            string currRecipeName = "";
            int counter = 0; //Counter variable to keep track of the amount of lines already iterated, used to check if the last line is currently being processed

            // Read each line read from the file
            foreach (string line in fileLines)
            {
                counter++;
                // Assumption, Ingredients first
                if (!recipeSection)
                {                    
                    if (line.Equals("Produce"))
                    {
                        currentType = IngredientType.Produce;
                        continue;
                    }
                    else if (line.Equals("Meat/poultry"))
                    {
                        currentType = IngredientType.Meat;
                        continue;
                    }
                    else if (line.Equals("Pantry"))
                    {
                        currentType = IngredientType.Pantry;
                        continue;
                    }

                    // Assumption: if the line starts with a '-' character, it is a valid ingredient description line

                    if (!currentType.Equals(IngredientType.Other) && line.Length > 0 && line[0] == '-')
                    {
                        //Console.WriteLine("\n" + line);

                        //Add valid ingredients into the IngredientContainer
                        Ingredient newIngredient = ParseHandler.parseIngredientLine(line, currentType);
                        if (newIngredient != null)
                        {
                            ingredientContainer.addIngredient(newIngredient);
                        }                      

                    }
                    //Recipe section has been reached, start processing recipes
                    if (line.Length > 0 && line.Split()[0].Equals("Recipe"))
                    {
                        recipeSection = true;
                        newRecipe = true;
                        currRecipeName = line.Trim();
                    }
                }
                else 
                {   // Start processing recipes
                    if (newRecipe)
                    {
                        currRecipe = new Recipe(currRecipeName);
                        newRecipe = false;
                    }
                    // New recipe detected, start a new recipe
                    if (line.Length > 0 && line.Split()[0].Equals("Recipe"))
                    {
                        //Console.WriteLine("\n New recipe: " + line);
                        recipeSection = true;
                        newRecipe = true;
                        currRecipeName = line.Trim();

                        // Print recipe stats here
                        currRecipe.calculateStats();
                    }
                    RecipeIngredient currRecipeIngredient = ParseHandler.parseRecipeLine(line, ingredientContainer);

                    if (currRecipeIngredient != null)
                    {
                        //Console.WriteLine("adding " + currRecipeIngredient.getIngredient().getName());
                        currRecipe.addRecipeIngredient(currRecipeIngredient);
                    }
                    //If it's the last line processed, then it's the last line for the last recipe as well, so print recipe's cost statistics
                    if (counter == (fileLines.Length))
                    {
                        currRecipe.calculateStats();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
