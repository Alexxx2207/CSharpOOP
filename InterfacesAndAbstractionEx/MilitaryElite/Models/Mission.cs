using MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        public Mission(string name, MissionStateEnum missionStateEnum)
        {
            Name = name;
            State = missionStateEnum;
        }
        public string Name { get; }

        public MissionStateEnum State { get; }

        public void CompleteMission(string mission)
        {
            
        }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}
