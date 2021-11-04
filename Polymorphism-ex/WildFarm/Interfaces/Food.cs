using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
    public abstract class Food
    {
        protected Food(int quaintity)
        {
            Quaintity = quaintity;
        }

        public int Quaintity { get; set; }
    }
}
