using System;
using System.Collections.Generic;
using System.Linq;

public class Arena
{
    private readonly List<Warrior> warriors;

    public Arena()
    {
        //here-ok
        this.warriors = new List<Warrior>();
    }
    //here-ok
    public IReadOnlyCollection<Warrior> Warriors =>
        this.warriors;
    //here-ok
    public int Count => this.warriors.Count;

    public void Enroll(Warrior warrior)
    {//here-ok
        if (this.warriors.Any(w => w.Name == warrior.Name))
        {
            throw new InvalidOperationException("Warrior is already enrolled for the fights!");
        }
        //here-ok
        this.warriors.Add(warrior);
    }

    public void Fight(string attackerName, string defenderName)
    {
        Warrior attacker = this.warriors
            .FirstOrDefault(w => w.Name == attackerName);
        Warrior defender = this.warriors
            .FirstOrDefault(w => w.Name == defenderName);
        //here-ok
        if (attacker == null || defender == null)
        {
            string missingName = attackerName;
            //here-ok
            if (defender == null)
            {
                missingName = defenderName;
            }

            throw new InvalidOperationException($"There is no fighter with name {missingName} enrolled for the fights!");
        }
        //here-ok
        attacker.Attack(defender);
    }

    public void Fight(object p)
    {
        throw new NotImplementedException();
    }
}
