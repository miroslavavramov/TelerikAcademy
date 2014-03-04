namespace AlexandreDumasOOP.Common.Characters
{
    using AlexandreDumasOOP.Common;

    public class Undead : Hero
    {
        private const int UndeadBasicHealthPoints = 775;
        private const int UndeadBasicAgilityPoints = 7;

        public Undead(string name)
            : base(name)
        {
            this.HealthPoints = UndeadBasicHealthPoints;
            this.Agility = UndeadBasicAgilityPoints;
            this.NativeLocation = LocationType.Graveyard;
        }

        public override void Revitalize()
        {
            this.HealthPoints = UndeadBasicHealthPoints;
        }

        public override string ToString()
        {
            string result = string.Format("[Undead] {0}", base.ToString());

            return result;
        }
    }
}
