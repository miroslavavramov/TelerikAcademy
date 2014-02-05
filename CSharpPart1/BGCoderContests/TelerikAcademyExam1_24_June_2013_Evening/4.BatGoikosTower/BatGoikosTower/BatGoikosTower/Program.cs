using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatGoikosTower
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int dashes = 1;
            int temp = 2;

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string('.', n-1-i));
                Console.Write("/");
                if (i == dashes)
                {
                    Console.Write(new string('-', i * 2));
                    dashes += temp;
                    temp++;
                }
                else
                {
                    Console.Write(new string('.', i * 2));
                }
                Console.Write("\\");
                Console.Write(new string('.', n - 1 - i));
                Console.WriteLine();
            }
        }
    }
}
