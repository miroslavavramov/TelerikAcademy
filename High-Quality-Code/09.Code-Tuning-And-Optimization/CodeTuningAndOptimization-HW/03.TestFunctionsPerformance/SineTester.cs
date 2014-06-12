namespace TestFunctionsPerformance
{
    using System;
    using System.Diagnostics;

    public class SineTester
    {
        private static readonly Stopwatch Timer = new Stopwatch();

        public static long TestFloat(uint operationsCount)
        {
            Timer.Restart();

            for (float i = 1; i < operationsCount; i++)
            {
                Math.Sin(i);
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDouble(uint operationsCount)
        {
            Timer.Restart();

            for (double i = 1; i < operationsCount; i++)
            {
                Math.Sin(i);
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDecimal(uint operationsCount)
        {
            Timer.Restart();

            for (decimal i = 1; i < operationsCount; i++)
            {
                Math.Sin((double)i);
            }

            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
