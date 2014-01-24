using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        List<int> cages = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }
            cages.Add(int.Parse(input));
        }

        int s;
        BigInteger nextSum;
        BigInteger nextProd;
        bool[] visited;
        var result = new StringBuilder();

        for (int i = 0; i < cages.Count; i++)
        {
            s = 0;
            nextSum = 0;
            nextProd = 1;
            visited = new bool[cages.Count];

            for (int k = 0; k <= i; k++)
            {
                s += cages[k];
                visited[k] = true;
            }

            if (s >= cages.Count)
            {
                break;
            }

            for (int m = 1; m <= s; m++)
            {
                nextSum += cages[i + m];
                nextProd *= cages[i + m];
                visited[i + m] = true;
            }

            result.Append(nextSum.ToString()).Append(nextProd.ToString());

            for (int p = 0; p < cages.Count; p++)
            {
                if (visited[p])
                {
                    continue;
                }
                result.Append(cages[p].ToString());
            }

            cages.Clear();

            for (int q = 0; q < result.Length; q++)
            {
                if (result[q] > '1')
                {
                    cages.Add(int.Parse(result[q].ToString()));
                }
            }

            result.Clear();
        }

        foreach (var item in cages)
        {
            Console.Write(item + " ");
        }
    }
}
