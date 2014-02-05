using System;

// 08. Write a program that, depending on the user's choice inputs int, double or string variable. 
// If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. 
// The program must show the value of that variable as a console output. Use switch statement.

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Choose a variable type (int, double or string) : ");
            Console.WriteLine("Type 1 for int; 2 for double; 3 for string");

            int variableType = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (variableType)
            {
                default:
                    Console.WriteLine("Invalid Input");
                    break;
                case 1:
                    Console.Write("Enter value for your \"int\" : ");
                    int myInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("Output: {0}", (myInt + 1));
                    break;
                case 2:
                    Console.Write("Enter value for your \"double\" : ");
                    double myDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine("Output: {0}", myDouble + 1);
                    break;
                case 3:
                    Console.Write("Enter value for your \"string\" : ");
                    string myString = Console.ReadLine();
                    Console.WriteLine("Output: {0}", myString + "*");
                    break;
            }
             Console.ReadKey();
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
    

