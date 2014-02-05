using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static string Decode(string seq)
    {
        var output = new StringBuilder();
        string number = string.Empty;

        for (int i = 0; i < seq.Length; i++)
        {
            if (char.IsDigit(seq[i]))
            {
                number += seq[i];
            }
            else if (!string.IsNullOrEmpty(number))
            {
                output.Append(new string(seq[i], int.Parse(number)));
                number = string.Empty;
            }
            else
            {
                output.Append(seq[i]);
            }
        }

        output.Append(number);
        return output.ToString();
    }
    static string Decrypt(string message, string cypher)
    {
        var output = new StringBuilder(message);

        var length = Math.Max(message.Length, cypher.Length);
        int messageIndex = 0;
        int cypherIndex = 0;

        for (int i = 0; i < length; i++)
        {
            messageIndex = i % message.Length;
            cypherIndex = i % cypher.Length;

            int n = (output[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A');
            output[messageIndex] = (char)(n + 'A');
        }

        return output.ToString();
    }
    static string GetCypher(ref string message)
    {
        var cypherLen = new List<char>();

        for (int i = message.Length-1; i >= 0; i--)
        {
            if (char.IsDigit(message[i]))
            {
                cypherLen.Add(message[i]);
            }
            else break;
        }

        cypherLen.Reverse();
        string cypLen = "";

        foreach (var item in cypherLen) cypLen += item;

        int cypherLength = int.Parse(cypLen);

        string cypher = message.Substring(message.Length - cypLen.Length - cypherLength, cypherLength);
        message = message.Substring(0, message.Length - cypLen.Length - cypherLength);
        

        return cypher;
    }
    static void Main()
    {
        string message = Decode(Console.ReadLine());

        string cypher = GetCypher(ref message);

        Console.WriteLine(Decrypt(message, cypher));
    }
}
