using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates)
             : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var privare in Privates)
            {
                sb.AppendLine(privare.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
