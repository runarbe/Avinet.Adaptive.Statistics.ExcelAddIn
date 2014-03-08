using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    class CTEntry : IComparable
    {
        public string key { get; set; }
        public CType value { get; set; }

        public CTEntry()
        {
        }

        public CTEntry(string pKey, CType pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }

        // Implement IComparable CompareTo method - provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            var c = (CTEntry)obj;
            return String.Compare(this.key, c.key);

        }


    }
}
