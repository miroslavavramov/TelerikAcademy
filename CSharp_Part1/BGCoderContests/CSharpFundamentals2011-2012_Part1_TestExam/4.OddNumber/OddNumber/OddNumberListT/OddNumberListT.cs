using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumberListT
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            List<long> numbers = new List<long>();
            long counter = 0;

            for (int i = 0; i < n; i++)
            {
                numbers.Add(long.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                counter = 0;
                for (int k = 0; k < numbers.Count; k++)
                {
                    if (numbers[i] == numbers[k])
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0)
                {
                    Console.WriteLine(numbers[i]);
                    break;
                }
            }


        }
    }
}
