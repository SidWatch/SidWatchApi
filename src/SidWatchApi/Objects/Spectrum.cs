using System;

namespace SidWatch.Api.Objects
{
    public class Spectrum
    {
        public Guid SiteId { get; set; }
        public DateTime ReadingDateTime { get; set; }
        public Double SamplesPerSecond { get; set; }
        public Double NFFT { get; set; }
        public int SampleBits { get; set; }
        public string DataFileUrl { get; set; }
    }
}