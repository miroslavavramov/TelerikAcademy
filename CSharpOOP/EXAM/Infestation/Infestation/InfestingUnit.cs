using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestingUnit : Unit
    {
        protected InfestingUnit(string id, UnitClassification unitType, int health, int power, int aggression) 
            : base(id, unitType, health, power, aggression)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var possibleTargets =
            from unit in attackableUnits
            where !(unit is InfestingUnit)
            select unit;

            possibleTargets = possibleTargets.OrderBy(x => x.Health);

            
            return possibleTargets.First();
            
        }
    }
}
