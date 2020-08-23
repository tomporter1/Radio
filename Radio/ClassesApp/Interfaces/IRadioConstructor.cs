namespace RadioClasses.Interfaces
{
    public interface IRadioConstructor
    {
        public static IRadio CreateRadio() => new Radio();
    }
}