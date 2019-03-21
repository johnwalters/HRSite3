using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRData
{
    public class MoqScraper : IHrScraper
    {
        public Race GetRaceEntries(string countryCode, string trackCode, DateTime raceDate, int raceNumber)
        {
            var race = new Race();
            race.CountryCode = "USA";
            race.TrackCode = "GP";
            race.RaceDate = raceDate;
            race.PostTime = "3:15 PM";
            race.RaceNumber = 7;
            race.Entries = new List<Entry>();

            var entry1 = this.InitEntry(race);
            entry1.PostNumber = 1;
            entry1.PostPosition = 1;
            entry1.HorseName = "Jolie Bay (FL)";
            entry1.AgeSex = "3/F";
            entry1.Jockey = "C Landeros";
            entry1.Trainer = "M E Casse";
            entry1.Weight = "120";
            entry1.Meds = "L";
            entry1.MorningLineOdds = "12/1";
            entry1.LiveOdds = "29/1";
            entry1.FinalOdds = "";
            race.Entries.Add(entry1);

            var entry2 = this.InitEntry(race);
            entry2.PostNumber = 1;
            entry2.PostPosition = 1;
            entry2.HorseName = "Catsoutofthebag (KY)";
            entry2.AgeSex = "3/F";
            entry2.Jockey = "I Ortiz, Jr.";
            entry2.Trainer = "V Barboza, Jr.";
            entry2.Weight = "120";
            entry2.Meds = "L";
            entry2.MorningLineOdds = "6/1";
            entry2.LiveOdds = "8/1";
            entry2.FinalOdds = "";
            race.Entries.Add(entry2);

            var entry3 = this.InitEntry(race);
            entry3.PostNumber = 1;
            entry3.PostPosition = 1;
            entry3.HorseName = "Bello Porte (KY)";
            entry3.AgeSex = "3/F";
            entry3.Jockey = "L Saez	";
            entry3.Trainer = "M K McDonald";
            entry3.Weight = "120";
            entry3.Meds = "L";
            entry3.MorningLineOdds = "12/1";
            entry3.LiveOdds = null;
            entry3.FinalOdds = "19/1";
            race.Entries.Add(entry3);

           return race;
        }

        private Entry InitEntry(Race race)
        {
            var entry = new Entry();
            entry.TrackCode = race.TrackCode;
            entry.CountryCode = race.CountryCode;
            entry.RaceDate = race.RaceDate;
            entry.RaceNumber = race.RaceNumber;
            entry.PostTime = race.PostTime;
            return entry;
        }
    }
}
