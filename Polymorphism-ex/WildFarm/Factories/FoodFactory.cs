using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    class FoodFactory
    {
        public FoodFactory()
        {

        }

        public Food CreateFood(string type, int quantity)
        {
            Food food;
            if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }
            else
            {
                throw new Exception("Invalid type!");
            }

            return food;
        }
    }
}
