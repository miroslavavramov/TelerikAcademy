using System;
using System.IO;
//Write a program that compares two text files line by line and prints the number of lines that 
//are the same and the number of lines that are different. Assume the files have equal number of lines.
class CompareTextFiles
{
    static void Main()
    {
        using (StreamReader reader1 = new StreamReader(@"..\..\text1.txt"))
        using (StreamReader reader2 = new StreamReader(@"..\..\text2.txt"))
        {
            int matchingLines = 0;
            int differentLines = 0;

            for (string line; (line = reader1.ReadLine()) != null; )
            {
                if (line == reader2.ReadLine())
                { matchingLines++; }
                else
                { differentLines++; }
            }
            Console.WriteLine("Matching Lines : " + matchingLines);
            Console.WriteLine("Total Lines : " + (matchingLines + differentLines));
        }
    }
}

