using RadioClasses.RadioDataHandling;
using System;

namespace RadioClasses.Interfaces
{
    public interface IStreamable
    {
        string Name { get; set; }
        Uri URL { get; set; }
        public static IStreamable IStreamableBasicConstructor() => new RadioStation();
    }
}