using RadioClasses;
using NUnit.Framework;
using System;

namespace ClassesTests
{
    public class RadioStationTests
    {
        private AllStations _allStations;

        [SetUp]
        public void Setup()
        {
            _allStations = new AllStations();
        }

        [Test]
        public void GetStationWithValidStringID()
        {
            bool result = _allStations.GetStationWithID("R1", out Station foundStation);
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
            bool result = _allStations.GetStationWithID(0, out Station foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntID(int id)
        {
            bool result = _allStations.GetStationWithID(id, out Station foundStation);
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

        [Test]
        public void UpdateChannelDataTest()
        {
            Station newStation = new Station("R1.1", "Radio 1.1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1.1_mf_p");
            _allStations.UpdateStationEntry(newStation,0);

            Assert.AreEqual(newStation, _allStations.AllStationsInfo.Stations[0]);
        }
    }
}
