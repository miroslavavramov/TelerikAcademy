using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreDumasOOP.Common.Items
{
    public class Sword : MeleeWeapon
    {
        public Sword(string name, int price, int damage, int attackSpeed, int doubleDamageRatio)
            : base(name, price, damage, attackSpeed, doubleDamageRatio)
        {
        }
    }
}
