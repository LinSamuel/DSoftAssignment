using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSoftAssignment
{
    public enum IngredientType { Produce, Meat, Pantry };
    class IngredientContainer
    {
        private Boolean isProduce;
        private String name;
        private IngredientType _type;

        // Cost of the ingredient for one unit of measurement
        private Double cost;

        public IngredientContainer(String name, IngredientType type, Double cost)
        {
            this.name = name;
            this._type = type;
            isProduce = this._type == IngredientType.Produce;
            this.cost = cost;
            Console.WriteLine("made " + name);
        }

    }
}
