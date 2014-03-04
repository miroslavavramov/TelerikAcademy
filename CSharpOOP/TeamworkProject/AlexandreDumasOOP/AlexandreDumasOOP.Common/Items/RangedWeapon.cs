namespace AlexandreDumasOOP.Common.Items
{
    using System;
    using System.Text;

    public abstract class RangedWeapon
    : Weapon
    {
        private int criticalStrikeRatio;

        protected RangedWeapon(string name, int price, int damage, int attackSpeed, int criticalStrikeRatio) 
            : base(name, price, damage, attackSpeed)
        {
            this.CriticalStrikeRatio = criticalStrikeRatio;
        }

        public int CriticalStrikeRatio
        {
            get
            { 
                return this.criticalStrikeRatio; 
            }
            protected set
            {
                if (value < 0 || value > 50)
                {
                    throw new InvalidRangeException("Critical damage ratio can not be negative or bigger than 50!");
                }
                this.criticalStrikeRatio = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString())
                .AppendFormat("\r\n[Critical Strike Ratio: {0}%]", this.CriticalStrikeRatio)
                .ToString();
        }
    }
}