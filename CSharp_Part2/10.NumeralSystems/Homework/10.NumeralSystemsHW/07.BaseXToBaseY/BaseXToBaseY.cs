using System;
//Write a program to convert from any numeral system of given base s 
//to any other numeral system of base d (2 ≤ s, d ≤  16).
class BaseXToBaseY
{
    static void Main()
    {
        Console.WriteLine(ConvertBaseXToBaseY("653", 11, 2));
        Console.WriteLine(ConvertBaseXToBaseY("52", 7, 9));
        Console.WriteLine(ConvertBaseXToBaseY("AA",12,14));
        Console.WriteLine(ConvertBaseXToBaseY("777",8,15));
        Console.WriteLine(ConvertBaseXToBaseY("B0A", 16,3));
        Console.WriteLine(ConvertBaseXToBaseY("911", 13, 4));
        Console.WriteLine(ConvertBaseXToBaseY("98A", 15, 6));
        Console.WriteLine(ConvertBaseXToBaseY("130001",4,5));
    }
    static string ConvertBaseXToBaseY(string num, int x, int y)
    {
        int numToBase10 = 0;
        for (int i = num.Length - 1; i >= 0; i--)
            numToBase10 += CheckDigit(num, i) * (int)Math.Pow(x, num.Length - i - 1);
        
        string numToBaseY = "";

        for (int i = numToBase10; i > 0; i/=y)
            numToBaseY += (char)((i % y) > 9 ? (i % y) + 'A' - 10 : (i % y) + '0');
        
        return Reverse(numToBaseY);
    }
    static int CheckDigit(string s, int pos)
    {
        if (s[pos] > '9') { return s[pos] - 'A' + 10; }
        return s[pos] - '0';
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();
        return new string(arr);
    }
}

