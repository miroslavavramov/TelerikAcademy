using System;
using System.Collections.Generic;

class Program
{
    static int N;
    static byte[,] board;
    static List<byte[,]> solutionsFound = new List<byte[,]>();
    
    static void Solve(int y = 0)
    {
        if (y == N)
        {
            solutionsFound.Add(CreateBoardDeepCopy());
        }
        else
        {
            for (int x = 0; x < N; x++)
            {
                if (IsPositionAvailable(x, y))
                {
                    board[x, y] = 1;
                    Solve(y + 1);
                    board[x, y] = 0;
                }
            }
        }
    }

    static bool IsPositionAvailable(int x, int y)
    {
        int posX;
        int posY;

        for (posX = x, posY = y - 1; posY >= 0; posY--) //horizontal check
        {
            if (board[posX, posY] == 1)
            {
                return false;
            }
        }

        for (posX = x - 1, posY = y - 1; posX >= 0 && posY >= 0; posX--, posY--) //backslash diagonal
        {
            if (board[posX, posY] == 1)
            {
                return false;
            }
        }

        for (posX = x + 1, posY = y - 1; posX < N && posY >= 0; posX++, posY--) //foreslash diagonal
        {
            if (board[posX, posY] == 1)
            {
                return false;
            }
        }

        return true;
    }

    static byte[,] CreateBoardDeepCopy()
    {
        var copy = new byte[N, N];

        Array.Copy(board, copy, board.Length);
        
        return copy;
    }

    static void PrintSolutionsOnConsole()
    {
        Console.SetBufferSize(100, 1500);

        for (int i = 0; i < solutionsFound.Count; i++)
        {
            var solution = solutionsFound[i];

            Console.WriteLine("SOLUTION: # {0}{1}", (i+1), Environment.NewLine);

            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    if (solution[x, y] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write("{0,2}", solution[x, y]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        N = 8;
        board = new byte[N, N];
        
        Solve();

        PrintSolutionsOnConsole();
    }
}