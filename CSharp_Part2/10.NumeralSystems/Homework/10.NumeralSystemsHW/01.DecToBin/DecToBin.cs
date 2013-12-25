using System;
//Write a program to convert decimal numbers to their binary representation.
class DecToBin
{
    static void Main()                                                          // x * (2^y) == x << y
    {                                                                           // x / (2^y) == x >> y
        Console.WriteLine(ToBinary(int.Parse(Console.ReadLine())));             // x % y == x & (y-1)          
    }                                                                                       
    static string ToBinary(int n)                                                           
    {
        string binary = "";

        for (int i = n; i != 0; i >>= 1)        
            binary += (char)('0' + (i & 1));    
                                                                                       
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






