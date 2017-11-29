using Microsoft.Office.Interop.Excel;
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
    public class UploadFormState
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string StateName { get; set; }
        public string StateDisplayName
        {
            get
            {
                var r = new StringBuilder();
                r.Append(Category);

                if (!String.IsNullOrWhiteSpace(SubCategory))
                {
                    r.AppendFormat(" > {0}", SubCategory);
                }

                r.AppendFormat(" > [{0}]", StateName);
                
                return r.ToString();
            }
        }

        public List<List<Object>> SourceData { get; set; }

        public string CbColCType1Text { get; set; }
        public string CbColCType2Text { get; set; }
        public string CbColCType3Text { get; set; }
        public string CbColCType4Text { get; set; }

        public string CbRowCType1Text { get; set; }
        public string CbRowCType2Text { get; set; }
        public string CbRowCType3Text { get; set; }
        public string CbRowCType4Text { get; set; }

        public string CbStatDatumFormatText { get; set; }
        public string TbStatDatumYearText { get; set; }
        public string CbStatDatumQuarterText { get; set; }
        public string TbStatDatumMonthText { get; set; }

        public string CbStatUnitTypeText { get; set; }
        public string TbStatUnitIdText { get; set; }
        public string TbStatUnitNameText { get; set; }
        public string TbStatUnitGroupText { get; set; }

        public List<StatVarPropertiesState> DgvStatVarPropertiesState { get; set; }

        public UploadFormState()
        {
            DgvStatVarPropertiesState = new List<StatVarPropertiesState>();
        }

        public static UploadFormState GetCurrentState(UploadForm frm)
        {

            var s = new UploadFormState();
            s.CbColCType1Text = frm.cbColCType1.Text;
            s.CbColCType2Text = frm.cbColCType2.Text;
            s.CbColCType3Text = frm.cbColCType3.Text;
            s.CbColCType4Text = frm.cbColCType4.Text;

            s.CbRowCType1Text = frm.cbRowCType1.Text;
            s.CbRowCType2Text = frm.cbRowCType2.Text;
            s.CbRowCType3Text = frm.cbRowCType3.Text;
            s.CbRowCType4Text = frm.cbRowCType4.Text;

            s.CbStatDatumFormatText = frm.cbStatDatumFormat.Text;
            s.TbStatDatumYearText = frm.tbStatDatumYear.Text;
            s.CbStatDatumQuarterText = frm.cbStatDatumQuarter.Text;
            s.TbStatDatumMonthText = frm.tbStatDatumMonth.Text;

            s.CbStatUnitTypeText = frm.cbStatUnitType.Text;
            s.TbStatUnitIdText = frm.tbStatUnitID.Text;
            s.TbStatUnitNameText = frm.tbStatUnitName.Text;
            s.TbStatUnitGroupText = frm.tbStatUnitGroup.Text;

            // Save source data
            s.SourceData = new List<List<Object>>();

            foreach (Range srcRow in frm.SelectedRange.Rows)
            {
                var innerRow = new List<Object>();
                foreach (Range srcCol in srcRow.Columns)
                {
                    innerRow.Add(srcCol.Value);
                }
                s.SourceData.Add(innerRow);
            }


            // Save statistical variable properties
            s.DgvStatVarPropertiesState = new List<StatVarPropertiesState>();
            foreach (DataGridViewRow dgvRow in frm.dgvStatVarProperties.Rows)
            {
                // Create temporary state for statvar property
                var tSS = new StatVarPropertiesState();

                foreach (DataGridViewColumn dgvCol in frm.dgvStatVarProperties.Columns)
                {
                    var val = dgvRow.Cells[dgvCol.Name].Value;
                    if (val != null)
                    {
                        switch (dgvCol.Name)
                        {
                            case "Title":
                                tSS.TitleText = val.ToString();
                                break;
                            case "SelectedStatVar":
                                var tmpStatVar = val as Variable;
                                if (tmpStatVar != null)
                                {
                                    tSS.SelectedStatVar = tmpStatVar;
                                }
                                break;
                            case "TimeUnit":
                                tSS.TimeUnitText = val.ToString();
                                break;
                            case "Year":
                                tSS.YearText = val.ToString();
                                break;
                            case "Quarter":
                                tSS.QuarterText = val.ToString();
                                break;
                            case "Month":
                                tSS.MonthText = val.ToString();
                                break;
                            case "Unit":
                                tSS.UnitText = val.ToString();
                                break;
                            case "Kretstype":
                                tSS.KretstypeText = val.ToString();
                                break;
                        }
                    }
                }
                s.DgvStatVarPropertiesState.Add(tSS);
            }

            return s;
        }

        /// <summary>
        /// Restore a worksheet from data in saved settings
        /// </summary>
        /// <returns>Worksheet on success, null on error</returns>
        public Worksheet RestoreSourceData()
        {
            try
            {
                Worksheet worksheet = ThisAddIn.AddInApp.Worksheets.Add();
                String baseSheetName = "Kjeldedata";
                String sheetName = baseSheetName;
                int counter = 1;
                while (ThisAddIn.AddInApp.Worksheets.OfType<Worksheet>().Select(d => d.Name).ToList().Contains(sheetName))
                {
                    sheetName = baseSheetName + " " + counter.ToString();
                    counter++;
                }
                worksheet.Name = sheetName;

                int colIdx = 1;
                int rowIdx = 1;

                foreach (List<Object> rowArray in this.SourceData)
                {
                    foreach (Object colValue in rowArray)
                    {
                        worksheet.Cells[rowIdx, colIdx].value = colValue;
                        colIdx++;
                    }
                    colIdx = 1;
                    rowIdx++;
                }
                return worksheet;

            }
            catch (Exception ex)
            {
                Dbg.WriteLine("Feil ved gjenoppretting av data", ex.Message);
                return null;
            }

        }



        public static List<UploadFormState> LoadSavedStates()
        {
            var json = File.ReadAllText(ThisAddIn.SavedStatesFilename);
            var states = JsonConvert.DeserializeObject<List<UploadFormState>>(json);
            ConfigProvider.savedUploadFormStates = states.Select(s => new NamedUploadFormState() { Name = s.StateName, State = s });
            return states;
        }

        public static bool DeleteState(UploadFormState state)
        {
            try
            {
                var states = LoadSavedStates();
                var itemToRemove = states.Single(s => s.StateName == state.StateName);
                if (itemToRemove != null)
                {
                    states.Remove(itemToRemove);
                }
                var json = JsonConvert.SerializeObject(states);
                File.WriteAllText(ThisAddIn.SavedStatesFilename, json);

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool SaveState(UploadFormState state)
        {
            var states = UploadFormState.LoadSavedStates();
            var exists = states.Where(d => d.StateName == state.StateName).Count() > 0 ? true : false;
            if (exists)
            {
                MessageBox.Show(null, "Trykk OK for å overskrive lagra oppsett", "Stadfest overskriving...", MessageBoxButtons.OK);
                for (var i = (states.Count() - 1); i >= 0; i--)
                {
                    if (states[i].StateName == state.StateName)
                    {
                        states.RemoveAt(i);
                        break;
                    }
                }
            }
            states.Add(state);
            var json = JsonConvert.SerializeObject(states);
            File.WriteAllText(ThisAddIn.SavedStatesFilename, json);
            return true;
        }

        public static bool ImportFromFile()
        {
            var dlg = new OpenFileDialog();
            dlg.Title = "Vel ei fil med opplastingsoppsett";
            dlg.Filter = "Upload states|*.json";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ExportToFile()
        {
            var dlg = new SaveFileDialog();
            dlg.Title = "Vel ei fil med opplastingsoppsett";
            dlg.Filter = "Upload states|*.json";
            dlg.FileName = "geostat-oppsett-" + DateTime.Now.ToString("yyyy-MM-dd") + ".json";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
