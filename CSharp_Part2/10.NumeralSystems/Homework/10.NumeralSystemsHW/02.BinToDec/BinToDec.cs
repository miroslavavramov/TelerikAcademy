using System;
class BinToDec
{
    static void Main()
    {
        Console.WriteLine(ToDec(Console.ReadLine()));
    }
    static int ToDec(string binary)
    {
        int dec = binary[binary.Length - 1] - '0';

        for (int i = binary.Length-2; i >= 0; i--)
            dec += binary[i] != '0' ? 2 << (binary.Length - 2 - i) : 0;     
        
        return dec;
    }
}

