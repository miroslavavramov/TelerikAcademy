using System;

//09.Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
//and out of the rectangle R(top=1, left=-1, width=6, height=2).

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
                bool inRectangle = true;

                if ((Math.Pow((x - 1), 2) + Math.Pow((y - 1), 2)) <= 9)     //check if P(x,y) is within the circle K
                {
                    inCircle = true;
                }
                if ((x > 5) || (x < -1) || (y > 1) || (y < -1))         //check if P(x,y) is within the rectangle R
                {
                    inRectangle = false;
                }

                if (inCircle == true && inRectangle == false)
                {
                    Console.WriteLine("P({0} , {1}) is within K and outside rectangle R", x, y);
                }
                else if (inCircle == false && inRectangle == false)
                {
                    Console.WriteLine("P({0} , {1}) is outside both circle K and rectangle R", x, y);
                }
                else if (inCircle == true && inRectangle == true)
                {
                    Console.WriteLine("P({0} , {1}) is within both circle K and rectangle R", x, y);
                }
                else if (inCircle == false && inRectangle == true)
                {
                    Console.WriteLine("P({0} , {1}) is outside circle K and inside rectangle R", x, y);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
            Console.ReadKey();
        }
    }

