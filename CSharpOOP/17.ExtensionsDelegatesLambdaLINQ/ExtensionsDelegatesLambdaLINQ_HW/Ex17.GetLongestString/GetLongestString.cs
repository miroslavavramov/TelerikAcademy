using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to return the string with maximum length from an array of strings. Use LINQ.

class GetLongestString
{
    static void Main()
    {
        string[] arr = 
            "Write a program to return the string with maximum length from an array of strings. Use LINQ."
            .Split();

        var orderedByLength =
            from str in arr
            orderby str.Length descending
            select str;

        Console.WriteLine(orderedByLength.First());

        string longestStr = arr.Aggregate((longest, current) => longest.Length > current.Length ? longest : current);

        Console.WriteLine(longestStr);
    }
}

