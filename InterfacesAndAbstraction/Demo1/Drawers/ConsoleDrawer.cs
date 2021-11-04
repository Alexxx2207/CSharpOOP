using Demo1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Drawers
{
    class ConsoleDrawer : IDrawer
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public void TukSum()
        { }
    }
}
