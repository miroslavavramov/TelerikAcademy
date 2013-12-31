using System;
//Write methods that calculates the surface of a triangle by given:
//Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.
class CalcSurface
{
    static void Main()
    {
        Console.WriteLine(CalcAreaBySideAndAltitude(7,6));
        Console.WriteLine(CalcAreaByTwoSidesAndAngle(5,6,55));
        Console.WriteLine(CalcAreaByHeron(10,12,15));
    }
    static double CalcAreaBySideAndAltitude(double a, double h)
    {
        return (a * h) / 2;
    }
    static double CalcAreaByTwoSidesAndAngle(double a, double b, double gamma)
    {
        return a*b*Math.Sin(Math.PI * 45 / 180);
    }
    static double CalcAreaByHeron(double a, double b, double c)
    {
        double p = (a+b+c)/2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    
}

