using Demo1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1.Models
{
    class Food : IGameObject
    {
        public bool IsEaten { get; set; }
        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("Hranaaaa");
        }
    }
}
