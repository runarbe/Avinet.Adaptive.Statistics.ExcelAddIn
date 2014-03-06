using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    static class DateFormats
    {
        public static List<CBEntry> List = new List<CBEntry>();

        static DateFormats()
        {
            DateFormats.List.Add(new CBEntry("åååå (td 2008)", "yyyy"));
            DateFormats.List.Add(new CBEntry("mm.åååå (td 04.2008)", "MM.yyyy"));
            DateFormats.List.Add(new CBEntry("dd.mm.åååå (td 01.09.2013)", "dd.MM.yyyy"));
        }
    }
}
