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

    class ParseHandler
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
         *  TODO: turn this into a factory maybe?
         * */

        public static Ingredient parseIngredientLine(string input, IngredientType currentType)
        {
            // If input is empty, return null, error
            if (input.Length == 0)
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
            double IngredientPrice = 0;
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
                IngredientPrice = Convert.ToDouble(ExtractedPrice);

                // Logic to make sure line was successfully parsed so Ingredient object can be successfully made
                if (!ExtractedPrice.Equals("") && !IngredientName.Equals(""))
                {
                    return new Ingredient(IngredientName, currentType, IngredientPrice, isOrganic);
                }
            }
            //else 
            //{
            //    //If no 'of' is detected, the remaining tokens represent the ingredient name and price
            //    // e.g. - 1 chicken breast = $2.19
            //    string[] nameAndPrice = new string[splitByWhiteSpace.Length - 2];
            //    Array.Copy(splitByWhiteSpace, 2, nameAndPrice, 0, nameAndPrice.Length);
            //    string nameAndPriceString = String.Join(" ", nameAndPrice);
            //    string[] priceArray = nameAndPriceString.Split('=');
            //    string ExtractedPrice = "";
            //    string IngredientName = "";
            //    Boolean isOrganic = false;
            //    double IngredientPrice = 0;
            //    if (priceArray.Length > 0)
            //    {
            //        //Extract Name (NOTE: check if capitals matter)
            //        IngredientName = priceArray[0];
            //        if (IngredientName.Contains("organic"))
            //        {
            //            isOrganic = true;
            //            IngredientName = IngredientName.Substring(7).Trim(); // NOTE: organic is 7 letters, so the name should be contained in the substring following the 7th index
            //        }
            //        //Check if 'organic' is present, if it is, extract from name string and set ingredient to organic type

            //        //Extract Price 
            //        string Price = priceArray[priceArray.Length - 1].Trim();
            //        ExtractedPrice = Price.TrimStart('$');
            //        IngredientPrice = Convert.ToDouble(ExtractedPrice);
            //    }

            //    // Logic to make sure line was successfully parsed so Ingredient object can be successfully made
            //    if (!ExtractedPrice.Equals("") && !IngredientName.Equals(""))
            //    {
            //        return new Ingredient(IngredientName.ToLower(), currentType, IngredientPrice, isOrganic);
            //    }

            //}
            return null;
        }
        // could work? ^\d+(?:\.?\d*|\s\d+\/\d+|\d+\/\d+)$
        public static RecipeIngredient parseRecipeLine(string input){
            Regex re = new Regex(@"(\d+\/\d|\d+)");
            //Match m = re.Match(input);
            foreach (Match match in re.Matches(input))
            {
                Console.WriteLine(match);
            }
            //if (m.Success)
            //{
            //    foreach()
            //    Console.WriteLine(string.Format("RegEx found " + m.Value + " at position " + m.Index.ToString()));
            //}
            //else
            //{
            //    Console.WriteLine("You didn't enter a string containing a number!");
            //}
            return null;
        }

        

        
    }
}
