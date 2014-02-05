using System;
//Write a method that reverses the digits of given decimal number. Example: 256  652
class ReverseDigits
{
    static void Main()
    {
        try
        {
            Console.Write("Number = ");
            Console.WriteLine("Reversed: {0}", Reverse(int.Parse(Console.ReadLine())));
        }
        catch (FormatException fe)
        { Console.WriteLine(fe.Message); }
        catch (OverflowException ofe)
        { Console.WriteLine(ofe.Message); }
    }
    static int Reverse(int n)
    {
        int result = 0;
        while (n > 0)
        {
            result = result * 10 + n % 10;
            n /= 10;
        }
        return result;
    }
}

