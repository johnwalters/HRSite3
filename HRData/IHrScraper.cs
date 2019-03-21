using System;

namespace HRData
{
    public interface IHrScraper
    {
        Race GetRaceEntries(string countryCode, string trackCode, DateTime raceDate, int raceNumber);
    }
}