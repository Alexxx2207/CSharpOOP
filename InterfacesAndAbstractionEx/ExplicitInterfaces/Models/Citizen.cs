using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs ";
        }
        string IPerson.GetName()
        {
            return $"{Name}";
        }
    }
}
