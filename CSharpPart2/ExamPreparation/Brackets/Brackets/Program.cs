using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static string paddingSymbol;
    static StringBuilder code;
    static void ParseInput()
    {
        int lines = int.Parse(Console.ReadLine());
        code = new StringBuilder();
        paddingSymbol = Console.ReadLine();

        for (int i = 0; i < lines; i++) code.Append(Console.ReadLine().Trim() + "\r\n");
    }
    static void FormatBrackets()
    {
        string temp = code.ToString();
        temp = Regex.Replace(temp, "{", "^{^").Replace("}", "^}^");
        code.Clear();
        code.Append(temp);
    }
    static void InsertPadding()
    {
        var lines = new List<string>(code.ToString()
            .Split(new string[]{"\r\n", "^"},StringSplitOptions.RemoveEmptyEntries));

        int pad = 0;

        for (int i = 0; i < lines.Count; i++)
        {
            lines[i] = Regex.Replace(lines[i], @"\s+", " ");
            lines[i] = lines[i].Trim();

            if (lines[i] == "{")
            {
                for (int k = 0; k < pad; k++)
                {
                    lines[i] = lines[i].Insert(0, paddingSymbol);
                }
                pad++;
                continue;
            }
            if (lines[i] == "}")
            {
                for (int k = 0; k < pad-1; k++)
                {
                    lines[i] = lines[i].Insert(0, paddingSymbol);
                }
                pad--;
                continue;
            }
            else if (lines[i].Length > 0)
            {
                for (int k = 0; k < pad; k++)
                {
                    lines[i] = lines[i].Insert(0, paddingSymbol);
                }
            }
        }
        foreach (var item in lines)
        {
            Console.WriteLine(item);
        }
    }
    static void Main()
    {
        ParseInput();
        FormatBrackets();
        InsertPadding();
    }
}

