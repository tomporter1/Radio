using System;
using System.Collections.Generic;

namespace RadioClasses
{
    public class Station : IEquatable<Station>
    {
        private string _url;

        ///////////////////////Properties///////////////////////
        public string Name { get; set; }
        public Uri URL { get => new Uri(_url); set => _url = value.ToString(); }
        public string ID { get; set; }

        ///////////////////////Methods///////////////////////

        public Station(string id, string name, string url)
        {
            Name = name;
            _url = url;
            ID = id;
        }

        public Station()
        {
            Name = "";
            _url = "about:blank";
            ID = "";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Station);
        }

        public bool Equals(Station other)
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

        public static bool operator ==(Station left, Station right)
        {
            return EqualityComparer<Station>.Default.Equals(left, right);
        }

        public static bool operator !=(Station left, Station right)
        {
            return !(left == right);
        }
    }
}
