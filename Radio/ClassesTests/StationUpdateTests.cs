using Moq;
using NUnit.Framework;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class StationUpdateTests
    {
        private IRadio _radio;

        [SetUp]
        public void Setup()
        {
            _radio = IRadioConstructor.CreateRadio();
            _radio.IsOn = true;
        }

        [Test, Ignore("Not finished")]
        public void UpdateStation_ThatExistsInSystem()
        {
            var mockRadio = new Mock<IRadio>();
            mockRadio.Object.IsOn = true;
            mockRadio.Setup(x => x.UpdateChannelData(IStreamable.IStreamableBasicConstructor(), "", ""));
            Assert.That(mockRadio.Object.AllStations.Count, Is.EqualTo(4));
        }

        [Test]
        public void UpdateStation_ThatDoesNotExistInSystem()
        {
            Assert.That(() => _radio.UpdateChannelData(IStreamable.IStreamableBasicConstructor(), "newName", "newUrl"), Throws.Exception.With.Message.EqualTo("The old station entry could not be found"));
        }
        
        [Test]
        public void UpdateStation_ThatCannotBeCastedToIStreamable()
        {
            Assert.That(() => _radio.UpdateChannelData(new object(), "newName", "newUrl"), Throws.Exception.With.Message.EqualTo("The object passed in could not be converted to an IStreamable"));
        }
    }
}