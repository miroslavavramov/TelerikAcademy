namespace TestOperationsPerformance
{
    using System;
    using System.Diagnostics;
    
    public class MultiplicationTester
    {
        private const int IntMultiplier = 1;
        private const long LongMultiplier = 1;
        private const float FloatMultiplier = 1f;
        private const double DoubleMultiplier = 1d;
        private const decimal DecimalMultiplier = 1m;

        private static readonly Stopwatch Timer = new Stopwatch();
        
        public static long TestInt(uint operationsCount)
        {
            int product = 1;

            Timer.Restart();

            for (int i = 1; i < operationsCount; i++)
            {
                product *= IntMultiplier;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestLong(uint operationsCount)
        {
            long product = 1;

            Timer.Restart();

            for (long i = 1; i < operationsCount; i++)
            {
                product *= LongMultiplier;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestFloat(uint operationsCount)
        {
            float product = 1f;

            Timer.Restart();

            for (float i = 1; i < operationsCount; i++)
            {
                product *= FloatMultiplier;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDouble(uint operationsCount)
        {
            double product = 1d;

            Timer.Restart();

            for (double i = 1; i < operationsCount; i++)
            {
                product *= DoubleMultiplier;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDecimal(uint operationsCount)
        {
            decimal product = 1m;

            Timer.Restart();

            for (decimal i = 1; i < operationsCount; i++)
            {
                product *= DecimalMultiplier;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
