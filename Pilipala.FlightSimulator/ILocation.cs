using System;

namespace Pilipala.FlightSimulator
{
    public interface ILocation
    {
        TimeZoneInfo GetTimeZoneInfoForCity(string country, string city);
    }
}
