using System;

class FillAndPrintMatrix
{
    static void Print(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3} ", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
    static void A(int[,] matrix, int length)
    {
        int value = 1;
        //assign values
        for (int col = 0; col < length; col++)
        {
            for (int row = 0; row < length; row++)
            {
                matrix[row, col] = value;
                value++;
            }
        }
        Console.WriteLine(" A) ");
        Print(matrix);  //print matrix
    }
    static void B(int[,] matrix, int length)
    {
        int value = 1;
        for (int col = 0; col < length; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < length; row++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }
            else
            {
                for (int row = length-1; row >= 0; row--)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }
        }
        Console.WriteLine(" B) ");
        Print(matrix);
    }
    static void C(int[,] matrix, int length)
    {
        int value = 1;
        for (int row = length-1; row >= 0; row--)
        {
            for (int col = 0; col < length-row; col++)
            {
                matrix[row + col, col] = value;
                value++;
            }
        }
        for (int col = 1; col < length; col++)
        {
            for (int row = 0; row < length-col; row++)
            {
                matrix[row, col + row] = value;
                value++;
            }
        }
        Console.WriteLine(" C) ");
        Print(matrix);
    }
    static void D(int[,] matrix, int length)
    {
        int row = 0; int col = 0;
        matrix[row, col] = 1;

        int i = 1;
        int k = 0;
        int rows = 0;
        int cols = 0;

        while (k < length)
        {
            while (cols < length - k)
            {
                matrix[rows, cols] = i;             // || ---------->>  ||
                i++;                                // ||               ||
                cols++;                             // ||               ||
            }
            cols--;
            i--;

            while (rows < length - k)
            {
                matrix[rows, cols] = i;             //  ||             |  ||
                i++;                                //  ||             |  ||
                rows++;                             //  ||            \/  ||

            }
            rows--;
            i--;

            while (cols >= k)
            {
                matrix[rows, cols] = i;             //  ||                  ||  
                i++;                                //  ||                  ||  
                cols--;                             //  || <--------------  ||

            }
            cols++;
            i--;
            k++;

            while (rows >= k)
            {                                       // ||  /\                ||
                matrix[rows, cols] = i;             // ||  |                 ||
                i++;                                // ||  |                 ||
                rows--;
            }
            i--;
            rows++;
        }

        Console.WriteLine(" D) ");
        Print(matrix);
    }
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("N = ");
                int n = int.Parse(Console.ReadLine());
                int[,] matrix = new int[n, n];

                A(matrix, n);
                B(matrix, n);
                C(matrix, n);
                D(matrix, n);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nPress <ENTER> to try again.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                continue;
            }
            else
            {
                Environment.Exit(0);
            }
        }
        
    }
    
}

