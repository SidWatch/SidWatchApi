using SidWatch.Api.Objects;
using SidWatchApi.ResponseObjects;

namespace SidWatch.Api.ResponseObjects
{
    public class GetLatestSpectrumResponse : BaseResponse
    {
        public Spectrum Spectrum { get; set; }
    }
}