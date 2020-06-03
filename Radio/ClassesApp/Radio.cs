using System;
using System.Linq;

namespace ClassesApp
{
    public class Radio
    {
        ///////////////////////Fields///////////////////////
        private int _channel, _volume;
        private bool _on, _isMuted;
        private AllStations _allStations = new AllStations();

        ///////////////////////Properties///////////////////////
        public int Channel
        {
            get => _channel;
            set => _channel = _on && Enumerable.Range(0, 4).Contains(value) ? value : _channel;
        }
        public int Volume
        {
            get => _volume;
            set => _volume = _on && !_isMuted && Enumerable.Range(0, 11).Contains(value) ? value : _volume;
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

        public string Play()
        {
            if (_on)
            {
                return $"Playing channel {Channel}";
            }
            return "Radio is off";
        }

        public Station PlayStation(int id)
        {
            if (_allStations.GetStationWithID(id, out Station radioStation))
                return radioStation;
            return new Station();
        }

        public void ToggelPower() => _on = !_on;

        public void ToggleMute() => _isMuted = !_isMuted;
    }
}