using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastMajorityMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int leastMajorityMultiple = 1;
            bool isFound = false;
            int counter = 0;
            int divisor = 1;


            while (isFound == false)
            {
                counter = 0;
                divisor++;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (divisor % arr[i] == 0)
                    {
                        counter++;
                    }
                }
                if (counter >= 3)
                {
                    leastMajorityMultiple = divisor;
                    isFound = true;
                    break;
                }
            }
            Console.WriteLine(leastMajorityMultiple);

            
        }
    }
}
