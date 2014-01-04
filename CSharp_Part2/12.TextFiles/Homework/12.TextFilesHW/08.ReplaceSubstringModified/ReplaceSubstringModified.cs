using System;
using System.IO;
using System.Text.RegularExpressions;
//Modify the solution of the previous problem to replace only whole words (not substrings).
class ReplaceSubstringModified
{
    static void Main()
    {
        using (StreamWriter writer = new StreamWriter(@"..\..\output.txt"))
        {
            using (StreamReader reader = new StreamReader(@"..\..\input.txt"))
            {
                writer.WriteLine(Regex.Replace(reader.ReadToEnd(), "@\b(start)\b", "finish"));
            }
        }
    }
}

