using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    class Programmer : Worker
    {
        public override int Salary { get; set; }

        public override void Work()
        {
            Console.WriteLine("Ne rabotq dneska");
        }
    }
}
