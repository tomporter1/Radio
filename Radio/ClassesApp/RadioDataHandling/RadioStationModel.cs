using RadioClasses.Interfaces;
using System;
using System.Collections.Generic;

namespace RadioClasses.RadioDataHandling
{
    internal class StationsRoot
    {
        public List<RadioStation> RadioStations { get; set; }
    }

    internal class RadioStation : IEquatable<RadioStation>, IStreamable
    {
        private string _url, _name;

        ///////////////////////Properties///////////////////////
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public Uri URL
        {
            get => new Uri(_url);
            set => _url = value.ToString();
        }
        public RadioStation(string name, string url)
        {
            _name = name;
            _url = url;
        }

        public RadioStation(string name, Uri url)
        {
            _name = name;
            _url = url.ToString();
        }

        public RadioStation()
        {
            _name = "";
            _url = "about:blank"; //defualt blank url that won't break the Uri class
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RadioStation);
        }

        public bool Equals(RadioStation other)
        {
            return other != null &&
                   _url == other._url &&
                   _name == other._name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_url, _name);
        }

        public override string ToString() => _name;

        public static bool operator ==(RadioStation left, RadioStation right)
        {
            return EqualityComparer<RadioStation>.Default.Equals(left, right);
        }

        public static bool operator !=(RadioStation left, RadioStation right)
        {
            return !(left == right);
        }
    }
}