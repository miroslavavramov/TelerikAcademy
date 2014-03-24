/* Write a program that reads a sequence of integers (List<int>) ending 
 * with an empty line and sorts them in an increasing order. */
using System;
using Wintellect.PowerCollections;

class SortInIncreasingOrder
{
    static void Main()
    {
        var bagOfNumbers = new OrderedBag<int>();

        string input = Console.ReadLine();

        while (!string.IsNullOrWhiteSpace(input))
        {
            bagOfNumbers.Add(int.Parse(input));

            input = Console.ReadLine();
        }

        foreach (var n in bagOfNumbers)
        {
            Console.Write("{0} ", n);
        }
    }
}

