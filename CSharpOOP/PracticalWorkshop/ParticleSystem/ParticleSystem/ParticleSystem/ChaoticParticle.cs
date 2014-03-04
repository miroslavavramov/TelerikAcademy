namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ChaoticParticle : Particle     //Task 1
    {
        private const int SpeedDeviationLimit = 1;  
        
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;
        }

        protected Random RandomGenerator { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            this.Accelerate(new MatrixCoords(
                    RandomGenerator.Next(-SpeedDeviationLimit, SpeedDeviationLimit + 1),
                    RandomGenerator.Next(-SpeedDeviationLimit, SpeedDeviationLimit + 1))
                    );

            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '?' } };
        }
    }
}
