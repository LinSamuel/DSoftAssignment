using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{

    /* Class representing a single ingredient type
     * 
     * */
    public enum IngredientType { Produce, Meat, Pantry, Other };
    class Ingredient
    {
        private Boolean isProduce;
        private Boolean isOrganic;
        private String name;
        private IngredientType _type;

        // Cost of the ingredient for one unit of measurement
        private Double cost;

        public Ingredient(String name, IngredientType type, Double cost, Boolean isOrganic)
        {
            this.name = name;
            this._type = type;
            isProduce = this._type == IngredientType.Produce;
            this.cost = cost;
            this.isOrganic = isOrganic;
            Console.WriteLine(name + isProduce);
        }

        public void printStats(){
            Console.WriteLine(name + isProduce);
        }
    }
}
