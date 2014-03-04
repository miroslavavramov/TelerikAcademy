namespace AlexandreDumasOOP.Common.Items
{
    using AlexandreDumasOOP.Common.Interfaces;
    using System;
    using System.Text;

    public class Charm
    :Item, IEvader
    {
        private int healthPoints;
        private int evasionRatio;
        
        public Charm(string name, int price, int healthPoints, int evasionRatio) 
            : base(name, price)
        {
            this.HealthPoints = healthPoints;
            this.EvasionRatio = evasionRatio;
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            private set
            {
                if (value < 0 || value > 150)
                {
                    throw new InvalidRangeException("Health Bonus can not be negative or bigger than 150", 0, 150);
                }
                this.healthPoints = value;
            }
        }

        public int EvasionRatio
        {
            get
            {
                return this.evasionRatio;
            }
            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new InvalidRangeException("Evasion Bonus can not be negative or bigger than 50!");
                }
                this.evasionRatio = value;
            }
        }

        public override string ToString()
        {
            var output =  new StringBuilder(base.ToString());
            
            if (this.HealthPoints != 0)
            {
                output.AppendFormat("[Health Bonus +{0}] ", this.HealthPoints);
            }
            if (this.EvasionRatio != 0)
            {
                output.AppendFormat("[Evasion Bonus +{0}%] ", this.EvasionRatio);
            }
            
            return output.ToString();
        }
    }
}