using System;
using System.Text;
using System.Text.RegularExpressions;
//Write a program that extracts from a given text all sentences containing given word.
class ExtractSentences
{
    static void Main()
    {
        string text =  "We are living in a yellow submarine. We don't have anything else." +
                       "Inside the submarine is very tight. So we are drinking all the day." + 
                       "We will move out of it in 5 days.";

        string word = "in";
        string pattern = @"[a-zA-Z\s,]*\b"+word+@"\b[a-zA-Z\s,0-9]*[.?!]";

        var extractedSentences = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        foreach (var sentence in extractedSentences)
            Console.WriteLine(sentence);

        
    }
}

