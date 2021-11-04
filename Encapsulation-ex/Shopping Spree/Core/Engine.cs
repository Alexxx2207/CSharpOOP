using Shopping_Spree.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree.Core
{
    //read data from the console
    //process data
    //Print data
    class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;

        public Engine()
        {
            people = new List<Person>();
            products = new List<Product>();
        }

        public void Run()
        {
            //place business logic here

            try
            {
                ParsePeopleInput();
                ParseProductInput();

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = this.people.FirstOrDefault(p => p.Name == personName);
                    Product product = this.products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        string result = person.BuyProduct(product);
                        Console.WriteLine(result);
                    }
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private void ParsePeopleInput()
        {
            string[] peopleArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var personStr in peopleArgs)
            {
                string[] personArgs = personStr.Split('=', StringSplitOptions.RemoveEmptyEntries);

                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                Person person = new Person(personName, personMoney);

                this.people.Add(person);
            }
        }

        private void ParseProductInput()
        {
            string[] productsArgs = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var productStr in productsArgs)
            {
                string[] productArgs = productStr.Split('=', StringSplitOptions.RemoveEmptyEntries);

                string productName = productArgs[0];
                decimal productMoney = decimal.Parse(productArgs[1]);

                Product person = new Product(productName, productMoney);

                this.products.Add(person);
            }
        }

        
    }
}
