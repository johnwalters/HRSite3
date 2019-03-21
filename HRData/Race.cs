using System;
using System.Collections.Generic;
using System.Text;

namespace HRData
{
    public class Race
    {
        public string CountryCode { get; set; }
        public string TrackCode { get; set; }
        public DateTime RaceDate { get; set; }
        public int RaceNumber { get; set; }
        public string PostTime { get; set; }

        public List<Entry> Entries { get; set; }
    }
}
