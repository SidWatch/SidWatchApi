using System.Collections.Generic;
using SidWatch.Api.Objects;

namespace SidWatch.Api.Extensions
{
    public static class ConversionExtensions
    {
        public static List<Station> ToTransferObjects(this List<Sidwatch.Library.Objects.Station> _input)
        {
            List<Station> output = new List<Station>();

            foreach (var station in _input)
            {
                output.Add(station.ToTransferObject());
            }

            return output;
        } 

        public static Station ToTransferObject(this Sidwatch.Library.Objects.Station _input)
        {
            Station output = new Station
            {
                CallSign = _input.CallSign,
                Country = _input.Country,
                Frequency = _input.Frequency,
                Notes = _input.Notes
            };

            if (_input.Location != null)
            {
                output.Location = new Position
                {
                    Latitude = _input.Location.Y, 
                    Longitude = _input.Location.X
                };
            }

            return output;
        }

        public static List<Site> ToTransferObjects(this List<Sidwatch.Library.Objects.Site> _input)
        {
            List<Site> output = new List<Site>();

            foreach (var site in _input)
            {
                output.Add(site.ToTransferObject());
            }

            return output;
        } 

        public static Site ToTransferObject(this Sidwatch.Library.Objects.Site _input)
        {
            Site output = new Site
            {
                MonitorId = _input.MonitorID,
                Name = _input.Name,
                Timezone = _input.Timezone,
                UTCOffset = _input.UTCOffset
            };

            //TODO - post populate some of the data
            return output;
        }


    }
}