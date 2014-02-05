using System;
class BinToDec
{
    static void Main()
    {
        string bin = Console.ReadLine();
        Console.WriteLine(ToDec(bin));
        Console.WriteLine(RecursiveBinToDec(bin,0));
    }
    static int ToDec(string binary)
    {
        int dec = binary[binary.Length - 1] - '0';

        for (int i = binary.Length-2; i >= 0; i--)
            dec += binary[i] != '0' ? 2 << (binary.Length - 2 - i) : 0;     
        
        return dec;
    }
    static int RecursiveBinToDec(string b, int pos)
    {
        int d = 0;

        if (pos < b.Length - 1)
        {
            return d += RecursiveBinToDec(b, pos + 1) + (b[pos] - '0') * (int)Math.Pow(2, b.Length - 1 - pos);
        }
        return (b[pos] - '0') * (int)Math.Pow(2, b.Length - 1 - pos);
    }
}

