using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Request object for adding a new variable
    /// </summary>
    public class AddVariableRequest
    {
        /// <summary>
        /// Data object holding the variable valuesList
        /// </summary>
        public Variable data { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddVariableRequest()
        {
            this.data = new Variable();
            this.data.var1 = "";
            this.data.var2 = "";
            this.data.var3 = "";
            this.data.var4 = "";
            this.data.var5 = "";
        }
    }
}