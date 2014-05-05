using System;

namespace Pilipala.FlightSimulator
{
    internal interface ICity
    {
        string Country { get; set; }

        double Latitude { get; set; }

        double Longitude { get; set; }

        string Name { get; set; }

        TimeZoneInfo TimeZoneInfo { get; set; }
    }
}
