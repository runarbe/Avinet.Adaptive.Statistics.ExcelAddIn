using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class StatDateParser
    {
        public string Year = null;
        public string Quarter = null;
        public string Month = null;
        public string Day = null;
        public bool Success = false;

        public StatDateParser(string pString, string pStringFormat)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;
            var mDateTime = new DateTime();

            if (!pStringFormat.Contains("K") && DateTime.TryParseExact(pString, pStringFormat, provider, DateTimeStyles.None, out mDateTime))
            {
                this.Success = true;

                if (pStringFormat.Contains("y"))
                {
                    this.Year = mDateTime.Year.ToString();
                }
                if (pStringFormat.Contains("M"))
                {
                    this.Month = mDateTime.Month.ToString();
                }
                if (pStringFormat.Contains("d"))
                {
                    this.Day = mDateTime.Day.ToString();
                }
            }
            else if (pStringFormat.Contains("K"))
            {
                var mDateParts = pString.Split('K');
                if (mDateParts.Length == 2)
                {
                    this.Year = mDateParts[0];
                    this.Quarter = mDateParts[1];
                }
            }
            else
            {
                // Handle exceptions in date format
            }
        }

    }
}
