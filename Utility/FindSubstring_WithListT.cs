using System;
using System.Collections.Generic;

// 09. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
// Example: 3, -2, 1, 1, 8  1+1-2=0.

class Program
{
    static void Main()
    {
        Console.Write("Define the set size: ");
        int setSize = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        for (int i = 0; i < setSize; i++)
        {
            Console.WriteLine("Enter number: ");
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        List<int> sum = new List<int>();
        sum.Add(0);

        List<string> subset = new List<string>();
        subset.Add("Subset {");

        int length = sum.Count;

        foreach (var element in numbers) //.............//
        {                                               //
            for (int i = 0; i < length; i++)            //
            {                                           //
                sum.Add(sum[i] + element);              // Here we find the sum
                subset.Add(subset[i] + "  " + element); // of all posibble subsets
            }                                           //
            length = sum.Count;                         //
        }                                //.............//

        for (int i = 1; i < length; i++) //....................//
        {                                                      //
            if (sum[i] == 0)                                   //
            {                                                  // Here we print them
                Console.Write("{0,-20} {1}", subset[i], "}");  // if the sum is Zero
                Console.WriteLine("{0}{1}", " = ", sum[i]);    //
            }
        }


    }
}

