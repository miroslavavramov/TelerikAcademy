namespace HashedSetImplementation
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;

    class Program
    {
        static void Main()
        {
            var firstSet = new HashedSet<int>();
            var secondSet = new HashedSet<int>();

            firstSet.Add(1);
            firstSet.Add(2);
            firstSet.Add(3);

            secondSet.Add(2);
            secondSet.Add(3);
            secondSet.Add(4);
            secondSet.Add(5);

            secondSet.Remove(2);

            var unified = new HashedSet<int>(firstSet);
            unified.UnionWith(secondSet);

            Console.WriteLine("Unified");

            foreach (var item in unified)
            {
                Console.Write(item + " ");
            }

            var intersected = new HashedSet<int>(firstSet);
            intersected.IntersectWith(secondSet);

            Console.WriteLine("\r\nIntersected");

            foreach (var item in intersected)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\r\n" + firstSet.Find(1));
        }
    }
}
