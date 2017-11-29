using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
            var frm = new StatVarTreeForm();
            frm.ShowDialog();

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var a = AdaptiveClient.Authenticate("a3@avinet.no", "test");

            if (a != null)
            {
                MessageBox.Show(a.key);
            }
            else
            {
                MessageBox.Show("Authentication failed");
            }

        }

        private void btnRestoreData_Click(object sender, RibbonControlEventArgs e)
        {
            var frm = new SavedStateSelectForm();

            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var s = frm.SelectedState.RestoreSourceData();
                if (s != null)
                {
                    MessageBox.Show(null,
                        "Henta kjeldedata og la til nytt ark i arbeidsboka",
                        "Operasjonen lukkast",
                        MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    MessageBox.Show(null,
                        "Kunne ikkje gjenopprette kjeldedataene",
                        "Operasjonen lukkast ikkje",
                        MessageBoxButtons.OK);
                }
            }


        }

        private void btnExportSavedStates_Click(object sender, RibbonControlEventArgs e)
        {
            if (!File.Exists(ThisAddIn.SavedStatesFilename))
            {
                MessageBox.Show("Det finst ingen oppsett å eksportere", "Informasjon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dlg = new SaveFileDialog();
            dlg.Title = "Eksporter lagra oppsett til...";
            dlg.Filter = "Oppsettfiler|*.json";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(dlg.FileName))
                    {
                        File.Delete(dlg.FileName);
                    }
                    File.Copy(ThisAddIn.SavedStatesFilename, dlg.FileName);
                    MessageBox.Show("Oppsettet vart lagra til fila: " + dlg.FileName, "Operasjonen vellukka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Det oppstod ein feil ved lagring av oppsettsfila: " + ex.Message, "Operasjonen feila", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportSavedStates_Click(object sender, RibbonControlEventArgs e)
        {

            try
            {
                var dlg = new OpenFileDialog();
                dlg.Title = "Vel ei fil med lagra oppsett...";
                dlg.Filter = "Oppsettfiler|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var combinedStates = new List<UploadFormState>();
                    var fileContent = File.ReadAllText(dlg.FileName);
                    var newStates = JsonConvert.DeserializeObject<List<UploadFormState>>(fileContent);
                    if (newStates != null)
                    {
                        combinedStates.AddRange(newStates);
                        if (File.Exists(ThisAddIn.SavedStatesFilename))
                        {

                            File.Copy(ThisAddIn.SavedStatesFilename, ThisAddIn.SavedStatesFilename + ".backup", true);

                            var existingStates = JsonConvert.DeserializeObject<List<UploadFormState>>(File.ReadAllText(ThisAddIn.SavedStatesFilename));
                            if (existingStates != null)
                            {
                                combinedStates.AddRange(existingStates);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Den valde fila inneheld ikkje gyldige oppsett", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    File.WriteAllText(ThisAddIn.SavedStatesFilename, JsonConvert.SerializeObject(combinedStates));
                    File.Delete(ThisAddIn.SavedStatesFilename + ".backup");
                    MessageBox.Show("Import av lagra oppsett var vellukka...", "Operasjonen vellukka", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                Dbg.WriteLine("Ein feil oppstod under import av lagra oppsett", ex.Message);
                if (File.Exists(ThisAddIn.SavedStatesFilename + ".backup") &&
                    !File.Exists(ThisAddIn.SavedStatesFilename))
                {
                    File.Copy(ThisAddIn.SavedStatesFilename + ".backup", ThisAddIn.SavedStatesFilename);
                    File.Delete(ThisAddIn.SavedStatesFilename + ".backup");
                }
            }
        }

        private void btnOpenLogFileDir_Click(object sender, RibbonControlEventArgs e)
        {
            if (Directory.Exists(ThisAddIn.AddInLogDirectory))
            {
                Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + ThisAddIn.LogFile));
            }
        }

    }
}
