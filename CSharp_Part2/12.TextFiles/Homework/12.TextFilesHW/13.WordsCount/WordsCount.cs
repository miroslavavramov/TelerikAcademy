using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
//Write a program that reads a list of words from a file words.txt and finds how many 
//times each of the words is contained in another file test.txt. The result should be written 
//in the file result.txt and the words should be sorted by the number of their occurrences 
//in descending order. Handle all possible exceptions in your methods.
class WordsCount
{
    static void Main()
    {
        List<string> words = SeparateWordsFromText(@"..\..\words.txt");
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\result.txt")) 
            { 
                string text = reader.ReadToEnd();
                int count;

                for (int i = 0; i < words.Count; i++)
                {
                    count = Regex.Matches(text, @"\b" + words[i] + @"\b").Count;
                    result.Add(words[i], count);
                }

                result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                foreach (var item in result)
                    writer.WriteLine("word \"{0}\" occurs {1} times", item.Key, item.Value);
            }
        }

    }
    static List<string> SeparateWordsFromText(string path)
    {
        List<string> list = new List<string>();
        using (StreamReader reader = new StreamReader(path))
        {
            string text = reader.ReadToEnd();
            char[] separators = { ' ', ',', '.', '!', '?', ':', ';', '(', ')', '\r', '\n'};
            list = new List<string>(text.Split(separators, StringSplitOptions.RemoveEmptyEntries));
        }
        return list;
    }
    
}

