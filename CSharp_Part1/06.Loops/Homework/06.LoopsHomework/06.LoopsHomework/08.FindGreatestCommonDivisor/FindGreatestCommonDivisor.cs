using System;
// 08. Write a program that calculates the greatest common divisor (GCD) of given two numbers.
// Use the Euclidean algorithm (find it in Internet).

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("b = ");
                int b = int.Parse(Console.ReadLine());
                int greatestCommonDivisor = 1;

                if (a != 0 && b != 0)
                {
                    int absA = Math.Abs(a);     // the use of absolute values of a & b allows 
                    int absB = Math.Abs(b);     // the inclusion of negative numbers as well

                    for (int i = absA; i > 0; i--)
                    {
                        if (absA % i == 0 && absB % i == 0)
                        {
                            greatestCommonDivisor = i;
                            break;
                        }

                    }
                    Console.WriteLine("The greatest common divisor of {0} and {1} is {2}", a, b, greatestCommonDivisor);
                }
                else
                {
                    Console.WriteLine("a & b shouldn't equal 0 !");
                }
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

