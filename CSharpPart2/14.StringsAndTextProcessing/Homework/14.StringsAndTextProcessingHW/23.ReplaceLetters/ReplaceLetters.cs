using System;
//Write a program that reads a string from the console and replaces all series 
//of consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
class ReplaceLetters
{
    static void Main()
    {
        string s = "aaaaabbbbbcdddeeeedssaa";

        for (int i = 0; i < s.Length; i++)
        {
            for (int k = i+1; k < s.Length; k++)
            {
                if (s[k] == s[i]) 
                { 
                    s = s.Remove(k, 1); 
                    k--; 
                }
                else 
                {
                    break; 
                }
            }
        }

        Console.WriteLine(s);
    }
}

