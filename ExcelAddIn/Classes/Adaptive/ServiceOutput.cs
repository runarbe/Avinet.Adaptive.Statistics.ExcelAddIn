using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ServiceOutput    
    {
        public ServiceOutputInner d;

        public class ServiceOutputInner
        {
            public int total { get; set; }
            public object records { get; set; }
            public bool success { get; set; }
            public AdaptiveException exception { get; set; }
            public AdaptiveException[] exceptions { get; set; }
            public List<object> data { get; set; }

            public string GetMessage()
            {
                if (exception != null)
                {
                    return exception.msg;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
