using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class AuthenticateResponse
    {
        public class AuthenticateKeyValue
        {
            public string key { get; set; }
            public string value { get; set; }
        }
        public class AuthenticateResponseInner
        {
            public bool success { get; set; }
            public List<AuthenticateKeyValue> data { get; set; }
        }

        public AuthenticateResponseInner d { get; set; }

    }

}
