namespace TestSortingAlgorithms
{
    using System;

    public class Program
    {
        private static void Main()
        {
            int length = 10000;

            Console.WriteLine(
                "Insertion sort performance for Int array of size 10000 : " +
                InsertionSortPerformanceTester.TestIntArray(
                ArrayGenerator.GenerateRandomIntArray(length, -1000, 1000)));

            Console.WriteLine(
                "Insertion sort for Double array of size 10000 : " +
                InsertionSortPerformanceTester.TestDoubleArray(
                ArrayGenerator.GenerateRandomDoubleArray(length, -1000, 1000)));

            Console.WriteLine(
                "Insertion sort for String array of size 10000 : " +
                InsertionSortPerformanceTester.TestStringArray(
                ArrayGenerator.GenerateRandomStringArray(length, 1, 100)));

            Console.WriteLine();

            Console.WriteLine(
                "Quicksort performance for Int array of size 10000 : " +
                QuicksortPerformanceTester.TestIntArray(
                ArrayGenerator.GenerateRandomIntArray(length, -1000, 1000)));

            Console.WriteLine(
                "Quicksort performance for Double array of size 10000 : " +
                QuicksortPerformanceTester.TestDoubleArray(
                ArrayGenerator.GenerateRandomDoubleArray(length, -1000, 1000)));

            Console.WriteLine(
                "Quicksort performance for String array of size 10000 : " +
                QuicksortPerformanceTester.TestStringArray(
                ArrayGenerator.GenerateRandomStringArray(length, 1, 100)));

            Console.WriteLine();

            Console.WriteLine(
                "Selection sort performance for Int array of size 10000 : " +
                SelectionSortPerformanceTester.TestIntArray(
                ArrayGenerator.GenerateRandomIntArray(length, -1000, 1000)));

            Console.WriteLine(
                "Selection sort performance for Double array of size 10000 : " +
                SelectionSortPerformanceTester.TestDoubleArray(
                ArrayGenerator.GenerateRandomDoubleArray(length, -1000, 1000)));

            Console.WriteLine(
                "Selection sort performance for String array of size 10000 : " +
                SelectionSortPerformanceTester.TestStringArray(
                ArrayGenerator.GenerateRandomStringArray(length, 1, 100)));
        }
    }
}
