using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IMission
    {
        string Name { get; }
        MissionStateEnum State { get; }

        void CompleteMission(string mission);
    }
}
