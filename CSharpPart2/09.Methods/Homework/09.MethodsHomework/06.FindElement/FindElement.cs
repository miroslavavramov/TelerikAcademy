using System;
//Write a method that returns the index of the first element in array that 
//is bigger than its neighbors, or -1, if there’s no such element.
//Use the method from the previous exercise.
class FindElement
{
    static void Main()
    {
        try
        {
            int[] array = GenerateArray();
            int index = CompareToNeighbours(array);

            switch (index)
            {
                default: Console.WriteLine("Element found! Index: {0}", index);
                    break;
                case -1: Console.WriteLine("No element is bigger than both of its neighbours");
                    break;
            }

            Print(array);
            Console.ReadKey();
        }
        catch(FormatException fe)
        { 
            Console.WriteLine(fe.Message); 
        }
        catch(OverflowException ofe)
        { 
            Console.WriteLine(ofe.Message); 
        }
    }

    static int CompareToNeighbours(int[] arr)
    {
        for (int i = 1; i < arr.Length-1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                return i;
            }
        }
        return -1;  //not found
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

