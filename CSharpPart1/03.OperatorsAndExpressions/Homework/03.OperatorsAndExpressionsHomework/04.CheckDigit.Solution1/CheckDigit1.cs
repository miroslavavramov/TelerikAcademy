using System;
//04.Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

    class Program
    {
        static void Main()
        {
            bool validInput = false;
            while (validInput == false)
            {
                try
                {
                    Console.Write("Enter a number that is at least 3 digits: ");
                    int number = int.Parse(Console.ReadLine());
                    if (number > 99)
                    {
                        if (number % 1000 > 699 && number % 1000 < 800)
                        {
                            Console.WriteLine("The third digit from right to left is 7: {0}", true);
                        }
                        else
                        {
                            Console.WriteLine("The third digit from right to left is 7: {0}", false);
                        }
                        validInput = true;
                    }
                    else
                    {
                        Console.Write("The number must contain at least three digits! Try again? (Y/N)");
                        string key = Console.ReadLine();
                            if (key == "y" || key == "Y")
	                        {
		                    }
                            else
                            {
                                validInput = true;
                            }
                    }
                }
                catch (FormatException fe)
                {
                    Console.Write(fe.Message + "\nTry Again? (Y/N) ");
                    string key = Console.ReadLine();
                            if (key == "y" || key == "Y")
	                        {
		                    }
                            else
                            {
                                validInput = true;
                            }
                }
                catch (OverflowException ofe)
                {
                    Console.Write(ofe.Message + "\nTry Again? (Y/N) ");
                    string key = Console.ReadLine();
                            if (key == "y" || key == "Y")
	                        {
		                    }
                            else
                            {
                                validInput = true;
                            }
                }
            }
        }
    }

