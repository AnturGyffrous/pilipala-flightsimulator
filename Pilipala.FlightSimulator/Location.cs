using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Pilipala.FlightSimulator.Properties;

namespace Pilipala.FlightSimulator
{
    public class Location : ILocation
    {
        private readonly List<ICity> _cities = new List<ICity>();

        public Location()
        {
            using (var reader = new StringReader(Resources.Cities))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _cities.Add(new City(line));
                }
            }
        }

        public TimeZoneInfo GetTimeZoneInfoForCity(string country, string city)
        {
            var cityDetails = _cities.FirstOrDefault(x => x.Country == country && x.Name == city);
            if (cityDetails == null)
            {
                throw new InvalidOperationException("City not found");
            }

            return cityDetails.TimeZoneInfo;
        }
    }
}
