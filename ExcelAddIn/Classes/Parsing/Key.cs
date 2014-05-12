using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class Key
    {
        public int FieldIndex;
        public int RowIndex;
        public Key(int pFieldIndex, int pRowIndex)
        {
            this.FieldIndex = pFieldIndex;
            this.RowIndex = pRowIndex;
        }
    }
}
