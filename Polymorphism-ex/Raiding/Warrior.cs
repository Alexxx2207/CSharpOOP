using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Warrior : BaseHero
    {
        public Warrior(string name)
        {
            Power = 100;
            Name = name;

        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
