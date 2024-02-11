namespace A32TAK
{
    public struct MGRSProfile
    {
        public string Name;
        public uint UTMZone;
        public char LatitudeBand;
        public char GridSquareFirst;
        public char GridSquareSecond;
    }
    public static class MGRSProfiles
    {
        public static MGRSProfile[] Profiles = [
            new()
            {
                Name = "Altis",
                UTMZone = 18,
                LatitudeBand = 'S',
                GridSquareFirst = 'X',
                GridSquareSecond = 'E'
            },
            new()
            {
                Name = "Takistan",
                UTMZone = 57,
                LatitudeBand = 'Q',
                GridSquareFirst = 'T',
                GridSquareSecond = 'D'
            }
        ];
    }
}