using System;
//* Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
//Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
public class PrintAllPermutations
{
    public static void Main()
    {
        try
        {
            Console.BufferHeight = 200;
            Console.Write("Task 19: \n\n");
            Console.Write(" N = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i < n; i++) //assign values
            {
                array[i] = i + 1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Permutations[1..{0}] : ", n);
            PrintPermutations(array, 0, array.Length - 1);
            Console.WriteLine("\n\n Total Permutations: {0}\n", Fact(n));
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
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
    static void PrintPermutations(int[] arr, int start, int end)
    {
        if (start == end)
        {
            PrintArray(arr);
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                SwapValues(ref arr[i], ref arr[start]);
                PrintPermutations(arr, start + 1, end);
                SwapValues(ref arr[i], ref arr[start]);
            }
        }
    }
    static void SwapValues(ref int num1, ref int num2)
    {
        int temp = num1;
        num1 = num2;
        num2 = temp;
    }
    static int Fact(int n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return n * Fact(n - 1);
        }
    }
    static void PrintArray(int[] arr)
    {
        Console.Write("\n ");
        foreach (var item in arr)
        {
            Console.Write(item);
        }
    }
}