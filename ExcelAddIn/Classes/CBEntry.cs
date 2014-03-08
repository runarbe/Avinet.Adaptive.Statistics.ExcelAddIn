using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    class CBEntry
    {
        public string key { get; set; }
        public string value { get; set; }

        public CBEntry(string pKey, string pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }
    }
}
