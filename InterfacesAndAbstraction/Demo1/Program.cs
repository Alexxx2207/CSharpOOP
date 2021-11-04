using Demo1.Drawers;
using Demo1.Interfaces;
using System;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDrawer drawer = new FileDrawer("../../../game.txt");
            Game game = new Game(drawer);
            game.Start();
        }
    }
}
