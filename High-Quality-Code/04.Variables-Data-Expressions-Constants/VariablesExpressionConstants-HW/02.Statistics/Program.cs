namespace Statistics
{
    using System;

    class Program
    {
        static void Main()
        {
            double[] numbers = new double[] { 1, 2, 1.1, 57.3, -312, 0012, 66 };
            StatisticsExtensions.PrintStatistics(numbers, numbers.Length);
        }
    }
}
