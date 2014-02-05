using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.DiamondTrolls
{
    class DiamondTrolls
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(new string('.', n / 2 + 1) + new string('*', n) + new string('.', n / 2 + 1));

            for (int i = 0; i < n/2; i++)
            {
                Console.Write(new string('.', n / 2 - i) + "*" + new string('.', n / 2 + i) + "*" + new string('.', n / 2 + i) + "*" + new string('.', n / 2 - i));
                Console.WriteLine();
            }
            Console.WriteLine(new string('*', n*2 + 1));

            for (int i = n-1; i > 0; i--)
            {
                Console.Write(new string('.', n - i) + "*" + new string('.', i-1) + "*" + new string('.', i-1) + "*" + new string('.', n - i));
                Console.WriteLine();
            }
            Console.WriteLine(new string('.', n) + "*" + new string('.', n));
        }
    }
}
