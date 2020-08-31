using RadioClasses.RadioDataHandling;
using System.Collections.Generic;

namespace RadioClasses.Interfaces
{
    public interface IRadio
    {
        public int Channel { get; set; }
        public int Volume { get; set; }
        public bool IsMuted { get; set; }
        public bool IsOn { get; set; }
        public List<IStreamable> AllStations { get; }

        public IStreamable GetStation(int id);

        public void UpdateChannelData(object station, string key, string name, string url);

        public void ToggelPower();

        public void ToggleMute();

        public static IStreamable MakeStation(string id, string name, string url) => new RadioStation(id, name, url);

        public static IStreamable MakeStation() => new RadioStation();
    }
}