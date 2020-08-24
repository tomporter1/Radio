using RadioClasses.RadioDataHandling;

namespace RadioClasses.Interfaces
{
    public interface IRadio
    {
        public int Channel { get; set; }
        public int Volume { get; set; }
        public bool IsMuted { get; set; }
        public bool IsOn { get; set; }

        public IStreamable GetStation(int id);

        public void UpdateChannelData(IStreamable newStation, int id);

        public void ToggelPower();

        public void ToggleMute();

        public static IStreamable MakeStation(string id, string name, string url) => new RadioStation(id, name, url);

        public static IStreamable MakeStation() => new RadioStation();
    }
}