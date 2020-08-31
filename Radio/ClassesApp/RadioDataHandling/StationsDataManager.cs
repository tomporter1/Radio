using Newtonsoft.Json;
using RadioClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RadioClasses.RadioDataHandling
{
    /*
     *  To find more urls for more stations go to http://www.radiofeeds.co.uk/mp3.asp
     */

    internal class StationsDataManager
    {
        private readonly string _jsonPath = AppDomain.CurrentDomain.BaseDirectory + "RadioDataHandling\\StationsData.json";
        public StationsRoot AllStationsInfo { get; private set; }

        public StationsDataManager()
        {
            if (File.Exists(_jsonPath))
            {
                AllStationsInfo = JsonConvert.DeserializeObject<StationsRoot>(File.ReadAllText(_jsonPath));
            }
            else
            {
                AllStationsInfo = new StationsRoot()
                {
                    RadioStations = new List<RadioStation>()
                    {
                        new RadioStation("R1", "Radio 1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p"),
                        new RadioStation("R2", "Radio 2", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p"),
                        new RadioStation("RMan", "Radio Manchester", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_lrmanc_mf_p?s=1591193950&e=1591208350&h=75b3dec246d371cd71071925f9f4735a"),
                        new RadioStation("RX", "Radio X", "http://media-ice.musicradio.com/RadioXUKMP3")
                    }
                };
                SerializeData();
            }
        }

        internal void SerializeData()
        {
            string JsonFile = JsonConvert.SerializeObject(AllStationsInfo, Formatting.Indented);
            File.WriteAllText(_jsonPath, JsonFile);
        }

        internal void UpdateStationEntry(object station, string key, string name, string url)
        {
            int pos = AllStationsInfo.RadioStations.FindIndex(s => s.ID == ((RadioStation)station).ID && s.Name == ((RadioStation)station).Name);
            if (pos >= 0 && pos < AllStationsInfo.RadioStations.Count)
            {
                AllStationsInfo.RadioStations[pos] = new RadioStation(key, name, url);
            }
            else
            {
                throw new Exception("The old station entry could not be found");
            }
        }

        /// <summary>
        /// Returns true if there is a radio station with the string ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="radioStation"></param>
        /// <returns></returns>
        internal bool GetStationWithID(string ID, out IStreamable radioStation)
        {
            radioStation = AllStationsInfo.RadioStations.Where(s => s.ID == ID).FirstOrDefault();
            if (radioStation != null)
                return true;

            radioStation = new RadioStation();
            return false;
        }

        /// <summary>
        /// Returns true if there is a radio station with the int ID. In this case the ID is the position in the list
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="radioStation"></param>
        /// <returns></returns>
        internal bool GetStationWithID(int ID, out IStreamable radioStation)
        {
            radioStation = new RadioStation();
            if (ID < AllStationsInfo.RadioStations.Count && ID >= 0)
            {
                radioStation = AllStationsInfo.RadioStations[ID];
                return true;
            }
            return false;
        }
    }
}