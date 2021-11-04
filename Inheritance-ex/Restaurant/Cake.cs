using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private const decimal DefaultCakePrice = 5;
        
        public Cake(string name) : base(name, DefaultCakePrice, 250, 1000)
        {
            
        }
    }
}
