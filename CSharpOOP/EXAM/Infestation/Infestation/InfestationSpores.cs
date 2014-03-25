using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        private const int PowerEffect = -1;
        private const int HealthEffect = 0;
        private const int AggressionEffect = 20;

        public InfestationSpores() 
            : base(PowerEffect, HealthEffect, AggressionEffect)
        {
        }
    }
}
