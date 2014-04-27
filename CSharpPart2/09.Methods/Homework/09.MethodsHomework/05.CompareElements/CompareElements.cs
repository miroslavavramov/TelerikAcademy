using System;
//Write a method that checks if the element at given position in given array of integers 
//is bigger than its two neighbors (when such exist).

class CompareElements
{
    static void Main()
    {
        try
        {
            int[] myArray = GenerateArray();
            Console.Write("number = ");
            int number = int.Parse(Console.ReadLine());

            CompareToNeighbours(myArray, number);

            Print(myArray);
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

    static void CompareToNeighbours(int[] arr, int n)
    {
        int index = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == n) { index = i; break; }
        }

        if (index > 0 && index < arr.Length-1)    
        {
            if (arr[index] > arr[index-1] && arr[index] > arr[index+1])
            {
                Console.WriteLine("Element found at Index: {0}. Bigger than both neighbours? Yes.", index);
            }
            else
            {
                Console.WriteLine("Element found at Index: {0}. Bigger than both neighbours? No.", index);
            }
        }
        else if(index == 0 || index == arr.Length-1)
        {
            Console.WriteLine("Element is on the array border.");
        }
        else
        {
            Console.WriteLine("Element not found!");
        }
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

