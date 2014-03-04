using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int DefaultLionSize = 6;

        public Lion(string name, Point location) 
            : base(name, location, DefaultLionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size * 2 >= animal.Size)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
            }
            
            return 0;
        }
    }
}
