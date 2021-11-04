using System;

namespace ExceptionHandling
{
    class Program
    {
        static void TestTryFinally()
        {
            int a = 0;
            Console.WriteLine("Code executed before try-finally.");
            try
            {
                a++;
                throw new Exception();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Parsing failed!");
            }
            finally
            {
                Console.WriteLine("This cleanup code is always executed.");
            }
            Console.WriteLine("This code is after the try-finally block.");
        }
        static void Main(string[] args)
        {

            TestTryFinally();
        }
    }
}
