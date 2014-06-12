namespace Statistics
{
    using System;
    
    public static class StatisticsExtensions
    {
        public static void PrintStatistics(double[] numbers, int numbersCount)
        {
            double largestNumber = GetMaxNumber(numbers, numbersCount);
            Console.WriteLine("Largest Number : {0}", largestNumber);

            double smallestNumber = GetMinNumber(numbers, numbersCount);
            Console.WriteLine("Smallest Number : {0}", smallestNumber);

            double average = GetAverage(numbers, numbersCount);
            Console.WriteLine("Average: {0}", average);
        }

        private static double GetMaxNumber(double[] numbers, int numbersCount)
        {
            double max = double.MinValue;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private static double GetMinNumber(double[] numbers, int numbersCount)
        {
            double min = double.MaxValue;

            for (int i = 0; i < numbersCount; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private static double GetAverage(double[] numbers, int numbersCount)
        {
            double sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                sum += numbers[i];
            }

            double average = sum / numbersCount;

            return average;
        }
    }
}
