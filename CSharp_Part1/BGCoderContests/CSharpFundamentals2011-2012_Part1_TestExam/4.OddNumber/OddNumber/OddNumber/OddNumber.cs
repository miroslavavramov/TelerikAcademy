using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            long counter = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = long.Parse(Console.ReadLine());
            }

            for (int i = 0; i < arr.Length; i++)
            {
                counter = 0;
                for (int k = 0; k < arr.Length; k++)
                {
                    if (arr[i] == arr[k])
                    {
                        counter++;
                    }
                }
                if (counter % 2 != 0)
                {
                    Console.WriteLine(arr[i]);
                    break;
                }
            }
        }
    }
}
