namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common;

    public class Orc : Hero
    {
        private const int OrcBasicHealthPoints = 1000;
        private const int OrcBasicAgilityPoints = 1;

        public Orc(string name)
            : base(name)
        {
            this.HealthPoints = OrcBasicHealthPoints;
            this.Agility = OrcBasicAgilityPoints;
            this.NativeLocation = LocationType.Desert;
        
        }

        public override void Revitalize()
        {
            this.HealthPoints = OrcBasicHealthPoints;
        }

        public override string ToString()
        {
            string result = string.Format("[Orc] {0}", base.ToString());

            return result;
        }
    }
}
