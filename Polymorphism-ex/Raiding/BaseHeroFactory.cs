using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class BaseHeroFactory
    {
        public BaseHeroFactory()
        {

        }
        public BaseHero CreateBaseHero(string name, string type)
        {
            BaseHero baseHero;

            if (type == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                baseHero = new Paladin(name);

            }
            else if (type == "Rogue")
            {
                baseHero = new Rogue(name);

            }
            else if (type == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            else
            {
                throw new Exception("Invalid hero!");
            }
            return baseHero;

        }
    }
}
