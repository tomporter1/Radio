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
        private string _url, _name, _id;

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
        public string ID
        {
            get => _id;
            set => _id = value;
        }

        public RadioStation(string id, string name, string url)
        {
            _name = name;
            _url = url;
            _id = id;
        }

        public RadioStation(string id, string name, Uri url)
        {
            _name = name;
            _url = url.ToString();
            _id = id;
        }

        public RadioStation()
        {
            _name = "";
            _url = "about:blank"; //defualt blank url that won't break the Uri class
            _id = "";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RadioStation);
        }

        public bool Equals(RadioStation other)
        {
            return other != null &&
                   _url == other._url &&
                   _name == other._name &&
                   _id == other._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_url, _name, _id);
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