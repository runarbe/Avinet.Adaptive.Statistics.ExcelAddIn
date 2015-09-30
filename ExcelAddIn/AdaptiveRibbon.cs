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

        private void btnMergeSavedImportSettings_Click(object sender, RibbonControlEventArgs e)
        {
            var mOpen = new OpenFileDialog();
            mOpen.FileName = "SavedImportSettings*.json";
            mOpen.Filter = "Saved import settings|*.json";
            mOpen.Title = "Please select the files to be merged";
            mOpen.CheckFileExists = true;

            string inputFile1, inputFile2;

            if (mOpen.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            inputFile1 = mOpen.FileName;

            if (mOpen.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            inputFile2 = mOpen.FileName;

            var settings1 = UploadFormStates.Load(inputFile1);
            var settings2 = UploadFormStates.Load(inputFile2);
            foreach (UploadFormState mState in settings2.States)
            {
                settings1.States.Add(mState);
            }

            var json = new JavaScriptSerializer(new SimpleTypeResolver());

            var mOutput = json.Serialize(settings1);

            var mSave = new SaveFileDialog();
            mSave.Title = "Please select an output file";
            mSave.FileName = "SavedImportSettings.json";
            mSave.Filter = "SavedImportSettings|*.json";

            if (mSave.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            File.WriteAllText(mSave.FileName, mOutput);

        }

    }
}
