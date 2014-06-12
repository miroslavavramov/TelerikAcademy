namespace Methods
{
    using System;

    public class MethodsDemo
    {
        private static void Main()
        {
            Console.WriteLine(GeometricOperations.CalculateTriangleAreaByHeron(3, 4, 5));
            
            Console.WriteLine(NumberParser.NumberToDigit(5));
            
            Console.WriteLine(StatisticalOperations.FindMax(5, -1, 3, 2, 14, 2, 3));
            
            ConsolePrinter.PrintWithPrecision(1.3, 3);
            ConsolePrinter.PrintAsPercentage(0.75);
            ConsolePrinter.PrintWithOffset(2.30, 8);
            
            Console.WriteLine(GeometricOperations.CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + GeometricOperations.IsHorizontalLine(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + GeometricOperations.IsVerticalLine(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "Sofia");
            
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "Vidin");
            stella.AdditionalInfo = "From Vidin, gamer, high results. ";
            
            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName, 
                stella.FirstName, 
                peter.IsOlderThan(stella));
        }
    }
}
