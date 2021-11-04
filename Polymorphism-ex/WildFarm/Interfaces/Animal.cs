using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
    public abstract class Animal : IFeedable
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
            prefferedFood = new List<Type>();
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        protected List<Type> prefferedFood;

        public IReadOnlyCollection<Type> PrefferedFoods => prefferedFood;

        public abstract void Feed(Food food);

        public abstract string ProduceSound();
    }
}
