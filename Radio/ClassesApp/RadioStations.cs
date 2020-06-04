using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RadioClasses
{
    public class RadioStations
    {
        public List<StationInfo> stations { get; set; }
    }

    public class StationInfo
    {
        public StationInfo(string key, string uRL, string name)
        {
            Key = key;
            Url = uRL;
            Name = name;
        }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

}
