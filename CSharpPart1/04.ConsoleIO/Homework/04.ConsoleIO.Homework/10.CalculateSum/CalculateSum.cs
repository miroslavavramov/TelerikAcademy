using System;
//10. Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

    class Program
    {
        static void Main()
        {
            double sum = 1.0D;
            double tempSum = 0;
            for (double i = 2; Math.Abs(sum - tempSum) > 0.001; i++)
            {
                tempSum = sum;
                if (i % 2 == 0)
                {
                    sum = tempSum + ((double)1 / i);
                }
                else
                {
                    sum = tempSum - ((double)1 / i);
                }
            }
            Console.WriteLine("{0:F3}", sum);
        }
    }

