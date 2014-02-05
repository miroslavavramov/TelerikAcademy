using System;
using System.Text;

/*09.Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
 * Use Windows Character Map to find the Unicode code of the © symbol. 
 * Note: the © symbol may be displayed incorrectly. */


    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            Console.Clear();        //clears the console 

            for (int i = 1; i <= num; i++)
            {
                string spaces = new string(' ', num  - i);              
                string symbols = new string('\u00A9', 2*i-1);
                Console.WriteLine(spaces + symbols);
            }
            Console.ReadKey();
        }
    }

