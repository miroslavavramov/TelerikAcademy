namespace AlexandreDumasOOP.Common.Items
{
    using System;
    using System.Text;

    public abstract class Weapon : Item
    {
        private int damage;
        private int attackSpeed;

        protected Weapon(string name, int price, int damage, int attackSpeed)
            : base(name, price)
        {
            this.Damage = damage;
            this.AttackSpeed = attackSpeed;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new InvalidRangeException("Damage can not be negative or bigger than 100!");
                }
                this.damage = value;
            }
        }

        public int AttackSpeed
        {
            get
            {
                return this.attackSpeed;
            }
            protected set
            {
                if (value < 0 || value > 10)
                {
                    throw new InvalidRangeException("Attack speed can not be negative or bigger than 10!");
                }
                this.attackSpeed = value;
            }
        }

        public override string ToString()
        {
            return new StringBuilder(base.ToString())
                .AppendFormat("[Damage: {0}] [Attack Speed: {1}]",
                this.Damage, this.AttackSpeed)
                .ToString();
        }
    }
}