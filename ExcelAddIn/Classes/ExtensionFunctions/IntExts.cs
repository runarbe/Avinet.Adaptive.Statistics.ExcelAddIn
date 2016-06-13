using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class IntExts
    {
        public static bool Between(this int i, int min, int max, bool inclusive = true) {
            if (inclusive)
            {
                if ((i >= min) && (i <= max))
                {
                    return true;
                }
            }
            else
            {
                if ((i > min) && (i < max))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
