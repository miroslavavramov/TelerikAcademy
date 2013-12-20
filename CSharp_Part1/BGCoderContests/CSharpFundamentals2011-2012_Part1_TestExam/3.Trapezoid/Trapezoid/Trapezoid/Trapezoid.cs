using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('.', n) + new string('*', n));

            for (int i = 0; i < n-1; i++)
            {
                Console.Write(new string('.', n-1-i));
                Console.Write("*");
                Console.Write(new string('.', n - 1 + i));
                Console.Write("*");
                Console.WriteLine();
            }

            Console.WriteLine(new string('*', n*2));
        }
    }
}
