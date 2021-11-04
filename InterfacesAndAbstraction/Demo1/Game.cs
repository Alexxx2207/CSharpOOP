using Demo1.Interfaces;
using Demo1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Demo1
{
    public class Game
    {
        private List<IGameObject> objects;
        private IDrawer drawer;

        public Game(IDrawer drawer)
        {
            this.drawer = drawer;
            objects = new List<IGameObject>();
            objects.Add(new Food());
            objects.Add(new Snake());
            objects.Add(new Obstacle());
        }

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                foreach (IGameObject @object in objects)
                {
                    @object.Draw(drawer);
                }
            }
        }
    }
}
