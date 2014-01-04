using System;
using System.IO;
using System.Collections.Generic;
//Write a program that deletes from given text file all odd lines. The result should be in the same file.
class DeleteOddLines
{
    static void Main()
    {
        List<string> evenLines = new List<string>();

        using (StreamReader reader = new StreamReader(@"..\..\text.txt"))
        {
            int i = 1;
            for (string line; (line=reader.ReadLine()) != null; i++)
            {
                if ((i & 1) == 0) evenLines.Add(line); 
            }
        }
        using (StreamWriter writer = new StreamWriter(@"..\..\text.txt"))
        {
            for (int i = 0; i < evenLines.Count; i++)
            {
                writer.WriteLine(evenLines[i]);
            }
        }
        
    }
}

