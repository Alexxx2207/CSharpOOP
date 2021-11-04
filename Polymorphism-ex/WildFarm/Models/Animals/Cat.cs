using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    class Cat : Felince
    {
        public  Cat(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion, breed)
        { 
            this.prefferedFood = new List<Type>{ typeof(Meat), typeof(Vegetable) };
        }

        public override void Feed(Food food)
        {
            FoodEaten += food.Quaintity;
            Weight += (0.3 * food.Quaintity);
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
