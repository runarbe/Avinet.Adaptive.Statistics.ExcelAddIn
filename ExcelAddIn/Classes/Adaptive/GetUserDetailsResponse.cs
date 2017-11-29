using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    public class GetUserDetailsResponse
    {
        public class GetUserDetailsInnerResponse
        {

        }

        public bool success { get; set; }
        public bool sessionExpired { get; set; }

    }

}
