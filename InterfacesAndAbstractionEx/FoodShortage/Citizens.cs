using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    class Citizens : IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizens(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            food = 0;
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Id { get => id; set => id = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public int Food { get => food; set { food = value; } }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
