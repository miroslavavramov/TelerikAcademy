namespace WarMachines
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> engagedMachines; 

        public Pilot(string name)
        {
            this.name = name;
            this.engagedMachines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.engagedMachines.Add(machine);
        }

        public string Report()
        {
            return string.Format("{0}{1}", this, string.Join("\n", this.engagedMachines));
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0} - ", this.Name);

            if (this.engagedMachines.Count == 0)
            {
                output.Append("no machines");
            }
            else if (this.engagedMachines.Count == 1)
            {
                output.Append("1 machine\n");
            }
            else
            {
                output.AppendFormat("{0} machines\n", this.engagedMachines.Count);
            }

            return output.ToString();
        }
    }
}
