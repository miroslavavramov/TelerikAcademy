using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionInhibitor : Inhibitor
    {
        private const int PowerEffect = 0;
        private const int HealthEffect = 0;
        private const int AggressionEffect = 3;
     
        public AggressionInhibitor() 
            : base(PowerEffect, HealthEffect, AggressionEffect)
        {
        }
    }
}
