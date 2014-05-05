using System;

using Pilipala.FlightSimulator.Properties;

namespace Pilipala.FlightSimulator
{
    internal class City : ICity
    {
        public City(string line)
        {
            var parts = line.Split('\t');
            if (parts.Length != 6)
            {
                throw new InvalidOperationException(Resources.CityLineMistHaveSixElements);
            }

            double latitude;
            double longitude;

            if (!double.TryParse(parts[3], out latitude) || !double.TryParse(parts[4], out longitude))
            {
                throw new InvalidOperationException(Resources.CityLineMustContainLatitudeAndLongtitude);
            }

            Name = parts[0];
            Country = parts[2];
            Latitude = latitude;
            Longitude = longitude;
            TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(parts[5]);
        }

        public string Country { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public TimeZoneInfo TimeZoneInfo { get; set; }
    }
}