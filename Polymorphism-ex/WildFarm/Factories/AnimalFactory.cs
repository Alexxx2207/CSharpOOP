using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interfaces;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    class AnimalFactory
    {
        public AnimalFactory()
        {

        }

        public Animal CreateAnimal(string[] info)
        {
            string type = info[0];
            string name = info[1];
            double weight = double.Parse(info[2]);

            Animal animal;

            if (type == nameof(Tiger))
            {
                animal = new Tiger(name, weight, 0, info[3], info[4]);
            }
            else if(type == nameof(Cat))
            {
                animal = new Cat(name, weight, 0, info[3], info[4]);
            }
            else if (type == nameof(Owl))
            {
                animal = new Owl(name, weight,0, double.Parse(info[3]));
            }
            else if (type == nameof(Hen))
            {
                animal = new Hen(name, weight, 0, double.Parse(info[3]));
            }
            else if (type == nameof(Mouse))
            {
                animal = new Mouse(name, weight, 0, info[3]);
            }
            else if (type == nameof(Dog))
            {
                animal = new Dog(name, weight, 0, info[3]);

            }
            else
            {
                throw new Exception("Invalid type!");
            }

            return animal;
        }
    }
}
