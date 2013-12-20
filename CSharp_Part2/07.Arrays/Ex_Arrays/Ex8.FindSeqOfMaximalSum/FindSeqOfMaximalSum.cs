using System;
//Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4}

    class Program
    {
        static void Main()
        {
            Console.Write("How many elements should the array contain? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] array = new int[length];
            for (int index = 0; index < length; index++)    //assign values
            {
                Console.Write("     array[{0}] = ", index);
                array[index] = int.Parse(Console.ReadLine());
            }

            // Kadane's Algorithm(just google it)
            int bestSum = int.MinValue;
            int tempBestSum = 0;
            int bestCount = 0;
            int count = 0;
            int startIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                tempBestSum += array[i];
                count++;

                if (tempBestSum < 0)
                {
                    count = 0;
                    tempBestSum = 0;
                }
                else if (tempBestSum > bestSum)
                {
                    bestSum = tempBestSum;
                    bestCount = count;
                    startIndex = i - (bestCount - 1);
                }
            }

            // print the best sequence
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n Best sequence : { ");
            for (int i = startIndex; i < startIndex + bestCount; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.Write("}\n\n");
            Console.ResetColor();
            Console.ReadKey();
        }
    }

