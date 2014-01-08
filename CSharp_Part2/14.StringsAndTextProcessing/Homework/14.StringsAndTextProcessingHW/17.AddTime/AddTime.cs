﻿using System;
using System.Globalization;
//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
class AddTime
{
    static void Main()
    {
        Console.Write("Enter Date and Time (dd.mm.yyyy hh:mm:ss) : ");
        
        DateTime date = DateTime.Parse(Console.ReadLine()).AddHours(6.5);

        Console.WriteLine(date + " " + date.ToString("dddd", new CultureInfo("bg-BG")));
    }
}

