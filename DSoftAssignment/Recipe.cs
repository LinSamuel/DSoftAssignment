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

        public void whatsintherecipe()
        {
            Console.WriteLine(this.name + " has: ");
            foreach (RecipeIngredient ingred in ingredientList)
            {
                Console.WriteLine(ingred.getAmount() + " of " + ingred.getIngredient().getName());
                
            }

        }

        // After analyzing the sample output, the examples demonstrate that the measurements are taken into account, and the
        // resulting value for the tax is rounded up to the nearest 7 cents.
        /*
         *  ======== Example with recipe 1: ========
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
         * 
         *  ======== Example with recipe 2: ========
         *  Produce
            - 1 clove of organic garlic = $0.67
            - 1 Lemon = $2.03
            - 1 cup of corn = $0.87

            Meat/poultry
            - 1 chicken breast = $2.19
            - 1 slice of bacon = $0.24

            Pantry
            - 1 ounce of pasta = $0.31
            - 1 cup of organic olive oil = $1.92
            - 1 cup of vinegar = $1.26
            - 1 teaspoon of salt = $0.16
            - 1 teaspoon of pepper = $0.17
         * 
         *  
            Recipe 2
            - 1 garlic clove
            - 4 chicken breasts
            - 1/2 cup olive oil
            - 1/2 cup vinegar
         * 
         * EXPECTED VALUE: 0.91
         * 
         * [(4 * 2.19) + (0.5 * 1.92) + (0.5 * 1.26)] * 0.086 = 0.8901 ---(round up to nearest 7 cents) ---> = 0.91 [RIGHT ANSWER]
         * 
         * 
         * 
         * So the approach mentioned above is apparently the way this is expected to be calculated for example 2, 
         * if you don't take into account the measurements like in example 1, you get an incorrect answer:
         * 
         * (2.19 + 1.92 + 1.26) * 0.086 = 0.46182 ---(round up to nearest 7 cents) ---> = 0.49 [WRONG ANSWER]
         * 
         * Conclusion: Because of the ambiguity, I have to make the decision on whether or not to include
         * measurements when calculating the sales tax. When I implemented this function, I will go ahead
         * and include measurements as well (like in example 2), because it would seem to make more sense
         * that way.
         * 
         * */
        public Decimal calculateSalesTax(){
            decimal salesTax = 0;
            foreach (RecipeIngredient ingred in ingredientList)
            {
                // If it is not produce, append to sales tax
                if (!ingred.getIngredient().getIsProduce())
                {
                    Decimal currentIncrease = Decimal.Multiply(ingred.getIngredient().getCost(), ingred.getAmount());
                    salesTax = Decimal.Add(salesTax, currentIncrease);
                }
                
            }
            salesTax *= 100;
            //return Math.Round(salesTax * 0.086 / 7) * 7 / 100;
            return Math.Round(Decimal.Ceiling(Decimal.Multiply(salesTax, new Decimal(0.086)) / 7)) * 7 / 100;
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
        public Decimal calculateDiscount()
        {
            Decimal discount = 0;
            foreach (RecipeIngredient ingred in ingredientList)
            {
                // If it is organic, add to the discount
                if (ingred.getIngredient().getIsOrganic())
                {
                    //discount += ingred.getIngredient().getCost() * ingred.getAmount();
                    Decimal currentIncrease = Decimal.Multiply(ingred.getIngredient().getCost(), ingred.getAmount());
                    discount = Decimal.Add(discount, currentIncrease);
                }

            }
            return Math.Round(Decimal.Multiply(discount, new Decimal(0.05)),2);

        }

        public Decimal calculateRawTotalCost()
        {
            Decimal totalCost = 0;
            foreach (RecipeIngredient ingred in ingredientList)
            {
                //totalCost += ingred.getAmount() * ingred.getIngredient().getCost();
                Decimal currentIncrease = Decimal.Multiply(ingred.getIngredient().getCost(), ingred.getAmount());
                totalCost = Decimal.Add(totalCost, currentIncrease);
            }
            return totalCost;
        }

        public void calculateStats()
        {
            Decimal initialCost = calculateRawTotalCost();
            Decimal tax = calculateSalesTax();
            Decimal discount = calculateDiscount();
            initialCost = initialCost + tax - discount;
            Console.WriteLine(this.name);
            Console.WriteLine("Tax = $" + Math.Round(tax,2));
            Console.WriteLine("Discount = ($" + Math.Round(discount,2) + ")");
            Console.WriteLine("Total = $" + Math.Round(initialCost,2) + "\n");
        }
        
    }
}
