using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n1 = BigInteger.Parse(Console.ReadLine());
            BigInteger n2 = BigInteger.Parse(Console.ReadLine());
            BigInteger n3 = BigInteger.Parse(Console.ReadLine());
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            if (n < 0)
            {
                n *= -1;
            }
            if (n == 1)
            {
                Console.WriteLine(n1);
                return;
            }
            else if (n == 2)
            {
                Console.WriteLine(n2);
                return;
            }
            else if(n == 3)
            {
                Console.WriteLine(n3);
                return;
            }

            
            for (int i = 0; i < n - 3; i++)
            {
                BigInteger temp = n1 + n2 + n3;
                n1 = n2;
                n2 = n3;
                n3 = temp;
            }
            Console.WriteLine(n3);

        }
    }
}
