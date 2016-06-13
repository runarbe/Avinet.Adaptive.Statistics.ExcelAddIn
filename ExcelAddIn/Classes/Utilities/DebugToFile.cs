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
    public static class DebugToFile
    {
        /// <summary>
        /// The filename of the log file that extended errors are being written to
        /// </summary>
        public static string LogFileName;

        static DebugToFile()
        {
            //String LogFileDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String LogFileDir = Application.StartupPath;

            LogFileName = Path.Combine(new String[] {
                LogFileDir,
                "/AdaptiveExcelAddIn/log.txt"
            });

            var mLogFileInfo = new FileInfo(LogFileName);
            if (!Directory.Exists(mLogFileInfo.DirectoryName))
            {
                Directory.CreateDirectory(mLogFileInfo.DirectoryName);
            }

        }

        public static void Write(string s)
        {

            using (System.IO.StreamWriter f = new System.IO.StreamWriter(LogFileName, true))
            {
                f.WriteLine(s);
            }
        }

        public static void Json(Object o)
        {
            Write(JsonConvert.SerializeObject(o));
        }

        public static void Log(string s, object o = null)
        {
            if (o != null)
            {
                Write(s + " - " + o.ToString());
            }
            else
            {
                Write(s);
            }
        }
    }
}
