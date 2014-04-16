/*Write a program that extracts from a given sequence of 
 strings all elements that present in it odd number of times.*/

using System;
using System.Collections.Generic;
using System.Linq;

class ExtractStringsAppearingOddTimes
{
    static void Main()
    {
        var seq = new string[]{"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        var dict = new Dictionary<string, int>();

        foreach (var str in seq)
        {
            if (!dict.ContainsKey(str))
            {
                dict.Add(str, 1);
            }
            else
            {
                dict[str]++;
            }
        }

        foreach (var kvp in dict)
        {
            if (kvp.Value % 2 != 0) 
            {
                Console.WriteLine("{0} -> {1} times", kvp.Key, kvp.Value);
            }
        }

        var groupedUsingLambda = seq.GroupBy(s => s)
            .ToDictionary(s => s.Key, s => s.Count())
            .Where(s => s.Value % 2 != 0);

        foreach (var kvp in groupedUsingLambda)
        {
            Console.WriteLine("{0} -> {1} times", kvp.Key, kvp.Value);
        }
    }
}

