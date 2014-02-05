using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//You are given a text. Write a program that changes the text in all regions 
//surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.
class ConvertToUppercase
{
    static void Main()
    {
        string text = @"We are living in a <upcase>yellow submarine</upcase>.We don't have <upcase>anything</upcase> else.";

        string openingTag = "<upcase>";     //length == 8
        string closingTag = "</upcase>";    //length == 9

        int start = text.IndexOf(openingTag) + 8;
        int end = text.IndexOf(closingTag);
        string sub;

        while (start - 8 > 0)
        {
            sub = text.Substring(start, end - start).ToUpper();
            text = text.Replace(text.Substring(start-8, end - start + 17), sub);

            start = text.IndexOf(openingTag,start) + 8;
            end = text.IndexOf(closingTag,start);
        }

        Console.WriteLine(text);
    }
}