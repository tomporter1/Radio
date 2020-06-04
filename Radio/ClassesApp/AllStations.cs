using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace RadioClasses
{
    public class RadioStations { public List<Station> Stations { get; set; } }

    public class AllStations
    {
        string jsonPath = @"E:/Documents/Visual Studio Projects/Radio/Radio/ClassesApp/Resources/RadioStations.json";

        public RadioStations AllStationsInfo { get; private set; }

        public AllStations()
        {
            AllStationsInfo = JsonConvert.DeserializeObject<RadioStations>(File.ReadAllText(
                jsonPath));
        }

        public void SerializeData()
        {
            string JsonFile = JsonConvert.SerializeObject(AllStationsInfo, Formatting.Indented);
            File.WriteAllText(jsonPath, JsonFile);
        }

        public void UpdateStationEntry(Station newStation, int index)
        {
            AllStationsInfo.Stations[index] = newStation;
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
            foreach (Station station in AllStationsInfo.Stations)
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
            if (ID < AllStationsInfo.Stations.Count && ID >= 0)
            {
                radioStation = AllStationsInfo.Stations[ID];
                return true;
            }
            return false;
        }
    }
}