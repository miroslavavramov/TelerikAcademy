using System;

//04.Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

    class Program
    {
        static void Main()
        {
            Console.Write("Enter a number which contains at least three digits: ");
            string number = Console.ReadLine();         
            char[] array = number.ToCharArray();        //Convert it to a char array

            bool check = false;
            double digit = Char.GetNumericValue(array[array.Length - 3]); //Get the numeric value of the third element from right to left

            Console.WriteLine("The third digit from right to left is {0} ", array[array.Length - 3]);   //Print it
            
            if (digit == 7)
            {
                check = true;
            }
            Console.WriteLine("Equal to 7 ?: {0}", check);
            Console.ReadKey();
        }
    }

