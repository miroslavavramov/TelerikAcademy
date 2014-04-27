using System;
using System.IO;
//Write a program that reads a text file containing a square matrix of numbers and 
//finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. The first line in 
//the input file contains the size of matrix N. Each of the next N lines contain N numbers separated 
//by space. The output should be a single number in a separate text file. Example:
// 4
// 2 3 3 4
// 0 2 3 4  -->	17
// 3 7 1 2
// 4 3 3 2

class MaxPlatform
{
    static void Main()
    {
        int[,] matrix = ReadMatrixFromFile(@"..\..\matrix.txt");

        File.WriteAllText(@"..\..\output.txt", GetMaxPlatform(matrix).ToString());
    }

    static int[,] ReadMatrixFromFile(string path)
    {
        int[,] matrix;

        using (StreamReader reader = new StreamReader(path))
        {
            int length = int.Parse(reader.ReadLine());
            matrix = new int[length, length];

            for (int row = 0; row < length; row++)
            {
                string[] line = reader.ReadLine().Split(' ');

                for (int col = 0; col < length; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            return matrix;
        }   
    }

    static int GetMaxPlatform(int[,] matrix)
    {
        int maxPlatform = int.MinValue;
        int platform = 0;

        for (int row = 0; row < matrix.GetLength(0)-1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1)-1; col++)
            {
                platform = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                maxPlatform = platform > maxPlatform ? platform : maxPlatform;
            }
        }

        return maxPlatform;
    }
}

