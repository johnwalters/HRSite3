using System;
using System.Collections.Generic;
using System.Text;

namespace HRData
{
    public class Entries
    {
        public string TrackCode { get; set; }
        public string CountryCode { get; set; }
        public int RaceNumber { get; set; }
        public string PostTime { get; set; }

        public List<Entry> Horses { get; set; }
    }
}
