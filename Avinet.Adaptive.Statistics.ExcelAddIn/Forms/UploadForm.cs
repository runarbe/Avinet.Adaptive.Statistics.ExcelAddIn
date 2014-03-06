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
        /// <summary>
        /// The selected range of cells from the excel sheet
        /// </summary>
        public Range SelectedRange;

        /// <summary>
        /// The parsed data, held in memory and updated as settings are changed
        /// </summary>
        public Values3D ParsedData;

        /// <summary>
        /// Dating of the data
        /// </summary>
        public StatProps StatDatumProps = null;

        /// <summary>
        /// Statistical variable definitions of the data
        /// </summary>
        public StatProps StatVarProps = null;

        /// <summary>
        /// Statistical area ids for the data
        /// </summary>
        public StatProps StatAreaIDsProps = null;

        /// <summary>
        /// Statistical area groupings for the data
        /// </summary>
        public StatProps StatAreaGroupProps = null;

        /// <summary>
        /// Statistical area names for the data
        /// </summary>
        public StatProps StatAreaNameProps = null;

        /// <summary>
        /// Limit the number of lines to keep in the log before overwriting
        /// </summary>
        public int NumberOfLinesInLog = 400;

        /// <summary>
        /// The connected comboboxes used for 
        /// </summary>
        public List<ComboBox> DataLayoutCBs = new List<ComboBox>();

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

            Util.SetComboBoxDS(cbDateFormats, DateFormats.List);

            foreach (var mComboBox in DataLayoutCBs)
            {
                Util.SetComboBoxDS(mComboBox, new List<CTEntry>(CTList.List));
            }

        }

        private void UploadForm_Load(object sender, EventArgs e)
        {

            this.dgvFieldProperties.AutoGenerateColumns = false;

            DataLayoutCBs.AddRange(new[] { cbColCType1, cbColCType2, cbColCType3, cbColCType4, cbRowCType1, cbRowCType2, cbRowCType3, cbRowCType4 });

            UpdateAdaptiveConfig(true);
            dgvPreviewSelection.DataSource = Table.RangeToDataTable(this.SelectedRange);
            dgvPreviewSelection.Refresh();
        }

        private void LoadDataGridView2()
        {
            dgvFieldProperties.DataSource = StatVarProps.AsDataTable();
            dgvFieldProperties.Refresh();
        }

        private void LoadDataGridView(SelectionType pSelectionType, CType pSecondDimension)
        {
            this.ParsedData = Table.ParseSelection(this.SelectedRange, pSelectionType, pSecondDimension, this);
        }

        public void Log(string pMsg)
        {
            var mList = tbLog.Lines.ToList<string>();
            mList.Add(pMsg);
            if (tbLog.Lines.Length > this.NumberOfLinesInLog)
            {
                mList.RemoveRange(0, (mList.Count - this.NumberOfLinesInLog));
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
            /*if (rbDataInRows.Checked == true)
            {
                this.LoadDataGridView(SelectionType.StatisticalVariabesInFirstCol);
            }*/
        }

        private void rbFirstColumn_CheckedChanged(object sender, EventArgs e)
        {
            /*if (rbDataInCols.Checked == true)
            {
                this.LoadDataGridView(SelectionType.StatisticalVariablesInFirstRow);
                this.LoadDataGridView(SelectionType.StatisticalVariabesInFirstCol);
            }*/
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

        private void ClearDGVStatVarNotSelected(CType pCol, CType pRow)
        {
            if (pCol != CType.StatVars && pRow != CType.StatVars)
            {
                dgvFieldProperties.DataSource = null;
                dgvFieldProperties.Refresh();
            }
        }

        private void OnLayoutComboBoxChange(ComboBox pChangedCb, DataOrientation pDataOrientation, int pIndex)
        {
            // Get the new value of the changed CB
            var mNewCType = Util.GetSelCType(pChangedCb);

            // Create a list to store all currently selected CB values
            var mUsedCTypes = new List<CType>();

            // For each of the comboboxes with data layout info
            foreach (ComboBox mCb in DataLayoutCBs)
            {
                // Get the current contents of col/row
                var mCbCType = Util.GetSelCType(mCb);

                // If the current control is not 
                if (mCb != pChangedCb && (mCbCType != CType.None && mCbCType != CType.Ignore))
                {
                    if (mCbCType == mNewCType || mUsedCTypes.Contains(mCbCType))
                    {
                        mCb.SelectedValue = CType.None;
                    }
                    mUsedCTypes.Add(mCbCType);
                }
            }

            // Add the new type to the list of used types
            if (!mUsedCTypes.Contains(mNewCType) && (mNewCType != CType.None && mNewCType != CType.Ignore))
            {
                mUsedCTypes.Add(mNewCType);
            }

            // Based on the new value of the changed CB, do something
            switch (mNewCType)
            {
                // Load stat vars
                case CType.StatVars:
                    this.StatVarProps = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    LoadDataGridView2();
                    break;
                // Load stat dates
                case CType.StatDatum:
                    this.StatDatumProps = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area IDs
                case CType.StatAreaIDs:
                    this.StatAreaIDsProps = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area names
                case CType.StatAreaNames:
                    this.StatAreaNameProps = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area groups
                case CType.StatAreaGroups:
                    this.StatAreaGroupProps = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
            }

            // Determine what to do about
            if (mUsedCTypes.Contains(CType.StatDatum) && mUsedCTypes.Contains(CType.StatVars))
            {
                this.grpManualDateSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = true;
            }
            else if (!mUsedCTypes.Contains(CType.StatDatum) && mUsedCTypes.Contains(CType.StatVars))
            {
                this.grpManualDateSettings.Enabled = true;
                this.grpAutoDateSettings.Enabled = false;
            }
            else
            {
                this.grpManualDateSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = false;
            }

            if (!mUsedCTypes.Contains(CType.StatAreaIDs) && mUsedCTypes.Contains(CType.StatVars))
            {
                this.grpManualStatAreaSettings.Enabled = true;
            }
            else if (mUsedCTypes.Contains(CType.StatAreaIDs) && mUsedCTypes.Contains(CType.StatVars))
            {
                this.grpManualStatAreaSettings.Enabled = false;
            }
            else
            {
                this.grpManualStatAreaSettings.Enabled = false;
            }

        }

        private void cbFirstColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbColCType1, DataOrientation.InColumns, 1);
        }

        private void cbSecondColCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbColCType2, DataOrientation.InColumns, 2);
        }

        private void cbThirdColCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbColCType3, DataOrientation.InColumns, 3);
        }

        private void cbColCType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbColCType4, DataOrientation.InColumns, 4);
        }

        private void cbFirstRowCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbRowCType1, DataOrientation.InRows, 1);
        }

        private void cbSecondRowCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbRowCType2, DataOrientation.InRows, 2);
        }

        private void cbRowCType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbRowCType3, DataOrientation.InRows, 3);
        }

        private void cbRowCType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnLayoutComboBoxChange(cbRowCType4, DataOrientation.InRows, 4);
        }


        private void btnTest_Click_1(object sender, EventArgs e)
        {
            Table.ParseSelection2(
                this.SelectedRange,
                this);
        }

        private void dgvPreviewSelection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int i = 1;
            foreach (DataGridViewRow mDataRow in dgvPreviewSelection.Rows)
            {
                mDataRow.HeaderCell.Value = "Rad " + i;
                i++;
            }
        }

        public StatVarProps GetStatVarProps(int pStatVarIndex)
        {
            var mSVPs = new StatVarProps();

            if (pStatVarIndex < dgvFieldProperties.Rows.Count)
            {
                var mRow = dgvFieldProperties.Rows[pStatVarIndex];
                mSVPs.StatisticalVariable = (string)mRow.Cells["VariableType"].Value;
                mSVPs.MeasurementUnit = (string)mRow.Cells["MeasurementUnit"].Value;
                mSVPs.Year = (string)mRow.Cells["Year"].Value;
                mSVPs.YearPart= (string)mRow.Cells["YearPart"].Value;
                mSVPs.Month = (string)mRow.Cells["Month"].Value;
                mSVPs.Day = (string)mRow.Cells["Day"].Value;
            }
            return mSVPs;
        }

    }
}
