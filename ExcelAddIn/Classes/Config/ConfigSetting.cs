using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ConfigSetting
    {
        public string key { get; set; }
        public string value { get; set; }

        public ConfigSetting()
        {
        }

        public ConfigSetting(string pKey, string pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }

    }
}
