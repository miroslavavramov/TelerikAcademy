using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
class ExtractTextFromHTML
{
    static void Main()
    {
        string html = @"<html><head><title>News</title></head><body>
<p><a href=""http://academy.telerik.com\>TelerikAcademy</a>
aims to provide free real-world practical training for young people who 
want to turn into skillful.NET software engineers.</p></body></html>";

        string tag = @"<[a-z ./"":=\\]*>";
        var text = Regex.Replace(html, tag, String.Empty);

        Console.WriteLine(text);
    }
}