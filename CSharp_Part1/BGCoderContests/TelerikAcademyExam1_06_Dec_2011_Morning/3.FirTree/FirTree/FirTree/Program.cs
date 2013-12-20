using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int stars = 1;

            for (int i = 1; i < n; i++)
            {
                Console.Write(new string('.', n - 1 - i));
                Console.Write(new string('*', stars));
                Console.Write(new string('.', n - 1 - i));
                stars += 2;
                Console.WriteLine();
            }
            Console.WriteLine(new string('.', n - 2) + "*" + new string('.', n - 2));
        }
    }
}
