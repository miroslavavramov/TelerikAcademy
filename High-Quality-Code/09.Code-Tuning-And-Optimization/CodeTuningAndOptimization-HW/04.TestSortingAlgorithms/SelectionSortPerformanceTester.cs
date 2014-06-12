namespace TestSortingAlgorithms
{
    using System;
    using System.Diagnostics;

    public static class SelectionSortPerformanceTester
    {
        private static readonly Stopwatch Timer = new Stopwatch();

        public static long TestIntArray(int[] array)
        {
            var selectionSorter = new SelectionSorter<int>();
            Timer.Restart();
            selectionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestDoubleArray(double[] array)
        {
            var selectionSorter = new SelectionSorter<double>();
            Timer.Restart();
            selectionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        public static long TestStringArray(string[] array)
        {
            var selectionSorter = new SelectionSorter<string>();
            Timer.Restart();
            selectionSorter.Sort(array);
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }
    }
}
