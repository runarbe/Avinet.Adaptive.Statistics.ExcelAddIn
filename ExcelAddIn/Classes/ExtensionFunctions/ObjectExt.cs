using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class ObjectExt
    {
        public static string GetNullEmptyOrString(this Object o)
        {
            if (o == null)
            {
                return null;
            }
            
            return o.ToString(); 
        }
    }
}
