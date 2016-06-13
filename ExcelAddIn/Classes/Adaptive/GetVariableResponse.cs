using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class GetVariableResponse
    {
        public class GetVariableResponseInner
        {
            public int total { get; set; }
            public List<Variable> records { get; set; }
            public bool success { get; set; }
        }

        public GetVariableResponseInner d { get; set; }
    }
}
