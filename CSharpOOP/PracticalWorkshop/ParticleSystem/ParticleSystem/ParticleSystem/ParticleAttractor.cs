using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleAttractor : Particle
    {
        public ParticleAttractor(MatrixCoords position, MatrixCoords speed, int attractionPower)
            : base (position, speed)
        {
            this.AttractionPower = attractionPower;
        }

        public int AttractionPower { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { 'A' } };
        }
    }
}
