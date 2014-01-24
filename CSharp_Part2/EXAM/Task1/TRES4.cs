using System;
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        string numInBase9 = ToBase9(BigInteger.Parse(Console.ReadLine()));

        var output = new StringBuilder();

        for (int i = 0; i < numInBase9.Length; i++)
        {
            output.Append(ToTres4(numInBase9[i]));
        }

        Console.WriteLine(output);
    }
    static string ToBase9(BigInteger n)
    {
        if (n == 0)
        {
            return "0";
        }
        var output = new StringBuilder();

        for (BigInteger i = n; i > 0; i/=9)
        {
            output.Insert(0, (char)((i % 9) + '0'));
        }

        return output.ToString();
    }
    static string ToTres4(char c)
    {
        switch (c)
        {
            default: return null;
                
            case '0': return "LON+";
            case '1': return "VK-";
            case '2': return "*ACAD";
            case '3': return "^MIM";
            case '4': return "ERIK|";
            case '5': return "SEY&";
            case '6': return "EMY>>";
            case '7': return "/TEL";
            case '8': return "<<DON";
        }
    }
}

