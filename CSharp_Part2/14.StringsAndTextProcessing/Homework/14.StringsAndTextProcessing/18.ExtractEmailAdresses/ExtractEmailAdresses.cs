using System;
using System.Text.RegularExpressions;
//Write a program for extracting all email addresses from given text. All substrings that match 
//the format <identifier>@<host>…<domain> should be recognized as emails.
class ExtractEmailAdresses
{
    static void Main()
    {
        string text = "Nemo Nobody(nobody@nowhere.com) has just sent an email to Santa Claus at your_santa@lappland.net.";
        string emailPattern = @"\b[A-za-z0-9._+-]+@+[A-Za-z0-9.]+.[a-z0-9]\b";
        var emails = Regex.Matches(text, emailPattern);

        foreach (var item in emails)
            Console.WriteLine(item);       
    }
}