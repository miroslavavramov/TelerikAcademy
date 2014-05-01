namespace Bank.Common
{
    using System;
    public class MortgageAccount
        : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
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
                if (months > 6)
                {
                    return base.CalculateInterest(months - 6);
                }
                else return 0; 
            }
            else 
            {
                if (months > 12)
                {
                    return base.CalculateInterest(months - 12) * base.CalculateInterest(12) / 2;
                }
                else
                {
                    return base.CalculateInterest(months) / 2;
                }
            }
        }
    }
}
