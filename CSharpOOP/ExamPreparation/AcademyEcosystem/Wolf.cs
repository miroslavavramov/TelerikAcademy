using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Wolf : Animal, ICarnivore
    {
        private const int DefaultWolfSize = 4;

        public Wolf(string name, Point location) 
            : base(name, location, DefaultWolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size || animal.State == AnimalState.Sleeping)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }
            
            return 0;
        }
    }
}
