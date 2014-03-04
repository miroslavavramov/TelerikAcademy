using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreDumasOOP.Common.Items
{
    public class Crossbow : RangedWeapon
    {
        public Crossbow(string name, int price, int damage, int attackSpeed, int criticalStrikeRatio)
            : base(name, price, damage, attackSpeed, criticalStrikeRatio)
        {
        }
    }
}
