using Demo1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Models
{
    class Obstacle : IGameObject
    {
        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("Spri se be");
        }
    }
}
