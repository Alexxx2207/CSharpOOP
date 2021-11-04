using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
        
    }
}
