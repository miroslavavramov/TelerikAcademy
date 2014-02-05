using System;
//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 
class CalcTimespan
{
    static void Main()
    {
        DateTime[] dates = new DateTime[2];

        for (int i = 0; i <= 1; i++)
        {
            Console.Write("date {0} (dd.mm.yyyy): ",i+1);
            dates[i] = DateTime.Parse(Console.ReadLine());
        }

        var span = Math.Abs(dates[0].Subtract(dates[1]).Days);
        Console.WriteLine(span);
    }
}

