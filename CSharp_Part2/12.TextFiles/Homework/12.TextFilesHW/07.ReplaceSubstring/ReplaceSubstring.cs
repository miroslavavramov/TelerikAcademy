﻿using System;
using System.IO;
using System.Collections.Generic;
//Write a program that replaces all occurrences of the substring "start" with the substring
// "finish" in a text file. Ensure it will work with large files (e.g. 100 MB).
class ReplaceSubstring
{
    static void Main()
    {
        using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
        {
            using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
            {
                writer.WriteLine(reader.ReadToEnd().Replace("start", "finish"));
            }
        }
    }
}

