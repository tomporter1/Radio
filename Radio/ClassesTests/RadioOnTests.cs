using NUnit.Framework;
using RadioClasses;
namespace ClassesTests
{
    public class RadioOnTests
    {
        private Radio _radio;
        [SetUp]
        public void Setup()
        {
            _radio = new Radio();
            _radio.ToggelPower();
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChangeToValidChannelTest(int newChannel)
        {
            _radio.Channel = newChannel;
            Assert.AreEqual(newChannel, _radio.Channel);
        }

        [TestCase(-1)]
        [TestCase(4)]
        public void ChangeToInvalidChannelTest(int newChannel)
        {
            // arrange
            _radio.Channel = 2;
            // act
            _radio.Channel = newChannel;
            // assert
            Assert.AreEqual(2, _radio.Channel);
        }

        [Test]
        public void TurnOffTest()
        {
            _radio.ToggelPower();
            Assert.AreEqual(_radio.IsOn, false);
        }
    }
}