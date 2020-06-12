using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RadioClasses
{
    /*
     *  To find more urls for more stations go to http://www.radiofeeds.co.uk/mp3.asp
     */

    public class RadioStations
    {
        public List<Station> Stations { get; set; }       
    }

    public class AllStations
    {
        //private string _jsonPathold = @"E:/Documents/Visual Studio Projects/Radio/Radio/ClassesApp/Resources/RadioStationsData.json";

        private string _jsonPath = @"RadioStationsData.json";
        public RadioStations AllStationsInfo { get; private set; }

        public AllStations()
        {
            if (File.Exists(_jsonPath))
            {
                AllStationsInfo = JsonConvert.DeserializeObject<RadioStations>(File.ReadAllText(_jsonPath));
            }
            else
            {
                AllStationsInfo = new RadioStations()
                {
                    Stations = new List<Station>() 
                    { 
                        new Station("R1", "Radio 1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p"),
                        new Station("R2", "Radio 2", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p"),
                        new Station("RMan", "Radio Manchester", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_lrmanc_mf_p?s=1591193950&e=1591208350&h=75b3dec246d371cd71071925f9f4735a"),
                        new Station("RX", "Radio X", "http://media-ice.musicradio.com/RadioXUKMP3")
                    }
                };
                SerializeData();
            }
        }

        public void SerializeData()
        {
            string JsonFile = JsonConvert.SerializeObject(AllStationsInfo, Formatting.Indented);
            File.WriteAllText(_jsonPath, JsonFile);
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
            radioStation = AllStationsInfo.Stations.Where(s => s.ID == ID).FirstOrDefault();
            if (radioStation != null)
                return true;

            radioStation = new Station();
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