namespace Bank.Common
{
    using System;
    using System.Text;

    public abstract class Account
    {
        private decimal monthlyInterestRate;
        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal MonthlyInterestRate
        {
            get { return this.monthlyInterestRate; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate can't be negative !");
                }
                this.monthlyInterestRate = value;
            }
        }

        protected Account(Customer customer, decimal balance, decimal interestRate) //i.o. to avoid creating accounts of non-specific type
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = interestRate;
        }

        public virtual decimal CalculateInterest(int months)
        {
            return this.Balance * this.MonthlyInterestRate * months;
        }

        public override string ToString()
        {
            return new StringBuilder()
            .AppendFormat("Account Holder: {0}", this.Customer.Name)
            .AppendFormat("\n #Acount Type: {0}", this.GetType().Name)
            .AppendFormat("\n #Customer Type: {0}", this.Customer.GetType().Name)
            .AppendFormat("\n #Balance: {0:C2}", this.Balance)
            .AppendFormat("\n #Monthly Interest Rate: {0:P}", this.MonthlyInterestRate)
            .ToString();
        }
    }
}
