using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class UploadForm : Form
    {

        /// <summary>
        /// The selected range of cells from the excel sheet
        /// </summary>
        public Range SelectedRange;

        /// <summary>
        /// The parsed valuesList, held in memory and updated as settings are changed
        /// </summary>
        public Values3D ParsedData;

        /// <summary>
        /// Dating of the valuesList
        /// </summary>
        public StatProps StatDatumProperties = null;

        /// <summary>
        /// Statistical variable definitions of the valuesList
        /// </summary>
        public StatProps StatVarProperties = null;

        /// <summary>
        /// Statistical variable 2 definitions of the valuesList
        /// </summary>
        public StatProps StatVarProperties2 = null;

        /// <summary>
        /// Statistical area idParts for the valuesList
        /// </summary>
        public StatProps StatAreaIDsProperties = null;

        /// <summary>
        /// Statistical area groupings for the valuesList
        /// </summary>
        public StatProps StatAreaGroupProperties = null;

        /// <summary>
        /// Statistical area names for the valuesList
        /// </summary>
        public StatProps StatAreaNameProperties = null;

        /// <summary>
        /// Limit the number of lines to keep in the log before overwriting
        /// </summary>
        public int NumberOfLinesInLog = 400;

        /// <summary>
        /// An array of ComboBox objects that describe the layout of the selected valuesList
        /// </summary>
        public List<ComboBox> CellContentTypeComboBoxes = new List<ComboBox>();

        /// <summary>
        /// The application configuration, read from Adaptive, cached locally
        /// TODO: Add remote storage
        /// </summary>
        public ConfigProvider AdaptiveConf = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UploadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function that is executed when the form is loaded. Setting up valuesList sources of controls, behaviors etc.
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void UploadForm_Load(object sender, EventArgs e)
        {
            if (!ConfigProvider.IsConfigured())
            {
                ConfigProvider.Load();
            }

            this.Log("Detailed log messages may be found here: " + DebugToFile.LogFileName);

            // Set StatVar DataGridView to *NOT* auto-generate columns from datasource
            dgvStatVarProperties.AutoGenerateColumns = false;

            // Set default edit-mode of StatVar DataGridView
            dgvStatVarProperties.EditMode = DataGridViewEditMode.EditOnEnter;

            // Attach event handlers to StatVar DataGridView to permit editing of currentCell valuesList
            dgvStatVarProperties.EditingControlShowing += dgvManualStatVarProps_EditingControlShowing;

            // Create an object to hold the CellContentTypes combos (in a specific order)
            CellContentTypeComboBoxes.AddRange(new[] {
                cbColCType1, cbColCType2, cbColCType3, cbColCType4,
                cbRowCType1, cbRowCType2, cbRowCType3, cbRowCType4 });

            // Populate comboboxes in the form and in the datagridview
            PopulateComboBoxes();

            // Set default state of CellContentTypes combos
            SetCellContentTypeComboBoxEnabledState();

            // Set valuesList source of Preview DataGridView
            dgvPreviewSelection.DataSource = Table.GetTableFromExcelRange(this.SelectedRange);
            dgvPreviewSelection.Refresh();

        }

        /// <summary>
        /// Load any existing saved settings from the client machine
        /// </summary>
        [Obsolete("No saving or loading of form states in v2")]
        private void LoadSavedUploadFormStates()
        {

            //cbSettings.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            //cbSettings.ComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cbSettings.ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            //sv mTmp = cbSettings.ComboBox.Text;
            //Util.SetComboBoxDS(cbSettings.ComboBox, UploadFormStates.AsComboBoxItems());

            //if (mTmp != null)
            //{
            //    cbSettings.ComboBox.Text = mTmp;
            //}
        }

        void dgvStatVarProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            // You could also check here to see if the currentCell in question is the combobox
            if (dgvStatVarProperties.IsCurrentCellDirty)
            {
                dgvStatVarProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Determine how many rows and cols to offset the selection to get *only* the valuesList cells, omitting any column
        /// or row headers
        /// </summary>
        /// <param title="pFirstDataRow"></param>
        /// <param title="pFirstDataCol"></param>
        public void GetRowColOffset(ref int pFirstDataRow, ref int pFirstDataCol)
        {
            // Increment if row types are set
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType1) != CellContentTypes.Values) pFirstDataRow = 2;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType2) != CellContentTypes.Values) pFirstDataRow = 3;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType3) != CellContentTypes.Values) pFirstDataRow = 4;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType4) != CellContentTypes.Values) pFirstDataRow = 5;

            // Increment if column types are set
            if (Util.GetComboBoxSelectedValueString(this.cbColCType1) != CellContentTypes.Values) pFirstDataCol = 2;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType2) != CellContentTypes.Values) pFirstDataCol = 3;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType3) != CellContentTypes.Values) pFirstDataCol = 4;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType4) != CellContentTypes.Values) pFirstDataCol = 5;

        }

        /// <summary>
        /// Add a log message to the log pane
        /// </summary>
        /// <param title="pMsg">The message to log</param>
        /// <param title="pClear">A boolean flag that determines if the log pane is to be cleared before adding the new info</param>
        public void Log(object pMsg, bool pClear = false, bool pDoEvents = true)
        {
            if (pMsg == null) return;

            var mList = tbLog.Lines.ToList<string>();
            if (pClear)
            {
                mList.Clear();
            }

            mList.Add(pMsg.ToString());
            if (tbLog.Lines.Length > this.NumberOfLinesInLog)
            {
                mList.RemoveRange(0, (mList.Count - this.NumberOfLinesInLog));
            }

            // Assign lines to textbox
            tbLog.Lines = mList.ToArray<string>();

            // Scroll to bottom
            this.tbLog.SelectionStart = tbLog.Text.Length;
            this.tbLog.ScrollToCaret();
            if (pDoEvents) System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// Copy the manual date settings to all rows in the StatVarProperties DataGridView
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void btnCopyDateToAll_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpStatisticsVariables;

            foreach (DataGridViewRow mRow in dgvStatVarProperties.Rows)
            {
                mRow.Cells["Year"].Value = tbStatDatumYear.Text;
                mRow.Cells["Quarter"].AsComboBox().Value = cbStatDatumQuarter.SelectedItem;
                mRow.Cells["Month"].Value = tbStatDatumMonth.Text;
            }
            this.ParseSelectionWithCurrentSettings();
        }

        private void cbFieldsUpdateHandler(Object pSender)
        {
            ComboBox mCombo = (ComboBox)pSender;
            if (mCombo.ValueMember != "")
            {
                var mFieldIndex = mCombo.SelectedValue.ToString();
                ExcludeFieldIndex(mFieldIndex);
            }
        }

        private void ExcludeFieldIndex(string pFieldIndexToExclude)
        {
            foreach (DataGridViewRow mRow in this.dgvStatVarProperties.Rows)
            {
                string mCFieldIndex = mRow.Cells["FieldIndex"].Value.ToString();
                if (mCFieldIndex == pFieldIndexToExclude)
                {
                    var mCell = mRow.Cells["Include"] as DataGridViewCheckBoxCell;
                    mCell.Value = mCell.FalseValue;
                }
            }
        }

        /// <summary>
        /// Handler function for the close window button
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void tsmiCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbStatUnitNameField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFieldsUpdateHandler(sender);
        }

        private void cbStatUnitGroupField_SelectedIndexChanged(object pSender, EventArgs e)
        {
            cbFieldsUpdateHandler(pSender);
        }

        /// <summary>
        /// Determines which of the DataLayoutCBs are to be enabled or not
        /// </summary>
        /// <remarks>
        /// This relies on the order in which the CBs are added to the List of CBs and the number of CBs
        /// presently the function assumes 4 cols followed by 4 rows
        /// </remarks>
        private void SetCellContentTypeComboBoxEnabledState()
        {

            // Set enabled state for columns combos
            for (int i = 2; i >= 0; i--)
            {
                if (Util.GetComboBoxSelectedValueString(CellContentTypeComboBoxes[i]) != CellContentTypes.Values)
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = true;
                }
                else
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = false;
                }
            }

            // Set enabled state for rows combos
            for (int i = 6; i >= 4; i--)
            {
                if (Util.GetComboBoxSelectedValueString(CellContentTypeComboBoxes[i]) != CellContentTypes.Values)
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = true;
                }
                else
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = false;
                }
            }

        }

        private void btnTestParsing_Click(object sender, EventArgs e)
        {
            this.ParseSelectionWithCurrentSettings();

            // Syn loggfliken
            this.tabControl.SelectedTab = tabPageLogOutput;

            // Test om det er fyllt in eigenskapar for statistikkvariablar
            if (this.StatVarProperties == null)
            {
                this.Log("Du må fyrst velje ei rad eller kolonne som inneheld statistikkvariablar");
                return;
            }
            this.Log("Startar test", true);
            foreach (var i in this.ParsedData.Keys)
            {
                foreach (var j in this.ParsedData[i].Keys)
                {
                    var adaptiveValue = this.ParsedData[i][j];
                    if (adaptiveValue != null)
                    {
                        this.Log(adaptiveValue.LogValidate());
                    }
                }
            }
            this.Log("Ferdig med test");
        }

        public void OnCellContenTypeComboBoxChangeCommit(ComboBox pChangedComboBox, DataOrientation pDataOrientation, int pIndex)
        {

            // Get the new value of the changed CB
            var mNewCellContentType = Util.GetComboBoxSelectedValueString(pChangedComboBox);

            // Create a list to store all currently selected CB values
            var mAssignedCellContentTypes = new List<string>();

            // For each of the comboboxes that may contain values
            foreach (ComboBox mComboBox in this.CellContentTypeComboBoxes)
            {
                // Get the current contents of col/row
                var mCellContentType = Util.GetComboBoxSelectedValueString(mComboBox);

                // For all but the current control
                if (mComboBox != pChangedComboBox &&
                    (mCellContentType != CellContentTypes.Values && mCellContentType != CellContentTypes.Ignore))
                {
                    if (mCellContentType == mNewCellContentType ||
                        mAssignedCellContentTypes.Contains(mCellContentType))
                    {
                        mComboBox.SelectedValue = CellContentTypes.Values;
                    }
                    mAssignedCellContentTypes.Add(mCellContentType);
                }
            }

            // Add the new type to the list of used types
            if (!mAssignedCellContentTypes.Contains(mNewCellContentType) &&
                (mNewCellContentType != CellContentTypes.Values && mNewCellContentType != CellContentTypes.Ignore))
            {
                mAssignedCellContentTypes.Add(mNewCellContentType);
            }

            // Based on the new value of the changed CB, do something
            SetStatVarProperties(mNewCellContentType, pIndex, pDataOrientation);

            DebugToFile.Json(mAssignedCellContentTypes);

            // Set conditional visibility of manual statdatum settings
            if (mAssignedCellContentTypes.Contains(CellContentTypes.StatDatum) && mAssignedCellContentTypes.Contains(CellContentTypes.StatVars))
            {
                this.grpStatDatumSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = true;
                this.dgvStatVarProperties.Columns["Year"].Visible = false;
                this.dgvStatVarProperties.Columns["Quarter"].Visible = false;
                this.dgvStatVarProperties.Columns["Month"].Visible = false;
            }
            else if (!mAssignedCellContentTypes.Contains(CellContentTypes.StatDatum) && mAssignedCellContentTypes.Contains(CellContentTypes.StatVars))
            {
                this.grpStatDatumSettings.Enabled = true;
                this.grpAutoDateSettings.Enabled = false;
                this.dgvStatVarProperties.Columns["Year"].Visible = true;
                this.dgvStatVarProperties.Columns["Quarter"].Visible = true;
                this.dgvStatVarProperties.Columns["Month"].Visible = true;
            }
            else
            {
                this.grpStatDatumSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = false;
            }

            // Set conditional visibility of manual stat area settings
            if (!mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDs) && !mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDsAndNames))
            {
                this.grpStatAreaSettings.Enabled = true;
            }
            else if (mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDs) || mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDsAndNames))
            {
                this.grpStatAreaSettings.Enabled = false;
            }
            else
            {
                this.grpStatAreaSettings.Enabled = false;
            }

            // Reset parsed valuesList if no longer present in layout combos
            // Reset statvars
            if (!mAssignedCellContentTypes.Contains(CellContentTypes.StatVars))
            {
                this.StatVarProperties = null;
                this.dgvStatVarProperties.DataSource = null;
                this.dgvStatVarProperties.Refresh();
            }

            // Reset statareaids
            if (!mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDs) &&
                !mAssignedCellContentTypes.Contains(CellContentTypes.StatAreaIDsAndNames))
            {
                this.StatAreaIDsProperties = null;
            }

            // Reset statdatum
            if (!mAssignedCellContentTypes.Contains(CellContentTypes.StatDatum))
            {
                this.StatDatumProperties = null;
            }

            // Rebind statvarprops to grid
            if (this.StatVarProperties != null)
            {
                // Load statvars to manual settings for statvars if not already done
                // or if change in content of perpendicular rows/columns
                if (dgvStatVarProperties.DataSource == null ||
                    mNewCellContentType == CellContentTypes.StatVars ||
                    // mNewCellContentType == CellContentTypes.StatVars2 ||
                    pDataOrientation != this.StatVarProperties.DataOrientation)
                {
                    this.LoadStatVarPropertiesGrid();
                    //tabControl.SelectedTab = tpStatisticsVariables;
                }

                // Parse with current settings
                // TODO: Verify if this causes multiple reloads
                this.ParseSelectionWithCurrentSettings();

            }

            // Determine whether layout comboboxes are supposed to be enabled or not
            this.SetCellContentTypeComboBoxEnabledState();
            return;

        }

        public void SetStatVarProperties(string pCellContentType, int pIndex, DataOrientation pDataOrientation)
        {
            switch (pCellContentType)
            {
                // Load stat variables
                case CellContentTypes.StatVars:
                    this.StatVarProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat dates
                case CellContentTypes.StatDatum:
                    this.StatDatumProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area IDs and names concatenated - note that this takes presedent over other stat area attributes
                case CellContentTypes.StatAreaIDsAndNames:
                    // Create three statvar props,
                    // One for ids and names concatenated
                    StatProps mIDsAndNames = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    // One for idParts alone
                    this.StatAreaIDsProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    // And one areas alone
                    this.StatAreaNameProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);

                    // Loop through the valuesList
                    foreach (int t in mIDsAndNames.Keys)
                    {
                        // Read the concatenated string
                        List<string> mStatAreaIDAndName = mIDsAndNames[t].ToString().Split(' ').ToList<string>();
                        if (mStatAreaIDAndName.Count() >= 1)
                        {
                            string mStatAreaID = mStatAreaIDAndName[0];
                            this.StatAreaIDsProperties[t] = mStatAreaID;

                            if (mStatAreaIDAndName.Count() >= 2)
                            {
                                mStatAreaIDAndName.RemoveAt(0);
                                string mStatAreaName = string.Join(" ", mStatAreaIDAndName);
                                this.StatAreaNameProperties[t] = mStatAreaName;
                            }
                        }
                    }
                    break;
                // Load stat area IDs
                case CellContentTypes.StatAreaIDs:
                    this.StatAreaIDsProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area names
                case CellContentTypes.StatAreaNames:
                    this.StatAreaNameProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area groups
                case CellContentTypes.StatAreaGroups:
                    this.StatAreaGroupProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
            }
            return;
        }

        public void LoadStatVarPropertiesGrid()
        {
            if (this.StatVarProperties != null)
            {
                int mFirstDataCol = 1, mFirstDataRow = 1;

                this.GetRowColOffset(
                    ref mFirstDataRow,
                    ref mFirstDataCol);

                if (this.StatVarProperties2 != null)
                {
                    dgvStatVarProperties.DataSource = this.StatVarProperties.AsDataTable(
                        mFirstDataRow,
                        mFirstDataCol,
                        this.StatVarProperties2);
                }
                else
                {
                    dgvStatVarProperties.DataSource = this.StatVarProperties.AsDataTable(
                        mFirstDataRow,
                        mFirstDataCol);
                }

                dgvStatVarProperties.Refresh();

            }

            return;
        }

        /// <summary>
        /// Parse the selection with the current settings
        /// </summary>
        public void ParseSelectionWithCurrentSettings()
        {
            if (this.StatVarProperties != null)
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
            else
            {
                this.Log("Du må fyrst velje ei rad eller kolonne som inneheld namn på statistikkvariablar");
            }
        }

        #region CellContentTypes ComboBox handlers

        private void cbFirstColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbColCType1, DataOrientation.InColumns, 1);
        }

        private void cbSecondColCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbColCType2, DataOrientation.InColumns, 2);
        }

        private void cbThirdColCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbColCType3, DataOrientation.InColumns, 3);
        }

        private void cbColCType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbColCType4, DataOrientation.InColumns, 4);
        }

        private void cbFirstRowCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbRowCType1, DataOrientation.InRows, 1);
        }

        private void cbSecondRowCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbRowCType2, DataOrientation.InRows, 2);
        }

        private void cbRowCType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbRowCType3, DataOrientation.InRows, 3);
        }

        private void cbRowCType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnCellContenTypeComboBoxChangeCommit(cbRowCType4, DataOrientation.InRows, 4);
        }

        #endregion

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

        private void btnCopyFirstMeasurementUnitToAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            DataGridViewComboBoxCell firstMeasurementUnitCell = null;
            foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            {
                var currentMeasurementUnitCell = currentRow.Cells["unit"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    firstMeasurementUnitCell = currentRow.Cells["unit"] as DataGridViewComboBoxCell;
                }
                else
                {
                    currentMeasurementUnitCell.CopyValueFrom(firstMeasurementUnitCell);
                }
                i++;
            }

            this.ParseSelectionWithCurrentSettings();

        }

        private void btnSetStatAreaInfo_Click(object sender, EventArgs e)
        {
            this.ParseSelectionWithCurrentSettings();
        }

        private void btnCopyStatVarAll_Click(object sender, EventArgs e)
        {
            int i = 1;

            DataGridViewComboBoxCell firstVar1 = null;
            DataGridViewComboBoxCell firstVar2 = null;
            DataGridViewComboBoxCell firstVar3 = null;
            DataGridViewComboBoxCell firstVar4 = null;
            DataGridViewComboBoxCell firstVar5 = null;
            DataGridViewComboBoxCell firstUnit = null;
            DataGridViewComboBoxCell firstTimeUnit = null;
            DataGridViewComboBoxCell firstKretstype = null;

            foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            {
                var currentVar1 = currentRow.Cells["StatVarCol1"] as DataGridViewComboBoxCell;
                var currentVar2 = currentRow.Cells["StatVarCol2"] as DataGridViewComboBoxCell;
                var currentVar3 = currentRow.Cells["StatVarCol3"] as DataGridViewComboBoxCell;
                var currentVar4 = currentRow.Cells["StatVarCol4"] as DataGridViewComboBoxCell;
                var currentVar5 = currentRow.Cells["StatVarCol5"] as DataGridViewComboBoxCell;
                var currentUnit = currentRow.Cells["Unit"] as DataGridViewComboBoxCell;
                var currentTimeUnit = currentRow.Cells["TimeUnit"] as DataGridViewComboBoxCell;
                var currentKretstype = currentRow.Cells["Kretstype"] as DataGridViewComboBoxCell;
                if (i == 1)
                {
                    firstVar1 = currentVar1;
                    firstVar2 = currentVar2;
                    firstVar3 = currentVar3;
                    firstVar4 = currentVar4;
                    firstVar5 = currentVar5;
                    firstUnit = currentUnit;
                    firstTimeUnit = currentTimeUnit;
                    firstKretstype = currentKretstype;

                }
                else
                {
                    currentVar1.CopyValueFrom(firstVar1);
                    currentVar2.CopyValueFrom(firstVar2);
                    currentVar3.CopyValueFrom(firstVar3);
                    currentVar4.CopyValueFrom(firstVar4);
                    currentVar5.CopyValueFrom(firstVar5);
                    currentUnit.CopyValueFrom(firstUnit);
                    currentTimeUnit.CopyValueFrom(firstTimeUnit);
                    currentKretstype.CopyValueFrom(firstKretstype);
                }
                i++;
            }

            this.ParseSelectionWithCurrentSettings();

        }

        private void btnUploadToAdaptive_Click(object sender, EventArgs e)
        {
            var mConfirm = MessageBox.Show("Vil du laste opp tabellen til Adaptive med gjeldande innstillingar?", "Åtvaring", MessageBoxButtons.YesNo);
            if (mConfirm == DialogResult.No) return;
            this.ParseSelectionWithCurrentSettings();

            // Syn loggfliken
            this.tabControl.SelectedTab = tabPageLogOutput;

            // Test om det er fyllt in eigenskapar for statistikkvariablar
            if (this.StatVarProperties == null)
            {
                this.Log("Du må fyrst velje ei rad eller kolonne som inneheld statistikkvariablar");
                return;
            }

            var data = this.ParsedData.AsAdaptiveValuesList();

            if (data != null)
            {
                var output = AdaptiveClient.AddData(data);
                if (output.d.success == true)
                {
                    this.Log("Opplasting vellukka");
                }
                else
                {
                    this.Log("Feil ved opplasting");
                }
            }
            else
            {
                this.Log("Det er feil i dei gjeldande innstillingane. Trykk 'Prøv innstillingar' for å finne ut kva som kan vere gale.");
            }
            this.Log("Ferdig");

        }

        private void btnAddEditVariables_Click(object sender, EventArgs e)
        {
            var frm = new StatVarForm();
            frm.ShowDialog();
        }


    }
}
