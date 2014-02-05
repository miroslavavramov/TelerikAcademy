using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        var sb = ParseInput();
        Console.WriteLine(MoveLetters(sb));
    }
    static StringBuilder ParseInput()
    {
        var output = new StringBuilder();

        var words = new List<string>(Console.ReadLine().Split());
        string[] init = new string[words.Count];
        words.CopyTo(init);

        words.Sort((a, b) => a.Length.CompareTo(b.Length));

        int maxLen = words[words.Count-1].Length;

        for (int i = 0; i < maxLen; i++)
        {
            for (int k = 0; k < init.Length; k++)
            {
                if (init[k].Length - 1 - i >= 0)
                {
                    output.Append(init[k][init[k].Length - 1 - i]);
                }
            }
        }

        return output;
    }
    static string MoveLetters(StringBuilder sb)
    {
        int pos;
        char c;

        for (int i = 0; i < sb.Length; i++)
        {
            pos = (GetIndex(sb[i])+i) % sb.Length;
            c = sb[i];

            sb.Remove(i, 1);
            sb.Insert(pos, c);
            
        }

        return sb.ToString();
    }
    static int GetIndex(char c)
    {
        if (c >= 97)
        {
            return c - 'a' + 1;  
        }

        return c - 'A' + 1;
    }
}

