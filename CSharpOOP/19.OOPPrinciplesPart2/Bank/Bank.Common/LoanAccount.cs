namespace Bank.Common
{
    using System;
    public class LoanAccount
        : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterest(months - 3);
            }
            else //if (this.Customer is CorporateCustomer)
            {
                return base.CalculateInterest(months - 2);
            }
        }
    }
}
