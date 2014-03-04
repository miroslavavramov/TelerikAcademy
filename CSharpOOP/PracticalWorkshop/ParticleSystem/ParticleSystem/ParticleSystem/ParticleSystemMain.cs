using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int Rows = 30;
        const int Cols = 30;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(Rows, Cols);

            var particleOperator = new FurtherAdvancedParticleOperator();

            var engine = new Engine(renderer, particleOperator, null, 300);

            GenerateInitialData(engine);

            engine.Run();
        }

        static void GenerateInitialData(Engine engine)
        {
            //engine.AddParticle(new Particle(
            //    new MatrixCoords(0, 8),
            //    new MatrixCoords(1, 1))
            //    );

            //engine.AddParticle(new DyingParticle(
            //    new MatrixCoords(20, 5),
            //    new MatrixCoords(-1, 1),
            //    12)
            //    );

            var emitterPosition = new MatrixCoords(20, 10);
            var emitterSpeed = new MatrixCoords(0,0);

            var emitter = new ParticleEmitter(emitterPosition, emitterSpeed,
                RandomGenerator,
                5,
                2,
                GenerateRandomParticle
                );

            //engine.AddParticle(emitter);      // uncomment when testing the repeller (Task 5)

            var firstAttractorPosition = new MatrixCoords(10, 3);
            var firstAttractor = new ParticleAttractor(firstAttractorPosition, new MatrixCoords(0, 0), 1);

            var secondAttractorPosition = new MatrixCoords(10, 13);
            var secondAttractor = new ParticleAttractor(secondAttractorPosition, new MatrixCoords(0, 0), 1);

            //engine.AddParticle(firstAttractor);
            //engine.AddParticle(secondAttractor);

            var chaoticParticle = new ChaoticParticle(new MatrixCoords(15, 15), new MatrixCoords(0, 0), RandomGenerator);

            engine.AddParticle(chaoticParticle);    //Task 1 test

            var chickenParticle = new ChickenParticle(new MatrixCoords(15, 15), new MatrixCoords(0, 0), RandomGenerator);

            //engine.AddParticle(chickenParticle);    //Task 3 test

            var repeller = new ParticleRepeller(new MatrixCoords(10, 10), range: 7);

            //engine.AddParticle(repeller);           //Task 5 test
        }

        static Particle GenerateRandomParticle(ParticleEmitter emitterParameter)
        {
            MatrixCoords particlePos = emitterParameter.Position;

            int particleRowSpeed = emitterParameter.
                RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);
            int particleColSpeed = emitterParameter.
                RandomGenerator.Next(emitterParameter.MinSpeedCoord, emitterParameter.MaxSpeedCoord + 1);

            MatrixCoords particleSpeed = new MatrixCoords(particleRowSpeed, particleColSpeed);

            Particle generated = null;

            int particleTypeIndex = emitterParameter.RandomGenerator.Next(0, 2);

            switch (particleTypeIndex)
            {
                case 0:
                    generated = new Particle(particlePos, particleSpeed);
                    break;
                case 1:
                    uint lifespan = (uint)emitterParameter.RandomGenerator.Next(8);
                    generated = new DyingParticle(particlePos, particleSpeed, lifespan);
                    break;
                default:
                    throw new Exception("No such particle for this particleTypeIndex");
                    break;
            }

            return generated;
        }
    }
}
