using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ISpecialisedSoldier
    {
        SoldierCorpEnum Corps { get; }
    }
}
