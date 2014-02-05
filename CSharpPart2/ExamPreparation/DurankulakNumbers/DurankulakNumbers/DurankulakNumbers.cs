using System;
using System.Collections.Generic;
class DurankulakNumbers
{
    static List<string> durankulakNumber;
    static List<string> ExtractDigits(string input)
    {
        List<string> durankulakNumber = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] <= 90) 
                durankulakNumber.Add(input[i].ToString());
            else if (input[i] >= 97)
                durankulakNumber.Add(string.Format("{0}{1}", input[i], input[i + 1])); i++;
        }
        return durankulakNumber;
    }
    static ulong GetDecimalValue(string s)
    {
        if (s.Length > 1)
            return (ulong)(26 * ((s[0] - 'a') + 1) + (s[1] - 'A'));

        return (ulong)(s[0] - 'A');
    }
    static ulong ConvertToBase10(List<string> digits)
    {
        ulong result = 0;

        for (int i = 0; i < digits.Count; i++)
            result += (ulong)Math.Pow(168, i) * GetDecimalValue(digits[digits.Count - 1 - i]);
        
        return result;
    }
    static void Main()
    {
        Console.WriteLine(ConvertToBase10(durankulakNumber = ExtractDigits(Console.ReadLine())));       
    }
   
}

