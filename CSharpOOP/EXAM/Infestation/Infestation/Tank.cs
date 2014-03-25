﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Tank : Unit
    {
        private const int TankBaseHealth = 20;
        private const int TankBasePower = 25;
        private const int TankBaseAggression = 25;
        
        public Tank(string id)
            : base(id, UnitClassification.Mechanical, TankBaseHealth, TankBasePower, TankBaseAggression)
        {
        }
    }
}
