using System;

namespace Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealPrivateMethods("Stealer.Hacker"));
        }
    }
}
