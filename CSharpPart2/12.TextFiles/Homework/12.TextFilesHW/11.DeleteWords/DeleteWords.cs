using System;
using System.IO;
using System.Text.RegularExpressions;
//Write a program that deletes from a text file all words that start with the prefix "test".
//Words contain only the symbols 0...9, a...z, A…Z, _.
class DeleteWords
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
            {
                string text = reader.ReadToEnd();

                writer.WriteLine(Regex.Replace(text, @"\b(test)\w*", ""));
            }
        }
    }
}

