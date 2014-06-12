namespace TestOperationsPerformance
{
    using System;

    public class Program
    {
        private static void Main()
        {
            uint operationsCount = 10000000;

            Console.WriteLine("Addition Performance(Int32) : " + AdditionTester.TestInt(operationsCount));
            Console.WriteLine("Addition Performance(Int64) : " + AdditionTester.TestLong(operationsCount));
            Console.WriteLine("Addition Performance(float) : " + AdditionTester.TestFloat(operationsCount));
            Console.WriteLine("Addition Performance(double) : " + AdditionTester.TestDouble(operationsCount));
            Console.WriteLine("Addition Performance(decimal) : " + AdditionTester.TestDecimal(operationsCount));

            Console.WriteLine();

            Console.WriteLine("Subtraction Performance(Int32) : " + SubtractionTester.TestInt(operationsCount));
            Console.WriteLine("Subtraction Performance(Int64) : " + SubtractionTester.TestLong(operationsCount));
            Console.WriteLine("Subtraction Performance(float) : " + SubtractionTester.TestFloat(operationsCount));
            Console.WriteLine("Subtraction Performance(double) : " + SubtractionTester.TestDouble(operationsCount));
            Console.WriteLine("Subtraction Performance(decimal) : " + SubtractionTester.TestDecimal(operationsCount));

            Console.WriteLine();

            Console.WriteLine("Multiplication Performance(Int32) : " + MultiplicationTester.TestInt(operationsCount));
            Console.WriteLine("Multiplication Performance(Int64) : " + MultiplicationTester.TestLong(operationsCount));
            Console.WriteLine("Multiplication Performance(float) : " + MultiplicationTester.TestFloat(operationsCount));
            Console.WriteLine("Multiplication Performance(double) : " + MultiplicationTester.TestDouble(operationsCount));
            Console.WriteLine("Multiplication Performance(decimal) : " + MultiplicationTester.TestDecimal(operationsCount));

            Console.WriteLine();

            Console.WriteLine("Division Performance(Int32) : " + DivisionTester.TestInt(operationsCount));
            Console.WriteLine("Division Performance(Int64) : " + DivisionTester.TestLong(operationsCount));
            Console.WriteLine("Division Performance(float) : " + DivisionTester.TestFloat(operationsCount));
            Console.WriteLine("Division Performance(double) : " + DivisionTester.TestDouble(operationsCount));
            Console.WriteLine("Division Performance(decimal) : " + DivisionTester.TestDecimal(operationsCount));
        }
    }
}