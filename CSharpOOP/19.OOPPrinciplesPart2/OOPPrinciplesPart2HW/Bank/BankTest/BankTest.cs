using Bank.Common;
using System;
using System.Collections.Generic;
using System.Linq;

class BankTest
{
    static void Main()
    {
        var accounts = new List<Account>()
        {
            new DepositAccount(new IndividualCustomer("Ivan Ivanov"), 9591.5M, .001M),
            new MortgageAccount(new IndividualCustomer("Petar Petrov"), -1e+5M, .05M),
            new LoanAccount(new CorporateCustomer("Planet Express Ltd."), -2e+4M, .025M),
            new DepositAccount(new CorporateCustomer("Ponzi Ltd."), 5e+6M, 0.0045M),
        };

        Print(accounts);

        Console.WriteLine("\nPonzi Ltd's interest for 12 months: {0:C}",
        accounts[3].CalculateInterest(months: 12) );

        LoanAccount loanAccount = new LoanAccount(new IndividualCustomer("Dr. Zoidberg"), -5000, 5);
        loanAccount.Deposit(4500);
        Console.WriteLine("{0} has {1:C} left to pay off his loan.", loanAccount.Customer.Name, -loanAccount.Balance);
    }

    static void Print<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}

