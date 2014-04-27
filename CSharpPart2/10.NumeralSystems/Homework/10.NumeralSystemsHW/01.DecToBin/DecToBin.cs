using System;
//Write a program to convert decimal numbers to their binary representation.
class DecToBin
{
    static void Main()                                                          
    {
        int n = int.Parse(Console.ReadLine());      
                                                                                // x * (2^y) == x << y         
        Console.WriteLine(ToBinary(n));                                         // x / (2^y) == x >> y
        Console.WriteLine(RecursiveDecToBin(n));                                // x % y == x & (y-1) 
    }       
                                                                                
    static string ToBinary(int n)                                                           
    {
        string binary = "";

        for (int i = n; i != 0; i >>= 1)
        {
            binary += (char)('0' + (i & 1));    
        }
                                       
        return n == 0 ? "0" : Reverse(binary);                                                         
    }

    static string RecursiveDecToBin(int n)
    {
        string bin = string.Empty;

        if (n > 1)
        {
            return bin = RecursiveDecToBin(n / 2) + (n % 2).ToString();
        }

        return (n % 2).ToString();
    }    
                                                                           
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();

        return new string(arr);
    }
}






