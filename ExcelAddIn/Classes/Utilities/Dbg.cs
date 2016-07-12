using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Debugger, writing to file
    /// </summary>
    public static class Dbg
    {

        /// <summary>
        /// Method to write to file
        /// </summary>
        /// <param name="s"></param>
        public static void Write(string s)
        {
            using (var f = File.AppendText(ThisAddIn.LogFile))
            {
                f.WriteLine(s);
            }
        }

        /// <summary>
        /// Method to convert any object to JSON
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson(Object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        /// <summary>
        /// Method to write a log entry as JSON
        /// </summary>
        /// <param name="o"></param>
        public static void WriteJson(Object o)
        {
            Write(Dbg.ToJson(o));
        }

        public static void WriteLine(string s, object o = null)
        {
            if (o != null)
            {
                Write(s + ": " + Dbg.ToJson(o));
            }
            else
            {
                Write(s);
            }
        }
    }
}
