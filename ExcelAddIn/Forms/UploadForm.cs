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
using System.Reflection;

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

        /// <summary>
        /// The most recent configuration read from Adaptive or the local cache file
        /// </summary>
        public ConfigList AdaptiveConf = null;

        /// <summary>
        /// Initialize the form
        /// </summary>
        public UploadForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BindRebindDGVCBs()
        {
            if (this.AdaptiveConf != null)
            {
                // Set data source for statvars
                Util.SetDgvComboBoxDS(
                    dgvManualStatVarProps.Columns["VariableType"] as DataGridViewComboBoxColumn,
                    ConfigList.AsDataTable(this.AdaptiveConf.statVariableTypes));

                // Set data source for measurement units
                Util.SetDgvComboBoxDS(
                    dgvManualStatVarProps.Columns["MeasurementUnit"] as DataGridViewComboBoxColumn,
                    ConfigList.AsDataTable(this.AdaptiveConf.measurementUnitTypes));

            }
        }

        /// <summary>
        /// Read adaptive configuration
        /// </summary>
        /// <param name="pRefresh">Refresh from server</param>
        private void UpdateAdaptiveConfig(bool pRefresh = false)
        {
            // Set data source for statistical unit types
            this.AdaptiveConf = WsDataSources.GetAdaptiveConfig(pRefresh);


            // Set data source for statareatypes
            if (this.AdaptiveConf != null)
            {
                Util.SetComboBoxDS(cbStatUnitType, this.AdaptiveConf.statUnitTypes);
            }

            // Call the script to bind CBs in ManualStatVarPropsDGV
            this.BindRebindDGVCBs();

            // Set data source for date formats
            Util.SetComboBoxDS(cbDateFormats, DateFormats.List);

            // Set default selection for all DataLayoutCBs
            foreach (var mComboBox in DataLayoutCBs)
            {
                Util.SetComboBoxDS(mComboBox, new List<CTEntry>(CTList.List));
                mComboBox.SelectedValue = CType.None;
            }

        }

        private void UploadForm_Load(object sender, EventArgs e)
        {

            this.dgvManualStatVarProps.AutoGenerateColumns = false;

            DataLayoutCBs.AddRange(new[] {
                cbColCType1, cbColCType2, cbColCType3, cbColCType4,
                cbRowCType1, cbRowCType2, cbRowCType3, cbRowCType4 });

            UpdateAdaptiveConfig(true);

            SetDataLayoutCBsEnabledState();

            dgvPreviewSelection.DataSource = Table.GetTableFromExcelRange(this.SelectedRange);
            dgvPreviewSelection.Refresh();
        }

        public void GetRowColOffset(ref int pFirstDataRow, ref int pFirstDataCol)
        {
            // Increment if row types are set
            if (Util.GetSelCType(this.cbRowCType1) != CType.None) pFirstDataRow = 2;
            if (Util.GetSelCType(this.cbRowCType2) != CType.None) pFirstDataRow = 3;
            if (Util.GetSelCType(this.cbRowCType3) != CType.None) pFirstDataRow = 4;
            if (Util.GetSelCType(this.cbRowCType4) != CType.None) pFirstDataRow = 5;

            // Increment if column types are set
            if (Util.GetSelCType(this.cbColCType1) != CType.None) pFirstDataCol = 2;
            if (Util.GetSelCType(this.cbColCType2) != CType.None) pFirstDataCol = 3;
            if (Util.GetSelCType(this.cbColCType3) != CType.None) pFirstDataCol = 4;
            if (Util.GetSelCType(this.cbColCType4) != CType.None) pFirstDataCol = 5;

        }

        /// <summary>
        /// Add a log message to the log pane
        /// </summary>
        /// <param name="pMsg">The message to log</param>
        /// <param name="pClear">A boolean flag that determines if the log pane is to be cleared before adding the new info</param>
        public void Log(string pMsg, bool pClear = false)
        {
            var mList = tbLog.Lines.ToList<string>();
            if (pClear)
            {
                mList.Clear();
            }

            mList.Add(pMsg);
            if (tbLog.Lines.Length > this.NumberOfLinesInLog)
            {
                mList.RemoveRange(0, (mList.Count - this.NumberOfLinesInLog));
            }

            // Assign lines to textbox
            tbLog.Lines = mList.ToArray<string>();

            // Scroll to bottom
            this.tbLog.SelectionStart = tbLog.Text.Length;
            this.tbLog.ScrollToCaret();
        }

        private void btnCopyDateToAll_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageStatisticsVariables;

            foreach (DataGridViewRow mRow in dgvManualStatVarProps.Rows)
            {
                mRow.Cells["Year"].Value = tbYear.Text;
                var m = mRow.Cells["YearPart"] as DataGridViewComboBoxCell;
                m.Value = cbYearPart.Text;
                mRow.Cells["Month"].Value = tbMonth.Text;
                mRow.Cells["Day"].Value = tbDay.Text;
            }
            this.ParseCurrent();
        }

        private void btnCopyFirstRowToAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            string mYear = "", mYearPart = "", mMonth = "", mDay = "", mMeasurementUnit = "", mVariableType = "";
            foreach (DataGridViewRow mRow in dgvManualStatVarProps.Rows)
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
            foreach (DataGridViewRow mRow in this.dgvManualStatVarProps.Rows)
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

                var mCsv = Export.Do(dgvManualStatVarProps, this.ParsedData, this);
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Determines which of the DataLayoutCBs are to be enabled or not
        /// </summary>
        /// <remarks>
        /// This relies on the order in which the CBs are added to the List of CBs and the number of CBs
        /// presently the function assumes 4 cols followed by 4 rows
        /// </remarks>
        private void SetDataLayoutCBsEnabledState()
        {
            for (int i = 2; i >= 0; i--)
            {
                if (Util.GetSelCType(DataLayoutCBs[i]) != CType.None)
                {
                    DataLayoutCBs[i + 1].Enabled = true;
                }
                else
                {
                    DataLayoutCBs[i + 1].Enabled = false;
                }
            }
            for (int i = 6; i >= 4; i--)
            {
                if (Util.GetSelCType(DataLayoutCBs[i]) != CType.None)
                {
                    DataLayoutCBs[i + 1].Enabled = true;
                }
                else
                {
                    DataLayoutCBs[i + 1].Enabled = false;
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Log("Startar eksport");

            this.ParseCurrent();

            dlgSaveCsvFile.FileName = Util.GetFilenameTemplate("csv");

            if (dlgSaveCsvFile.ShowDialog() == DialogResult.OK)
            {
                this.Log("Skriv til fil: " + dlgSaveCsvFile.FileName);
                var mStreamWriter = new StreamWriter(dlgSaveCsvFile.FileName);
                mStreamWriter.WriteLine(this.ParsedData.GetCSVHeader());
                foreach (var mRow in this.ParsedData.Keys)
                {
                    foreach (var mCol in this.ParsedData[mRow].Keys)
                    {
                        mStreamWriter.WriteLine(this.ParsedData[mRow][mCol].ToCSV());
                    }
                }
                mStreamWriter.Flush();
                mStreamWriter.Close();
                mStreamWriter = null;
            }

            this.Log("Ferdig med eksport");
        }

        private void btnTestParsing_Click(object sender, EventArgs e)
        {
            this.ParseCurrent();

            this.tabControl.SelectedTab = tabPageLogOutput;

            if (this.StatVarProps == null)
            {
                this.Log("Du må fyrst velje ei rad eller kolonne som inneheld statistikkvariablar");
                return;
            }
            this.Log("Startar test", true);
            this.Log(this.ParsedData.GetCSVHeader());
            foreach (var i in this.ParsedData.Keys)
            {
                foreach (var j in this.ParsedData[i].Keys)
                {
                    this.Log(this.ParsedData[i][j].ToCSV());
                }
            }
            this.Log("Ferdig med test");
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
                    tabControl.SelectedTab = tabPageStatisticsVariables;
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

            // Set conditional visibility of manual statdatum settings
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

            // Set conditional visibility of manual stat area settings
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

            // Reset parsed values if no longer present in layout combos

            // Reset statvars
            if (!mUsedCTypes.Contains(CType.StatVars))
            {
                this.StatVarProps = null;
                this.dgvManualStatVarProps.DataSource = null;
                this.dgvManualStatVarProps.Refresh();
            }

            // Reset statareaids
            if (!mUsedCTypes.Contains(CType.StatAreaIDs))
            {
                this.StatAreaIDsProps = null;
            }

            // Reset statdatum
            if (!mUsedCTypes.Contains(CType.StatDatum))
            {
                this.StatDatumProps = null;
            }

            // Rebind statvarprops to grid
            if (this.StatVarProps != null)
            {
                // Load statvars to manual settings for statvars if not already done
                // or if change in content of perpendicular rows/columns
                if (dgvManualStatVarProps.DataSource == null ||
                    mNewCType == CType.StatVars ||
                    pDataOrientation != this.StatVarProps.DataOrientation)
                {
                    this.PopulateManualStatVarDGV();
                }

                // Parse with current settings
                this.ParseCurrent();

            }

            // Determine whether layout comboboxes are supposed to be enabled or not
            this.SetDataLayoutCBsEnabledState();

            return;

        }

        public void PopulateManualStatVarDGV()
        {
            int mFirstDataCol = 1, mFirstDataRow = 1;

            this.GetRowColOffset(
                ref mFirstDataRow,
                ref mFirstDataCol);

            dgvManualStatVarProps.DataSource = StatVarProps.AsDataTable(
                mFirstDataRow,
                mFirstDataCol,
                this.StatVarProps.DataOrientation);

            dgvManualStatVarProps.Refresh();

            // Add logic to rebind columns here
            this.BindRebindDGVCBs();

            return;
        }

        /// <summary>
        /// Parse the selection with the current selection
        /// </summary>
        public void ParseCurrent()
        {
            if (this.StatVarProps != null)
            {
                int mFirstDataCol = 1, mFirstDataRow = 1;

                this.GetRowColOffset(
                        ref mFirstDataRow,
                        ref mFirstDataCol);

                this.ParsedData = Table.ParseSelectionWithCurrentSettings(
                        this.SelectedRange,
                        this,
                        mFirstDataRow,
                        mFirstDataCol);
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

        private void dgvPreviewSelection_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int i = 1;
            foreach (DataGridViewRow mDataRow in dgvPreviewSelection.Rows)
            {
                mDataRow.HeaderCell.Value = "Rad " + i;
                i++;
            }

            foreach (DataGridViewColumn mDataCol in dgvPreviewSelection.Columns)
            {
                mDataCol.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        public ManualStatVarProps GetManualStatVarProps(int pRow, int pCol, DataOrientation pDataOrientation)
        {

            int mStatVarIndex;

            if (pDataOrientation == DataOrientation.InColumns)
            {
                mStatVarIndex = pRow;
            }
            else
            {
                mStatVarIndex = pCol;
            }

            var mMSVPs = new ManualStatVarProps();

            for (int i = 0, j = dgvManualStatVarProps.RowCount; i < j; i++)
            {
                int mIndex = (int)dgvManualStatVarProps["Index", i].Value;
                Debug.WriteLine(mIndex + "==" + mStatVarIndex, "Freistar å parse rad-index");


                if (mIndex == mStatVarIndex)
                {
                    for (int f = 0; f < dgvManualStatVarProps.ColumnCount; f++)
                    {
                        DataGridViewColumn mDGVC = dgvManualStatVarProps.Columns[f];

                        switch (mDGVC.Index)
                        {
                            case 2:
                                mMSVPs.StatVar = Util.CheckNullOrEmpty(dgvManualStatVarProps[f, i].Value);
                                break;
                            case 3:
                                mMSVPs.MUnit = Util.CheckNullOrEmpty(dgvManualStatVarProps[f, i].Value);
                                break;
                            case 4:
                                mMSVPs.Year= Table.GetNullOrDoubleString(dgvManualStatVarProps[f, i].Value);
                                break;
                            case 5:
                                mMSVPs.YearPart = Table.GetNullOrDoubleString(dgvManualStatVarProps[f, i].Value);
                                break;
                            case 6:
                                mMSVPs.Month = Table.GetNullOrDoubleString(dgvManualStatVarProps[f, i].Value);
                                break;
                            case 7:
                                mMSVPs.Day = Table.GetNullOrDoubleString(dgvManualStatVarProps[f, i].Value);
                                break;
                        }

                    }
                    Util.DebugFields(mMSVPs);

                    break;
                }
            }
            return mMSVPs;
        }

        private void btnCopyFirstRowAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            string mYear = "", mYearPart = "", mMonth = "", mDay = "", mMeasurementUnit = "", mVariableType = "";
            foreach (DataGridViewRow mRow in dgvManualStatVarProps.Rows)
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

            this.ParseCurrent();

        }

        private void cbDateFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseCurrent();
        }

        private void cbStatUnitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParseCurrent();
        }

        private void btnCreateNewStatVar_Click(object sender, EventArgs e)
        {
            var mFrm = new StatVarForm();
            if (mFrm.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine("Invoke web service to add statvar");
            }

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            int i = 1;
            string mMeasurementUnit = "";
            foreach (DataGridViewRow mRow in dgvManualStatVarProps.Rows)
            {
                var mMeasurementUnitCell = mRow.Cells["MeasurementUnit"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    mMeasurementUnit = Table.GetNullOrString(mMeasurementUnitCell.Value);
                }
                else
                {
                    mMeasurementUnitCell.Value = mMeasurementUnit;
                }
                i++;
            }

            this.ParseCurrent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ParseCurrent();
        }

        private void btnCopyStatVarAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            string mVariableType = "";
            foreach (DataGridViewRow mRow in dgvManualStatVarProps.Rows)
            {
                var mVariableTypeCell = mRow.Cells["VariableType"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    mVariableType = Table.GetNullOrString(mVariableTypeCell.Value);
                }
                else
                {
                    mVariableTypeCell.Value = mVariableType;
                }
                i++;
            }

            this.ParseCurrent();

        }


    }
}
