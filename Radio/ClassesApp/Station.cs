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

        public Station(string id, string name, Uri url)
        {
            Name = name;
            _url = url.ToString();
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
                   Name == other.Name &&
                   EqualityComparer<Uri>.Default.Equals(URL, other.URL) &&
                   ID == other.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, URL, ID);
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
