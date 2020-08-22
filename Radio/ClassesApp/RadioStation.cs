using System;
using System.Collections.Generic;

namespace RadioClasses
{
    public class RadioStation : IEquatable<RadioStation>, IStreamable
    {
        private string _url;

        ///////////////////////Properties///////////////////////
        public string Name { get; set; }
        public Uri URL { get => new Uri(_url); set => _url = value.ToString(); }
        public string ID { get; set; }

        ///////////////////////Methods///////////////////////

        public RadioStation(string id, string name, string url)
        {
            Name = name;
            _url = url;
            ID = id;
        }

        public RadioStation(string id, string name, Uri url)
        {
            Name = name;
            _url = url.ToString();
            ID = id;
        }

        public RadioStation()
        {
            Name = "";
            _url = "about:blank"; //defualt blank url that won't break the Uri class
            ID = "";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as RadioStation);
        }

        public bool Equals(RadioStation other)
        {
            return other != null &&
                   _url == other._url &&
                   Name == other.Name &&
                   ID == other.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_url, Name, ID);
        }

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
