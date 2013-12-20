using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrunkenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int rounds = int.Parse(Console.ReadLine());
            if (rounds >= 1 && rounds <= 100)
            {
                long beersOfMitko = 0;
                long beersOfVlado = 0;

                long[] drunkenNumber = new long[rounds];

                for (int i = 0; i < drunkenNumber.Length; i++)
                {
                    drunkenNumber[i] = long.Parse(Console.ReadLine());
                    if(drunkenNumber[i] < 0)
                    {
                        drunkenNumber[i] *= -1;
                    }
                }
                string[] drunkenNumbers = new string[rounds];

                for (int i = 0; i < rounds; i++)
                {
                    drunkenNumbers[i] = drunkenNumber[i].ToString();
                }

                for (int i = 0; i < rounds; i++)
                {
                    if (drunkenNumbers[i].Length % 2 != 0)
                    {
                        string str1 = drunkenNumbers[i].Substring(0, (drunkenNumbers[i].Length / 2 + 1));
                        long num1 = long.Parse(str1);
                        for (int k = 0; k < str1.Length; k++)
                        {

                            beersOfMitko += (num1 / (long)Math.Pow(10, k)) % 10;
                        }

                        string str2 = drunkenNumbers[i].Substring((drunkenNumbers[i].Length / 2), drunkenNumbers[i].Length / 2 + 1);
                        long num2 = long.Parse(str2);
                        for (int k = 0; k < str2.Length; k++)
                        {
                            beersOfVlado += (num2 / (long)Math.Pow(10, k)) % 10;
                        }
                    }
                    else
                    {
                        string str1 = drunkenNumbers[i].Substring(0, drunkenNumbers[i].Length / 2);
                        long num1 = long.Parse(str1);
                        for (int k = 0; k < str1.Length; k++)
                        {
                            beersOfMitko += (num1 / (long)Math.Pow(10, k)) % 10;
                        }

                        string str2 = drunkenNumbers[i].Substring(drunkenNumbers[i].Length / 2, drunkenNumbers[i].Length / 2);
                        long num2 = long.Parse(str2);
                        for (int k = 0; k < str2.Length; k++)
                        {
                            beersOfVlado += (num2 / (long)Math.Pow(10, k)) % 10;
                        }
                    }

                }

                if (beersOfMitko > beersOfVlado)
                {
                    Console.WriteLine("M {0}", beersOfMitko - beersOfVlado);
                }
                else if (beersOfVlado > beersOfMitko)
                {
                    Console.WriteLine("V {0}", beersOfVlado - beersOfMitko);
                }
                else if (beersOfMitko == beersOfVlado)
                {
                    Console.WriteLine("No {0}", beersOfVlado + beersOfMitko);
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
}
