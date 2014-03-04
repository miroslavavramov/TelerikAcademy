namespace AlexandreDumasOOP.Common.Items
{
    using System;
    using System.Text;

    public abstract class MeleeWeapon
    : Weapon
    {
        private int doubleDamageRatio;

        protected MeleeWeapon(string name, int price, int damage, int attackSpeed, int doubleDamageRatio) 
            : base(name, price, damage, attackSpeed)
        {
            this.DoubleDamageRatio = doubleDamageRatio;
        }

        public int DoubleDamageRatio
        {
            get
            {
                return this.doubleDamageRatio;
            }
            protected set
            {
                if (value < 0 || value > 50)
                {
                    throw new InvalidRangeException("Double damage ratio can not be negative or bigger than 50!");
                }
                this.doubleDamageRatio = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString())
                .AppendFormat("\r\n[Double Damage Ratio: {0}%]", this.DoubleDamageRatio)
                .ToString();
        }
    }
}