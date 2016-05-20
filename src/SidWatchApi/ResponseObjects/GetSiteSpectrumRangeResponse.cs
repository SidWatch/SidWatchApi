using System.Collections.Generic;
using SidWatch.Api.Objects;
using SidWatchApi.ResponseObjects;

namespace SidWatch.Api.ResponseObjects
{
    public class GetSiteSpectrumRangeResponse : BaseResponse
    {
        public List<Spectrum> Spectrums { get; set; }
    }
}