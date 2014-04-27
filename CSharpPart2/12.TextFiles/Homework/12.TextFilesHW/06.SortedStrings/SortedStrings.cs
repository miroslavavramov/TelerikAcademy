using System;
using System.IO;
using System.Collections.Generic;
//Write a program that reads a text file containing a list of strings,
// sorts them and saves them to another text file. Example:
    //Ivan			George
    //Peter	 -->    Ivan
    //Maria			Maria
    //George		Peter

class SortedStrings
{
    static void Main()
    {
        List<string> words = ReadStringsFromFile(@"..\..\input.txt");

        WriteSortedStringsToFile(words, @"..\..\output.txt");
    }

    static List<string> ReadStringsFromFile(string path) 
    {
        List<string> words = new List<string>();

        using (StreamReader reader = new StreamReader(path))
        {
            for (string line;(line = reader.ReadLine()) != null;)
            {
                words.Add(line);
            }
        }

        return words;
    }

    static void WriteSortedStringsToFile(List<string> words, string path)
    {
        words.Sort();

        using (StreamWriter writer = new StreamWriter(path))
        {
            for (int i = 0; i < words.Count; i++) 
            {
                writer.WriteLine(words[i]); 
            }
        }
    }
}


