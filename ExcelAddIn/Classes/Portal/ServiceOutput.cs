using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    public class ServiceOutput    
    {
        public ServiceOutputInner d;

        public class ServiceOutputInner
        {
            public int total { get; set; }
            public object records { get; set; }
            public bool success { get; set; }
        }
    }
}
