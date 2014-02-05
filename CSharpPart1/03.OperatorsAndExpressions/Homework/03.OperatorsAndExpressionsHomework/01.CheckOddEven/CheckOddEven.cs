using System;
//01.Write an expression that checks if given integer is odd or even.

    class Program
    {
        static void Main()
        {
            bool validInput = false;
            while (validInput == false)     //a "while loop" that will repeat until validInput==true;
            {
                Console.Write("Enter a number: ");
                try                  
                {
                    int num = int.Parse(Console.ReadLine());

                    if (num % 2 == 0)
                    {
                        Console.WriteLine("{0} is even ", num);
                    }
                    else
                    {
                        Console.WriteLine("{0} is odd", num);
                    }
                    validInput = true;
                }
                catch (FormatException)     //if the input is not in correct format - executes the following code
                {
                    Console.Write("Incorrect Input! Try Again ? (Y/N)");
                    string key = Console.ReadLine();
                    if (key == "y" || key == "Y")
                    {
                        validInput = false;
                    }
                    else 
                    {
                        validInput = true;
                    }
                }
                catch (OverflowException)    //if the input is too large or small for the specified data type, executes this:
                {
                    Console.Write("The number cannot fit in an Int32. Try Again ? (Y/N)");
                    string key = Console.ReadLine();
                    if (key == "y" || key == "Y")
                    {
                        validInput = false;
                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
            
            
        }
    }

