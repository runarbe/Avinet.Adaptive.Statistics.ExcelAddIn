using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class UploadForm : Form
    {
        public Range SelectedRange;

        public Values3D ParsedData;

        public int NumberOfLinesInLog = 200;

        public UploadForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Export.Do(this.dgvFieldProperties, this.ParsedData, this);
        }

        private void UpdateAdaptiveConfig(bool pRefresh = false)
        {

            // Set data source for statistical unit types
            var mAdaptiveConf = WsDataSources.GetAdaptiveConfig(pRefresh);
            if (mAdaptiveConf != null)
            {

                Util.SetComboBoxDS(cbStatUnitType, mAdaptiveConf.statUnitTypes);

                // Set data source for statistical variable types
                Util.SetDgvComboBoxDS(dgvFieldProperties.Columns["VariableType"] as DataGridViewComboBoxColumn, mAdaptiveConf.statVariableTypes);

                // Set data source for measurement units
                Util.SetDgvComboBoxDS(dgvFieldProperties.Columns["MeasurementUnit"] as DataGridViewComboBoxColumn, mAdaptiveConf.measurementUnitTypes);

            }
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {

            this.dgvFieldProperties.AutoGenerateColumns = false;
            UpdateAdaptiveConfig(true);

        }

        private void LoadDataGridView(SelectionType pSelectionType)
        {
            this.ParsedData = Table.ParseSelection(this.SelectedRange, pSelectionType, this);
        }

        public void Log(string pMsg)
        {
            var mList = tbLog.Lines.ToList<string>();
            mList.Insert(0, pMsg);
            if (tbLog.Lines.Length > this.NumberOfLinesInLog)
            {
                mList.RemoveRange(this.NumberOfLinesInLog, (mList.Count - this.NumberOfLinesInLog));
            }
            tbLog.Lines = mList.ToArray<string>();
        }

        private void btnCopyDateToAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow mRow in dgvFieldProperties.Rows)
            {
                mRow.Cells["Year"].Value = tbYear.Text;
                var m = mRow.Cells["YearPart"] as DataGridViewComboBoxCell;
                m.Value = cbYearPart.SelectedValue;
                mRow.Cells["Month"].Value = tbMonth.Text;
                mRow.Cells["Day"].Value = tbDay.Text;
            }
        }

        private void btnCopyFirstRowToAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            string mYear = "", mYearPart = "", mMonth = "", mDay = "", mMeasurementUnit = "", mVariableType = "";
            foreach (DataGridViewRow mRow in dgvFieldProperties.Rows)
            {
                var mYearPartCell = mRow.Cells["YearPart"] as DataGridViewComboBoxCell;
                var mVariableTypeCell = mRow.Cells["VariableType"] as DataGridViewComboBoxCell;
                var mMeasurementUnitCell = mRow.Cells["MeasurementUnit"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    mYear = Table.GetNullOrString(mRow.Cells["Year"].Value);
                    mYearPart = Table.GetNullOrString(mYearPartCell.Value);
                    mMonth = Table.GetNullOrString(mRow.Cells["Month"].Value);
                    mDay = Table.GetNullOrString(mRow.Cells["day"].Value);
                    mVariableType = Table.GetNullOrString(mVariableTypeCell.Value);
                    mMeasurementUnit = Table.GetNullOrString(mMeasurementUnitCell.Value);
                }
                else
                {
                    mRow.Cells["Year"].Value = mYear;
                    mYearPartCell.Value = mYearPart;
                    mRow.Cells["Month"].Value = mMonth;
                    mRow.Cells["day"].Value = mDay;
                    mVariableTypeCell.Value = mVariableType;
                    mMeasurementUnitCell.Value = mMeasurementUnit;
                }
                i++;
            }

        }

        private void rbFirstRow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDataInRows.Checked == true)
            {
                this.LoadDataGridView(SelectionType.DataInRows);
            }
        }

        private void rbFirstColumn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDataInCols.Checked == true)
            {
                this.LoadDataGridView(SelectionType.DataInCols);
            }
        }

        private void cbStatisticalUnitField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFieldsUpdateHandler(sender);
        }

        private void cbFieldsUpdateHandler(Object sender)
        {
            ComboBox mCombo = (ComboBox)sender;
            if (mCombo.ValueMember != "")
            {
                var mFieldIndex = mCombo.SelectedValue.ToString();
                ExcludeFieldIndex(mFieldIndex);
            }
        }

        private void ExcludeFieldIndex(string pFieldIndexToExclude)
        {
            foreach (DataGridViewRow mRow in this.dgvFieldProperties.Rows)
            {
                string mCFieldIndex = mRow.Cells["FieldIndex"].Value.ToString();
                if (mCFieldIndex == pFieldIndexToExclude)
                {
                    var mCell = mRow.Cells["Include"] as DataGridViewCheckBoxCell;
                    mCell.Value = mCell.FalseValue;
                }
            }

        }

        private void ProcessExportCSV()
        {
            if (dlgSaveCsvFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                var mCsv = Export.Do(dgvFieldProperties, this.ParsedData, this);
                if (mCsv != null)
                {
                    StreamWriter sw = new StreamWriter(dlgSaveCsvFile.FileName, false, Encoding.UTF8);
                    sw.Write(mCsv.Serialize());
                    this.Log(String.Format("Informasjon: lagra CSV-data til fila: {0}", dlgSaveCsvFile.FileName));
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    Log("Feil: eksportrutina returnerte ingen rader...");
                }
            }
            else
            {
                this.Log("Informasjon: brukaren avbraut operasjonen");
            }
        }

        private void lagreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessExportCSV();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }

        private void stengToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cbStatUnitNameField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFieldsUpdateHandler(sender);
        }

        private void cbStatUnitGroupField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFieldsUpdateHandler(sender);
        }

        private void updateConfigFromServer(object sender, EventArgs e)
        {
            UpdateAdaptiveConfig(true);
        }

        private void TestExport()
        {
            var mCsv = Export.Do(dgvFieldProperties, this.ParsedData, this);
            if (mCsv != null)
            {
                Log(mCsv.Serialize());
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestExport();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ProcessExportCSV();
        }

        private void lastOppToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnTestParsing_Click(object sender, EventArgs e)
        {
            TestExport();
        }

        private void lagreSomCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessExportCSV();
        }

    }
}
