namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        protected double attackPoints;
        protected double defensePoints;
        private List<string> targets;

        protected Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(targets);
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine(string.Format("- {0}", this.Name));
            output.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            output.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            output.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            output.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            output.AppendLine(string.Format(" *Targets: {0}", 
                this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets)));
            
            return output.ToString();
        }
    }
}
