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

        // After analyzing the sample output, it seems like the sales tax is calculated by raw value, ignoring the measurements in the recipe, rounded
        // to the nearest 7 cents after taking 8.6% of total price
        /*
         *  Example:
         *  Produce
         *  - 1 clove of organic garlic = $0.67
         *  - 1 Lemon = $2.03
         *  Pantry
         *  - 1 cup of organic olive oil = $1.92
         *  - 1 teaspoon of salt = $0.16
         *  - 1 teaspoon of pepper = $0.17
         *  
         *  Recipe 1
            - 1 garlic clove
            - 1 lemon
            - 3/4 cup olive oil
            - 3/4 teaspoons of salt
            - 1/2 teaspoons of pepper
         * 
         * EXPECTED VALUE: 0.21
         * 
         * (1.92 + 0.16 + 0.17) * 0.086 = 0.1935 ---(round to nearest 7 cents) ---> = 0.21 [RIGHT ANSWER]
         * 
         * So the approach mentioned above is apparently the way this is expected to be calculated, 
         * if you take into account the measurements, you get an incorrect answer:
         * 
         * (0.75 * 1.92) + (0.75 * 0.16) + (0.50 * 0.17) * 0.086 = 0.14147 ---(round to nearest 7 cents) ---> = 0.14 [WRONG ANSWER]
         * */
        public double calculateSalesTax(){
            double salesTax = 0;
            foreach (RecipeIngredient ingred in ingredientList)
            {
                // If it is not produce, append to sales tax
                if (!ingred.getIngredient().getIsProduce())
                {
                    salesTax += ingred.getIngredient().getCost();
                }
                
            }
            salesTax *= 100;
            return (double) Math.Round(salesTax * 0.086 / 7) * 7 / 100;
        }

        // After analyzing the sample output, it seems the discount DOES into account the measurements in the recipe
        // The wellness discount is calculated by taking 5% of the price of ORGANIC ingredients after taking into account the measurements
        /*
         *  Example:
         *  Produce
         *  - 1 clove of organic garlic = $0.67
         *  - 1 Lemon = $2.03
         *  Pantry
         *  - 1 cup of organic olive oil = $1.92
         *  - 1 teaspoon of salt = $0.16
         *  - 1 teaspoon of pepper = $0.17
         *  
         *  Recipe 1
            - 1 garlic clove
            - 1 lemon
            - 3/4 cup olive oil
            - 3/4 teaspoons of salt
            - 1/2 teaspoons of pepper
         * 
         * EXPECTED VALUE: 0.11
         * 
         * [(1 * 0.67) + (0.75 * 1.92)] * 0.05 = 0.1055 ---(round to nearest cent) ---> 0.11 [RIGHT ANSWER]
         *          * 
         * So the approach mentioned above is apparently the way this is expected to be calculated, 
         * if you do not take into account the measurements, you get an incorrect answer:  
         *  
         * (0.67 + 1.92) * 0.05 = 0.1295 ---(round to nearest cent) ---> 0.13 [WRONG ANSWER]
         * */
        public double calculateDiscount()
        {
            double discount = 0;

        }

        public double calculateTotalCost()
        {
            double totalCost = 0;
            foreach (RecipeIngredient ingred in ingredientList)
            {
                totalCost += ingred.getAmount() * ingred.getIngredient().getCost();
            }
            return totalCost;
        }

        public void calculateStats()
        {
            Console.WriteLine("Tax = $" + calculateSalesTax());
            Console.WriteLine("Total = $" + calculateTotalCost());
        }
        
    }
}
