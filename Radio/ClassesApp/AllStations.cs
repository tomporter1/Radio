using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using System.Collections.Generic;
using System.IO;

namespace RadioClasses
{
    public class AllStations
    {
        string jsonPath = @"E:/Documents/Visual Studio Projects/Radio/Radio/ClassesApp/Resources/RadioStations.json";
        public List<Station> stations;

        public AllStations()
        {
            RadioStations stationsInfo = JsonConvert.DeserializeObject<RadioStations>(File.ReadAllText(
                jsonPath));

            stations = new List<Station>();

            foreach (StationInfo info in stationsInfo.stations)
            {
                stations.Add(new Station(info.Key, info.Name, info.Url));
            }
        }

        public void SerializeData()
        {
            RadioStations radioStations = new RadioStations
            {
                stations = new List<StationInfo>()
            };

            foreach (Station station in stations)
            {
                radioStations.stations.Add(new StationInfo(station.ID, station.URL.ToString(), station.Name));
            }
            string JsonFile = JsonConvert.SerializeObject(radioStations, Formatting.Indented);
            File.WriteAllText(jsonPath, JsonFile);
        }

        /// <summary>
        /// Returns true if there is a radio station with the string ID. 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="radioStation"></param>
        /// <returns></returns>
        public bool GetStationWithID(string ID, out Station radioStation)
        {
            radioStation = new Station();
            foreach (Station station in stations)
            {
                if (station.ID == ID)
                {
                    radioStation = station;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if there is a radio station with the int ID. In this case the ID is the position in the list
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="radioStation"></param>
        /// <returns></returns>
        public bool GetStationWithID(int ID, out Station radioStation)
        {
            radioStation = new Station();
            if (ID < stations.Count && ID >= 0)
            {
                radioStation = stations[ID];
                return true;
            }
            return false;
        }
    }
}
