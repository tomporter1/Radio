using System;
using System.Linq;

namespace RadioClasses
{
    public class Radio
    {
        ///////////////////////Fields///////////////////////
        private const int _maxVol = 10, _maxNumOfStations = 4;
        private int _channel, _volume;
        private bool _on, _isMuted;
        private StationsDataManager _stationsData = new StationsDataManager();

        ///////////////////////Properties///////////////////////
        public int Channel
        {
            get => _channel;
            set => _channel = _on && Enumerable.Range(0, _maxNumOfStations).Contains(value) ? value : _channel;
        }
        public int Volume
        {
            get => _volume;
            set => _volume = _on && !_isMuted && Enumerable.Range(0, _maxVol + 1).Contains(value) ? value : _volume;
        }
        public bool IsMuted { get => _isMuted; set => _isMuted = value; }
        public bool IsOn { get => _on; set => _on = value; }

        ///////////////////////Methods///////////////////////

        public Radio()
        {
            _channel = 0;
            _on = false;
            _isMuted = false;
            _volume = 5;
        }

        public IStreamable GetStation(int id)
        {
            if (_stationsData.GetStationWithID(id, out IStreamable radioStation))
                return radioStation;
            return new RadioStation();
        }

        public void UpdateChannelData(IStreamable newStation, int id)
        {
            _stationsData.UpdateStationEntry(newStation, id);
            _stationsData.SerializeData();
        }

        public void ToggelPower() => _on = !_on;

        public void ToggleMute() => _isMuted = !_isMuted;

        public static IStreamable MakeStation(string url, string name, string id) => new RadioStation(url, name, id);
    }
}