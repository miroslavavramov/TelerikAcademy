using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
//Write a program that removes from a text file all words listed in given another text file. 
//Handle all possible exceptions in your methods.
class DeleteWords2
{
    static void Main()
    {
        try
        {
            List<string> words = SeparateWordsFromText(@"..\..\text.txt");
            List<string> wordsToRemove = SeparateWordsFromText(@"..\..\wordsToRemove.txt");

            using (StreamWriter writer = new StreamWriter(@"..\..\remainingWords.txt"))
            {
                for (int i = 0; i < words.Count; i++)
                    if (!wordsToRemove.Contains(words[i]))
                        writer.WriteLine(words[i]);
            }
            
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine(fnfe.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine(dnfe.Message);
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (System.Security.SecurityException se)
        {
            Console.WriteLine(se.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine(uae.Message);
        }
    }
    static List<string> SeparateWordsFromText(string path)
    {
        List<string> list = new List<string>();
        using (StreamReader reader = new StreamReader(path))
        {
            string text = reader.ReadToEnd();
            list = new List<string>(text.Split(' ', ',', '.', '!', '?',':',';', '(', ')', '\n'));
            list.RemoveAll(string.IsNullOrEmpty);
        }
        return list;
    }
}

