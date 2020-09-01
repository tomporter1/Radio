using System;

namespace RadioClasses.Interfaces
{
    public interface IStreamable
    {
        string Name { get; set; }
        Uri URL { get; set; }
    }
}