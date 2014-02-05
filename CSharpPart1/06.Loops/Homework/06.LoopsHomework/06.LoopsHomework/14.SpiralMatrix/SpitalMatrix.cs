using System;

// 14*. Write a program that reads a positive integer number N (N < 20) 
//from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
    class Program
    {
        static void Main()
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                int[,] matrix = new int[n, n];      // declare a two-dimensional array with n rows and n columns
                int i = 1;
                int k = 0;
                int rows = 0;
                int cols = 0;

                while (k < n)
                {
                    while (cols < n - k)                            
                    {
                        matrix[rows, cols] = i;             // || ---------->>  ||
                        i++;                                // ||               ||
                        cols++;                             // ||               ||
                    }
                    cols--;
                    i--;

                    while (rows < n - k)
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


                int element = (matrix.GetLength(0) * matrix.GetLength(1) - 1).ToString().Length + 1;
                
                for (int row = 0; row < matrix.GetLength(0); row++)         //print
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col].ToString().PadLeft(element, ' '));
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
            }

            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

