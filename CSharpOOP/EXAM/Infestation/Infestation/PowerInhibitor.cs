using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerInhibitor : Inhibitor
    {
        private const int PowerEffect = 3;
        private const int HealthEffect = 0;
        private const int AggressionEffect = 0;
     
        public PowerInhibitor() 
            : base(PowerEffect, HealthEffect, AggressionEffect)
        {
        }
    }
}
