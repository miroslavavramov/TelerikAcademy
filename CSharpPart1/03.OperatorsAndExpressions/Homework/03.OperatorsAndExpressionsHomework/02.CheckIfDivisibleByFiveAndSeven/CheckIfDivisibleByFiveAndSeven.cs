using System;
//02.Write a boolean expression that checks for given integer if it can be divided 
//(without remainder) by 7 and 5 in the same time.

 class Program
    {
        static void Main()
        {
            bool validInput = false;

            while (validInput == false)         //a "while loop" that will repeat until validInput==true;
            {
                Console.Write("Enter a number: ");
                try
                {
                    int num = int.Parse(Console.ReadLine());
                    bool divisibleByFiveAndSeven = false;

                    if ((num % 5 == 0) && (num % 7 == 0))
                    {
                        divisibleByFiveAndSeven = true;
                    }
                    Console.WriteLine("{0} is divisible without remainder by 5 and 7 at the same time: {1}",
                        num, divisibleByFiveAndSeven);
                    validInput = true;
                }
                catch (FormatException)     //if the input is not in correct format - executes the following code
                {
                    Console.Write("Invalid Input! Try again? (Y/N) ");
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
                catch (OverflowException) //if the input is too large or small for the specified data type, executes this:
                {
                    Console.Write("The number cannot fit in an Int32. Try Again ? (Y/N) ");
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

