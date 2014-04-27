using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//Write a program that reverses the words in given sentence.
//Example: "C# is not C++, not PHP and not Delphi!" : "Delphi not and PHP, not C++ not is C#!".

class ReverseWordsInSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP and not Delphi!";
        
        string pattern = @"[\w+.]*[^, !?.]|,|:";

        var words = Regex.Matches(sentence, pattern);
        var reversed = new StringBuilder();

        for (int i = words.Count - 1; i >= 0; i--)
        {
            reversed.Append(words[i] + " ");
        }

        reversed.Append(sentence[sentence.Length - 1]);
        
        Console.WriteLine(reversed);
    }
}

