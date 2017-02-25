using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{

    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\sam\Documents\Visual Studio 2013\Projects\DSoftAssignment\input.txt");

            // Display the file contents to the console. Variable text is a string.
            // System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            /* Assumption: Input is organized in the following format:
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



            string[] fileLines = System.IO.File.ReadAllLines(@"C:\Users\sam\Documents\Visual Studio 2013\Projects\DSoftAssignment\input.txt");

            // Boolean flag signifying if the input has reached the recipe portion (the latter half)
            Boolean recipeSection = false;
            IngredientType currentType;
            //Read each line read from the file
            foreach (string line in fileLines)
            {
                // Assumption, Ingredients first
                if (!recipeSection)
                {
                    if (line.Equals("Produce"))
                    {
                        currentType = IngredientType.Produce;
                    }
                    else if (line.Equals("Meat/poultry"))
                    {
                        currentType = IngredientType.Meat;
                    }
                    else if (line.Equals("Pantry"))
                    {
                        currentType = IngredientType.Pantry;
                    }

                    // Assumption: if the line starts with a '-' character, it is a valid ingredient description line

                    if (line.Length > 0 && line[0] == '-')
                    {
                        Console.WriteLine("\n" + line);
                        
                        /*  Make a decription string array
                         *  Example strings: 1 cup of organic olive oil = $1.92, 1 chicken breast = $2.19
                         *  - The first character will always be a single unit for that particular ingredient
                         *  - Next character will either be:
                         *      - A unit of measurement, in which case, continue
                         *      - Not a unit of measurement, in which case the rest of the string describes the name of the ingredient
                         *  - Ignore 'of'
                         *  - Check if 'organic' is in the string
                         *  
                         * 
                         * /
                        //IngredientContainer newIngredient = new IngredientContainer()
                    }

                    //Recipe section has been reached, start processing recipes
                    if (line.Length > 0 && line.Split()[0].Equals("Recipe"))
                    {
                        Console.WriteLine("\n" + line);
                        recipeSection = true;
                    }
                }
                else 
                {   // Start processing recipes
                    Console.WriteLine(":D");
                }

                

            }

            Console.ReadKey();
        }
    }
}
