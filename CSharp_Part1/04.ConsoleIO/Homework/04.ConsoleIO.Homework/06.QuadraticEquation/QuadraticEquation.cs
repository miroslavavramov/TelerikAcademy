using System;
//06.Write a program that reads the coefficients a, b and c of a 
//quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine());
                double discriminant = (b * b) - (4 * a * c);

                if (a == 0)
                {
                    if (b == 0)
                    {
                        if (c == 0)
                        {
                            Console.WriteLine("Every number is a solution");
                        }
                        else
                        {
                            Console.WriteLine("There is no solution");
                        }
                    }
                    else
                    {
                        double root = -(c / b);
                        Console.WriteLine("The equation has one real root = {0}", root);
                    }
                }
                else
                {
                    if (discriminant < 0)
                    {
                        Console.WriteLine("The equation has no real roots");
                    }
                    else if (discriminant == 0)
                    {
                        double root = (-b) / (2 * a);
                        Console.WriteLine("root1 = root2 = {0}", root);
                    }
                    else
                    {
                        double root1 = ((((-b) + Math.Sqrt(discriminant)) / (2 * a)));
                        double root2 = ((((-b) - Math.Sqrt(discriminant)) / (2 * a)));
                        Console.WriteLine("The equation has two real roots = {0}, {1}", root1, root2);
                    }
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }

