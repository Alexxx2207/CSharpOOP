using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum corps, ICollection<IMission> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = repairs;
        }
        public ICollection<IMission> Missions { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine($"  {mission}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
