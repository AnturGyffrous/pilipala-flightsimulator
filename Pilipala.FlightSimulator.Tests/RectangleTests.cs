using NUnit.Framework;

namespace Pilipala.FlightSimulator.Tests
{
    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void ToStringShowsCoordinates()
        {
            var rectangle = new Rectangle { X1 = 10, X2 = 20, Y1 = 30, Y2 = 40 };
            Assert.That(rectangle.ToString(), Is.EqualTo("X1 = 10, Y1 = 30, X2 = 20, Y2 = 40"));
        }
    }
}
