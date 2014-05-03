using System;
using System.Collections.Generic;

class Program
{
    static void GenerateVariations<T>(IList<T> elements, IList<T> variation, int index = 0)
    {
        if (index == variation.Count)
        {
            Print(variation);
        }
        else
        {
            for (int i = 0; i < elements.Count; i++)
            {
                variation[index] = elements[i];
                GenerateVariations(elements, variation, index + 1);
            }
        }
    }

    static void Print<T>(IList<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }

    static void Main()
    {
        var elements = new string[] { "hi", "a", "b", };
        int k = 2;

        GenerateVariations(elements, new string[k]);
    }
}

