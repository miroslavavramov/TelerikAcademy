using System;
//Write a program to convert hexadecimal numbers to binary numbers (directly).
class HexToBin
{
    static void Main()
    {
        Console.WriteLine(ToBin(Console.ReadLine()));
    }

    static string ToBin(string hex)
    {
        string bin = "";
        
        for (int i = hex.Length-1; i >= 0; i--)
        {
            for (int k = 0, n = hex[i] > '9' ? hex[i] - 'A' + 10 : hex[i] - '0'; k < 4; k++, n /= 2)
            {
                bin += (n & 1);
            }
                
        }
        
        return Reverse(bin);
    }

    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();

        return new string(arr);
    }
}

