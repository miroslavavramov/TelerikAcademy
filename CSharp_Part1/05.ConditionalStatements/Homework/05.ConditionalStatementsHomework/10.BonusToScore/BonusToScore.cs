using System;

    //10. Write a program that applies bonus scores to given scores in the range [1..9]. 
    //The program reads a digit as an input. If the digit is between 1 and 3, the program multiplies it by 10; 
    //if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. 
    //If it is zero or if the value is not a digit, the program must report an error.
    //Use a switch statement and at the end print the calculated new value in the console.

    class Program
    {
        static void Main()
        {
            Console.Write("Enter a number from 1 to 9: ");
            string input = Console.ReadLine();
            int num;
            bool isNum = int.TryParse(input, out num);
            switch (num)
            {
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
                case 1:
                case 2:
                case 3:
                    num *= 10;
                    Console.WriteLine(num);
                    break;
                case 4:
                case 5:
                case 6:
                    num *= 100;
                    Console.WriteLine(num);
                    break;
                case 7:
                case 8:
                case 9:
                    num *= 1000;
                    Console.WriteLine(num);
                    break;

            }
        }
    }

