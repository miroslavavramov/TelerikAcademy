using System;
//Write a program to convert decimal numbers to their hexadecimal representation.
class DecToHex
{
    static void Main()
    {
        Console.WriteLine(ToHex(int.Parse(Console.ReadLine())));
    }
    static string ToHex(int n)
    {
        string hex = "";

        for (int i = n; i > 0; i >>= 4)     
            hex += (char)((i & 15) > 9 ? ((i & 15) + 'A' - 10) : ((i & 15) + '0')); // x % 16 == x & 15

        return Reverse(hex);
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();
        return new string(arr);
    }
}

