using NUnit.Framework;
using RadioClasses.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ClassesTests
{
    public class RadioOnTests
    {
        private IRadio _radio;

        private static List<int> _validVolumes = Enumerable.Range(0, 11).ToList();
        private static List<int> _validChannels = Enumerable.Range(0, 4).ToList();

        [SetUp]
        public void Setup()
        {
            _radio = IRadioConstructor.CreateRadio();
            _radio.IsOn = true;
        }

        [TestCaseSource("_validChannels")]
        public void ChangeToValidChannelTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.That(_radio.Channel,Is.EqualTo(newChannel));
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void ChangeToInvalidChannelTest(int newChannel)
        {
            int startingChannel = _radio.Channel;
            _radio.Channel = newChannel;

            Assert.That(_radio.Channel, Is.EqualTo(startingChannel));
        }

        [TestCaseSource("_validVolumes")]
        public void ChangeToValidVolumeTest(int newVolume)
        {
            _radio.Volume = newVolume;
            Assert.That(_radio.Volume, Is.EqualTo(newVolume));
        }

        [TestCase(-1)]
        [TestCase(11)]
        public void ChangeToInvalidVolumeTest(int newVolume)
        {
            int startingVol = _radio.Volume;
            _radio.Volume = newVolume;

            Assert.That(_radio.Volume, Is.EqualTo(startingVol));
        }

        [Test]
        public void TurnOffTest()
        {
            _radio.ToggelPower();
            Assert.That(_radio.IsOn, Is.False);
        }
    }
}