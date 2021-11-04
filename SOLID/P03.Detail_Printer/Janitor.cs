using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class Janitor : Employee, IPrintable
    {
        public Janitor(string name) : base(name)
        {

        }

        public new string Print()
        {
            return "I am cleaning!";
        }
    }
}
