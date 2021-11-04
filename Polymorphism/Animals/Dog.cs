using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override void CalcAge()
        {
            Console.WriteLine("Dog age");
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "DJAAF";
        }
    }
}
