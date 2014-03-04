namespace AlexandreDumasOOP.Common
{
    public struct Location
    {
        public Location(string locationName, LocationType type = LocationType.Neutral)
            : this()
        {
            this.LocationName = locationName;
            this.Type = type;
        }

        public string LocationName { get; private set; }

        public LocationType Type { get; set; }
    }
}
