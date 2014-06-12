namespace TestOperationsPerformance
{
    using System;
    using System.Diagnostics;
    
    public static class AdditionTester
    {
        private const int IntAddend = 4;
        private const long LongAddend = 4;
        private const float FloatAddend = 4f;
        private const double DoubleAddend = 4d;
        private const decimal DecimalAddend = 4m;

        private static readonly Stopwatch Timer = new Stopwatch();
        
        public static long TestInt(uint operationsCount)
        {
            int sum = 0;

            Timer.Restart();

            for (int i = 0; i < operationsCount; i++)
            {
                sum += IntAddend;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestLong(uint operationsCount)
        {
            long sum = 0;

            Timer.Restart();

            for (long i = 0; i < operationsCount; i++)
            {
                sum += LongAddend;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestFloat(uint operationsCount)
        {
            float sum = 0f;

            Timer.Restart();

            for (float i = 0; i < operationsCount; i++)
            {
                sum += FloatAddend;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDouble(uint operationsCount)
        {
            double sum = 0d;

            Timer.Restart();

            for (double i = 0; i < operationsCount; i++)
            {
                sum += DoubleAddend;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDecimal(uint operationsCount)
        {
            decimal sum = 0m;

            Timer.Restart();

            for (decimal i = 0; i < operationsCount; i++)
            {
                sum += DecimalAddend;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
