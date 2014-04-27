using System;
using System.Collections.Generic;
//Write a program that reads a string from the console and prints all different letters 
//in the string along with information how many times each letter is found. 
class ExtractLetters
{
    static void Main()
    {
        string text = "Write a program that reads a string from the console and prints all different letters";

        Dictionary<char, int> letters = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (IsLetter(text[i]) && !letters.ContainsKey(text[i]))
            {
                letters.Add(text[i], 1);
            }
            else if (IsLetter(text[i]))
            {
                letters[text[i]] += 1;
            }
        }

        foreach (var letter in letters)
        {
            Console.WriteLine("{0} {1}", letter.Key, letter.Value);
        }
    }

    static bool IsLetter(char ch)
    {
        return (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122);
    }
}

