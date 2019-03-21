using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRSite3.Models
{
    public class Entry
    {
        public string TrackCode { get; set; }
        public string CountryCode { get; set; }
        public int RaceNumber { get; set; }
        public string PostTime { get; set; }
        public int? PostNumber {get;set;}
        public int? PostPosition { get; set; }
        public string HorseName { get; set; }
        public string AgeSex { get; set; }
        public string Meds { get; set; }
        public string Jockey { get; set; }
        public string Weight { get; set; }
        public string Trainer { get; set; }
        public string MorningLineOdds { get; set; }
        public string LiveOdds { get; set; }
        public string FinalOdds { get; set; }
    }
}
