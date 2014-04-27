using System;
using System.Text.RegularExpressions;
//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
class ExtractPalindomes
{
    static void Main()
    {
        string text = @"Some people have names that are palindromes. Included are given names 
                        (Ada, Anna, Bob, Aviva), surnames (Harrah, Renner, Salas, Arora) 
                        or both (Eve, Hannah, Maham, Otto)";

        var words = Regex.Matches(text, @"\b\w+\b");

        foreach (var word in words)
        {
            if (IsPalindrome(word.ToString().ToUpper()))
            { 
                Console.WriteLine(word); 
            }
        }
    }

    static bool IsPalindrome(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}
