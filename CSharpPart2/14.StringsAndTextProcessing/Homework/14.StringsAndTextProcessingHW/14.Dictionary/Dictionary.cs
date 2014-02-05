using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//A dictionary is stored as a sequence of text lines containing words and their explanations.
//Write a program that enters a word and translates it by using the dictionary.
class Dictionary
{
    static void Main()
    {
        string[] words = {
                ".NET - platform for applications from Microsoft",
                "CLR - managed execution environment for .NET",
                "namespace - hierarchical organization of classes"
        };

        Dictionary<string, string> dict = new Dictionary<string, string>();
        
        foreach (var word in words)
        {
            int dash = word.IndexOf('-');
            dict.Add(word.Substring(0, dash-1), word.Substring(dash, word.Length-dash));
        }
        try
        {
            Console.WriteLine(dict[Console.ReadLine()]);
        }
        catch (KeyNotFoundException e) { Console.WriteLine(e.Message); }
    }
}

