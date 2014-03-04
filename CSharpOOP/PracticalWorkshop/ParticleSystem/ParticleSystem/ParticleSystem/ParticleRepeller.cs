using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleRepeller : Particle       //Task 3
    {
        private const uint DefaultRepellingRange = 5;
        private const uint DefaultRepellingPower = 3;

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed = new MatrixCoords(), 
            uint range = DefaultRepellingRange, uint power = DefaultRepellingPower)
            : base(position, speed)
        {
            this.Range = range;
            this.Power = power;
        }

        public uint Range { get; private set; }

        public uint Power { get; private set; }
        
        public override char[,] GetImage()
        {
            return new char[,] { { 'R' } };
        }
    }
}
