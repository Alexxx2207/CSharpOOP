using Logger.IOManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.IOManagement
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
