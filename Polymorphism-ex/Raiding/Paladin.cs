using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Paladin : BaseHero
    {
        public Paladin(string name)
        {
            Power = 100;
            Name = name;
            
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";

        }
    }
}
