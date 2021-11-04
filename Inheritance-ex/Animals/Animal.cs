using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    class Animal
    {
        public virtual void ProduceSound() 
        {
            Console.WriteLine();
        } 
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
