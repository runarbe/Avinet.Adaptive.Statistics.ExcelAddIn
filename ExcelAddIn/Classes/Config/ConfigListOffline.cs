using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes
{
    public class ConfigListOffline
    {
        public List<ConfigSetting> list { get; set; }

        public ConfigListOffline()
        {
            this.list = new List<ConfigSetting>();
        }

        public void Add(string pKey, string pValue)
        {
            this.list.Add(new ConfigSetting(pKey, pValue));
        }

        public void Insert(string pKey, string pValue)
        {
            this.list.Insert(0, new ConfigSetting(pKey, pValue));
        }


    }
}
