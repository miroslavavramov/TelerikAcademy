namespace Methods
{
    using System;

    public static class GeometricOperations
    {
        public static double CalculateTriangleAreaByHeron(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("No side should be smaller or equal to zero.");
            }

            if (!CanFormTriangle(a, b, c))
            {
                throw new ArgumentOutOfRangeException("Provided line lengths can't form a triangle.");
            }

            double semiperimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));

            return area;
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool IsVerticalLine(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("Provided coordinates overlap!");
            }

            return y1 == y2;
        }

        public static bool IsHorizontalLine(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("Provided coordinates overlap!");
            }

            return x1 == x2;
        }

        private static bool CanFormTriangle(double a, double b, double c)
        {
            return (a + b > c) & (a + c > b) && (b + c > a);
        }
    }
}
