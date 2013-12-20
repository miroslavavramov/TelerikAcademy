using System;

// 08. Write a program that, depending on the user's choice inputs int, double or string variable. 
// If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
// The program must show the value of that variable as a console output. Use switch statement.
    class Program
    {
        static void Main()
        {
                int myInt = 0;
                double myDouble = 0;
                bool isDouble = false;
                string input = Console.ReadLine();
                
                isDouble = double.TryParse(input, out myDouble);
                if (isDouble == true)
                {
                    if (myDouble % 1 == 0)  
                    {
                            myInt = (int)myDouble + 1;
                            Console.WriteLine("Input type: \"int\" = {0}", myInt);
                    }
                    else
                    {
                        myDouble += 1;
                        Console.WriteLine("Input type: \"double\" = {0}", myDouble);
                    }
                }
                else
                {
                    Console.WriteLine("Input type: \"string\" = {0}", input + "*");
                }
                Console.ReadKey();
              


            
        }
    }

