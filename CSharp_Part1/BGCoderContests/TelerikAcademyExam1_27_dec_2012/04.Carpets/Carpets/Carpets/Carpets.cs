using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
                for (int i = 1; i <= n / 2; i++)
                {
                    Console.Write(new string('.', n / 2 - i));

                    if (i > 1)
                    {
                        for (int k = 1; k < i; k += 2)
                        {
                            Console.Write("/ ");
                        }
                    }

                    if (i % 2 != 0)
                    {
                        Console.Write("/\\");
                    }

                    if (i > 1)
                    {
                        for (int k = 1; k < i; k += 2)
                        {
                            Console.Write(" \\");
                        }
                    }

                    Console.Write(new string('.', n / 2 - i));
                    Console.WriteLine();
                }

                for (int i = n / 2; i >= 1; i--)
                {
                    Console.Write(new string('.', n / 2 - i));

                    for (int k = 1; k < i; k += 2)
                    {
                        Console.Write("\\ ");
                    }

                    if (i % 2 != 0)
                    {
                        Console.Write("\\/");
                    }

                    for (int k = 1; k < i; k += 2)
                    {
                        Console.Write(" /");
                    }

                    Console.Write(new string('.', n / 2 - i));
                    Console.WriteLine();
                }

            
            
        }
    }
}
