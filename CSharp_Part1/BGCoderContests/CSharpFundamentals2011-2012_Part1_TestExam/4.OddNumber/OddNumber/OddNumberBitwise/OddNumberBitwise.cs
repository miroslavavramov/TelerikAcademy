using System;

class OddNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long result = 0;
        for (int i = 0; i < n; i++)
        {
            long num = long.Parse(Console.ReadLine());
            result = result ^ num;
        }
        Console.WriteLine(result);
    }
}