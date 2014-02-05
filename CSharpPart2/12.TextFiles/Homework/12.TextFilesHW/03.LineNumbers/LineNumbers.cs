using System;
using System.IO;
//Write a program that reads a text file and inserts line numbers in front of each of its 
//lines. The result should be written to another text file.
class LineNumbers
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader(@"..\..\LineNumbers.cs"))
        using (StreamWriter writer = new StreamWriter(@"..\..\source.txt"))
        {
            int lineNumber = 1;
            for (string line; (line = reader.ReadLine()) != null; lineNumber++)
            {
                writer.WriteLine("Line {0}| {1}", lineNumber, line);
            }
        }
    }
}