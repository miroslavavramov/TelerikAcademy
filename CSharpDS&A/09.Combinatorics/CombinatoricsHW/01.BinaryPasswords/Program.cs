using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static ulong Pow(int p)
    {
        ulong result = 1;
             
        for (int i = 0; i < p; i++)
        {
            result *= 2;
        }

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();
        int n = input.Length - input.Replace("*","").Length;
        Console.WriteLine(Pow(n));
    }
}

