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
            
            if (!pStringFormat.Contains("k") && DateTime.TryParseExact(pString, pStringFormat, provider, DateTimeStyles.None, out mDateTime))
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

                if (pStringFormat.Contains("r"))
                {
                    this.Day = mDateTime.Day.ToString();
                }
            }
            else if (pStringFormat.Contains("k") && pString.Contains("K"))
            {
                var mDateParts = pString.Split('K');
                if (mDateParts.Length == 2)
                {
                    this.Success = true;
                    this.Year = mDateParts[0];
                    this.Quarter = mDateParts[1];
                }
            }
            else
            {
                Debug.WriteLine("Unable to parse " + pString + " with the format " + pStringFormat);
                try
                {
                    DateTime.ParseExact(pString, pStringFormat, provider);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                // Handle exceptions in date format
            }
        }

    }
}
