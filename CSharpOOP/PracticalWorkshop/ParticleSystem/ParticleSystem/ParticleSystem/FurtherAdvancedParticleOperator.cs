namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FurtherAdvancedParticleOperator : AdvancedParticleOperator    //Task 5
    {
        private List<Particle> particles;
        private List<ParticleRepeller> repellers;

        public FurtherAdvancedParticleOperator()
        {
            this.particles = new List<Particle>();
            this.repellers = new List<ParticleRepeller>();
        }

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            ParticleRepeller repellerCandidate = p as ParticleRepeller;

            if (repellerCandidate != null)
            {
                this.repellers.Add(repellerCandidate);
            }
            else
            {
                this.particles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in repellers)
            {
                foreach (var particle in particles)
                {
                    if(IsInRepellingRange(repeller.Position, particle.Position, repeller.Range))
                    {
                        Repell(particle, repeller.Power);
                    }
                }
            }

            this.particles.Clear();
            this.repellers.Clear();
            base.TickEnded();
        }

        private bool IsInRepellingRange(MatrixCoords repellerPos, MatrixCoords particlePos, uint range)
        {
            double distance = Math.Sqrt(
                (repellerPos.Row - particlePos.Row) * (repellerPos.Row - particlePos.Row) +
                (repellerPos.Col - particlePos.Col) * (repellerPos.Col - particlePos.Col)
                );

            return range >= distance;
        }

        private void Repell(Particle p, uint repellingPower)
        {
            p.Accelerate(new MatrixCoords(
                - p.Speed.Row * (int)repellingPower,
                - p.Speed.Col * (int)repellingPower
                ));
        }
    }
}
