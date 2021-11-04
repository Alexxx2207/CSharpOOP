using FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            players = new List<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
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

        public int Rating 
        {
            get => this.players.Count > 0 ? (int)Math.Round(players.Average(p => p.OverallSkill)) : 0;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(players => players.Name == playerName);

            if (playerToRemove == null)
            {
                throw new Exception(string.Format(GlobalConstants.MISSING_PLAYER_EXC_MSG, playerName, this.Name));
            }
            players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
