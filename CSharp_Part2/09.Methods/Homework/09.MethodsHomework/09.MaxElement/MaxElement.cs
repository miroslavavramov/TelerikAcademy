using System;
//Write a method that return the maximal element in a portion of array of integers 
//starting at given index. Using it write another method that sorts an array in ascending / descending order.

class MaxElement
{
    static void Main()
    {
        int[] myArray = GenerateArray();
        Console.Write("Unsorted : ");
        Print(myArray);
        SortMyArray(myArray);
        Console.Write("Sorted : ");
        Print(myArray);
    }
    static int GetMaxElementIndex(int[] arr, int startIndex)
    {
        int maxElementIndex = startIndex;

        for (int i = startIndex; i < arr.Length; i++)
        {
           if(arr[i] >= arr[maxElementIndex])  
               maxElementIndex = i;
        }
        return maxElementIndex;
    }
    static void SortMyArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Swap(arr, i, GetMaxElementIndex(arr, i));
        }
        Array.Reverse(arr);
    }
    static void Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
    static int[] GenerateArray()
    {
        Console.Write("Array length = ");
        int length = int.Parse(Console.ReadLine());
        Console.Write("Min value = ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Max value = ");
        int max = int.Parse(Console.ReadLine());

        int[] arr = new int[length];
        Random rnd = new Random();

        for (int i = 0; i < length; i++)
        {
            arr[i] = rnd.Next(min, max);
        }
        Console.WriteLine("Array is generted!" + Environment.NewLine);
        return arr;
    }
    static void Print<T>(T[] arr)
    {
        Console.Write("Array : { ");
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine(" }" + Environment.NewLine);
    }
}

