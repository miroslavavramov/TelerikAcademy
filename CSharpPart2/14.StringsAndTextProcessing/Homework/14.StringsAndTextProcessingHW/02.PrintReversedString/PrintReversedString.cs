using System;
//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

class PrintReversedString
{
    static void Main()
    {
        Console.WriteLine(Reverse(Console.ReadLine()));
    }

    static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);

        return new string(charArray);
    }
}

