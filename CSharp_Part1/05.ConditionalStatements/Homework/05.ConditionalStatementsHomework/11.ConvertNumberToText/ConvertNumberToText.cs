using System;
using System.Collections.Generic;

/* 11* Write a program that converts a number in the range [0...999] to a text 
    corresponding to its English pronunciation. Examples:
	0  "Zero"
	273  "Two hundred seventy three"
	400  "Four hundred"
	501  "Five hundred and one"
	711  "Seven hundred and eleven" */

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("number[0..999] = ");
                GetNumberName(int.Parse(Console.ReadLine()));
            }
            catch(OverflowException ofe)
            {
                Console.WriteLine(ofe.Message);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        static void GetNumberName(int input)    //declare a method that will take the input integer
        {                                       //and print its name in english

            //declare three string arrays, that will keep the names; the index of each element corresponds to
            //the name of the digit/number it keeps

            string[] unitNames = {"", "one", "two", "three", "four", "five",
                                    "six", "seven", "eight", "nine", "ten", "eleven",
                                    "twelve", "thirteen", "fourteen", "fifteen", "sixteen", 
                                    "seventeen", "eightteen", "nineteen" };

            string[] decimalNames = {"", "", "twenty", "thirty", "fourty", "fifty",
                                "sixty", "seventy", "eighty", "ninety"};

            string[] hundredNames = {"", "one hundred", "two hundred", "three hundred", "four hundred",
                               "five hundred", "six hundred", "seven hundred", "eight hundred", "nine hundred"};

            

            int hundreds = input / 100;                         //find out the amount of hundreds
            int decimals = (input / 10) - hundreds * 10;        //decimals and units of the input number
            int units = input % 10;                             //and keep them in seperate "int" variables 

            if (input >= 100 && input <= 999)
            {
                if (decimals < 2)
                {
                    if (units == 0 && decimals == 0)
                    {
                        Console.WriteLine(hundredNames[hundreds]);
                    }
                    else
                    {
                        Console.WriteLine("{0} and {1}", hundredNames[hundreds], unitNames[input % 100]);
                    }
                }
                else
                {
                    Console.WriteLine("{0} and {1} {2}", hundredNames[hundreds], 
                        decimalNames[decimals], unitNames[units]);
                }
            }

            else if (input >= 20 && input <= 99)
            {
                Console.WriteLine("{0} {1}", decimalNames[decimals], unitNames[units]);
            }

            else if (input >= 0 && input < 20)
            {
                if (input == 0)
                {
                    Console.WriteLine("zero");
                }
                Console.WriteLine("{0}", unitNames[input]);
            }

            else
            {
                Console.WriteLine("Invalid Input");  //this will take place if the input is outside the [0..999] interval
            }
            
            
        }
    }

