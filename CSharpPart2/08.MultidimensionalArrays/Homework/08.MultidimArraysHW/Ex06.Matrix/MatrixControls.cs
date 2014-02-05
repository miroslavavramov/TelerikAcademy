using System;
//* Write a class Matrix, to holds a matrix of integers. Overload the operators for adding,
//subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
class MatrixControls
{
    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Matrix 1 : \n");
                Matrix matrix1 = Matrix.GenerateMatrix();
                Console.Write("Matrix 2 : \n");
                Matrix matrix2 = Matrix.GenerateMatrix();

                Console.WriteLine("Matrices as strings: \n{0}\n{1}", matrix1.ToString(), matrix2.ToString());

                Console.Write("Matrix 1 + Matrix 2 : \n");
                Matrix.PrintMatrix(matrix1 + matrix2);

                Console.Write("\nMatrix 1 - Matrix 2 : \n");
                Matrix.PrintMatrix(matrix1 - matrix2);

                Console.Write("\nMatrix 1 * Matrix 2 : \n");
                Matrix.PrintMatrix(matrix1 * matrix2);
            }
            catch(FormatException fe)
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
                break;  //exit
            }          
        }
    }
}

