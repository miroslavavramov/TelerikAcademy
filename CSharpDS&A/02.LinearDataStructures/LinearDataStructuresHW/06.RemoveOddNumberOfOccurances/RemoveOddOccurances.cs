/*Write a program that removes from given sequence all numbers that occur odd number of times. 
 Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5} */
using System;
using System.Collections.Generic;
using System.Linq;

class RemoveOddNumberOfOccurances
{
    static void RemoveNumbersOccuringOddTimes(List<int> numbers)
    {
        int occurances;
        int num;

        for (int i = 0; i < numbers.Count; i++)
        {
            occurances = 0;
            num = numbers[i];

            for (int k = 0; k < numbers.Count; k++)
            {
                if (num == numbers[k])
                {
                    occurances++;
                }
            }

            if (occurances % 2 != 0)
            {
                numbers.RemoveAll(x => x == num);
            }
        }
    }
    static void Main()
    {
        var numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

        RemoveNumbersOccuringOddTimes(numbers);

        Console.WriteLine(string.Join(", ",numbers));
    }
}

