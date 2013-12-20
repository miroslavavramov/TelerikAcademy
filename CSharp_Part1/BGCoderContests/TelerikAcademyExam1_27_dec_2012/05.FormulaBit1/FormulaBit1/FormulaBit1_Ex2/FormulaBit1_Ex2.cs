using System;
class Program
{
    static void Main()
    {
        int[,] grid = new int[8, 8];
        int row = 0;
        int col = 7;
        bool down = true;
        bool left = false;
        bool up = false;
        bool win = false;
        bool flipNorth = true;
        int turns = 0;
        int distance = 1;

        for (int i = 0; i < 8; i++)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            string inputString = Convert.ToString(inputNumber, 2).PadLeft(8, '0');
            for (int j = 0; j < 8; j++)
            {
                if (inputString[j] == '1')
                {
                    grid[i, j] = 1;
                }
            }
        }
        while (!(row == 7 && col == 0))
        {
            if (grid[row, col] == 1)
            {
                distance = 0;
                break;
            }
            if (down == true)
            {
                if (row < 7 && grid[row + 1, col] != 1)
                {
                    row++;
                    distance++;
                }
                else
                {
                    down = false;
                    if (col > 0 && grid[row, col - 1] != 1)
                    {
                        left = true;
                        turns++;
                    }
                }
            }
            if (left == true)
            {
                if (col > 0 && grid[row, col - 1] != 1)
                {
                    col--;
                    distance++;
                }
                else
                {
                    left = false;
                    if (flipNorth)
                    {
                        if (row > 0 && grid[row - 1, col] != 1)
                        {
                            up = true;
                            turns++;
                            flipNorth = false;
                        }
                    }
                    else
                    {
                        if (row < 7 && grid[row + 1, col] != 1)
                        {
                            down = true;
                            turns++;
                            flipNorth = true;
                        }
                    }
                }
            }
            if (up == true)
            {
                if (row > 0 && grid[row - 1, col] != 1)
                {
                    row--;
                    distance++;
                }
                else
                {
                    up = false;
                    if (col > 0 && grid[row, col - 1] != 1)
                    {
                        left = true;
                        turns++;
                    }
                }
            }
            if (row == 7 && col == 0)
            {
                win = true;
            }

            if (down == false && left == false && up == false)
            {
                break;
            }
        }

        if (win == true)
        {
            Console.WriteLine("{0} {1}", distance, turns);
        }
        else
        {
            Console.WriteLine("No {0}", distance);
        }
    }
}
