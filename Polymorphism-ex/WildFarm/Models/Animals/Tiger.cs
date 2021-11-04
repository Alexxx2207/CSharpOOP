using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    class Tiger : Felince
    {
        public Tiger(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        {
            prefferedFood = new List<Type> { typeof(Meat) };

        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quaintity;
            Weight += (1.00 * food.Quaintity);
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
