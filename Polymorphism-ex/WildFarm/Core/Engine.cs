using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Factories;
using WildFarm.Interfaces;

namespace WildFarm.Core
{
    class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            AnimalFactory aFactory = new AnimalFactory();
            FoodFactory fFactory = new FoodFactory();

            List<Animal> zoo = new List<Animal>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Animal animal = aFactory.CreateAnimal(animalInfo);

                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Food food = fFactory.CreateFood(foodInfo[0], int.Parse(foodInfo[1]));

                Console.WriteLine(animal.ProduceSound());
                zoo.Add(animal);
                if (animal.PrefferedFoods.Contains(food.GetType()))
                {
                    animal.Feed(food);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                }
            }

            zoo.ForEach(a => Console.WriteLine(a));
        }
    }
}
