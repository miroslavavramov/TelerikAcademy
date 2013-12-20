using System;

/*14. A bank account has a holder name (first name, middle name and last name), available amount of money (balance),
bank name, IBAN, BIC code and 3 credit card numbers associated with the account. 
Declare the variables needed to keep the information for a single bank account using the appropriate data types 
and descriptive names. */

    class BankAccount
    {
        static void Main()
        {
            Console.Write("Please Enter a First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Please Enter a Middle Name: ");
            string middleName = Console.ReadLine();
            Console.Write("Please Enter a Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Bank Name: ");
            string bankName = Console.ReadLine();
            Console.Write("Bank Balance: ");
            decimal bankBalance = decimal.Parse(Console.ReadLine());
            Console.Write("IBAN: ");
            string iban = Console.ReadLine();
            Console.Write("BIC/SWIFT: ");
            string bic = Console.ReadLine();

            Console.Write("First Credit Card Number: ");
            ulong creditCardNum1 = ulong.Parse(Console.ReadLine());
            Console.Write("Second Credit Card Number: ");
            ulong creditCardNum2 = ulong.Parse(Console.ReadLine());
            Console.Write("Third Credit Card Number: ");
            ulong creditCardNum3 = ulong.Parse(Console.ReadLine());

           
            Console.Clear();

            Console.WriteLine("Holder Name: {0} {1} {2}", firstName, middleName, lastName);
            Console.WriteLine("Bank Name: {0}", bankName);
            Console.WriteLine("Assets: {0}", bankBalance);
            Console.WriteLine("IBAN: {0}", iban);
            Console.WriteLine("BIC/SWIFT: {0}", bic);
            Console.Write("Credit Card Numbers: \n 1. {0} \n 2. {1} \n 3. {2}", creditCardNum1, creditCardNum2, creditCardNum3);

            Console.ReadKey();



        }
    }

