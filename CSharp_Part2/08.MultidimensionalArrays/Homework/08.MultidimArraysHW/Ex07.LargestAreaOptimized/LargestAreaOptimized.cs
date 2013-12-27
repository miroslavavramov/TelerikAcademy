using System;
//* Write a program that finds the largest area of equal neighbor elements
//in a rectangular matrix and prints its size. 
class LargestAreaOptimized
{
    static int[,] field = new int[7, 7];
    static bool[,] visited = new bool[7, 7];
    static void Main()
    {
        Random rnd = new Random();
        for (int i = 0; i < field.GetLength(0); i++)
            for (int j = 0; j < field.GetLength(1); j++) { field[i, j] = rnd.Next(1, 4); }

        int max = 0;
        int p = 0;
        int element = -1;
        int startRow = -1;
        int startCol = -1;

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int k = 0; k < field.GetLength(1); k++)
            {
                Console.Write(field[i, k] + " ");
                p = find(i, k);
                if (p > max) { max = p; startRow = i; startCol = k; element = field[i, k]; }
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nmax area : " + max);
        Console.WriteLine("element : " + element);
        Console.WriteLine("postion r:{0} c:{1}\n", startRow, startCol);
    }
    static int find(int row, int col)
    {
        int platform = 1;
        visited[row, col] = true;

        for (int i = -1; i <= 1; i++)
        {
            for (int k = -1; k <= 1; k++)
            {
                if (Math.Abs(i) != Math.Abs(k)  // i != k to avoid checking diagonals
                    && row + i >= 0 && row + i < field.GetLength(0)
                    && col + k >= 0 && col + k < field.GetLength(1)
                    && visited[row + i, col + k] == false
                    && field[row, col] == field[row + i, col + k])
                {
                    platform += find(row + i, col + k);
                }
            }
        }
        return platform;
    }
}

