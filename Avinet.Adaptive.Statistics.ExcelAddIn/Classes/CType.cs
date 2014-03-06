using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public enum CType : int
    {
        None = 0,
        StatVars = 1,
        StatAreaIDs = 2,
        StatDatum = 3,
        StatAreaNames = 4,
        StatAreaGroups = 5,
        Ignore = 99
    }
}
