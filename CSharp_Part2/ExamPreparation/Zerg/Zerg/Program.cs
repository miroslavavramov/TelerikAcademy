using System;

class Program
{
    static void Main()
    {
        string zergNum = Console.ReadLine();
        string temp = "";
        long power = zergNum.Length / 4 - 1;
        long result = 0;

        for (int i = 0; i < zergNum.Length; i+=4, power--)
        {
            temp = zergNum.Substring(i,4);

            result += (long)(ParseString(temp)*ToPower(power));
        }
        Console.WriteLine(result);
    }
    static long ToPower(long p)
    {
        long sum = 1;

        for (int i = 0; i < p; i++)
        {
            sum *= 15;    
        }
        return sum;
    }
    static long ParseString(string s)
    {
        switch (s)
        {
            default: return -1;
            case "Rawr": return 0;
            case "Rrrr": return 1;
            case "Hsst": return 2;
            case "Ssst": return 3;
            case "Grrr": return 4;
            case "Rarr": return 5;
            case "Mrrr": return 6;
            case "Psst": return 7;
            case "Uaah": return 8;
            case "Uaha": return 9;
            case "Zzzz": return 10;
            case "Bauu": return 11;
            case "Djav": return 12;
            case "Mjau": return 13;
            case "Gruh": return 14;
        }
    }
}

