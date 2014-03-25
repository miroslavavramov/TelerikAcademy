using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class WeaponrySkill : Supplement
    {
        private const int PowerEffect = 0;
        private const int HealthEffect = 0;
        private const int AggressionEffect = 0;

        public WeaponrySkill() 
            : base(PowerEffect, HealthEffect, AggressionEffect)
        {
        }
    }
}
