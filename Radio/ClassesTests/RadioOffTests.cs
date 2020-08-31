using NUnit.Framework;
using RadioClasses.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ClassesTests
{
    public class RadioOffTests
    {
        private IRadio _radio;
        private static readonly List<int> _validVolumes = Enumerable.Range(0, 11).ToList();
        private static readonly List<int> _validChannels = Enumerable.Range(0, 4).ToList();

        [SetUp]
        public void Setup()
        {
            _radio = IRadioConstructor.CreateRadio();
        }

        [Test]
        public void CheckThatMadeIRadio_IsOffNyDefault()
        {
            Assert.That(_radio.IsOn, Is.False);
        }

        [TestCaseSource("_validChannels")]
        public void ChangeToValidChannelWhenOffTest(int newChannel)
        {
            _radio.Channel = newChannel;

            Assert.That(_radio.Channel, Is.EqualTo(0));
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void ChangeToInvalidChannelWhenOffTest(int newChannel)
        {
            _radio.Channel = newChannel;

            Assert.That(_radio.Channel, Is.EqualTo(0));
        }

        [TestCaseSource("_validVolumes")]
        public void ChangeToValidVolumeWhenOffTest(int newVlo)
        {
            _radio.Volume = newVlo;

            Assert.That(_radio.Volume, Is.EqualTo(5));
        }

        [TestCase(-1)]
        [TestCase(11)]
        public void ChangeToInvalidVolumeWhenOffTest(int newVlo)
        {
            _radio.Volume = newVlo;

            Assert.That(_radio.Volume, Is.EqualTo(5));
        }

        [Test]
        public void UnmuteWhenOff_HasNoChangeOn_MutedStatus()
        {
            _radio.IsMuted = true;

            Assert.That(_radio.IsMuted, Is.False);
        }

        [Test]
        public void TurnOnTest()
        {
            _radio.ToggelPower();
            Assert.That(_radio.IsOn, Is.True);
        }
    }
}