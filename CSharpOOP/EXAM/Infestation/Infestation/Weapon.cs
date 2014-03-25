using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : Supplement
    {
        private const int BoostedPower = 10;
        private const int BoostedHealth = 0;
        private const int BoostedAggresssion = 3;

        private const int InitialPowerEffect = 0;
        private const int InitialHealthEffect = 0;
        private const int InitialAggressionEffect = 0;

        public Weapon() 
            : base(InitialPowerEffect, InitialHealthEffect, InitialAggressionEffect)
        {
        }

        public Weapon(int power, int health, int aggression)
            : base(power, health, aggression)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.AggressionEffect = BoostedAggresssion;
                this.HealthEffect = BoostedHealth;
                this.PowerEffect = BoostedPower;
            }
        }
    }
}
