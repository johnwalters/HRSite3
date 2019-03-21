using System;
using System;
using System.Diagnostics;
using HRData;
using NUnit.Framework;

namespace HRDataTests
{
    [TestFixture]
    public class RaceFixture 
    {
        private IHrScraper _scraper;

        [Test]
        public void GetEquibaseUrl()
        {
            var countryCode = "USA";
            var trackCode = "GP";
            var raceDate = HrUtilities.ParseDateMDY("032119");
            var raceNumber = 7;
            var url = HrUtilities.GetEquibaseUrl(countryCode, trackCode, raceDate, raceNumber);
            Assert.IsTrue(url == "http://www.equibase.com/static/entry/GP032119USA7-EQB.html");

        }

        [Test]
        public void GetRaceWithMoqScraper()
        {
            _scraper = new MoqScraper();

            var countryCode = "USA";
            var trackCode = "GP";
            var raceDate = HrUtilities.ParseDateMDY("032019");
            var raceNumber = 7;


            // http://www.equibase.com/static/entry/GP032119USA7-EQB.html

            var race = _scraper.GetRaceEntries(countryCode, trackCode, raceDate, raceNumber);
            Assert.IsNotNull(race);
            Assert.IsTrue(race.RaceNumber == raceNumber);
            Assert.IsTrue(race.RaceDate.ToShortDateString() == raceDate.ToShortDateString());
            Assert.IsTrue(race.TrackCode == trackCode);
            Assert.IsTrue(race.CountryCode == countryCode);
            Assert.IsTrue(race.Entries != null);
            Assert.IsTrue(race.Entries.Count > 0);
            this.AssertEntry(race.Entries[0], race);
            this.AssertEntry(race.Entries[1], race);

        }

        [Test]
        public void GetRaceWithScraper()
        {
            _scraper = new HrScraper();

            //TODO: make this match a current race
            // find available tracks/races here: http://www.equibase.com/static/entry/index.html
            // sample url  http://www.equibase.com/static/entry/GP032119USA7-EQB.html
            var countryCode = "USA";
            var trackCode = "GP";
            var raceDate = HrUtilities.ParseDateMDY("032119");
            var raceNumber = 7;

            var race = _scraper.GetRaceEntries(countryCode, trackCode, raceDate, raceNumber);
            Assert.IsNotNull(race);
            Assert.IsTrue(race.RaceNumber == raceNumber);
            Assert.IsTrue(race.RaceDate.ToShortDateString() == raceDate.ToShortDateString());
            Assert.IsTrue(race.TrackCode == trackCode);
            Assert.IsTrue(race.CountryCode == countryCode);
            Assert.IsTrue(race.Entries != null);
            Assert.IsTrue(race.Entries.Count > 0);
            this.AssertEntry(race.Entries[0], race);
            this.AssertEntry(race.Entries[1], race);

        }

        private void AssertEntry(Entry entry, Race race)
        {
            Assert.IsTrue(entry.RaceNumber == race.RaceNumber);
            Assert.IsTrue(entry.RaceDate.ToShortDateString() == race.RaceDate.ToShortDateString());
            Assert.IsTrue(entry.TrackCode == race.TrackCode);
            Assert.IsTrue(entry.CountryCode == race.CountryCode);
            Assert.IsTrue(entry.MorningLineOdds != null);
            Assert.IsTrue(entry.HorseName != null);
            Assert.IsTrue(entry.Jockey != null);
            Assert.IsTrue(entry.Trainer != null);
            Assert.IsTrue(entry.Weight != null);
            Assert.IsTrue(entry.PostNumber != null);
            Assert.IsTrue(entry.PostPosition != null);
        }
    }
}
