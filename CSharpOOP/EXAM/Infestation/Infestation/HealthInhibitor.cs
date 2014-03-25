using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthInhibitor : Inhibitor
    {
        private const int PowerEffect = 0;
        private const int HealthEffect = 3;
        private const int AggressionEffect = 0;
     
        public HealthInhibitor() 
            : base(PowerEffect, HealthEffect, AggressionEffect)
        {
        }
    }
}
