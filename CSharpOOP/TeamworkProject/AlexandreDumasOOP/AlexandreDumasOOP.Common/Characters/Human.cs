namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common;

    public class Human : Hero
    {
        private const int HumanBasicHealthPoints = 800;
        private const int HumanBasicAgilityPoints = 4;

        public Human(string name)
            : base(name)
        {
            this.HealthPoints = HumanBasicHealthPoints;
            this.Agility = HumanBasicAgilityPoints;
            this.NativeLocation = LocationType.Town;
        }

        public override void Revitalize()
        {
            this.HealthPoints = HumanBasicHealthPoints;
        }

        public override string ToString()
        {
            string result = string.Format("[Human] {0}", base.ToString());

            return result;
        }
    }
}
