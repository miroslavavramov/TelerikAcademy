using System;
class Program
{
    static int dirX = 0, dirY = 1;         
    static int x = 1, y = 1;               
    static void ProceedMove(char c)
    {
        if (c == 'L')
        {
            if      (dirX == 1  && dirY == 0)    { dirX = 0;  dirY = -1; }
            else if (dirX == 0  && dirY == -1)   { dirX = -1; dirY = 0;  }
            else if (dirX == -1 && dirY == 0)    { dirX = 0;  dirY = 1;  }
            else if (dirX == 0  && dirY == 1)    { dirX = 1;  dirY = 0;  }
        }
        else if (c == 'R')
        {
            if      (dirX == 1  && dirY == 0)    { dirX = 0;  dirY = 1;  }
            else if (dirX == 0  && dirY == 1)    { dirX = -1; dirY = 0;  }
            else if (dirX == -1 && dirY == 0)    { dirX = 0;  dirY = -1; }
            else if (dirX == 0  && dirY == -1)   { dirX = 1;  dirY = 0;  }
        }
        else
        {
            x += dirX;
            y += dirY;

            if (x < 0) 
            {
                x = 2;
            }
            else 
            {
                x %= 3;
            }
            if (y < 0)
            {
                y = 2;
            }
            else
            {
                y %= 3;
            }
        }
    }
    static void PrintCurrentSquareColor()
    {
        if (x == 1 && y == 1)
        {
            Console.WriteLine("GREEN");
        }
        else if (Math.Abs(x - y) == 1)
        {
            Console.WriteLine("BLUE");
        }
        else
        {
            Console.WriteLine("RED");
        }
    }
    static void Main()
    {
        int moves = int.Parse(Console.ReadLine());

        for (int i = 0; i < moves; i++)
        {
            string move = Console.ReadLine();

            for (int k = 0; k < move.Length; k++)
            {
                ProceedMove(move[k]);
            }
            PrintCurrentSquareColor();
        }
    }
}

