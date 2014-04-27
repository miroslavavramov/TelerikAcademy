using System;
using System.Text.RegularExpressions;
//Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).
class CountSubstrings
{
    static void Main()
    {
        string text = @"We are living in an yellow submarine. We don't have anything else. 
                        Inside the submarine is very tight. So we are drinking all the day. 
                        We will move out of it in 5 days.";

        string pattern = "in";

        int matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase).Count;

        Console.WriteLine(matches);
    }
}

