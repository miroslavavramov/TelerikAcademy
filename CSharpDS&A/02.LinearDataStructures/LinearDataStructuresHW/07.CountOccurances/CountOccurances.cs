/*Write a program that finds in given array of integers 
(all belonging to the range [0..1000]) how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2  2 times
3  4 times
4  3 times */
using System;
using System.Linq;

class CountOccurances
{
    static void Main()
    {
        var numbers = new int[] { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        var occurancesByNumber = new int[1001];

        for (int i = 0; i < numbers.Length; i++)
        {
            occurancesByNumber[numbers[i]]++;
        }

        for (int i = 0; i < occurancesByNumber.Length; i++)
        {
            if (occurancesByNumber[i] > 0)
            {
                Console.WriteLine("{0} occurs {1} times", i, occurancesByNumber[i]);
            }
        }
    }
}
