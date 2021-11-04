using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    public abstract class Worker
    {
        public abstract int Salary { get; set; }
        public abstract void Work();
        public void Slack()
        {
            Console.WriteLine("Slacking is cool!");
        }
    }
}
