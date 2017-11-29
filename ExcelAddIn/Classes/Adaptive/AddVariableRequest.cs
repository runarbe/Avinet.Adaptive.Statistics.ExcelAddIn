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
        public Variable variable { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public AddVariableRequest()
        {
            this.variable = new Variable();
            this.variable.var1 = "";
            this.variable.var2 = "";
            this.variable.var3 = "";
            this.variable.var4 = "";
            this.variable.var5 = "";
        }
    }
}