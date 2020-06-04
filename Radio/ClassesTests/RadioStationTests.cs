using RadioClasses;
using NUnit.Framework;

namespace ClassesTests
{
    public class RadioStationTests
    {
        [Test]
        public void GetStationWithValidStringID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID("R1", out Station foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [Test]
        public void GetStationWithInvalidStringID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID("", out Station foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new Station(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID(0, out Station foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntID(int id)
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID(id, out Station foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new Station(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntIDFromRadio()
        {
            Radio radio = new Radio();
            Station result = radio.GetStation(0);
            Assert.AreEqual("Radio 1", result.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntIDFromRadio(int id)
        {
            Radio radio = new Radio();
            Station result = radio.GetStation(id);
            Assert.AreEqual(new Station(), result);
        }
    }
}
