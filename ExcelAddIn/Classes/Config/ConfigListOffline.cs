using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes
{
    public class ConfigListOffline
    {
        public List<ConfigListEntry> list { get; set; }

        public ConfigListOffline()
        {
            this.list = new List<ConfigListEntry>();
        }

        public void Add(string pKey, string pValue)
        {
            this.list.Add(new ConfigListEntry(pKey, pValue));
        }

        public void Insert(string pKey, string pValue)
        {
            this.list.Insert(0, new ConfigListEntry(pKey, pValue));
        }


    }
}
