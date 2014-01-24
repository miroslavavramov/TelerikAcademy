using System;

class Program
{
    static int[,] matrix;
    static int length, max = int.MinValue, temp;
    static bool found = false;
    static void ParseInput()
    {
        length = int.Parse(Console.ReadLine());
        matrix = new int[length,length];

        for (int row = 0; row < length; row++)
        {
            string[] numbers = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < length; col++)
            {
                matrix[row, col] = int.Parse(numbers[col]);
            }
        }

    }
    static bool IsPattern(int r, int c)
    {
        if( (matrix[r,c] == matrix[r,c+1] - 1) &&
            (matrix[r,c+1] == matrix[r,c+2] - 1) && 
            (matrix[r,c+2] == matrix[r+1,c+2] - 1) &&
            (matrix[r+1,c+2] == matrix[r+2,c+2] - 1) && 
            (matrix[r+2,c+2] == matrix[r+2,c+3] - 1) &&
            (matrix[r + 2, c + 3] == matrix[r + 2, c + 4] - 1))
        {
            return true;
        }
        return false;
    }
    static int CalcPattern(int r, int c)
    {
        return (matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2] + matrix[r + 1, c + 2]
                + matrix[r + 2, c + 2] + matrix[r + 2, c + 3] + matrix[r + 2, c + 4]);
    }
    static int CalcDiagonal()
    {
        int diag = 0;

        int r = 0;
        int c = 0;

        while (r < length)
        {
            diag += matrix[r, c];
            r++;
            c++;
        }
        return diag;
    }
    static void Main()
    {
        ParseInput();

        for (int row = 0; row < length-2; row++)
        {
            for (int col = 0; col < length-4; col++)
            {
                if (IsPattern(row, col))
                {
                    found = true;

                    temp = CalcPattern(row, col);

                    max = temp > max ? temp : max;
                }
            }
        }

        if (found)
        {
            Console.WriteLine("YES {0}", max);
        }
        else
        {
            Console.WriteLine("NO {0}", CalcDiagonal());
        }
    }
}

