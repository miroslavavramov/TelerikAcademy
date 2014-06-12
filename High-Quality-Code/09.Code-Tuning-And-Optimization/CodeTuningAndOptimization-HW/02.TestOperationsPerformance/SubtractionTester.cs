namespace TestOperationsPerformance
{
    using System;
    using System.Diagnostics;
    
    public class SubtractionTester
    {
        private const int IntSubtractor = 4;
        private const long LongSubtractor = 4;
        private const float FloatSubtractor = 4f;
        private const double DoubleSubtractor = 4d;
        private const decimal DecimalSubtractor = 4m;

        private static readonly Stopwatch Timer = new Stopwatch();
        
        public static long TestInt(uint operationsCount)
        {
            int sum = 0;

            Timer.Restart();

            for (int i = 0; i < operationsCount; i++)
            {
                sum -= IntSubtractor;
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
                sum -= LongSubtractor;
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
                sum -= FloatSubtractor;
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
                sum -= DoubleSubtractor;
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
                sum -= DecimalSubtractor;
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
