using ExplicitInterfaces.Interfaces;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");
                Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine( ((IResident)citizen).GetName() + ((IPerson)citizen).GetName() );
            }
        }
    }
}
