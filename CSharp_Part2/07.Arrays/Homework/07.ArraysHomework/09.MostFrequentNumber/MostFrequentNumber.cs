using System;
//Write a program that finds the most frequent number in an array. 
//Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
public class MostFrequentNumber
{
    public static void Main()
    {
        try
        {
            Console.Write("Task 9:\n\n ");
            Console.Write(" How many elements should the array contain? ");
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
            Console.WriteLine("\n  Elements of value {0} occurs most often({1} times).\n\n", value, bestCount);
            Console.ResetColor();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n You did something wrong!\n Type task number and press");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" <ENTER> ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("to try again.\n");
            Console.ResetColor();
        }
    }
}

