using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    public class GetKretstyperResponse
    {

        public class GetKretstyperResponseInner {
            public int total { get; set; }
            public List<Kretstyper> records {get; set;}
            public bool success { get; set; }
        }

        public GetKretstyperResponseInner d { get; set; }

    }
}
