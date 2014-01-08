using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//Write a program that reads a string from the console and lists all different words
//in the string along with information how many times each word is found.
class ExtractWords
{
    static void Main()
    {
        string text = @"Write a program that reads a string from the console and lists all the different words
                        in the string along with information how many times each of the words is found.";

        var sep = Regex.Matches(text, @"\b\w+\b");

        Dictionary<string, int> words = new Dictionary<string, int>(); ;

        for (int i = 0; i < sep.Count; i++)
        {
            if (!words.ContainsKey(sep[i].ToString())) 
                words.Add(sep[i].ToString(), 1);
            
            else words[sep[i].ToString()] += 1;
        }

        foreach (var word in words)
            Console.WriteLine("{0} {1}", word.Key, word.Value);
    }
}