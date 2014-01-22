using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        int inputLines = int.Parse(Console.ReadLine());
        int maxLineLength = int.Parse(Console.ReadLine());

        var text = new StringBuilder();

        for (int i = 0; i < inputLines; i++) text.Append(Console.ReadLine() + " ");

        string[] words = text.ToString().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

        var output = new StringBuilder();
        int lineLength = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if ((lineLength + words[i].Length) < maxLineLength)
            {
                output.Append(words[i] + " ");
                lineLength += words[i].Length + 1;
            }
            else if ((lineLength + words[i].Length) <= maxLineLength)
            {
                output.Append(words[i]);
                lineLength += words[i].Length;
            }
            else
            {
                output.Append('\n');
                lineLength = 0;
                i--;
            }
        }
        
        string[] lines = output.ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].Trim();

            if (lines[i].Length == maxLineLength 
                || lines[i].IndexOf(' ') < 0)
            {
                continue;
            }
            else
            {
                for (int k = 0; k < lines[i].Length && lines[i].Length < maxLineLength; k++)
                {
                    if ((k < lines[i].Length - 1) 
                        && (lines[i][k] == ' ')
                        && (lines[i][k + 1] != ' '))
                    {
                        lines[i] = lines[i].Insert(k+1, " ");
                        k++;
                    }
                    if (k == lines[i].Length - 1) { k = -1; }
                }
            }
        }

        foreach (var line in lines)
            Console.WriteLine(line);
        
    }
}

