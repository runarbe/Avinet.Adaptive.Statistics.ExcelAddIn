using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Excel;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class AdaptiveRibbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private Range GetSelectedRange()
        {
            return (Range)Globals.ThisAddIn.Application.ActiveWindow.Selection;
        }

        private void BtnUploadSelection_Click(object sender, RibbonControlEventArgs e)
        {
            var mSelection = this.GetSelectedRange();
            
            if (mSelection == null || (mSelection.Width < 2 && mSelection.Height < 2)) {
                return;
            }

            var mFrm = new UploadForm();
            mFrm.SelectedRange = this.GetSelectedRange();
            mFrm.ShowDialog();
        }

        private void ButtonHelp_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void ButtonAbout_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void btnConfig_Click(object sender, RibbonControlEventArgs e)
        {
            var mFrm = new ConfigForm();
            mFrm.ShowDialog();
        }
    }
}
