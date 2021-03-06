﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    static class DateFormats
    {
        public static List<ComboBoxItem> List = new List<ComboBoxItem>();

        static DateFormats()
        {
            DateFormats.List.Add(new ComboBoxItem("åååå (td 2008)", "yyyy"));
            DateFormats.List.Add(new ComboBoxItem("ååååkk (td 2013K1)", "yyyykk"));
            DateFormats.List.Add(new ComboBoxItem("åååå.mm (td 2008.01)", "MM.yyyy"));
            DateFormats.List.Add(new ComboBoxItem("åååå.mm.dd (td 2008.12.24)", "yyyy.mm.dd"));
            DateFormats.List.Add(new ComboBoxItem("mm.åååå (td 04.2008)", "MM.yyyy"));
            DateFormats.List.Add(new ComboBoxItem("dd.mm.åååå (td 01.09.2013)", "dd.MM.yyyy"));
        }
    }
}
