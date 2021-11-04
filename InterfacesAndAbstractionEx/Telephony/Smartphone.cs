using System;
using System.Collections.Generic;
using System.Text;

namespace Tele
{
    class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");

        }
    }
}
