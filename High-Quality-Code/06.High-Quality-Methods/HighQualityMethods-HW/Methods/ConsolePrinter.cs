namespace Methods
{
    using System;

    public static class ConsolePrinter
    {
        public static void PrintAsPercentage(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintWithPrecision(object number, int precision)
        {
            Console.WriteLine("{0:f" + precision + "}", number);
        }

        public static void PrintWithOffset(object number, int offset)
        {
            Console.WriteLine("{0," + offset + "}", number);
        }
    }
}
