using NUnit.Framework;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class StationTests
    {
        [Test]
        public void EmptyStationAreEqualTest()
        {
            IStreamable s1 = IRadio.MakeStation();
            IStreamable s2 = IRadio.MakeStation();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationAreEqualTest()
        {
            IStreamable s1 = IRadio.MakeStation("Station 1", "Best radio station eva", "radio.com");
            IStreamable s2 = IRadio.MakeStation("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void EmptyStationObjectAreEqualTest()
        {
            IStreamable s1 = IRadio.MakeStation();
            IStreamable s2 = IRadio.MakeStation();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationObjectAreEqualTest()
        {
            IStreamable s1 = IRadio.MakeStation("Station 1", "Best radio station eva", "radio.com");
            IStreamable s2 = IRadio.MakeStation("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }
    }
}