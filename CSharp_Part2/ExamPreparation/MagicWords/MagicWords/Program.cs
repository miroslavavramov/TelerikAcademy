using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var words = new List<string>();
        
        for (int i = 0; i < n; i++)
        {
            words.Add(Console.ReadLine().Trim());
        }

        for (int i = 0; i < n; i++)
        {
            string temp = words[i];
            int index = words[i].Length % (n + 1);

            words.Insert(index, temp);

            if (i < index)
            {
                words.RemoveAt(i);
            }
            else
            {
                words.RemoveAt(i + 1);
            }
        }

        var sb = new StringBuilder();
        int letter = 0;
        int len = 0;

        while (true)
        {
            for (int i = 0; i < words.Count; i++)
            {
                if (letter < words[i].Length)
                {
                    sb.Append(words[i][letter]);
                }
            }
            if (sb.Length > len)
            {
                letter++;
                len = sb.Length;
            }
            else break;
        }
        Console.WriteLine(sb);
    }
}

