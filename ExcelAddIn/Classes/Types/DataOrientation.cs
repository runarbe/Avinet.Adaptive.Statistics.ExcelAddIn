﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Enumeration used to determine if a set of properties shall be accessed by columnIndex number or by
    /// rowIndex number
    /// </summary>
    public enum DataOrientation
    {
        InRows = 1,
        InColumns = 2
    }
}
