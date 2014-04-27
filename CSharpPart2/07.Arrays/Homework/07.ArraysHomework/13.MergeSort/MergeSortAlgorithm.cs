using System;
//* Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).
public class MergeSortAlgorithm
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Task 13: \n\n");
            Console.Write(" How many elements should the array contain ? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int length = int.Parse(Console.ReadLine());

            int[] myArray = new int[length];
            AssignValues(myArray);
            Console.Write("\n Your Array: ");
            PrintArray(myArray);

            Console.ForegroundColor = ConsoleColor.Green;
            myArray = MergeSort(myArray); //sort the array
            Console.Write("\n Sorted Array: ");
            PrintArray(myArray);
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
    static int[] MergeSort(int[] array)
    {
        if (array.Length < 2)
        {
            return array;
        }

        int mid = array.Length / 2;
        int[] leftArr = new int[mid];
        int[] rightArr = new int[array.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            leftArr[i] = array[i];
        }
        for (int i = mid; i < array.Length; i++)
        {
            rightArr[i - mid] = array[i];
        }

        leftArr = MergeSort(leftArr);
        rightArr = MergeSort(rightArr);

        return Merge(leftArr, rightArr);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] arr = new int[left.Length + right.Length];
        int leftIndex = 0;
        int rightIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (rightIndex == right.Length || ((leftIndex < left.Length) && (left[leftIndex] <= right[rightIndex])))
            {
                arr[i] = left[leftIndex];
                leftIndex++;
            }
            else if (leftIndex == left.Length || ((rightIndex < right.Length) && (right[rightIndex] <= left[leftIndex])))
            {
                arr[i] = right[rightIndex];
                rightIndex++;
            }
        }
        return arr;
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

    static int[] AssignValues(int[] array)
    {
        Console.WriteLine();
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("\t element[{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }
}

