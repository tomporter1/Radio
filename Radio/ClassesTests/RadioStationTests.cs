using NUnit.Framework;
using RadioClasses;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class RadioStationTests
    {
        private IRadio _radio;

        [SetUp]
        public void Setup()
        {
            _radio = IRadioConstructor.CreateRadio();
        }

        [Test]
        public void GetStationWithValidIntID()
        {
            IStreamable result = _radio.GetStation(0);
            Assert.AreEqual("Radio 1", result.Name);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntIDFromRadio(int id)
        {
            IStreamable result = _radio.GetStation(-1);
            Assert.AreEqual("", result.Name);
        }

        //[Test]
        //public void GetStationWithValidIntID()
        //{
        //    bool result = _radio.GetStationWithID(0, out Station foundStation);
        //    Assert.IsTrue(result);
        //    Assert.AreEqual("Radio 1", foundStation.Name);
        //}

        //[TestCase(-1)]
        //[TestCase(4)]
        //public void GetStationWithInvalidIntID(int id)
        //{
        //    bool result = _radio.GetStationWithID(id, out Station foundStation);
        //    Assert.IsFalse(result);
        //    Assert.AreEqual(new Station(), foundStation);
        //}

        //[Test]
        //public void UpdateChannelDataTest()
        //{
        //    IStreamable newStation = Radio.MakeStation("R1.1", "Radio 1.1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1.1_mf_p");
        //    _radio.UpdateStationEntry(newStation,0);

        //    Assert.AreEqual(newStation, _radio.AllStationsInfo.Stations[0]);
        //}
    }
}