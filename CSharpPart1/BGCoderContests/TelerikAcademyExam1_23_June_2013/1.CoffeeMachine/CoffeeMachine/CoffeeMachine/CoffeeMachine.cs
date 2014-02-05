using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n1 = 0.05m; 
            decimal n2 = 0.10m; 
            decimal n3 = 0.20m;
            decimal n4 = 0.50m;
            decimal n5 = 1.00m;

            decimal n1s = decimal.Parse(Console.ReadLine());
            decimal n2s = decimal.Parse(Console.ReadLine());
            decimal n3s = decimal.Parse(Console.ReadLine());
            decimal n4s = decimal.Parse(Console.ReadLine());
            decimal n5s = decimal.Parse(Console.ReadLine());

            decimal cashAvailable = n1 * n1s + n2 * n2s + n3 * n3s + n4 * n4s + n5 * n5s;
            

            decimal amount = decimal.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());

            decimal cashToReturn = amount - price;

            if (cashToReturn < 0)
            {
                Console.WriteLine("More {0}", price - amount);
            }
            else if (cashToReturn >= 0)
            {
                if (cashAvailable < cashToReturn)
                {
                    Console.WriteLine("No {0}", cashToReturn - cashAvailable);
                }
                else if (cashToReturn == 0)
                {
                    Console.WriteLine("Yes {0}", cashAvailable);
                }
                else if (cashAvailable > cashToReturn)
                {
                    Console.WriteLine("Yes {0}", cashAvailable - cashToReturn);
                }
            }
        }
    }
}
