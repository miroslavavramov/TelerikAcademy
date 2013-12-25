using System;
//Write a program to convert binary numbers to hexadecimal numbers (directly).
class BinToHex
{
    static void Main()
    {
        Console.WriteLine(ToHex(Console.ReadLine()));
    }
    static string ToHex(string bin)
    {
        if ((bin.Length & 3) != 0)
        { bin = bin.Insert(0, new string('0', 4 - (bin.Length & 3))); } //add leading zeros if necessary

        string hex = "";
        int h = 0;
        for (int i = bin.Length-1; i >= 0; i-=4)
        {
            h = bin[i] - '0';
            for (int k = 0; k < 3; k++)
            {
                h += bin[i - 1 - k] != '0' ? (2 << k) : 0;
            }
            hex += (char)(h > 9 ? 'A' + h - 10 : '0' + h);
        }        
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

