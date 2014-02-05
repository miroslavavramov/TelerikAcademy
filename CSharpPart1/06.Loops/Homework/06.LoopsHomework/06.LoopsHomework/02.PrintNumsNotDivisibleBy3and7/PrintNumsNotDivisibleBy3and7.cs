﻿using System;

// 02. Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("N = ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    if (i % (3*7) != 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

