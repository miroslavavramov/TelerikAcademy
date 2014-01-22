using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;
class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        var digits = new List<BigInteger>();
        BigInteger result = 0;
        string temp = "";

        for (int i = 0; i < input.Length; i++)
        {
            temp += input[i];

            if (GetNumericValue(temp) < 9)
            {
                digits.Add(GetNumericValue(temp));
                temp = "";
            }
        }

        digits.Reverse();

        for (int i = 0; i < digits.Count; i++)
        {
            result += (BigInteger)(digits[i] * (BigInteger)Math.Pow(9, i));
        }
        Console.WriteLine(result);
    }
    static BigInteger GetNumericValue(string s)
    {
        switch (s)
        {
            default: return 9;
            case "-!": return 0; 
            case "**": return 1; 
            case "!!!": return 2; 
            case "&&": return 3;
            case "&-": return 4;
            case "!-": return 5;
            case "*!!!": return 6;
            case "&*!": return 7;
            case "!!**!-": return 8;
        }
    }
}

