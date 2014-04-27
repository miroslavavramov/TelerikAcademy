using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
class OrderAlphabetically
{
    static void Main()
    {
        string text = @"Write a program that reads a list of words, separated 
                        by spaces and prints the list in an alphabetical order.";

        var sep = Regex.Matches(text, @"\b\w+\b");

        List<string> words = new List<string>();

        foreach (var item in sep)
        {
            words.Add(item.ToString());
        }

        words.Sort();

        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
}