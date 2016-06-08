using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class AdaptiveRibbon
    {

        private Range GetSelectedRange()
        {
            return (Range)Globals.ThisAddIn.Application.ActiveWindow.Selection;
        }

        private void btnConfig_Click(object sender, RibbonControlEventArgs e)
        {
            var mFrm = new ConfigForm();
            mFrm.ShowDialog();
        }

        private void btnUpload_Click(object sender, RibbonControlEventArgs e)
        {
            var mSelection = this.GetSelectedRange();

            if (mSelection.Cells.Value is string || mSelection.Cells.Value == null || (mSelection.Cells.Width < 2 && mSelection.Cells.Height < 2))
            {
                return;
            }

            var mFrm = new UploadForm();
            mFrm.SelectedRange = this.GetSelectedRange();
            mFrm.ShowDialog();

        }

        private void btnHelp_Click(object sender, RibbonControlEventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\docs\\brukarrettleiing-nynorsk.pdf");
        }

        private void btnAbout_Click(object sender, RibbonControlEventArgs e)
        {
            var frm = new AboutAddInForm();
            frm.ShowDialog();
        }

        private void btnEditStatVar_Click(object sender, RibbonControlEventArgs e)
        {
            var frm = new StatVarForm();
            frm.ShowDialog();

        }

    }
}
