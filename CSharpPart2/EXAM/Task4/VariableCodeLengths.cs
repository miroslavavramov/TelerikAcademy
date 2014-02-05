using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Program
{
    static void Main()
    {
        byte[] numbers = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(byte.Parse).ToArray();

        int n = int.Parse(Console.ReadLine());

        Dictionary<int, char> dict = new Dictionary<int, char>();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            byte key = byte.Parse(input.Substring(1, input.Length - 1));

            if (key > 0)
            {
                dict.Add(key, input[0]);
            }
            
        }

        var code = new StringBuilder();

        for (int i = 0; i < numbers.Length; i++)
        {
            code.Append(Convert.ToString(numbers[i], 2).PadLeft(8, '0'));
        }

        string[] output = code.ToString().Split(new char[] { '0' });

        for (int i = 0; i < output.Length; i++)
        {
            if (dict.ContainsKey(output[i].Length))
            {
                Console.Write(dict[output[i].Length]);
            }
        }
    }
}

