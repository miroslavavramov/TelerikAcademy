using System;
using System.Collections.Generic;
//We are given a string containing a list of forbidden words and a text 
//containing some of these words. Write a program that replaces the forbidden words with asterisks. 
class ForbiddenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today.\n" +
                      "It is based on .NET Framework 4.0\nand is implemented as" +
                      "a dynamic language in CLR.\n\n";

        List<string> forbiddenWords = new List<string>() {"PHP", "CLR", "Microsoft" };

        foreach (var word in forbiddenWords)
        {
            text = text.Replace(word, new string('*', word.Length));
        }

        Console.WriteLine(text);
    }
}

