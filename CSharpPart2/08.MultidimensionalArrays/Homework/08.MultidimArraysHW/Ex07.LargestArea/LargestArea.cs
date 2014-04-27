using System;
//* Write a program that finds the largest area of equal neighbor elements
//in a rectangular matrix and prints its size. 

class LargestArea
{
    static int[,] matrix;
    static bool[,] visited; //mark the already visited cells i.o. to avoid counting them more than once
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("height = ");
                int height = int.Parse(Console.ReadLine());
                Console.Write("width = ");
                int width = int.Parse(Console.ReadLine());

                matrix = new int[height, width];
                visited = new bool[height, width];
                Random rnd = new Random();

                //assign random values [1..4)
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = rnd.Next(1, 4);
                    }
                }
                
                Print(matrix);

                int area;
                int maxArea = 0;
                int bestNum = -1;
                int startRow = -1;
                int startCol = -1;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        area = CalculateArea(row, col);

                        if (area > maxArea)
                        {
                            maxArea = area;
                            bestNum = matrix[row, col];
                            startRow = row;
                            startCol = col;
                        }
                    }
                }

                Console.WriteLine("\nmax area: " + maxArea);
                Console.WriteLine("element: " + bestNum);
                Console.WriteLine("start pos: r:{0} c:{1}\n", startRow, startCol);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }

            Console.WriteLine("\nPress <ENTER> to try again.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                continue;   //restart
            }
            else
            {
                break;  //Exit
            }
        }
    }

    static int CalculateArea(int row, int col)  //starting point
    {                                           
        int distance = 1;
        visited[row, col] = true;

        if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
        {
            distance += GoNorth(row - 1, col);
        }
        if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
        {
            distance += GoEast(row, col + 1);
        }
        if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
        {
            distance += GoSouth(row + 1, col);
        }
        if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
        {
            distance += GoWest(row, col - 1);
        }

        return distance;
    }

    static int GoNorth(int row, int col)
    {
        visited[row, col] = true;
        int dist = 1;

        if (row == 0 || matrix[row, col] != matrix[row - 1, col] || visited[row - 1, col] == true)
        {
            if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
            {
                dist += GoEast(row, col + 1);
            }
            if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
            {
                dist += GoWest(row, col - 1);
            }
            return dist;
        }
        else
        {
            if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
            {
                dist += GoNorth(row - 1, col);
            }
            if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
            {
                dist += GoEast(row, col + 1);
            }
            if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
            {
                dist += GoWest(row, col - 1);
            }
            return dist;
        }

    }

    static int GoEast(int row, int col)
    {
        visited[row, col] = true;
        int dist = 1;

        if (col == matrix.GetLength(1) - 1 || matrix[row, col] != matrix[row, col + 1] || visited[row, col + 1] == true)
        {
            if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
            {
                dist += GoNorth(row - 1, col);
            }
            if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
            {
                dist += GoSouth(row + 1, col);
            }
            return dist;
        }
        else
        {
            if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
            {
                dist += GoEast(row, col + 1);
            }
            if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
            {
                dist += GoNorth(row - 1, col);
            }
            if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
            {
                dist += GoSouth(row + 1, col);
            }
            return dist;
        }
    }

    static int GoSouth(int row, int col)
    {
        visited[row, col] = true;
        int dist = 1;

        if (row == matrix.GetLength(0) - 1 || matrix[row, col] != matrix[row + 1, col] || visited[row + 1, col] == true)
        {
            if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
            {
                dist += GoEast(row, col + 1);
            }
            if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
            {
                dist += GoWest(row, col - 1);
            }
            return dist;
        }
        else
        {
            if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
            {
                dist += GoSouth(row + 1, col);
            }
            if (col < matrix.GetLength(1) - 1 && matrix[row, col] == matrix[row, col + 1] && visited[row, col + 1] == false)    //E
            {
                dist += GoEast(row, col + 1);
            }
            if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
            {
                dist += GoWest(row, col - 1);
            }
            return dist;
        }
    }

    static int GoWest(int row, int col)
    {
        visited[row, col] = true;
        int dist = 1;

        if (col == 0 || matrix[row, col] != matrix[row, col - 1] || visited[row, col - 1] == true)
        {
            if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
            {
                dist += GoNorth(row - 1, col);
            }
            if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
            {
                dist += GoSouth(row + 1, col);
            }
            return dist;
        }
        else
        {
            if (col > 0 && matrix[row, col] == matrix[row, col - 1] && visited[row, col - 1] == false)        //W
            {
                dist += GoWest(row, col - 1);
            }
            if (row > 0 && matrix[row, col] == matrix[row - 1, col] && visited[row - 1, col] == false)    //N
            {
                dist += GoNorth(row - 1, col);
            }
            if (row < matrix.GetLength(0) - 1 && matrix[row, col] == matrix[row + 1, col] && visited[row + 1, col] == false)    //S
            {
                dist += GoSouth(row + 1, col);
            }
            return dist;
        }

    }

    static void Print<T>(T[,] matrix)   //generic method; works with various data types 
    {
        Console.WriteLine();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,1} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}

