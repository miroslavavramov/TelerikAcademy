using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{   
    static void Main()
    {
        var phpCode = new StringBuilder();
        HashSet<string> variables = new HashSet<string>();

        for (string i; (i = Console.ReadLine()) != "?>";)
        {
            phpCode.AppendLine(i);
        }

        var sb = new StringBuilder();

        for (int i = 0; i < phpCode.Length; i++)
        {
            if (phpCode[i] == '/' && phpCode[i + 1] == '/')
            {
                i = phpCode.ToString().IndexOf('\n', i);
            }
            if (phpCode[i] == '/' && phpCode[i + 1] == '*')
            {
                i = phpCode.ToString().IndexOf("*/", i)+1;
            }
            if (phpCode[i] == '"')
            {
                i = phpCode.ToString().IndexOf('"', i+1);
            }

            if (phpCode[i] == '$')
            {
                for (int k = i+1; (char.IsLetterOrDigit(phpCode[k]) || phpCode[k] == '_'); k++)
                {
                    sb.Append(phpCode[k]);
                }
                i += sb.Length;

                
                    variables.Add(sb.ToString());
                
                
                sb.Clear();
            }
        }

        Console.WriteLine(variables.Count);

        var sorted = variables.OrderBy(x => x);

        foreach (var item in sorted)
        {
            Console.WriteLine(item);
        }
    }
}

