
//We are given a date (day + month + year). Write a program to print the next day.
//The input data consists of 3 lines holding the integer numbers: day, month and year.
//The input data will always be valid and in the format described. There is no need to check it explicitly.
//The output data should be printed on the console in the format day.month.year (no leading zeroes).

using System;

    class Program
    {
        static void Main()
        {
            byte day = byte.Parse(Console.ReadLine());
            byte month = byte.Parse(Console.ReadLine());
            ushort year = ushort.Parse(Console.ReadLine());

            day++;

            if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                if (day > 30)
                {
                    day = 1;
                    month++;
                }
            }
            else if (month == 2)
            {
                if (year == 2000 || year == 2004 || year == 2008 || year == 2012)
                {
                    if (day > 29)
                    {
                        day = 1;
                        month++;
                    }
                }
                else
                {
                    if (day > 28)
                    {
                        day = 1;
                        month++;
                    }
                }
            }
            else 
            {
                if (day > 31)
                {
                    if (month == 12)
                    {
                        month = 1;
                        day = 1;
                        year++;
                    }
                    else
                    {
                        day = 1;
                        month++;
                        
                    }
                }
            }
            Console.WriteLine("{0}.{1}.{2}", day, month, year);
          
        }
    }
    


