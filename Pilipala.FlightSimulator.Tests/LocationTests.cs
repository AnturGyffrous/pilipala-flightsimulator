using System;

using NUnit.Framework;

namespace Pilipala.FlightSimulator.Tests
{
    [TestFixture]
    public class LocationTests
    {
        [Test]
        public void CanGetTimeZoneForCity()
        {
            ILocation location = new Location();
            var timeZone = location.GetTimeZoneInfoForCity("United Kingdom", "Bristol");

            Assert.That(timeZone.DaylightName, Is.EqualTo("GMT Daylight Time"));
            Assert.That(timeZone.GetUtcOffset(new DateTime(2015, 10, 22, 0, 29, 0)), Is.EqualTo(new TimeSpan(0, 1, 0, 0)));
            Assert.That(timeZone.GetUtcOffset(new DateTime(2015, 10, 25, 2, 0, 0)), Is.EqualTo(new TimeSpan(0, 0, 0, 0)));
        }
    }
}
