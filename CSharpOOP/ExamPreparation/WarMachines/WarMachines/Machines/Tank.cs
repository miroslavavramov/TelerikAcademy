namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines;
    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;
        private const double DefenseBonusInDefenseMode = 30;
        private const double AttackPenaltyInDefenseMode = 40;

        private bool inDefenseMode;

        public Tank(string tankName, double tankAttackPoints, double tankDefensePoints)
            : base(tankName, tankAttackPoints, tankDefensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get
            {
                return this.inDefenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.inDefenseMode = false;
                this.defensePoints -= DefenseBonusInDefenseMode;
                this.attackPoints += AttackPenaltyInDefenseMode;
            }
            else
            {
                this.inDefenseMode = true;
                this.defensePoints += DefenseBonusInDefenseMode;
                this.attackPoints -= AttackPenaltyInDefenseMode;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());

            output.Append(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return output.ToString();
        }
    }
}
