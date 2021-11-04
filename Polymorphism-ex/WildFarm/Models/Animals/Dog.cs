using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten, livingRegion)
        {
            prefferedFood = new List<Type> { typeof(Meat) };
        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quaintity;

            Weight += (0.4 * food.Quaintity);
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
