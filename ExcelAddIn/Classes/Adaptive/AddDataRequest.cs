
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    /// <summary>
    /// A wrapper for the upload data request
    /// </summary>
    class AddDataRequest
    {
        public List<AdaptiveValue> data;

        public AddDataRequest(List<AdaptiveValue> values)
        {
            this.data = values;
        }
    }
}
