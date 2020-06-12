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
            Station s1 = new Station();
            Station s2 = new Station();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationAreEqualTest()
        {
            Station s1 = new Station("Station 1", "Best radio station eva", "radio.com");
            Station s2 = new Station("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void EmptyStationObjectAreEqualTest()
        {
            object s1 = new Station();
            object s2 = new Station();

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void StationObjectAreEqualTest()
        {
            object s1 = new Station("Station 1", "Best radio station eva", "radio.com");
            object s2 = new Station("Station 1", "Best radio station eva", "radio.com");

            bool result = s1.Equals(s2);

            Assert.AreEqual(result, true);
        }
    }
}
