using RadioClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTests
{
    public class VolumeTests
    {
        private Radio _radio;

        [SetUp]
        public void Setup()
        {
            _radio = new Radio();
            _radio.ToggelPower();
        }

        [Test]
        public void DefualtConstructorTest()
        {
            Radio r = new Radio();
            Assert.AreEqual(r.IsOn, false);
            Assert.AreEqual(r.IsMuted, false);
            Assert.AreEqual(r.Volume, 5);
            Assert.AreEqual(r.Play(), "Radio is off");
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
