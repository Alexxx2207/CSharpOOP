using BirthdayCelebrations;
using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IBirthable> society = new List<IBirthable>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");
                if (tokens[0] == "Citizen" && tokens.Length == 5)
                {
                    IBirthable member = new Citizens(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    society.Add(member);
                }
                else if (tokens[0] == "Pet" && tokens.Length == 3)
                {
                    IBirthable member = new Pet(tokens[1], tokens[2]);
                    society.Add(member);
                }
            }

            string lastDigits = Console.ReadLine();
            foreach (var member in society)
            {
                CheckID(member, lastDigits);
            }

            
        }

        private static void CheckID(IBirthable member, string lastDigits)
        {
            if (member.Birthdate.EndsWith(lastDigits))
            {
                Console.WriteLine(member.Birthdate);
            }
        }
    }
}
