using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());

        long[] arr = new long[n];
        bool[] used = new bool[n];
        
        string[] inputNumbers = Console.ReadLine().Split(new char[] { ' ' });

        for (int i = 0; i < n; i++) arr[i] = long.Parse(inputNumbers[i]);

        var sb = new StringBuilder();

        for (long i = 0; i < n && i >= 0; i = arr[i])
        {
            if (used[i])
            {
                sb.Insert((int)i, "(");
                sb.Append(")");
                break;
            }

            sb.Append(i.ToString() + " ");
            used[i] = true;
        }
        sb = sb.Replace("( ", "(").Replace(" )", ")");
        sb = sb.Replace(" ( ", "(").Replace(" ) ", ")");
        sb = sb.Replace(" (", "(").Replace(") ", ")");
        
        Console.WriteLine(sb.ToString().Trim());
    }
}
