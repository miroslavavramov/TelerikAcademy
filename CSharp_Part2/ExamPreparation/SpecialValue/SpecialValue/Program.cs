using System;

class Program
{
    static int[][] jagged;
    static bool[][] visited;
    static void ParseInput()
    {
        int rows = int.Parse(Console.ReadLine());
        jagged = new int[rows][];
        
        for (int i = 0; i < rows; i++)
        {
            string[] numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            jagged[i] = new int[numbers.Length];
            
            for (int k = 0; k < numbers.Length; k++)
            {
                jagged[i][k] = int.Parse(numbers[k]);
            }
        }
    }
    static void ClearVisited()
    {
        visited = new bool[jagged.Length][];

        for (int i = 0; i < jagged.Length; i++) visited[i] = new bool[jagged[i].Length];
        
    }
    static int GetMaxSpecialValue()
    {
        int max = int.MinValue;
        int path;
        int row;
        int col;

        for (int cell = 0; cell < jagged[0].Length; cell++)
        {
            path = 1;
            col = cell;
            row = 0;
            ClearVisited();

            while (true)
            {
                if (visited[row][col])
                {
                    path = int.MinValue;
                    break;
                }
                else if (jagged[row][col] < 0)
                {
                    path += -jagged[row][col];
                    break;
                }
                else if (jagged[row][col] >= 0)
                {
                    path++;
                    visited[row][col] = true;
                    col = jagged[row][col];
                    row = (row + 1) % jagged.Length;
                }
            }

            max = max < path ? path : max;
        }
        return max;
    }
    static void Main()
    {
        ParseInput();
        Console.WriteLine(GetMaxSpecialValue());
    }
}

