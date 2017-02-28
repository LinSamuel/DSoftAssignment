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
        private Decimal cost;

        public Ingredient(String name, IngredientType type, Decimal cost, Boolean isOrganic)
        {
            this.name = name;
            this._type = type;
            isProduce = this._type == IngredientType.Produce;
            this.cost = cost;
            this.isOrganic = isOrganic;
        }

        public String getName(){
            return this.name;
        }

        public Boolean getIsProduce()
        {
            return this.isProduce;
        }

        public Boolean getIsOrganic()
        {
            return this.isOrganic;
        }

        public Decimal getCost()
        {
            return this.cost;
        }

        public void printStats(){
            Console.WriteLine(name + isProduce + " is it organic though? : " + isOrganic);
        }
    }
}
