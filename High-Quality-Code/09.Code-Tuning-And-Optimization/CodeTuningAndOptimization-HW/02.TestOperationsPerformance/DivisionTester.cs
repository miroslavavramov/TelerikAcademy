namespace TestOperationsPerformance
{
    using System;
    using System.Diagnostics;
    
    public class DivisionTester
    {
        private const int IntDivisor = 1;
        private const long LongDivisor = 1;
        private const float FloatDivisor = 1f;
        private const double DoubleDivisor = 1d;
        private const decimal DecimalDivisor = 1m;

        private static readonly Stopwatch Timer = new Stopwatch();
        
        public static long TestInt(uint operationsCount)
        {
            int divident = 1;

            Timer.Restart();

            for (int i = 1; i < operationsCount; i++)
            {
                divident /= IntDivisor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestLong(uint operationsCount)
        {
            long divident = 1;

            Timer.Restart();

            for (long i = 1; i < operationsCount; i++)
            {
                divident /= LongDivisor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestFloat(uint operationsCount)
        {
            float divident = 1f;

            Timer.Restart();

            for (float i = 1; i < operationsCount; i++)
            {
                divident /= FloatDivisor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDouble(uint operationsCount)
        {
            double divident = 1d;

            Timer.Restart();

            for (double i = 1; i < operationsCount; i++)
            {
                divident /= DoubleDivisor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDecimal(uint operationsCount)
        {
            decimal divident = 1m;

            Timer.Restart();

            for (decimal i = 1; i < operationsCount; i++)
            {
                divident /= DecimalDivisor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
