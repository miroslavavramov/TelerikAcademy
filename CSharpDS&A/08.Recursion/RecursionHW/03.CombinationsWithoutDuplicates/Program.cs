using System;
using System.Collections.Generic;

class Program
{
    static void GenerateCombinationsNoDuplicates<T>(IList<T> elements, IList<T> combination, int currentIndex, int startIndex)
    {
        if (currentIndex == combination.Count)
        {
            Print(combination);
        }
        else
        {
            for (int i = startIndex; i < elements.Count; i++)
            {
                combination[currentIndex] = elements[i];

                GenerateCombinationsNoDuplicates(elements, combination, currentIndex + 1, i + 1);
            }
        }
    }

    static void Print<T>(IEnumerable<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }

    static void Main()
    {
        var elements = new int[] { 1, 2, 3, 4 };
        int k = 2;

        GenerateCombinationsNoDuplicates(elements, new int[k], 0, 0);
    }
}
