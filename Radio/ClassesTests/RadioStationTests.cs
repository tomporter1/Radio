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
            bool result = allStations.GetStationWithID("R1", out IStreamable foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [Test]
        public void GetStationWithInvalidStringID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID("", out IStreamable foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new Station(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID(0, out IStreamable foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntID(int id)
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID(id, out IStreamable foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new Station(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntIDFromRadio()
        {
            Radio radio = new Radio();
            IStreamable result = radio.PlayStation(0);
            Assert.AreEqual("Radio 1", result.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntIDFromRadio(int id)
        {
            Radio radio = new Radio();
            IStreamable result = radio.PlayStation(id);
            Assert.AreEqual(new Station(), result);
        }
    }
}
