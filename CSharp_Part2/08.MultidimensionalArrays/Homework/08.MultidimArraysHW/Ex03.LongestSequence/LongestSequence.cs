using System;

//We are given a matrix of strings of size N x M. Sequences in the matrix we define
//as sets of several neighbor elements located on the same line, column or diagonal. 
//Write a program that finds the longest sequence of equal strings in the matrix. 
class LongestSequence
{
    static string[,] matrix;
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("How many different strings you want to type? ");
                int strCount = int.Parse(Console.ReadLine());
                string[] words = new string[strCount];

                for (int i = 0; i < strCount; i++)
                {
                    words[i] = Console.ReadLine();
                    if (words[i].Length > 4)
                    {
                        Console.WriteLine("Input should be no more than 4 characters long! Try again.");
                        i--;
                        continue;
                    }
                }
                Console.Write("Height : "); int height = int.Parse(Console.ReadLine());
                Console.Write("Widht : "); int width = int.Parse(Console.ReadLine());
                matrix = new string[height, width];
                Random rnd = new Random();

                //generate string matrix and fill it with array's elements in random order
                for (int row = 0; row < height; row++)
                    for (int col = 0; col < width; col++) { matrix[row, col] = words[rnd.Next(0, strCount)]; }

                Print(matrix);

                //find longest sequence
                string bestWord = "";
                int longestStreak = 0;
                int startRow = -1;
                int startCol = -1;
                int streak;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)                     //starting from this cell, check for seq's in
                    {                                                                       //every possible direction and assign the largest
                        streak = GetMax(CheckRows(row, col), CheckCols(row, col),           //as a value to count
                            CheckDiag1(row, col), CheckDiag2(row, col));
                        if (longestStreak < streak)                                         //compare and reset
                        {
                            longestStreak = streak; bestWord = matrix[row, col];
                            startRow = row;
                            startCol = col;
                        }
                    }
                }

                Console.WriteLine("\nLongest sequence consists of \"{0}\", appearing {1} consecutive times.\n", bestWord, longestStreak);
                Console.WriteLine("start pos: r:{0} c:{1}", startRow, startCol);
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
                break;
            }
        }


    }
    static int GetMax(int a, int b, int c, int d)   //even if there are several longest sequences, equal by size
    {                                               //the method returns the first one found
        if (a >= b && a >= c && a >= d)
        {
            return a;
        }
        if (b >= a && b >= c && b >= d)
        {
            return b;
        }
        if (c >= a && c >= b && c >= d)
        {
            return c;
        }
        else //if (d >=a && d >= b && d >= c)
        {
            return d;
        }
    }
    static int CheckRows(int row, int col)   //recursive call; if you're not familiar with it, debug it with F11
    {                                                   
        int count = 1;
        if (col == matrix.GetLength(1) - 1 || matrix[row, col] != matrix[row, col + 1])
        {
            return count;
        }
        return count += CheckRows(row, col + 1);
    }
    static int CheckCols(int row, int col)
    {
        int count = 1;
        if (row == matrix.GetLength(0) - 1 || matrix[row, col] != matrix[row + 1, col])
        {
            return count;
        }
        return count += CheckCols(row + 1, col);
    }
    static int CheckDiag1(int row, int col)           //diagonal from left to right
    {
        int count = 1;
        if ((row == matrix.GetLength(0) - 1 || col == matrix.GetLength(1) - 1)
            || matrix[row, col] != matrix[row + 1, col + 1])
        {
            return count;
        }
        return count += CheckDiag1(row + 1, col + 1);
    }
    static int CheckDiag2(int row, int col)           //diagonal from right to left
    {
        int count = 1;
        if ((row == matrix.GetLength(0) - 1 || col == 0)
            || matrix[row, col] != matrix[row + 1, col - 1])
        {
            return count;
        }
        return count += CheckDiag2(row + 1, col - 1);
    }
    static void Print<T>(T[,] matrix)   //generic method; works with various data types 
    {
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

