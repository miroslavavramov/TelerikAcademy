using System;
using System.IO;
//Write a program that concatenates two text files into another text file.
class ConcatTextFiles
{
    static void Main()
    {
        string text1 = File.ReadAllText(@"..\..\text1.txt");
        string text2 = File.ReadAllText(@"..\..\text2.txt");
        File.WriteAllText(@"..\..\merged.txt", text1 + text2);
    }
}

