using System;

class GreedyDwarf
{
    static void Main()
    {
        char[] separators = { ' ', ',' };

        int[] valley = ToIntArray(Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries));
        bool[] visited = new bool[valley.Length];

        int[][] patterns = new int[int.Parse(Console.ReadLine())][];
        for (int i = 0; i < patterns.Length; i++)
            patterns[i] = ToIntArray(Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries));

        long coins;
        int index;
        long max = long.MinValue;

        for (int i = 0; i < patterns.Length; i++)
        {
            index = 0;
            coins = valley[index];
            visited[index] = true;
            for (int k = 0; k < patterns[i].Length; k++)
            {
                index += patterns[i][k];

                if (k == patterns[i].Length - 1)
                {
                    k = -1;
                }
                if (index < 0 || index > valley.Length-1 || visited[index])
                {
                    break;
                }
                else
                {
                    coins += valley[index]; 
                    visited[index] = true;
                }
            }
            max = coins > max ? coins : max;
            Reset(visited);
        }
        Console.WriteLine(max);
    }
    static int[] ToIntArray(string[] arr)
    {
        int[] nums = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++) nums[i] = int.Parse(arr[i]);
        return nums;
    }
    static void Reset(bool[] b)
    {
        for (int i = 0; i < b.Length; i++) b[i] = false;
    }
}

