using System;
using System.Text;
//Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. 
class UnicodeLiterals
{
    static void Main()
    {
        Console.WriteLine(ToUnicode(Console.ReadLine()));   
    }
    static string ToUnicode(string s)
    {
        var output = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
            output.Append(@"\u" + string.Format("{0:X4}", (int)s[i]));

        return output.ToString();
    }
}

