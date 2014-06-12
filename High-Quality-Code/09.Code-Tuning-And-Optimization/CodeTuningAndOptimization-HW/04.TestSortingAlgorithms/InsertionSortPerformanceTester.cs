namespace TestSortingAlgorithms
{
    using System;
    using System.Diagnostics;

    public class InsertionSortPerformanceTester
    {
        private static readonly Stopwatch Timer = new Stopwatch();

        public static long TestIntArray(int[] array)
        {
            var insertionSorter = new InsertionSorter<int>();
            Timer.Restart();
            insertionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDoubleArray(double[] array)
        {
            var insertionSorter = new InsertionSorter<double>();
            Timer.Restart();
            insertionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestStringArray(string[] array)
        {
            var insertionSorter = new InsertionSorter<string>();
            Timer.Restart();
            insertionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
