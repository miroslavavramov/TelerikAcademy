using System;
//Write a program that reads two numbers N and K and generates all the combinations
//of K distinct elements from the set [1..N]. Example:
//	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
public class PrintAllCombinations
{
    static int iterations;
    static int loops;
    static int next = 1;
    static int totalCombinations = 0;
    public static void Main()
    {
        try
        {
            Console.Write("Task 21: \n\n");
            Console.Write(" N = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            iterations = int.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.Write(" K = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            loops = int.Parse(Console.ReadLine());
            Console.ResetColor();

            int[] array = new int[loops];
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n Combinations of {0} elements in [1..{1}] : \n\n", loops, iterations);

            PrintCombinations(0, next, array);
            Console.WriteLine("\n Total Combinations: {0} ", totalCombinations);
            Console.Write("\n\n");
            Console.ResetColor();
            Console.ReadKey();
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
    static void PrintCombinations(int index, int next, int[] numbers)
    {
        if (index == numbers.Length)
	    {
            totalCombinations++;
            Print(numbers);
	    }
        else
        {
            for (int i = next; i <= iterations; i++)
            {
                numbers[index] = i;
                PrintCombinations(index+1, i+1, numbers);
            }
        }
    }
    static void Print(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(" " + item);
        }
        Console.WriteLine();
    }
}

