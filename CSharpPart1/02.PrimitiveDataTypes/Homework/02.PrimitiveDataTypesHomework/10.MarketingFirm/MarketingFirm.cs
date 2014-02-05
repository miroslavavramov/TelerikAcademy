using System;

// 10. A marketing firm wants to keep record of its employees. Each record would have the following characteristics – 
//first name, family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999).
//Declare the variables needed to keep the information for a single employee using appropriate data types and descriptive names.

    class MarketingFirm
    {
        static void Main()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("Gender male/female: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Identification Number: ");
            long idNum = long.Parse(Console.ReadLine());
            Console.Write("Enter Employee Number: ");
            int employeeNum = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine(" Employee Number: {0} \n Fist Name: {1} \n Last Name: {2} \n Age: {3} \n Gender: {4} \n ID: {5}", 
                employeeNum, firstName, lastName, age, gender, idNum);
            Console.ReadKey();


        }
    }

