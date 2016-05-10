using System.Collections.Generic;
using SidWatch.Api.Objects;
using SidWatchApi.ResponseObjects;

namespace SidWatch.Api.ResponseObjects
{
    public class GetSitesResponse : BaseResponse
    {
        public List<Site> Sites { get; set; } 
    }
}