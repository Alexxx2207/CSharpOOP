using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            
            Employee janitor = new Janitor("Stely");
            Employee manager = new Manager("Gosho", new List<string> { "A", "B"});

            DetailsPrinter detailsPrinter = new DetailsPrinter(new List<Employee> { janitor, manager} );
            detailsPrinter.PrintDetails();
        }
    }
}
