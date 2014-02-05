using System;
//* Write a program that shows the internal binary representation of given 32-bit 
//signed floating-point number in IEEE 754 format (the C# type float). 
//Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

class FloatToBin
{                                                                                                       
    static void Main()                                                                                  
    {
        float f = float.Parse(Console.ReadLine());          
        char msb = f >= 0 ? '0' : '1';                      //determine the most significant bit (sign)
        int power = 0;
        int exp = 0;
        string mantissa = "";

        f = Math.Abs(f);                                    //use abs. value i.o. to simplfy calculations
        if (f > 1) { for (; f > 2; f /= 2) power++; }       //normalize by dividing  by 2 so f = 1.YYYYY * 2^power
        else { for (; f < 1; f*=2) power--; }               // f = 1.YYYYY * 2^(-power)
        exp = power + 127;                                  //calculate the decimal value of the exponent

        f = (f - 1) * 2;                                    //only the fractional part of the normalized number is to be used

        for (; mantissa.Length < 23; f *= 2)
        {
            mantissa += f >= 1 ? "1" : "0";
            f = f >= 1 ? f - 1 : f;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(msb);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(ToBinary(exp));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mantissa);
        Console.ResetColor();
    }
    static string ToBinary(int n)
    {
        string binary = "";
        
        for (int i = n; i != 0; i >>= 1)
            binary += (char)('0' + (i & 1));

        return n == 0 ? "0".PadLeft(8, '0') : Reverse(binary.PadRight(8, '0'));
    }
    static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        s = arr.ToString();
        return new string(arr);
    }
}

