using System;
using System.Collections.Generic;
using System.Text;

namespace HRData
{
    public class HrUtilities
    {
        public static string GetEquibaseUrl(string countryCode, string trackCode, DateTime raceDate, int raceNumber)
        {
            // http://www.equibase.com/static/entry/GP032119USA7-EQB.html 
            var dateMDY = raceDate.ToString("MMddyy");
            var url = $"http://www.equibase.com/static/entry/{trackCode}{dateMDY}{countryCode}{raceNumber}-EQB.html ";
            return url.Trim();
        }

        public static DateTime ParseDateMDY(string mdy)
        {
            bool success = DateTime.TryParseExact(mdy, "MMddyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime raceDate);
            return raceDate;
        }
    }
}
