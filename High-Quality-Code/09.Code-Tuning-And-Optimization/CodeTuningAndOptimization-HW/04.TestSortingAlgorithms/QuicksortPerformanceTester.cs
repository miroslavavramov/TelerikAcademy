namespace TestSortingAlgorithms
{
    using System;
    using System.Diagnostics;

    public static class QuicksortPerformanceTester
    {
        private static readonly Stopwatch Timer = new Stopwatch();
        
        public static long TestIntArray(int[] array)
        {
            var quickSorter = new Quicksorter<int>();
            Timer.Restart();
            quickSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDoubleArray(double[] array)
        {
            var quickSorter = new Quicksorter<double>();
            Timer.Restart();
            quickSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestStringArray(string[] array)
        {
            var quickSorter = new Quicksorter<string>();
            Timer.Restart();
            quickSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
