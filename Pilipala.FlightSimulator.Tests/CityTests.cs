using System;

using NUnit.Framework;

using Pilipala.FlightSimulator.Properties;

namespace Pilipala.FlightSimulator.Tests
{
    [TestFixture]
    public class CityTests
    {
        [Test]
        public void CanCreateCity()
        {
            var city = new City("Bristol\t(GMT) Dublin, Edinburgh, Lisbon, London\tUnited Kingdom\t51.48333359\t-2.533333302\tGMT Standard Time");

            Assert.That(city.Name, Is.EqualTo("Bristol"));
            Assert.That(city.Country, Is.EqualTo("United Kingdom"));
            Assert.That(city.Latitude, Is.EqualTo(51.48333359d));
            Assert.That(city.Longitude, Is.EqualTo(-2.533333302d));
            Assert.That(city.TimeZoneInfo.DaylightName, Is.EqualTo("GMT Daylight Time"));
            Assert.That(city.TimeZoneInfo.GetUtcOffset(new DateTime(2014, 10, 26, 0, 59, 0)), Is.EqualTo(new TimeSpan(0, 1, 0, 0)));
            Assert.That(city.TimeZoneInfo.GetUtcOffset(new DateTime(2014, 10, 26, 2, 0, 0)), Is.EqualTo(new TimeSpan(0, 0, 0, 0)));
        }

        [Test]
        public void WillGetAnErrorIfTheLineDoesNotContainSixElements()
        {
            var exception =
                Assert.Throws<InvalidOperationException>(
                    () => new City("Bristol\t(GMT) Dublin, Edinburgh, Lisbon, London\tUnited Kingdom\t51.48333359\t-2.533333302\tGMT Standard Time\tSomething else you weren't expecting!"));
            Assert.That(exception.Message, Is.EqualTo(Resources.CityLineMistHaveSixElements));
        }

        [Test]
        public void WillGetAnErrorIfTheLatitudeIsNotFloatingPointNumber()
        {
            var exception =
                Assert.Throws<InvalidOperationException>(
                    () => new City("Bristol\t(GMT) Dublin, Edinburgh, Lisbon, London\tUnited Kingdom\tFiftyOneDegreesNorth\t-2.533333302\tGMT Standard Time"));
            Assert.That(exception.Message, Is.EqualTo(Resources.CityLineMustContainLatitudeAndLongtitude));
        }

        [Test]
        public void WillGetAnErrorIfTheLongitudeIsNotFloatingPointNumber()
        {
            var exception =
                Assert.Throws<InvalidOperationException>(
                    () => new City("Bristol\t(GMT) Dublin, Edinburgh, Lisbon, London\tUnited Kingdom\t51.48333359\tTwoOneDegreesWest\tGMT Standard Time"));
            Assert.That(exception.Message, Is.EqualTo(Resources.CityLineMustContainLatitudeAndLongtitude));
        }

        [Test]
        public void WillGetAnErrorIfTheTimeZoneDoesNotExist()
        {
            Assert.Throws<TimeZoneNotFoundException>(
                () => new City("Bristol\t(GMT) Dublin, Edinburgh, Lisbon, London\tUnited Kingdom\t51.48333359\t-2.533333302\tSomewhere Made Up"));
        }
    }
}
