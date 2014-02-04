namespace People.Common
{
    using System;

    public class Worker
        : Human
    {
        private const byte weeklyWorkdays = 5;
        private decimal? weeklySalary;
        private byte? dailyWorkingHours;

        public decimal? WeeklySalary
        {
            get { return this.weeklySalary; }
            set
            {
                if (value != null)
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("Salary can't be negative!");
                    }
                }
                this.weeklySalary = value;
            }
        }

        public byte? DailyWorkingHours
        {
            get { return this.dailyWorkingHours; }
            set
            {
                if (value != null)
                {
                    if (!(value > 0 && value <= 24))
                    {
                        throw new ArgumentOutOfRangeException("Invalid working hours!");
                    }
                }
                this.dailyWorkingHours = value;
            }
        }

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }
        public Worker(string firstName, string lastName, decimal weeklySalary, byte dailyWorkingHours)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.DailyWorkingHours = dailyWorkingHours;
        }

        public decimal CalcHourlySalary()
        {
            if (this.DailyWorkingHours == null || this.WeeklySalary == null)
            {
                throw new ArgumentNullException("The complete information isn't provided!");
            }
            return (decimal)(this.WeeklySalary / (this.DailyWorkingHours * weeklyWorkdays));
        }

        public override string ToString()
        {
            return String.Format("{0} {1} | Hourly Salary : {2:C2}", this.FirstName, this.LastName, this.CalcHourlySalary());
        }
    }
}