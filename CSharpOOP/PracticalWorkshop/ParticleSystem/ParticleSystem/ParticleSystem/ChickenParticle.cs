namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class ChickenParticle : ChaoticParticle     //Task 2
    {
        private const uint DefaultEggLayingRatio = 15;
        private const uint DefaultTotalEggsLaid = 2;

        private int laidEggsCount;
        private bool isStandingStill;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator,
            uint probabilityToStartEggLaying = DefaultEggLayingRatio, uint totalEggsLaid = DefaultTotalEggsLaid)
            : base(position, speed, randomGenerator)
        {
            this.ProbabilityToStartEggLaying = probabilityToStartEggLaying;
            this.TotalEggsLaid = totalEggsLaid;
            this.laidEggsCount = 0;
        }

        public uint ProbabilityToStartEggLaying { get; private set; }

        public uint TotalEggsLaid { get; private set; }    // amount of ticks the chicken will spend in immutable state && amount of new eggs laid

        public override IEnumerable<Particle> Update()
        {
            if (!this.isStandingStill && this.ProbabilityToStartEggLaying > this.RandomGenerator.Next(101))
            {
                this.isStandingStill = true;
            }

            if (this.isStandingStill && this.laidEggsCount < this.TotalEggsLaid)
            {
                laidEggsCount++;

                if (this.laidEggsCount == this.TotalEggsLaid)
                {
                    this.isStandingStill = false;
                }
                
                return LayNewEgg();
            }
            
            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '>' } };
        }

        public IEnumerable<Particle> LayNewEgg()
        {
            return new List<Particle>() { new ChickenParticle(this.Position, this.Speed, this.RandomGenerator) };
        }
    }
}
