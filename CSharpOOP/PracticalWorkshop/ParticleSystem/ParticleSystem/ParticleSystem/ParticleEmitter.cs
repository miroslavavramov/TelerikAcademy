using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleEmitter : Particle
    {
        private uint maxEmittedPerTickCount;
        private Func<ParticleEmitter, Particle> randomParticleGeneratorMethod;

        public ParticleEmitter(MatrixCoords position, MatrixCoords speed, 
            Random randomGenerator, 
            uint maxEmittedPerTickCount, uint maxAbsCoord,
            Func<ParticleEmitter, Particle> randomParticleGeneratorMethod)
            : base(position, speed)
        {
            this.RandomGenerator = randomGenerator;

            this.maxEmittedPerTickCount = maxEmittedPerTickCount;
            this.MinSpeedCoord = -(int)maxAbsCoord;
            this.MaxSpeedCoord = (int)maxAbsCoord;

            this.randomParticleGeneratorMethod = randomParticleGeneratorMethod;
        }

        public Random RandomGenerator { get; private set; }
        public int MinSpeedCoord { get; private set; }
        public int MaxSpeedCoord { get; private set; }

        public override IEnumerable<Particle> Update()
        {
            var baseProduced = base.Update();

            var produced = new List<Particle>();

            int emittedCount = this.RandomGenerator.Next((int)this.maxEmittedPerTickCount + 1);

            for (int i = 0; i < emittedCount; i++)
            {
                Particle p = GetRandomParticle();
                produced.Add(p);
            }

            produced.AddRange(baseProduced);
            return produced;
        }
  
        private Particle GetRandomParticle()
        {
            Particle result = this.randomParticleGeneratorMethod(this);

            return result;
        }
    }
}
