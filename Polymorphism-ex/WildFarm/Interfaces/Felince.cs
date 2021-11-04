using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
    public abstract class Felince : Mammal
    {
        protected Felince(string name, double weight, int foodEaten, string livingRegion, string breed) : base(name, weight, foodEaten, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
    }
}
