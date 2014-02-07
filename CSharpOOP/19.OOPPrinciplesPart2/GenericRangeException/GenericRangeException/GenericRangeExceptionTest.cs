using System;
using System.Collections.Generic;

class GenericRangeExceptionTest
{
    static void Main()
    {
        InvalidRangeException<int> integerRangeTest =
            new InvalidRangeException<int>(1, 100);

        Console.Write("To get an error enter a number outside the [1..100] interval: ");
        int num = int.Parse(Console.ReadLine());

        if (!(num >= integerRangeTest.Min && num <= integerRangeTest.Max))
        {
            throw integerRangeTest;
        }

        InvalidRangeException<DateTime> dateTimeRangeTest =
            new InvalidRangeException<DateTime>("Input date is outside the specified range!",
                new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));

        Console.Write("To get an error enter a date outside the [1.1.1980..31.12.2013]: ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        if(!(date >= dateTimeRangeTest.Min && date <= dateTimeRangeTest.Max))
        {
            throw dateTimeRangeTest;
        }
    }
}

