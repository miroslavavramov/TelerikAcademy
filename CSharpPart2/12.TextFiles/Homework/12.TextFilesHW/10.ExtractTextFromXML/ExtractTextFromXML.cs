using System;
using System.Collections.Generic;
using System.IO;
//Write a program that extracts from given XML file all the text without the tags.
class ExtractTextFromXML
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\testXML.xml")) 
        {
            List<string> separatedWords = new List<string>();
            for (string line; (line = reader.ReadLine()) != null;)
            {
                for (int start = 0; start < line.Length; start++)
                {
                    if (line[start] == '>' && start != line.Length - 1)
                    {
                        int end = line.IndexOf('<', start);
                        separatedWords.Add(line.Substring(start + 1, end - start - 1).Trim());  //remove whitespaces
                        start += end;
                    }
                }
            }
            foreach (var word in separatedWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}

