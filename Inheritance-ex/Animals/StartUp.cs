using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
            string input;
            List<Animal> animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    switch (input)
                    {
                        case "Cat":
                            Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(cat);

                            break;
                        case "Dog":
                            Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(dog);


                            break;
                        case "Frog":
                            Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                            animals.Add(frog);


                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                            animals.Add(kitten);


                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                            animals.Add(tomcat);


                            break;
                        default:
                            break;
                    } 
                }
                else if (tokens.Length == 2)
                {
                    switch (tokens[0])
                    {
                        case "Kitten":
                            Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                            animals.Add(kitten);


                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                            animals.Add(tomcat);


                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var item in animals)
            {
                if (item.Age > 0)
                {
                    Console.WriteLine(item.GetType().Name);
                    Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                    item.ProduceSound(); 
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
