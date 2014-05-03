using System;
using System.Collections.Generic;

class Program
{
    static void GeneratePermutations<T>(IList<T> elements, int index = 0)
    {
        if (index == elements.Count)
        {
            Print(elements);
        }
        else
        {
            GeneratePermutations(elements, index + 1);

            for (int i = index + 1; i < elements.Count; i++)
            {
                Swap(elements, index, i);
                GeneratePermutations(elements, index + 1);
                Swap(elements, index, i);
            }
        }
    }

    static void Print<T>(IList<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }

    static void Swap<T>(IList<T> collection, int firstIndex, int secondIndex)
    {
        T buffer = collection[firstIndex];
        collection[firstIndex] = collection[secondIndex];
        collection[secondIndex] = buffer;
    }

    static void Main()
    {
        GeneratePermutations(new int[] { 1, 3, 5, 5 }); 
    }
}

