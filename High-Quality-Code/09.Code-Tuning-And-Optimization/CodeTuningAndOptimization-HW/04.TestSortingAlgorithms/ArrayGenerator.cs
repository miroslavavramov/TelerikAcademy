namespace TestSortingAlgorithms
{
    using System;
    using System.Text;

    public class ArrayGenerator
    {
        private static readonly Random GlobalRandomGenerator = new Random();

        public static int[] GenerateRandomIntArray(int arrayLength, int minValue, int maxValue)
        {
            var result = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                GetRandomInt(minValue, maxValue);
            }

            return result;
        }

        public static double[] GenerateRandomDoubleArray(int arrayLength, double minValue, double maxValue)
        {
            var result = new double[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                GetRandomDouble(minValue, maxValue);
            }

            return result;
        }

        public static string[] GenerateRandomStringArray(int arrayLength, int minLength, int maxLength)
        {
            var result = new string[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                result[i] = GetRandomString(minLength, maxLength);
            }

            return result;
        }

        private static int GetRandomInt(int min, int max)
        {
            return GlobalRandomGenerator.Next(min, max + 1);    
        }

        private static double GetRandomDouble(double min, double max)
        {
            return (GlobalRandomGenerator.NextDouble() * (max - min)) + min;
        }

        private static string GetRandomString(int minLength, int maxLength)
        {
            int length = GlobalRandomGenerator.Next(minLength, maxLength + 1);

            var output = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                output.Append((char)GlobalRandomGenerator.Next(33, 127));
            }

            return output.ToString();
        }
    }
}
