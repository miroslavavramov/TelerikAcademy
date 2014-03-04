namespace AlexandreDumasOOP.Common.Items
{
    using System;
    using System.Text;

    public abstract class MagicalWeapon
    : Weapon
    {
        private int directDamageRatio;

        protected MagicalWeapon(string name, int price, int damage, int attackSpeed, int directDamageRatio) 
            : base(name, price, damage, attackSpeed)
        {
            this.DirectDamageRatio = directDamageRatio;
        }

        public int DirectDamageRatio
        {
            get
            {
                return this.directDamageRatio;
            }
            protected set
            {
                if (value < 0 || value > 50)
                {
                    throw new InvalidRangeException("Direct damage ratio can not be negative or bigger than 50!");
                }
                this.directDamageRatio = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString())
                .AppendFormat("\r\n[Direct Damage Ratio: {0}%]", this.DirectDamageRatio)
                .ToString();
        }
    }
}
