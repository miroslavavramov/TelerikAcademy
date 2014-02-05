using System;
//Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).
public class QuickSortAlgorithm
{
    public static void Main()
    {
        try
        {
            Console.Write("Task 14: \n\n");
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

            QuickSort(array, 0, array.Length - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\n Sorted Array :");
            PrintArray(array);
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
    static int Partition(int[] arr, int start, int end)
    {
        int pIndex = start;
        int pivot = arr[end];
        int temp = 0;

        for (int i = start; i < end; i++)
        {
            if (arr[i] <= pivot)    //swap values
            {
                temp = arr[i];
                arr[i] = arr[pIndex];
                arr[pIndex] = temp;
                pIndex++;
            }
        }
        arr[end] = arr[pIndex];
        arr[pIndex] = pivot;
        return pIndex;      //pivot index
    }
    static void QuickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int pIndex = Partition(arr, start, end);
            QuickSort(arr, start, pIndex - 1);
            QuickSort(arr, pIndex + 1, end);
        }
    }
    static void PrintArray(int[] array)
    {
        Console.Write("\t { ");
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.Write("} \n");
        Console.WriteLine();
    }
}

