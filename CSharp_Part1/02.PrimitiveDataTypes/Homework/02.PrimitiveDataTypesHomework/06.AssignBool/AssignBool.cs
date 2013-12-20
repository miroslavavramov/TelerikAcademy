using System;

//06. Declare a boolean variable called isFemale and assign an appropriate value corresponding to your gender.

    class Program
    {
        static void Main()
        {
            Console.Write("What is your gender? (male/female) ");
            string gender = Console.ReadLine();
            bool isFemale = false;
            if (gender == "male" || gender == "MALE" || gender == "m" || gender == "M") // "||" -"or" operator (или)
            {
                isFemale = false;
                Console.WriteLine("Is Female? : {0}", isFemale);
            }
            else if (gender == "female" || gender == "FEMALE" || gender == "f" || gender == "F")
            {
                isFemale = true;
                Console.WriteLine("Is Female? : {0}", isFemale);
            }
            else
            {
                Console.WriteLine("Incorrect input");
            }
            
            
        }
    }

