namespace A32TAK
{
    public struct MGRSProfile
    {
        public string Name;
        public double GeoidHeight;
        public uint UTMZone;
        public char LatitudeBand;
        public char GridSquareFirst;
        public char GridSquareSecond;
    }
    public static class MGRSProfiles
    {
        public static readonly MGRSProfile[] Profiles = [
            new()
            {
                Name = "Altis",
                GeoidHeight = -44.7,
                UTMZone = 18,
                LatitudeBand = 'S',
                GridSquareFirst = 'X',
                GridSquareSecond = 'E'
            },
            new()
            {
                Name = "Takistan",
                GeoidHeight = 2026.1,
                UTMZone = 57,
                LatitudeBand = 'Q',
                GridSquareFirst = 'T',
                GridSquareSecond = 'D'
            }
        ];
    }
}