using System;
//Write a program to convert hexadecimal numbers to their decimal representation.
class HexToDec
{
    static void Main()
    {
        Console.WriteLine(ToDec(Console.ReadLine()));
    }
    static int ToDec(string hex)
    {
        int dec = hex[hex.Length - 1] > '9' ? hex[hex.Length - 1] - 'A' + 10 : hex[hex.Length - 1] - '0';
        int n = 0;

        for (int i = hex.Length - 2; i >= 0; i--)
        {
            n = (int)(hex[hex.Length - 2 - i]);
            if (n > '9') { dec += (16 << 4 * i) * (n - 'A' + 10); } 
            else { dec += (16 << 4 * i) * (n - '0'); }
        }
        return dec;
    }
}

