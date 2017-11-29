using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class DialogBoxes
    {
        public static void Error(string message, string title = "Feil")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        public static void Warning(string message, string title = "Åtvaring")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        public static void Information(string message, string title = "Informasjon")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
