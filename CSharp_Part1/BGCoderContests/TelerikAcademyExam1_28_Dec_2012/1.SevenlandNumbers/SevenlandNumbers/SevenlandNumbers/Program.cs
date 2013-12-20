using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenlandNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            n += 1;
            int hunderds = n / 100;
            int decimals = (n % 100) / 10;
            int units = n % 10;
           

            if (units > 6)
            {
                units = 0;
                decimals++;
            }
            if (decimals > 6)
            {
                decimals = 0;
                hunderds++;
            }
            if (hunderds > 6)
            {
                hunderds = 10; ;
            }
            int newNumber = hunderds * 100 + decimals * 10 + units;
            Console.WriteLine(newNumber);
        }
    }
}
