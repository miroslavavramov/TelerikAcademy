/*Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. 
 * Calculate and print the sum and average of the elements of the sequence. 
 * Keep the sequence in List<int>.
*/
using System;
using System.Collections.Generic;

class SumAndAverage
{
    static uint CalcSum(ICollection<uint> numbers)
    {
        uint sum = 0;

        foreach (var n in numbers)
        {
            sum += n;
        }

        return sum;
    }

    static double CalcAverage(ICollection<uint> numbers)
    {
        double avrg = (double)CalcSum(numbers) / numbers.Count;

        return avrg;
    }

    static void Main()
    {
        var numbers = new List<uint>();
        string input = Console.ReadLine();
        uint n;

        while (!string.IsNullOrWhiteSpace(input))
        {
            if (uint.TryParse(input, out n))
            {
                numbers.Add(n);
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }

            input = Console.ReadLine();
        }

        if (numbers.Count > 0)
        {
            Console.WriteLine(CalcSum(numbers));
            Console.WriteLine(CalcAverage(numbers));
        }
    }
}

