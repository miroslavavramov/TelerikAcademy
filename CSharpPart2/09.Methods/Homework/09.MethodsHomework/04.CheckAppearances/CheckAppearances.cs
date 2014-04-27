using System;
//Write a method that counts how many times given number appears in given array. 
//Write a test program to check if the method is working correctly.
class CheckAppearances
{
    static void Main()
    {
        try
        {
            int[] myArray = GenerateArray();
            Console.Write("number = ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Your number appears {0} times in the array!", CountAppearances(myArray, number));

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
    static int CountAppearances(int[] arr, int n)
    {
        int count = 0;
        int[] copy = new int[arr.Length];      //i.o. to avoid breaking the original order of array's elements

        Array.Copy(arr, copy, arr.Length);
        Array.Sort(copy);

        int index = Array.BinarySearch(copy, n);    //if n appears more than once - returns the middle index

        if (index >= 0)
        {
            count++;

            for (int i = index + 1; i < copy.Length && copy[i] == n; i++)
            {
                count++;
            }
            for (int i = index - 1; i >= 0 && copy[i] == n; i--)
            {
                count++;
            }
        }

        return count;
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
        Console.Write("{ ");

        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }

        Console.WriteLine(" }" + Environment.NewLine);
    }
}