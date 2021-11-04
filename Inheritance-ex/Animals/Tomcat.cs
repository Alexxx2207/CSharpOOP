using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, "MEOW")
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
