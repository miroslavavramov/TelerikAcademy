/*Write a program that counts how many times each word from given text file words.txt 
 appears in it. The character casing differences should be ignored. 
 The result words should be ordered by their number of occurrences in the text.*/

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class CountWordsInText
{
    static void Main()
    {
        string text = "";

        using (var sr = new StreamReader(@"../../words.txt"))
        {
            text = sr.ReadToEnd();
        }

        var dict = Regex.Matches(text, @"\w+")
            .Cast<Match>()
            .Select(m => m.Value.ToLower())
            .GroupBy(w => w)
            .ToDictionary(w => w.Key, w => w.Count())
            .OrderBy(kvp => kvp.Value);

        foreach (var kvp in dict)
        {
            Console.WriteLine(kvp);
        }
    }
}

