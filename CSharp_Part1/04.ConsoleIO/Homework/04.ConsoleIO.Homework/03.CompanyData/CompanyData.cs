using System;
//03.A company has name, address, phone number, fax number, web site and manager. 
//The manager has first name, last name, age and a phone number. 
//Write a program that reads the information about a company and its manager and prints them on the console.


    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter Company Name: ");
                string companyName = Console.ReadLine();
                Console.Write("Enter Company Adress: ");
                string companyAdress = Console.ReadLine();
                Console.Write("Enter Company Phone Number: ");
                string companyPhoneNumber = Console.ReadLine();
                Console.Write("Enter Company Fax Number: ");
                string companyFaxNumber = Console.ReadLine();
                Console.Write("Enter Company Website: ");
                string webSite = Console.ReadLine();

                Console.WriteLine();

                Console.Write("Manager's First Name: ");
                string managerFirstName = Console.ReadLine();
                Console.Write("Manager's Last Name: ");
                string managerLastName = Console.ReadLine();
                Console.Write("Manager's Age: ");
                byte managerAge = byte.Parse(Console.ReadLine());
                Console.Write("Manager's Phone Number: ");
                string managerPhoneNumber = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine("Company Name: {0}", companyName);
                Console.WriteLine("Adress: {0}", companyAdress);
                Console.WriteLine("Phone Number: {0} \nFax Number: {1} ", companyPhoneNumber, companyFaxNumber);
                Console.WriteLine("Website: {0}", webSite);
                Console.WriteLine();
                Console.WriteLine("Manager : \nName: {0} {1}", managerFirstName, managerLastName);
                Console.WriteLine("Age : {0}", managerAge);
                Console.WriteLine("Phone Number: {0}", managerPhoneNumber);
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

