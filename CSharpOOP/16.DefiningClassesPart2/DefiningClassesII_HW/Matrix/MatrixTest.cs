using System;
using System.Threading;

class MatrixTest
{
    static void Main()
    {
        Matrix<int> firstMatrix = new Matrix<int>();
        firstMatrix.AssignRandomValues(0,10);

        Matrix<int> secondMatrix = new Matrix<int>();
        secondMatrix.AssignRandomValues(0,10);

        Console.WriteLine("Matrix 1 : \r\n{0}\r\n", firstMatrix);
        Console.WriteLine("Matrix 2 : \r\n{0}\r\n", secondMatrix);

        Console.WriteLine("Matrix 1 + Matrix 2 : \r\n{0}\r\n", firstMatrix + secondMatrix);
        Console.WriteLine("Matrix 1 - Matrix 2 : \r\n{0}\r\n", firstMatrix - secondMatrix);
        Console.WriteLine("Matrix 1 * Matrix 2 : \r\n{0}\r\n", firstMatrix * secondMatrix);

        if (firstMatrix)
        {
            Console.WriteLine("Matrix 1 has no zero valued element.");
        }
        else
        {
            Console.WriteLine("Matrix 1 contains a zero valued element.");
        }
    }
}

