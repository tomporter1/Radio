using System.Collections.Generic;

namespace RadioClasses
{
    public class AllStations
    {
        //ToDo make it get the stations from a json file


        public List<IStreamable> stations;

        public AllStations()
        {
            stations = new List<IStreamable>()
            {
            new Station("R1", "Radio 1", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio1_mf_p"),
            new Station("R2", "Radio 2", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_radio2_mf_p"),
            new Station("RMan", "Radio Manchester", "http://bbcmedia.ic.llnwd.net/stream/bbcmedia_lrmanc_mf_p?s=1591193950&e=1591208350&h=75b3dec246d371cd71071925f9f4735a"),
            new Station("RX", "Radio X", "http://media-ice.musicradio.com:80/RadioXUKMP3")
            };
        }

        /// <summary>
        /// Returns true if there is a radio station with the string ID. 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="radioStation"></param>
        /// <returns></returns>
        public bool GetStationWithID(string ID, out IStreamable radioStation)
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
        public bool GetStationWithID(int ID, out IStreamable radioStation)
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
