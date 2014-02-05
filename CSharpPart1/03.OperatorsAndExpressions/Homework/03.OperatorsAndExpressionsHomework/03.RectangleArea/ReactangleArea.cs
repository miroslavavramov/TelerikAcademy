using System;
//03.Write an expression that calculates rectangle’s area by given width and height.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter height: ");
                double height = double.Parse(Console.ReadLine());
                Console.Write("Enter width: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("The rectangle's area equals {0} \n", (height * width));
            }
            catch(FormatException fe)       
            {
                Console.WriteLine(fe.Message);   
            }
           
            
        }
    }

