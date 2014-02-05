using System;
//06.Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter the coordinates of a point P(x,y): ");
                Console.Write("x = ");
                float x = float.Parse(Console.ReadLine());
                Console.Write("y = ");
                float y = float.Parse(Console.ReadLine());
                bool inCircle = false;

                if ((Math.Pow(x, 2) + Math.Pow(y, 2)) <= Math.Pow(5, 2)) //for p(x,y) to be in K(0,r)
                {                                                        // x^2 + y^2 should be <= to r^2   
                    inCircle = true;
                }
                Console.WriteLine("The point p({0}, {1}) is within the circle K(0, 5): {2}", x, y, inCircle);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
        }
    }

