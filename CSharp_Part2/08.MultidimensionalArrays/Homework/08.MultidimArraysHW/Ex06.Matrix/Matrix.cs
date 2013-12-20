using System;

class Matrix
{
    private int[,] matrix;

    public Matrix(int rows, int cols)   //constructor
    {
        this.matrix = new int[rows, cols];
    }
    public int Rows //property
    {
        get
        {
            return this.matrix.GetLength(0);
        }
    }
    public int Cols //property
    {
        get
        {
            return this.matrix.GetLength(1);
        }
    }
    public static Matrix GenerateMatrix()   //static method
    {   
        Console.Write("Rows = ");
        int height = int.Parse(Console.ReadLine()); //rows
        Console.Write("Columns = ");
        int width = int.Parse(Console.ReadLine());  //columns
        
        Matrix myMatrix = new Matrix(height, width);

        for (int row = 0; row < myMatrix.Rows; row++)
        {
            Console.Write("row {0} : ", row + 1);
            string[] separators = new string[] {" ", "  ", "   ", "     ", "\t"};
            string currentRow = Console.ReadLine();
            string[] numsAsStrings = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < numsAsStrings.Length; col++)
            {
                if (col < myMatrix.Cols)
                {
                    int num = 0;
                    bool validNum = int.TryParse(numsAsStrings[col], out num);
                    myMatrix[row, col] = num;
                    //if (!valid) { myMatrix[row,col] = 0} else {myMatrix[row,col] = num};
                }
            }
        }
        Console.WriteLine();
        return myMatrix;
    }
    public static Matrix operator +(Matrix matrix1, Matrix matrix2)     //add  
    {
        Matrix sum = new Matrix(matrix1.Rows, matrix1.Cols);
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            Console.WriteLine("Matrices can't be added, because they're not the same size!");
            sum = new Matrix(0, 0);
            return sum;
        }
        //else
        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix1.Cols; col++)
            {
                sum[row, col] = matrix1[row, col] + matrix2[row, col];
            }
        }
        return sum;
    }
    public static Matrix operator -(Matrix matrix1, Matrix matrix2)     //subtract  
    {
        Matrix sum = new Matrix(matrix1.Rows, matrix1.Cols);
        if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
        {
            Console.WriteLine("Matrices can't be subtracted, because they're not the same size!");
            sum = new Matrix(0, 0);
            return sum;
        }
        //else
        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix1.Cols; col++)
            {
                sum[row, col] = matrix1[row, col] - matrix2[row, col];
            }
        }
        return sum;
    }
    public static Matrix operator *(Matrix matrix1, Matrix matrix2)     //multiply
    {
        Matrix product = new Matrix(matrix1.Rows, matrix2.Cols);
        if (matrix1.Cols != matrix2.Rows)
        {
            Console.WriteLine("Matrices can't be multiplied, because the colums of the first\n" +
             "matrix don't match the rows of the second!");
            product = new Matrix(0, 0);
            
            return product;
        }
        //else
        for (int row = 0; row < product.Rows; row++)
        {
            for (int col = 0; col < product.Cols; col++)
            {
                for (int i = 0; i < matrix1.Cols; i++)
                {
                    product[row, col] += matrix1[row, i] * matrix2[i, col];
                }
            }
        }
        return product;
    }
    public override string ToString()
    {
        string output = "";
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                output += matrix[row, col] + " ";
            }
            output += Environment.NewLine;
        }
        return output;
    }
    public static void PrintMatrix(Matrix matrix)  //static method
    {
        for (int row = 0; row < matrix.Rows; row++)
        {
            for (int col = 0; col < matrix.Cols; col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    public int this[int row, int col]   //indexer (instance method)
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }
}



