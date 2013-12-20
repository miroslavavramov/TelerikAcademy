using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
    class SandGlass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n/2 + 1; i++)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', n - 2*i));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
            for (int i = n/2-1; i >= 0; i--)
            {
                Console.Write(new string('.', i));
                Console.Write(new string('*', n - 2*i));
                Console.Write(new string('.', i));
                Console.WriteLine();
            }
        }
    }
}
