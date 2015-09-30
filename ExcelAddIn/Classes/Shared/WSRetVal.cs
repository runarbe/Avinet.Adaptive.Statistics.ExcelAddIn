using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Shared
{
    class WSRetVal
    {
        public string feedbackMsg { get; set; }

        public string success { get; set; }

        public static WSRetVal ParseJSON(string pJSON) {
            try
            {
                return (WSRetVal)Newtonsoft.Json.JsonConvert.DeserializeObject(pJSON, typeof(WSRetVal));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
