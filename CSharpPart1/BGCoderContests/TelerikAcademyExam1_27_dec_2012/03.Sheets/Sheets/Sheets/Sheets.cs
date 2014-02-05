using System;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] sizes = { "A10", "A9", "A8", "A7", "A6", "A5", "A4", "A3", "A2", "A1", "A0" };

        for (int i = 10; i >= 0; i--)
        {
            if (n >= Math.Pow(2, i))
            {
                n -= (int)Math.Pow(2, i);
                sizes[i] = "";
                if (n == 0)
                {
                    break;
                }
            }
        }
        for (int i = 0; i < sizes.Length; i++)
        {
            if (sizes[i] != "")
            {
                Console.WriteLine(sizes[i]);
            }
        }
    }
}