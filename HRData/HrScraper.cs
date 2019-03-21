using System;
using System.Collections.Generic;
using System.Text;

namespace HRData
{
    public class HrScraper : IHrScraper
    {
        public Race GetRaceEntries(string countryCode, string trackCode, DateTime raceDate, int raceNumber)
        {
            // get equibase.com race url
            var url = HrUtilities.GetEquibaseUrl(countryCode, trackCode, raceDate, raceNumber);

            //TODO: implement HrScraper.GetRaceEntries();
            // feel free to make this an async method if needed
            return null;
        }
    }
}
