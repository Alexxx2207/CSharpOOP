using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
namespace Tele
{
    class Startup
    {
        static void Main()
        {
            var smartphone = new Smartphone("Nokia");
            string[] phones = Console.ReadLine().Split(new[] { ' ' });
            foreach (var phone in phones)
            {
                Console.WriteLine(smartphone.Call(phone));
            }
            string[] websites = Console.ReadLine().Split(new[] { ' ' });
            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.Browse(website));
            }
        }
    }
}