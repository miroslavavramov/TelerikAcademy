using System;
//Write a program to convert decimal numbers to their binary representation.
class DecToBin
{
    static void Main()                                                          
    {                                                                           
        Console.WriteLine(ToBinary(int.Parse(Console.ReadLine())));                       
    }                                                                                       
    static string ToBinary(int n)                                                           
    {
        string binary = "";

        for (int i = n; i != 0; i >>= 1)        // i / 2
            binary += (char)('0' + (i & 1));    // i % 2
                                                                                       
        return Reverse(binary);                                                         
    }                                                                                   
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();
        return new string(arr);
    }
}






