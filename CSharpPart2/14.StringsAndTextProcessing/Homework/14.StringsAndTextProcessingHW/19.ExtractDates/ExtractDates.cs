using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
//Display them in the standard date format for Canada.
class ExtractDates
{
    static void Main()
    {
        string text = "John was born on 24.12.1971 and his wife July was born on 31.5.1974.";

        string datePattern = @"\b\d+.\d+.\d+\b";
        var dates = Regex.Matches(text, datePattern);

        foreach (var date in dates)
        {
            Console.WriteLine(
                DateTime.Parse(date.ToString()).ToString("d", new CultureInfo("en-CA"))
                );
        }
    }
}
