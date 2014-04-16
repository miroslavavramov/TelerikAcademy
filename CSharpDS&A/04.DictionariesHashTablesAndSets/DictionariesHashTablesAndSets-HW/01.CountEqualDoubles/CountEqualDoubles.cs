/*Write a program that counts in a given array of double values the
 number of occurrences of each value. Use Dictionary<TKey,TValue>.*/

using System;
using System.Collections.Generic;
using System.Linq;

class CountEqualDoubles
{
    static void Main()
    {
        var nums = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
        var dict = new SortedDictionary<double, int>();
        
        foreach (var n in nums)
        {
            if (!dict.ContainsKey(n))
            {
                dict.Add(n, 1);
            }
            else
            {
                dict[n]++;
            }
        }

        foreach (var kvp in dict)
        {
            Console.WriteLine("{0} -> {1} times", kvp.Key, kvp.Value);
        }

        var groupedUsingLambda = nums.GroupBy(n => n)
            .ToDictionary(n => n.Key, n => n.Count())
            .OrderBy(n => n.Key);

        foreach (var kvp in groupedUsingLambda)
        {
            Console.WriteLine("{0} -> {1} times", kvp.Key, kvp.Value);
        }
    }
}

