using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        
        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam { get => firstTeam.AsReadOnly(); private set { } }
        public IReadOnlyCollection<Person> ReserveTeam { get => reserveTeam.AsReadOnly(); private set { } }

        public void AddPlayer(Person person)
        {

            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
