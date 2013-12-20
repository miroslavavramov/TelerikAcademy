using System;

// 03. Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("N = ");
                int n = int.Parse(Console.ReadLine());

                int[] numbers = new int[n];     //declare an integer array with N elements
                int maxNum = int.MinValue;
                int minNum = int.MaxValue;

                for (int i = 0; i < numbers.Length; i++)    //assign values to the members in the array
                {
                    Console.Write("member[{0}] = ", i);
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < numbers.Length; i++)
                {
                    maxNum = (numbers[i] > maxNum ? numbers[i] : maxNum);
                    minNum = (numbers[i] < minNum ? numbers[i] : minNum);
                }
                Console.WriteLine("Greatest member of the sequence: {0}", maxNum);
                Console.WriteLine("Smallest member of the sequence: {0}", minNum);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

