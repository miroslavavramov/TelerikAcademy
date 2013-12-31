using System;
//Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
class Workdays
{
    static readonly DateTime[] publicHolidays = {new DateTime(2013, 12, 24), new DateTime(2013,12,25), new DateTime(2013,12,30),
                                       new DateTime(2013, 12, 31), new DateTime(2014, 1, 1), new DateTime(2014,3,3),
                                       new DateTime(2014,5,6), new DateTime(2014,5,24), new DateTime(2014,9,6) };
    static void Main()
    {
        Console.Write("Enter date in DD/MM/YYYY format: ");
        string inputDate = Console.ReadLine();

        string[] endDate = inputDate.Split('/');
        int day = int.Parse(endDate[0]);
        int month = int.Parse(endDate[1]);
        int year = int.Parse(endDate[2]);

        Console.WriteLine("Between today and {0} there are {1} workdays.", inputDate, CalcWorkdays(new DateTime(year, month, day)));
    }
    static int CalcWorkdays(DateTime end)
    {
        int workdays = 0;
        DateTime date = DateTime.Now;

        for (; date <= end; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday
                && !(CheckIfPublicHoliday(date)))
            {
                workdays++;
            }
        }
        return workdays;
    }
    static bool CheckIfPublicHoliday(DateTime date)
    {
        bool isHoliday = false;

        for (int i = 0; i < publicHolidays.Length; i++)
        {
            if (publicHolidays[i].Month == date.Month
                && publicHolidays[i].Day == date.Day)
            {
                isHoliday = true;
                break;
            }
        }
        return isHoliday;
    }
}

