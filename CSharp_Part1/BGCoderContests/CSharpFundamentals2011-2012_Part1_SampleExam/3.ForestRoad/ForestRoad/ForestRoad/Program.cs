using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestRoad
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', i));
                Console.Write("*");
                Console.Write(new string('.', n-1-i));
                Console.WriteLine();
            }
            for (int i = n-1, j = 1; i > 0 ; i--, j++)
            {
                Console.Write(new string('.', i-1));
                Console.Write("*");
                Console.WriteLine(new string('.', j));
            }
        }
    }
}
