using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int code) : base(id, firstName, lastName)
        {
            Code = code;
        }

        public int Code { get; }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}" + Environment.NewLine + $"Code Number: {Code}";
        }
    }
}
