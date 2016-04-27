using System;

namespace SidWatch.Api.Objects
{
    public class Site
    {
        public int MonitorId { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public double UTCOffset { get; set; }
        public Position Location { get; set; }
        public string Username { get; set; }

        public DateTime DataStartDate { get; set; }
        public DateTime DataEndDate { get; set; }
        public int DaysWithData { get; set; }
    }
}