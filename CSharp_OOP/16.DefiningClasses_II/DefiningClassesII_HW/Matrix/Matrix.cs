using System;
using System.Text;

class Matrix<T>
    where T : IComparable
{
    #region Fields
    private T[,] matrix;
    private Random rnd = new Random();
    #endregion

    #region Properties
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public T this[int row, int column]  //indexer
    {
        get { return this.matrix[row, column]; }
        set { this.matrix[row, column] = value; }
    }
    #endregion

    #region Constructors
    public Matrix()
        : this(3, 3)    //default 
    {
    }
    public Matrix(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new ArgumentOutOfRangeException("Matrix cannot consist of zero or negative rows and columns");
        }

        this.Rows = rows;
        this.Columns = columns;

        this.matrix = new T[this.Rows, this.Columns];
    }

    #endregion

    #region Operator Overloading

    public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)     //addition  
    {
        Matrix<T> sum = new Matrix<T>(matrix1.Rows, matrix1.Columns);

        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new ArgumentException("Matrices can't be added, because they're not the same size!");
        }

        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix1.Columns; col++)
            {
                sum[row, col] = (dynamic)matrix1[row, col] + matrix2[row, col];
            }
        }
        return sum;
    }

    public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)     //subtraction  
    {
        Matrix<T> sum = new Matrix<T>(matrix1.Rows, matrix1.Columns);

        if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
        {
            throw new ArgumentException("Matrices can't be subtracted, because they're not the same size!");
        }

        for (int row = 0; row < matrix1.Rows; row++)
        {
            for (int col = 0; col < matrix1.Columns; col++)
            {
                sum[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
            }
        }
        return sum;
    }
    public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)     //multiplication 
    {
        Matrix<T> product = new Matrix<T>(matrix1.Rows, matrix2.Columns);

        if (matrix1.Columns != matrix2.Rows)
        {
            throw new ArgumentException(@"Matrices can't be multiplied, because the colums of the first\n
             matrix don't match the rows of the second!");
        }

        for (int row = 0; row < product.Rows; row++)
        {
            for (int col = 0; col < product.Columns; col++)
            {
                for (int i = 0; i < matrix1.Columns; i++)
                {
                    product[row, col] += (dynamic)matrix1[row, i] * matrix2[i, col];
                }
            }
        }
        return product;
    }
    
    public static bool operator true(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int k = 0; k < matrix.Columns; k++)
            {
                if ((dynamic)matrix[i, k] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public static bool operator false(Matrix<T> matrix)
    {
        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int k = 0; k < matrix.Columns; k++)
            {
                if ((dynamic)matrix[i, k] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    #endregion

    #region Methods
    public void AssignRandomValues(int min, int max)
    {
        for (int i = 0; i < this.Rows; i++)
        {
            for (int k = 0; k < this.Columns; k++)
            {
                this[i, k] = (dynamic)rnd.Next(min, max+1);
            }
        }
    }
    public override string ToString()
    {
        var output = new StringBuilder();

        for (int i = 0; i < this.Rows; i++)
        {
            for (int k = 0; k < this.Columns; k++)
            {
                output.Append(string.Format("{0,3} ", this[i, k]));
            }
            output.Append("\r\n");
        }
        return output.ToString();
    }
    #endregion
}