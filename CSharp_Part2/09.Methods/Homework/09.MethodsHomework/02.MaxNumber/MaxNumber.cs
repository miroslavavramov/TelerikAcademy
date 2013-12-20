using System;
//Write a method GetMax() with two parameters that returns the bigger of two integers. 
//Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

class Program
{
    static void Main()
    {
        try
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int biggestNum = GetMax(firstNum, GetMax(secondNum, thirdNum));
            Console.WriteLine("Biggest : {0}", biggestNum);
        }
        catch(FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch(OverflowException ofe)
        {
            Console.WriteLine(ofe.Message);
        }
    }
    static int GetMax(int a, int b)
    {
        return a > b ? a : b;
    }
}

