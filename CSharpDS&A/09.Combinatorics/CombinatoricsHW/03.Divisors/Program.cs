using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int[] permutation;
    static int minDivisors = int.MaxValue;
    static int minNumber = int.MaxValue;

    static void GeneratePermutationsNoRepentitions<T>(IList<T> elements, int startIndex = 0)
    {
        Check();

        if (startIndex < elements.Count)
        {
            for (int i = elements.Count - 2; i >= startIndex; i--)
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

                for (int k = i; k < elements.Count - 1; k++)
                {
                    elements[k] = elements[k + 1];
                }

                elements[elements.Count - 1] = temp;
            }
        }
    }

    private static void Check()
    {
        var sb = new System.Text.StringBuilder();

        foreach (var n in permutation)
        {
            sb.Append(n);
        }

        int currentNum = int.Parse(sb.ToString());
        int currentDivisors = 1;

        for (int i = 1; i <= currentNum / 2; i++)
        {
            if (currentNum % i == 0)
            {
                currentDivisors++;

                if (currentDivisors > minDivisors)
                {
                    break;
                }
            }
        }

        if (currentDivisors <= minDivisors)
        {
            if (currentDivisors == minDivisors)
            {
                if (currentNum < minNumber)
                {
                    minNumber = currentNum;
                }
            }
            else
            {
                minDivisors = currentDivisors;
                minNumber = currentNum;
            }
        }
    }

    static void Swap<T>(IList<T> collection, int firstIndex, int secondIndex)
    {
        T buffer = collection[firstIndex];
        collection[firstIndex] = collection[secondIndex];
        collection[secondIndex] = buffer;
    }

    static void ParseInput()
    {
        int n = int.Parse(Console.ReadLine());
        permutation = new int[n];

        for (int i = 0; i < n; i++)
        {
            permutation[i] = int.Parse(Console.ReadLine());
        }
    }

    static void Main()
    {
        ParseInput();
        GeneratePermutationsNoRepentitions(permutation);
        Console.WriteLine(minNumber);
        // Console.WriteLine(minDivisors);
    }
}