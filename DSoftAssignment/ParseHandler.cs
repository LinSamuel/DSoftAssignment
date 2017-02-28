using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DSoftAssignment
{

    /*
     * ParseHandler class parses input strings and returns a corresponding ingredient or recipe object 
     * */

    public class ParseHandler
    {
        /*  Make a decription string array
         *  Example strings: 1 cup of organic olive oil = $1.92, 1 chicken breast = $2.19
         *  - The first character will always be a single unit for that particular ingredient
         *  - Next character will either be:
         *      - A unit of measurement, in which case, continue (can safely ignore, assuming units of measurements will be consistent)
         *      - Not a unit of measurement, in which case the rest of the string describes the name of the ingredient
         *  - Ignore 'of'
         *  - Check if 'organic' is in the string
         *  
         * */

        public static Ingredient parseIngredientLine(string input, IngredientType currentType)
        {
            // If input is empty, return null, or if the first character in the line 
            // is not a '- character, it is considered error
            if (input.Length == 0 || input[0] != '-')
            {
                return null;
            }

            // Input is split by whitespace
            // - 1 clove of organic garlic = $0.67 --> [ - , 1 , clove , of , organic , garlic , = , $0.67]
            string[] splitByWhiteSpace = input.Split();

            string[] nameAndPrice;
            string nameAndPriceString;

            // If there is 'of' present in input, the following strings represent the ingredient name and price
            int ofIndex = Array.IndexOf(splitByWhiteSpace, "of");
            if ( ofIndex > -1)
            {
                // string manipulation logic to extact the name and price
                nameAndPrice = new string[splitByWhiteSpace.Length - ofIndex - 1];
                Array.Copy(splitByWhiteSpace, ofIndex + 1, nameAndPrice, 0, nameAndPrice.Length);
                nameAndPriceString = String.Join(" ", nameAndPrice);
            } else {
                nameAndPrice = new string[splitByWhiteSpace.Length - 2];
                Array.Copy(splitByWhiteSpace, 2, nameAndPrice, 0, nameAndPrice.Length);
                nameAndPriceString = String.Join(" ", nameAndPrice);
            }
            string[] priceArray = nameAndPriceString.Split('=');
            string ExtractedPrice = "";
            string IngredientName = "";
            Boolean isOrganic = false;
            Decimal IngredientPrice = 0;
            if (priceArray.Length > 0)
            {
                //Extract Name (NOTE: check if capitals matter)
                IngredientName = priceArray[0];
                if (IngredientName.Contains("organic"))
                {
                    isOrganic = true;
                    IngredientName = IngredientName.Substring(7).Trim(); // NOTE: organic is 7 letters, so the name should be contained in the substring following the 7th index
                }
                //Check if 'organic' is present, if it is, extract from name string and set ingredient to organic type

                //Extract Price 
                string Price = priceArray[priceArray.Length - 1].Trim();
                ExtractedPrice = Price.TrimStart('$');
                IngredientPrice = Convert.ToDecimal(ExtractedPrice);

                // Logic to make sure line was successfully parsed so Ingredient object can be successfully made
                if (!ExtractedPrice.Equals("") && !IngredientName.Equals(""))
                {
                    return new Ingredient(IngredientName.ToLower().Trim(), currentType, IngredientPrice, isOrganic);
                }
            }
            return null;
        }

        public static RecipeIngredient parseRecipeLine(string input, IngredientContainer container){

            // If input is empty, return null, or if the first character in the line 
            // is not a '- character, it is considered error
            if (input.Length == 0 || input[0] != '-')
            {
                return null;
            }

            Regex re = new Regex(@"(\d+\/\d|\d+)");
            //Match m = re.Match(input);
            double amount = 0;
            foreach (Match match in re.Matches(input))
            {
                try
                {
                    amount += measurementConversion(match.ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine("Could not process measurement amount");
                }

            }

            Ingredient currIngredient = findIngredient(input, container);

            if (currIngredient != null && amount != 0)
            {
                return new RecipeIngredient(currIngredient, Convert.ToDecimal(amount));
            }

            //Return null if there is error reading string
            return null;


        }

        /*  
         * Helper function to get double value from a number or number/fraction combo
         * e.g. 3/4 -> 0.75, 1 1/4 -> 1.25, 1 -> 1
         * */
        public static double measurementConversion(string amount)
        {
            double result;

            // return if it's just a regular number
            if (double.TryParse(amount, out result))
            {
                return result;
            }

            string[] split = amount.Split(new char[] { ' ', '/' });

            if (split.Length == 2 || split.Length == 3)
            {
                int a, b;

                if (int.TryParse(split[0], out a) && int.TryParse(split[1], out b))
                {
                    // Scenario when input is just a fraction (e.g. 3/4)
                    if (split.Length == 2)
                    {
                        return (double)a / b;
                    }

                    int c;

                    // Scenario when input is a number and a fraction (e.g. 1 1/4)
                    if (int.TryParse(split[2], out c))
                    {
                        return a + (double)b / c;
                    }
                }
            }

            throw new FormatException("Invalid input");
        }
        
        // Helper function to help identify ingredient given a recipe line
        public static Ingredient findIngredient(string input, IngredientContainer container)
        {
            Dictionary<string, Ingredient>.KeyCollection containerKeys = container.getContainerKeys();

            //Iterate through the key names and pinpoint an ingredient where the name
            foreach (string name in containerKeys)
            {
                if (input.Contains(name.Trim()))
                {
                    //Console.WriteLine("found!0");
                    return container.getIngredient(name);
                }
            }
            // if code reaches here, no valid ingredients found, return null
            return null;
        }
        

        
    }
}
