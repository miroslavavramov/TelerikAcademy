using System;
using System.IO;
//Write a program that reads a text file and prints on the console its odd lines.
class PrintOddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\someText.txt ");

        using (reader)
        {
            string line = reader.ReadLine();

            for (int i = 1; line != null; i++, line = reader.ReadLine())
            {
                if ((i & 1) != 0) { Console.WriteLine(line); }
            }
        }
    }
}

