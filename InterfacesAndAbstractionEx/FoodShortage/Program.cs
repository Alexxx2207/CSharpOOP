using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodBought = 0;
            int N = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");

                if (tokens.Length == 3)
                {
                    IBuyer buyer = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    buyers.Add(buyer);
                }
                else
                {
                    IBuyer buyer = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    buyers.Add(buyer);
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == input);
                if (buyer != null)
                {
                    int prevFood = buyer.Food;
                    buyer.BuyFood();
                    foodBought += buyer.Food - prevFood; 
                }
            }

            Console.WriteLine(foodBought);
        }
    }
}
