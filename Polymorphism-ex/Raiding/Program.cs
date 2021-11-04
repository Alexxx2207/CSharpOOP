using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int totalPower = 0, counter = 0;

            List<BaseHero> heros = new List<BaseHero>();

            while(N != heros.Count)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    BaseHeroFactory factory = new BaseHeroFactory();
                    BaseHero hero = factory.CreateBaseHero(name, heroType);

                    heros.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            int Boss = int.Parse(Console.ReadLine());
            totalPower = heros.Sum(h => h.Power);
            heros.ForEach(h => Console.WriteLine(h.CastAbility()));

            if (Boss <= totalPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        
    }
}
