using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name 
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(GlobalConstants.INVALID_NAME_EXC_MSG);
                }
                name = value;
            }
        }

        public Stats Stats { get; set; }

        public double OverallSkill { get => Stats.AverageStat; }
    }
}
