using System;
//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
//If an invalid number or non-number text is entered, the method should throw an exception. 
//Using this method write a program that enters 10 numbers:
//			a1, a2, … a10, such that 1 < a1 < … < a10 < 100

class CheckIfInRange
{
    static void Main()
    {
        try 
        {
            int a;

            for (int i = 0; i < 10; i++)
            {
                a = ReadNumber(1, 100);
            }
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (OverflowException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static int ReadNumber(int start, int end)
    {
        int a = int.Parse(Console.ReadLine());

        if (a <= start || a >= end)
        {
            throw new ArgumentOutOfRangeException(); 
        }

        return a;
    }
}

