using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            //long bit = long.Parse(Console.ReadLine());
            char bit = char.Parse(Console.ReadLine());
            long n = long.Parse(Console.ReadLine());
            long[] arr = new long[n];
            long counter = 0;

            for (long i = 0; i < n; i++)
            {
                arr[i] = long.Parse(Console.ReadLine());
            }

            for (long i = 0; i < arr.Length; i++)
            {
                string s = Convert.ToString(arr[i], 2);
                s.ToCharArray();

                for (int k = 0; k < s.Length; k++)
                {
                    if (s[k] == bit /*.ToString().ToCharArray()[0]*/)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
                counter = 0;
            }
        }
    }
}
