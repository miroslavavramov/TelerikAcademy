using System;
using System.Text;
//Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. The encoding/decoding is done by performing XOR 
//(exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, etc. When the last key character is reached, the next is the first.

class EncodeDecodeString
{
    private static string key = "Luke, I'm%Your$Father!_";

    static void Main()
    {
        string input = Console.ReadLine();

        Console.WriteLine("Encoded: {0}", Code(input));
        Console.WriteLine("Decoded: {0}", Code(Code(input)));
    }

    static string Code(string s)
    {
        var output = new StringBuilder();
        int k = 0;  //key index

        for (int i = 0; i < s.Length; i++, k++)
        {
            if (k == key.Length) k = 0;
            {
                output.Append((char)(s[i] ^ key[k]));
            }
        }

        return output.ToString(); 
    }
    
}
