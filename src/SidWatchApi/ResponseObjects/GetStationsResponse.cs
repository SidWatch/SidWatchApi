using System.Collections.Generic;
using SidWatch.Api.Objects;
using SidWatchApi.ResponseObjects;

namespace SidWatch.Api.ResponseObjects
{
    public class GetStationsResponse : BaseResponse
    {
        public List<Station> Stations { get; set; }

    }
}