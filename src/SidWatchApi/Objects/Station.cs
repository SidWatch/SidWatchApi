namespace SidWatch.Api.Objects
{
    public class Station
    {
        public string CallSign { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public double Frequency { get; set; }
        public Position Location { get; set; }
    }
}