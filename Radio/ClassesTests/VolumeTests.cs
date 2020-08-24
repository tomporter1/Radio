using NUnit.Framework;
using RadioClasses;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class VolumeTests
    {
        private IRadio _radio;

        [SetUp]
        public void Setup()
        {
            _radio = IRadioConstructor.CreateRadio();
            _radio.IsOn = true;
        }

        [TestCase(0, 1)]
        [TestCase(10, 10)]
        public void TurnVolumeUp(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.Volume += 1;
            Assert.That(_radio.Volume, Is.EqualTo(expectedVol));
        }

        [TestCase(0, 0)]
        [TestCase(5, 4)]
        public void TurnVolumeDown(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.Volume -= 1;
            Assert.That(_radio.Volume, Is.EqualTo(expectedVol));
        }

        [TestCase(0, 0)]
        [TestCase(10, 10)]
        public void TurnVolumeDownWhileMuted(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.IsMuted = true;
            _radio.Volume -= 1;
            Assert.That(_radio.Volume, Is.EqualTo(expectedVol));
        }

        [TestCase(0, 0)]
        [TestCase(10, 10)]
        public void TurnVolumeUpWhileMuted(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.IsMuted = true;
            _radio.Volume += 1;
            Assert.That(_radio.Volume, Is.EqualTo(expectedVol));
        }

        [Test]
        public void ToggleMuteTest_WhenStaringFromMuted()
        {
            _radio.IsMuted = true;
            _radio.ToggleMute();

            Assert.That(_radio.IsMuted,Is.False);
        }

        [Test]
        public void ToggleMuteTest_WhenStaringFromUnmuted()
        {
            _radio.IsMuted = false;
            _radio.ToggleMute();

            Assert.That(_radio.IsMuted, Is.True);
        }
    }
}