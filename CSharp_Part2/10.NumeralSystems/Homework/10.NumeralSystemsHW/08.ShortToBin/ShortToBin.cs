using System;
//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
class ShortToBin
{
    static void Main()
    {
        short s = short.Parse(Console.ReadLine());

        Console.WriteLine(BinaryRep(s));
        //Console.WriteLine(Convert.ToString(s, 2).PadLeft(16, '0'));
    }
    static string BinaryRep(short n)
    {
        string b = string.Empty;
        int x = n >= 0 ? n : (1 << 15) + n;
        for (int i = x; i > 0; i >>= 1) b += i & 1;

        return n >= 0 ? Reverse(b.PadRight(16,'0')) : Reverse(b.PadRight(16,'1'));
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();
        return new string(arr);
    }
    
}

