﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id) 
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var possibleTargets =
            from unit in attackableUnits
            where unit.Power <= this.Aggression
            select unit;

            possibleTargets = possibleTargets.OrderByDescending(x => x.Health);

            return possibleTargets.First();
        }
    }
}
