using MilitaryElite.Enumerations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    class Program
    {
        static void Main(string[] args)
        {
            ICollection<ISoldier> soldiers = new List<ISoldier>();

            string input;
            ISoldier s;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ");

                if (tokens[0] == nameof(Private))
                {
                    s = new Private(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                    soldiers.Add(s);

                }
                else if (tokens[0] == nameof(LieutenantGeneral))
                {
                    ICollection<IPrivate> privates = new List<IPrivate>();
                    int[] privates1 = tokens.Skip(5).Select(int.Parse).ToArray();
                    for (int i = 0; i < privates1.Length; i++)
                    {
                        ISoldier soldier = soldiers.First(s => s.Id == privates1[i]);
                        if (soldier != null)
                        {
                            privates.Add((IPrivate)soldier);
                        }
                    }
                    s = new LieutenantGeneral(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), privates);
                    soldiers.Add(s);

                }
                else if (tokens[0] == nameof(Engineer))
                {
                    ICollection<IRepair> repairs = new List<IRepair>();
                    string[] repairs1 = tokens.Skip(6).ToArray();
                    for (int i = 0; i < repairs1.Length; i+=2)
                    {

                        IRepair repair = new Repair(repairs1[i], int.Parse(repairs1[i+1]));
                        repairs.Add(repair);

                    }
                    if (Enum.TryParse(tokens[5], out SoldierCorpEnum corps))
                    {
                        s = new Engineer(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), corps, repairs); 
                        soldiers.Add(s);

                    }
                }
                else if (tokens[0] == nameof(Commando))
                {
                    ICollection<IMission> missions = new List<IMission>();
                    string[] missions1 = tokens.Skip(6).ToArray();
                    for (int i = 0; i < missions1.Length; i += 2)
                    {

                        if (Enum.TryParse(missions1[i + 1], out MissionStateEnum missionStateEnum))
                        {
                            IMission mission = new Mission(missions1[i], missionStateEnum);
                            missions.Add(mission); 
                        }

                    }
                    if (Enum.TryParse(tokens[5], out SoldierCorpEnum corps))
                    {
                        s = new Commando(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), corps, missions);
                        soldiers.Add(s);

                    }
                }
                else
                {
                    s = new Spy(int.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4]));
                    soldiers.Add(s);

                }

            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
