namespace TestFunctionsPerformance
{
    using System;

    public class Program
    {
        private static void Main()
        {
            uint operationsCount = 10000000;

            Console.WriteLine("Natural logarithm peformance(float) : " + LogarithmTester.TestFloat(operationsCount));
            Console.WriteLine("Natural logarithm peformance(double) : " + LogarithmTester.TestDouble(operationsCount));
            Console.WriteLine("Natural logarithm peformance(decimal) : " + LogarithmTester.TestDecimal(operationsCount));

            Console.WriteLine();

            Console.WriteLine("Sine function peformance(float) : " + SineTester.TestFloat(operationsCount));
            Console.WriteLine("Sine function peformance(double) : " + SineTester.TestDouble(operationsCount));
            Console.WriteLine("Sine function peformance(decimal) : " + SineTester.TestDecimal(operationsCount));

            Console.WriteLine();

            Console.WriteLine("Square root peformance(float) : " + SineTester.TestFloat(operationsCount));
            Console.WriteLine("Square root peformance(double) : " + SineTester.TestDouble(operationsCount));
            Console.WriteLine("Square root peformance(decimal) : " + SineTester.TestDecimal(operationsCount));
        }
    }
}
