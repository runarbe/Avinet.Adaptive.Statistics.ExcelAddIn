using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Types
{
    class CustomWebClient : WebClient
    {
        public int Timeout { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            request.Timeout = Timeout;
            return request;
        }
    }

}
