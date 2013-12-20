using System;
using System.Numerics;
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = BigInteger.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            BigInteger c = BigInteger.Parse(Console.ReadLine());
            BigInteger result = 0;

            switch (b)
            {
                default:
                    return;
                case 3: result = a + c;
                    break;
                case 6: result = a * c;
                    break;
                case 9: result = a % c;
                    break;
            }

            BigInteger r = result;

            if (result % 3 == 0)
            {
                result /= 3;
            }
            else
            {
                result %= 3;
            }
            Console.WriteLine(result);
            Console.WriteLine(r);
        }
    }

