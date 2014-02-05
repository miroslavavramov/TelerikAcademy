using System;
//05. Write program that asks for a digit and depending on the input shows the name of that digit 
//(in English) using a switch statement.

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter a digit from 0 to 9: ");
                int digit = int.Parse(Console.ReadLine());

                switch (digit)
                {
                    default:
                        Console.WriteLine("The given input is either too large or too small");
                        break;
                    case 1:
                        Console.WriteLine("one");
                        break;
                    case 2:
                        Console.WriteLine("two");
                        break;
                    case 3:
                        Console.WriteLine("three");
                        break;
                    case 4:
                        Console.WriteLine("four");
                        break;
                    case 5:
                        Console.WriteLine("five");
                        break;
                    case 6:
                        Console.WriteLine("six");
                        break;
                    case 7:
                        Console.WriteLine("seven");
                        break;
                    case 8:
                        Console.WriteLine("eight");
                        break;
                    case 9:
                        Console.WriteLine("nine");
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

