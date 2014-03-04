namespace AlexandreDumasOOP.Common.Items
{
    using AlexandreDumasOOP.Common.Interfaces;
    using System;
    using System.Text;

    public class Armour
    : Item, IEvader
    {
        private int defence;
        private int evasionRatio;

        public Armour(string name, int price, int defence, int evasionRatio) 
            : base(name, price)
        {
            this.Defence = defence;
            this.EvasionRatio = evasionRatio;
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }
            private set
            {
                if (value < 0 || value > 1000)
                {
                    throw new InvalidRangeException("Defence can not be negative or bigger than 1000!", 0, 1000);
                }
                this.defence = value;
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
                    throw new InvalidRangeException("Evasion ratio can not be negative or bigger than 50!");
                }
                this.evasionRatio = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString())
                .AppendFormat("[Defence: {0}] [Evasion Ratio: {1}%]", this.Defence, this.EvasionRatio)
                .ToString();       
        }
    }
}