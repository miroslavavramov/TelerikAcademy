using System;
using System.Linq;
using System.Collections.Generic;
//You are given an array of strings. Write a method that sorts the array by the length 
//of its elements (the number of characters composing them).
class SortByLengthUsingLinq
{
    static void Main()
    {
        /*
        int n = int.Parse(Console.ReadLine());
        string[] words = new string[n];

        for (int i = 0; i < n; i++)
            words[i] = Console.ReadLine(); */

        string[] words = { "Luxemburg", "Canada", "China", "UAE", "Netherlands", "Brazil"};

        foreach (var word in Sort(words))
        {
            Console.WriteLine(word);
        }
    }
    static IEnumerable<string> Sort(IEnumerable<string> words)
    {
        var sorted = from word in words orderby word.Length ascending/*descending*/ select word;
        return sorted;
    }
}

