using System;
using System.Text;
//Implement an extension method Substring(int index, int length) for the class StringBuilder 
//that returns new StringBuilder and has the same functionality as Substring in the class String.

static class StringBuilderExtensions
{
    public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
    {
        var output = new StringBuilder();

        return output.Append(sb.ToString().Substring(startIndex, length));
    }
}
class SubstringExtension
{
    static void Main()
    {
        Console.WriteLine(new StringBuilder("ABCDEFGHIJK").Substring(2,5));
    }
}
