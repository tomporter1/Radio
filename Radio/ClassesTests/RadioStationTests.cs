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
            bool result = _allStations.GetStationWithID("R1", out RadioStation foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [Test]
        public void GetStationWithInvalidStringID()
        {
            AllStations allStations = new AllStations();
            bool result = allStations.GetStationWithID("", out RadioStation foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new RadioStation(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntID()
        {
            bool result = _allStations.GetStationWithID(0, out RadioStation foundStation);
            Assert.IsTrue(result);
            Assert.AreEqual("Radio 1", foundStation.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntID(int id)
        {
            bool result = _allStations.GetStationWithID(id, out RadioStation foundStation);
            Assert.IsFalse(result);
            Assert.AreEqual(new RadioStation(), foundStation);
        }

        [Test]
        public void GetStationWithValidIntIDFromRadio()
        {
            Radio radio = new Radio();
            RadioStation result = radio.GetStation(0);
            Assert.AreEqual("Radio 1", result.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntIDFromRadio(int id)
        {
            Radio radio = new Radio();
            RadioStation result = radio.GetStation(id);
            Assert.AreEqual(new RadioStation(), result);
        }

        [Test]
        public void UpdateChannelDataTest()
        {
            RadioStation newStation = new RadioStation("R1.1", "Radio 1.1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1.1_mf_p");
            _allStations.UpdateStationEntry(newStation,0);

            Assert.AreEqual(newStation, _allStations.AllStationsInfo.Stations[0]);
        }
    }
}
