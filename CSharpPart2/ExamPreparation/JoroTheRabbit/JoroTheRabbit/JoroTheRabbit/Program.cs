using System;
using System.Collections.Generic;

class Program
{
    static int[] terrain;
    static void Main()
    {
        ReadInput();
        GetBestRoute();
    }
    static void ReadInput()
    {
        string[] numbers = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        terrain = new int[numbers.Length];

        for (int i = 0; i < numbers.Length; i++) terrain[i] = short.Parse(numbers[i]);
    }
    static void GetBestRoute()
    {
        short max = 0;
        short dist;

        for (int step = 1; step < terrain.Length; step++)
        {
            for (int start = 0; start < terrain.Length; start++)
            {
                dist = 1;
                int index = start;
                int next = (index + step) % terrain.Length;

                while (next != start && terrain[index] < terrain[next])
                {
                    dist++;
                    index = next;
                    next = (index + step) % terrain.Length; 
                }
                max = max < dist ? dist : max;
            }
        }
        Console.WriteLine(max);
    }
}