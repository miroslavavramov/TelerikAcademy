using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] symbols = {"CHU", "TEL", "OFT", "IVA", "EMY", "VNB","POQ",
                            "ERI", "CAD","K-A","IIA","YLO","PLA" };

        int pow = input.Length / 3 - 1;
        
        double base10 = 0;

        for (int i = 0; i < input.Length; i+=3)
        {
            string symbol = input[i].ToString() + input[i + 1].ToString() + input[i + 2].ToString();

            for (int k = 0; k < symbols.Length; k++)
            {
                if (symbol == symbols[k])
                {
                    base10 += k * Math.Pow(13, pow);
                    pow--;
                }
            }
        }
        Console.WriteLine(base10);

    }
}
