/* We are given numbers N and M and the following operations:
N = N+1
N = N+2
N = N*2
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. 
Hint: use a queue.
Example: N = 5, M = 16
Sequence: 5  7  8  16*/
using System;
using System.Collections.Generic;

class ShortestSequenceOfOperations
{
    static ICollection<int> GetLeastAmountOfOperations(int start, int end, Func<int, int>[] operations)
    {
        var progression = new List<int>();
        int temp = start;

        for (int i = operations.Length - 1; i >= 0; i--)
        {
            while (true)
            {
                temp = operations[i](start);

                if (temp < end)
                {
                    start = temp;
                    progression.Add(temp);
                }
                else break;
            }
        }

        return progression;
    }

    static void Main()
    {
        int start = 5;
        int end = 16;

        var operations = new Func<int, int>[]
        {
            x => x + 1,
            x => x + 2,
            x => x * 2
        };

        var progression = GetLeastAmountOfOperations(start, end, operations);

        Console.WriteLine(string.Join(", ", progression));
        Console.WriteLine("Operations count = " + progression.Count);
    }
}

