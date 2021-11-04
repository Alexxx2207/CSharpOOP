using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    class Druid : BaseHero
    {
        public Druid(string name)
        {
            Power = 80;
            Name = name;
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";

        }
    }
}
