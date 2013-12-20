using System;


namespace Ex9.FindMostFrequentNumber
{
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

            int count = 0;
            int bestCount = 0;
            int value = 0;

            for (int i = 0; i < length; i++)
            {
                count = 0;
                for (int k = i; k < length; k++)
                {
                    if (array[k] == array[i])
                    {
                        count++;
                    }
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    value = array[i];
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nElements of value {0} occur most often({1} times).\n\n", value, bestCount);
            Console.ResetColor();
        }
    }
}
