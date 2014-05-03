using System;
using System.Collections.Generic;

class Program
{
    static void GeneratePermutationsNoRepentitions<T>(IList<T> elements, int startIndex = 0)
    {
        Print(elements);

        if (startIndex < elements.Count)
        {
            for (int i = elements.Count-2; i >= startIndex; i--)
            {
                for (int k = i + 1; k < elements.Count; k++)
                {
                    if (!elements[i].Equals(elements[k]))
                    {
                        Swap(elements, i, k);
                        GeneratePermutationsNoRepentitions(elements, i + 1);
                    }
                }

                var temp = elements[i];

                for (int k = i; k < elements.Count-1;k++)
                {
                    elements[k] = elements[k + 1];
                }

                elements[elements.Count - 1] = temp;
            }
        }
    }

    static void Swap<T>(IList<T> collection, int firstIndex, int secondIndex)
    {
        T buffer = collection[firstIndex];
        collection[firstIndex] = collection[secondIndex];
        collection[secondIndex] = buffer;
    }

    static void Print<T>(IEnumerable<T> collection)
    {
        Console.WriteLine(string.Join(", ", collection));
    }

    static void Main()
    {
        var elements = new int[] { 1,3,5,5 };

        //elements = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};

        GeneratePermutationsNoRepentitions(elements);
    }
}

