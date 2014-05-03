using System;

class Program
{
    static void Loop(int[] arr, int index = 0)
    {
        if (index == arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
        else
        {
            for (int i = 1; i <= arr.Length; i++)
            {
                arr[index] = i;
                Loop(arr, index+1);
            }
        }
    }

    static void Main()
    {
        int n = 2;
        Loop(new int[n]);
    }
}

