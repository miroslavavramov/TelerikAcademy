namespace Bank.Common
{
    public class DepositAccount
        : Account, IDepositable, IWithdrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate )
            : base(customer, balance, interestRate)
        {
        }

        public void Deposit(decimal sum)
        {
            this.Balance += sum;
        }

        public void Withdraw(decimal sum)
        {
            this.Balance -= sum;
        }

        public override decimal CalculateInterest(int months)
        {
            if(this.Balance >= 0 && this.Balance <= 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}
