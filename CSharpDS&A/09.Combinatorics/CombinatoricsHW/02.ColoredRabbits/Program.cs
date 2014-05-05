using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<int, int> dict = new Dictionary<int, int>();

    static void ParseInput()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int input = int.Parse(Console.ReadLine());

            if (!dict.ContainsKey(input))
            {
                dict.Add(input, 0);
            }

            dict[input]++;
        }
    }

    static int GetResult()
    {
        int result = 0;

        foreach (var item in dict)
        {
            if (item.Key == 0)
            {
                result += item.Value;
            }
            else if (item.Key == 1)
            {
                result += item.Value;

                if (item.Value % 2 != 0)
                {
                    result += 1;
                }
            }
            else if (item.Key >= item.Value)
            {
                result += item.Key + 1;
            }
            else
            {
                int a = (int)Math.Ceiling(item.Value / ((decimal)item.Key + 1));
                int b = (item.Key + 1);
                result += a * b;
                    
            }
        }

        return result;
    }

    static void Main()
    {
        ParseInput();
        Console.WriteLine(GetResult());
    }
}

