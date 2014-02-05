using System;

// 12. Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix 
    class Program
    {
        static void Main()
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 1; i <= n; i++)
                {
                    for (int k = i; k < n + i; k++)
                    {
                        if (k < 10)
                        {
                            Console.Write(0+"{0} ", k); 
                        }
                        else
                        {
                            Console.Write("{0} ", k);
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }

