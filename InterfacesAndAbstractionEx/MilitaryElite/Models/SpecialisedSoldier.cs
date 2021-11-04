using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, SoldierCorpEnum corps)
             : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }
        public SoldierCorpEnum Corps { get; }
    }
}
