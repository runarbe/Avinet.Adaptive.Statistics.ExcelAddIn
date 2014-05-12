using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ConfigListEntry
    {
        public string key { get; set; }
        public string value { get; set; }

        public ConfigListEntry()
        {
        }

        public ConfigListEntry(string pKey, string pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }

    }
}
