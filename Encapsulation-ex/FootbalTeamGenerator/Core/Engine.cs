using FootballTeamGenerator.Common;
using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator.Core
{
    class Engine
    {

        private readonly ICollection<Team> teams;
        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(";");

                string commandType = cmdArgs[0];

                try
                {
                    string[] cmdParams = cmdArgs.Skip(1).ToArray();

                    if (commandType == "Team")
                    {
                        this.CreateTeam(cmdParams);
                    }
                    else if (commandType == "Add")
                    {
                        this.AddPlayerToTeam(cmdParams);
                    }
                    else if (commandType == "Remove")
                    {
                        this.RemovePlayerFromTeam(cmdParams);
                    }
                    else if (commandType == "Rating")
                    {
                        this.RateTeam(cmdParams);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }
        }
        private void CreateTeam(string[] commandArgs)
        {
            string teamName = commandArgs[0];

            Team team = new Team(teamName);
            teams.Add(team);
        }

        private void AddPlayerToTeam(string[] cmdArgs)
        {
            string teamName = cmdArgs[0];
            string playerName = cmdArgs[1];

            this.ValidateTeamExists(teamName);


            Stats stats = this.BuildStats(cmdArgs.Skip(2).ToArray());

            Player player = new Player(playerName, stats);


            Team team = this.teams.First(t => t.Name == teamName);
            team.AddPlayer(player);
        }

        private void RemovePlayerFromTeam(string[] args)
        {
            string teamName = args[0];
            string playerName = args[1];

            ValidateTeamExists(teamName);

            Team team = teams.First(t => t.Name == teamName);

            team.RemovePlayer(playerName);
        }

        private void RateTeam(string[] agrs)
        {
            string teamName = agrs[0];

            ValidateTeamExists(teamName);

            Team team = teams.First(t => t.Name == teamName);

            Console.WriteLine(team);

        }

        private Stats BuildStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);

            Stats statsObject = new Stats(endurance, sprint,dribble,passing,shooting);

            return statsObject;
        }

        private void ValidateTeamExists(string teamName)
        {
            if (!teams.Any(t => t.Name == teamName))
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.MISSING_TEAM_EXC_MSG, teamName));
            }
        }


    }
}
