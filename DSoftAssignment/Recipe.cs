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

        // After analyzing the sample output, it seems like the sales tax is calculated by raw value, ignoring the measurements in the recipe
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
