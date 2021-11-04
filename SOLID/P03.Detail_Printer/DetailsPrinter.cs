using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IPrintable employee in this.employees)
            {
                this.PrintEmployee(employee);
                
            }
        }

        private void PrintEmployee(IPrintable employee)
        {
            Console.WriteLine(employee.Print());
        }
    }
}
