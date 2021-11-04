using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
            prefferedFood = new List<Type> { typeof(Meat), typeof(Vegetable), typeof(Seeds), typeof(Fruit) };
        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quaintity;

            Weight += (0.35 * food.Quaintity); 
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
