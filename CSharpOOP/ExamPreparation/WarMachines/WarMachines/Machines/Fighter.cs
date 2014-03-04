namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;

        private bool fighterStealthMode;

        public Fighter(string fighterName, double fighterAttackPoints, double fighterDefensePoints, bool fighterStealthMode)
            :base(fighterName, fighterAttackPoints, fighterDefensePoints)
        {
            this.fighterStealthMode = fighterStealthMode;

            this.HealthPoints = InitialHealthPoints;
        }

        public bool StealthMode
        {
            get
            {
                return this.fighterStealthMode;
            }
        }

        public void ToggleStealthMode()
        {
            if (this.StealthMode)
            {
                this.fighterStealthMode = false;
            }
            else
            {
                this.fighterStealthMode = true;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            output.Append(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return output.ToString();
        }
    }
}
