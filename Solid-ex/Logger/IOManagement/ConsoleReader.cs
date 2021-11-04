using Logger.IOManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.IOManagement
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
