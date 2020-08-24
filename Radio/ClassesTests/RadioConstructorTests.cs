using NUnit.Framework;
using RadioClasses.Interfaces;

namespace ClassesTests
{
    public class RadioConstructorTests
    {
        [Test]
        public void DefualtConstructorTest_IsOn_SetToFalse()
        {
            IRadio r = IRadioConstructor.CreateRadio();
            Assert.That(r.IsOn, Is.False);
        }

        [Test]
        public void DefualtConstructorTest_IsMuted_SetToFalse()
        {
            IRadio r = IRadioConstructor.CreateRadio();
            Assert.That(r.IsMuted, Is.False);
        }

        [Test]
        public void DefualtConstructorTest_Volume_SetTo5()
        {
            IRadio r = IRadioConstructor.CreateRadio();
            Assert.That(r.Volume, Is.EqualTo(5));
        }

        [Test]
        public void DefualtConstructorTest_Name_SetToEmptyString()
        {
            IRadio r = IRadioConstructor.CreateRadio();
            Assert.That(r.Channel, Is.EqualTo(0));
        }
    }
}