using NUnit.Framework;
using RadioClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesTests
{
    public class StationTests
    {
        [Test]
        public void EmptyStationAreEqualTest()
        {
            RadioStation s1 = new RadioStation();
            RadioStation s2 = new RadioStation();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationAreEqualTest()
        {
            RadioStation s1 = new RadioStation("Station 1", "Best radio station eva", "radio.com");
            RadioStation s2 = new RadioStation("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void EmptyStationObjectAreEqualTest()
        {
            object s1 = new RadioStation();
            object s2 = new RadioStation();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationObjectAreEqualTest()
        {
            object s1 = new RadioStation("Station 1", "Best radio station eva", "radio.com");
            object s2 = new RadioStation("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }
    }
}
