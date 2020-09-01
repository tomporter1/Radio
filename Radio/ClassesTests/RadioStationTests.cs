using NUnit.Framework;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class RadioStationTests
    {
        [Test]
        public void GetStationWithValidIntId()
        {
            IRadio _radio = IRadioConstructor.CreateRadio();
            IStreamable result = _radio.GetStation(0);

            Assert.That(result.Name, Is.EqualTo("Radio 1"));
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void GetStationWithInvalidIntIdFromRadio(int id)
        {
            IRadio _radio = IRadioConstructor.CreateRadio();
            IStreamable result = _radio.GetStation(id);

            Assert.That(result.Name, Is.EqualTo(""));
        }

        [Test]
        public void DefaultStationCreation_HasCorrect_Name()
        {
            IStreamable result = IRadio.MakeStation();

            Assert.That(result.Name, Is.EqualTo(""));
        }

        [Test]
        public void StationCreation_HasCorrect_Name()
        {
            IStreamable result = IRadio.MakeStation("stationID", "stationName", "https://stationURL.com/");

            Assert.That(result.Name, Is.EqualTo("stationName"));
        }

        [Test]
        public void StationCreation_HasCorrect_Url()
        {
            IStreamable result = IRadio.MakeStation("stationID", "stationName", "https://stationURL.com/");

            Assert.That(result.URL.ToString(), Is.EqualTo("https://stationurl.com/"));
        }
    }
}