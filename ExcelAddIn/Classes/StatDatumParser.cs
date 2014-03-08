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
        public string YearPart = null;
        public string Month = null;
        public string Day = null;
        public bool Success = false;

        public StatDateParser(string pString, string pStringFormat)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;
            var mDateTime = new DateTime();

            if (DateTime.TryParseExact(pString, pStringFormat, provider, DateTimeStyles.None, out mDateTime))
            {
                this.Success = true;

                this.Year = mDateTime.Year.ToString();
                if (pStringFormat.Contains("M"))
                {
                    this.Month = mDateTime.Month.ToString();
                }
                if (pStringFormat.Contains("d"))
                {
                    this.Day = mDateTime.Day.ToString();
                }
                switch (this.Month)
                {
                    case "3":
                        this.YearPart = "K1";
                        break;
                    case "6":
                        this.YearPart = "K2";
                        break;
                    case "9":
                        this.YearPart = "K3";
                        break;
                    case "12":
                        this.YearPart = "K4";
                        break;
                }
            }
        }

    }
}
