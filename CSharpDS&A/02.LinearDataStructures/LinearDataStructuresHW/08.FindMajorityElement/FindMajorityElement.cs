//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
//Write a program to find the majorant of given array (if exists). Example:
//{2, 2, 3, 3, 2, 3, 4, 3, 3}  3

using System;
using System.Linq;

class Program
{
    static int? FindMajorant(int[] arr)
    {
        /* Moore's voting algorithm */

        int candidate = 0;
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (count == 0)
            {
                candidate = arr[i];
            }

            if (candidate == arr[i])
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        int candidateOccurances = arr.Count(x => x == candidate);

        if (candidateOccurances > arr.Length / 2)
        {
            return candidate;
        }
        else
        {
            return null;
        }
    }

    static void Main()
    {
        var numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
        
        var majorant = FindMajorant(numbers);

        if (majorant != null)
        {
            Console.WriteLine(majorant);
        }
        else
        {
            Console.WriteLine("There is no majority element");
        }
    }
}

