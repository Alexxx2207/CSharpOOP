using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> society = new List<IIdentifiable>(); 
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");
                if (tokens.Length == 3)
                {
                    IIdentifiable member = new Citizens(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    society.Add(member);
                }
                else
                {
                    IIdentifiable member = new Robot(tokens[0], tokens[1]);
                    society.Add(member);
                }
            }

            string lastDigits = Console.ReadLine();

            foreach (var member in society)
            {
                CheckID(member, lastDigits);
            }
        }

        private static void CheckID(IIdentifiable member , string lastDigits)
        {
            if (member.Id.EndsWith(lastDigits))
            {
                Console.WriteLine(member.Id);
            }
        }
    }
}
