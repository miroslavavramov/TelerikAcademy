using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Program
{
    static Dictionary<char, int> dict = new Dictionary<char, int>();

    static void ParseInput()
    {
        string input = Console.ReadLine();

        foreach (var ch in input)
        {
            if (!dict.ContainsKey(ch))
            {
                dict.Add(ch, 0);
            }
            dict[ch]++;
        }
    }

    static BigInteger Fact(int n)
    {
        BigInteger result = 1;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    static void PrintResult()
    {
        BigInteger result = 0;
        BigInteger numerator = Fact(dict.Values.Sum());
        BigInteger denominator = 1;

        foreach (var item in dict)
        {
            denominator *= Fact(item.Value);
        }

        result = numerator / denominator;

        Console.WriteLine(result);
    }

    static void Main()
    {
        ParseInput();
        PrintResult();
    }
}

