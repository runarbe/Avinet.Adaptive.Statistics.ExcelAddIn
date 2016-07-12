using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;
using System.IO;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class ThisAddIn
    {
        public static Excel.Application AddInApp = null;
        public static String LogFile = null;
        public static String SavedStatesFilename = null;


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            AddInApp = this.Application;
            string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);            
            LogFile = Path.Combine(MyDocuments, "GeoStat2 Excel Add-in", "error.log");
            SavedStatesFilename = Path.Combine(MyDocuments, "GeoStat2 Excel Add-in", "savedstates.json");

            if (!File.Exists(SavedStatesFilename))
            {
                File.WriteAllText(SavedStatesFilename, "[]");
            }

            if (!File.Exists(LogFile))
            {
                using (var w = File.CreateText(LogFile))
                {
                    w.WriteLine("Created error log at: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                }
            }
            else
            {
                using (var w = File.AppendText(LogFile))
                {
                    w.WriteLine("Started add-in at: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm"));
                }
            }

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
