using System;
//Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.
class IsLeapYear
{
    static void Main()
    {
        int year = int.Parse(Console.ReadLine());
        bool isLeapYear = DateTime.IsLeapYear(year);
        Console.WriteLine("{0} is leap year? : {1}", year, isLeapYear);
    }
}

