using NUnit.Framework;
using RadioClasses;

namespace ClassesTests
{
    public class RadioOffTests
    {
        private Radio _radio;

        [SetUp]
        public void Setup()
        {
            _radio = new Radio();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChangeToValidChannelWhenOffTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.AreEqual(0, _radio.Channel);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void ChangeToInvalidChannelWhenOffTest(int newChannel)
        {
            // act
            _radio.Channel = newChannel;
            // assert
            Assert.AreEqual(0, _radio.Channel);
        }
    }
}