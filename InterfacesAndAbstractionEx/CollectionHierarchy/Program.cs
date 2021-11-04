using CollectionHierarchy.Interfaces;
using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeCount = int.Parse(Console.ReadLine());

            Array.ForEach(input, str => Console.Write(addCollection.Add(str) + " "));
            Console.WriteLine();
            Array.ForEach(input, str => Console.Write(addRemoveCollection.Add(str) + " "));
            Console.WriteLine();
            Array.ForEach(input, str => Console.Write(myList.Add(str) + " "));
            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < removeCount; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            

        }
    }
}
