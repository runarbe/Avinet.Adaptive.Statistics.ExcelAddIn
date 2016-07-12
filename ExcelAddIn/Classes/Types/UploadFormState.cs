using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class UploadFormState
    {
        public string Category;
        public string SubCategory;
        public string StateName;

        public Range SourceData;

        public string CbColCType1Text;
        public string CbColCType2Text;
        public string CbColCType3Text;
        public string CbColCType4Text;

        public string CbRowCType1Text;
        public string CbRowCType2Text;
        public string CbRowCType3Text;
        public string CbRowCType4Text;

        public string CbStatDatumFormatText;
        public string TbStatDatumYearText;
        public string CbStatDatumQuarterText;
        public string TbStatDatumMonthText;

        public string CbStatUnitTypeText;
        public string TbStatUnitIdText;
        public string TbStatUnitNameText;
        public string TbStatUnitGroupText;

        public List<StatVarPropertiesState> DgvStatVarPropertiesState;

        public UploadFormState()
        {
            DgvStatVarPropertiesState = new List<StatVarPropertiesState>();
        }

        public static UploadFormState GetCurrentState(UploadForm frm) {
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
            return s;
        }

        public bool RestoreSourceData()
        {
            Worksheet worksheet = ThisAddIn.AddInApp.Worksheets.Add();
            worksheet.Name = "New";
            return true;
        }



        public static List<UploadFormState> LoadSavedStates() {
            var json = File.ReadAllText(ThisAddIn.SavedStatesFilename);
            var states = JsonConvert.DeserializeObject<List<UploadFormState>>(json);
            ConfigProvider.savedUploadFormStates = states.Select(s => new NamedUploadFormState() { Name = s.StateName, State = s });
            return states;
        }

        public static bool SaveState(UploadFormState state) {
            var states = UploadFormState.LoadSavedStates();
            var exists = states.Where(d => d.StateName == state.StateName).Count() > 0 ? true : false;
            if (exists)
            {
                for (var i = (states.Count() - 1); i >= 0; i--) {
                    if (states[i].StateName == state.StateName) {
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

        public static UploadFormState RestoreState(UploadForm uploadForm) {
            var state = new UploadFormState();
            return state;
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
