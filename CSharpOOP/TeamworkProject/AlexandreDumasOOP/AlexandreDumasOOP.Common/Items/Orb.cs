﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexandreDumasOOP.Common.Items
{
    public class Orb : MagicalWeapon
    {
        public Orb(string name, int price, int damage, int attackSpeed, int directDamageRatio)
            : base(name, price, damage, attackSpeed, directDamageRatio)
        {
        }
    }
}
