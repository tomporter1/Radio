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
            _radio.ToggelPower();
        }

        [Test]
        public void DefualtConstructorTest()
        {
            IRadio r = IRadioConstructor.CreateRadio();
            Assert.AreEqual(r.IsOn, false);
            Assert.AreEqual(r.IsMuted, false);
            Assert.AreEqual(r.Volume, 5);
        }

        [TestCase(0, 1)]
        [TestCase(10, 10)]
        public void TurnVolumeUp(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.Volume += 1;
            Assert.AreEqual(_radio.Volume, expectedVol);
        }

        [TestCase(0, 0)]
        [TestCase(5, 4)]
        public void TurnVolumeDown(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.Volume -= 1;
            Assert.AreEqual(_radio.Volume, expectedVol);
        }

        [TestCase(0, 0)]
        [TestCase(10, 10)]
        public void TurnVolumeDownWhileMuted(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.IsMuted = true;
            _radio.Volume -= 1;
            Assert.AreEqual(_radio.Volume, expectedVol);
        }

        [TestCase(0, 0)]
        [TestCase(10, 10)]
        public void TurnVolumeUpWhileMuted(int startVol, int expectedVol)
        {
            _radio.Volume = startVol;
            _radio.IsMuted = true;
            _radio.Volume += 1;
            Assert.AreEqual(_radio.Volume, expectedVol);
        }

        [Test]
        public void ToggleMuteTest()
        {
            Assert.AreEqual(_radio.IsMuted, false);
            _radio.ToggleMute();
            Assert.AreEqual(_radio.IsMuted, true);
            _radio.ToggleMute();
            Assert.AreEqual(_radio.IsMuted, false);
        }
    }
}