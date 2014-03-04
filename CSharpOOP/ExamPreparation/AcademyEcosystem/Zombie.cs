using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int DefaultZombieSize = 0;

        public Zombie(string name, Point location) 
            : base(name, location, DefaultZombieSize)
        {
        }

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
