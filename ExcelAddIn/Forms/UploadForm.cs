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
using System.Net;
using System.Xml.Serialization;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Shared;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;

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
        public StatProps StatDatumProperties = null;

        /// <summary>
        /// Statistical variable definitions of the data
        /// </summary>
        public StatProps StatVarProperties = null;

        /// <summary>
        /// Statistical variable 2 definitions of the data
        /// </summary>
        public StatProps StatVarProperties2 = null;

        /// <summary>
        /// Statistical area ids for the data
        /// </summary>
        public StatProps StatAreaIDsProperties = null;

        /// <summary>
        /// Statistical area groupings for the data
        /// </summary>
        public StatProps StatAreaGroupProperties = null;

        /// <summary>
        /// Statistical area names for the data
        /// </summary>
        public StatProps StatAreaNameProperties = null;

        /// <summary>
        /// Limit the number of lines to keep in the log before overwriting
        /// </summary>
        public int NumberOfLinesInLog = 400;

        /// <summary>
        /// An array of ComboBox objects that describe the layout of the selected data
        /// </summary>
        public List<ComboBox> CellContentTypeComboBoxes = new List<ComboBox>();

        /// <summary>
        /// The application configuration, read from Adaptive, cached locally
        /// TODO: Add remote storage
        /// </summary>
        public ConfigProvider AdaptiveConf = null;

        /// <summary>
        /// Loaded datasets from Adaptive
        /// TODO: Add remote storage
        /// </summary>
        [Obsolete]
        public AASDatasets AdaptiveDatasets = null;

        /// <summary>
        /// Existing saved states
        /// TODO: Add remote storage
        /// </summary>'
        [Obsolete]
        public UploadFormStates SavedStates = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public UploadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function that is executed when the form is loaded. Setting up data sources of controls, behaviors etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadForm_Load(object sender, EventArgs e)
        {
            DebugToFile.Log("Testing to write this");

            // Set StatVar DataGridView to *NOT* auto-generate columns from datasource
            dgvStatVarProperties.AutoGenerateColumns = false;

            // Set default edit-mode of StatVar DataGridView
            dgvStatVarProperties.EditMode = DataGridViewEditMode.EditOnEnter;

            // Attach event handlers to StatVar DataGridView to permit editing of currentCell values
            dgvStatVarProperties.EditingControlShowing += dgvManualStatVarProps_EditingControlShowing;
            dgvStatVarProperties.CellValidating += dgvManualStatVarProps_CellValidating;

            // Create an object to hold the CellContentType combos (in a specific order)
            CellContentTypeComboBoxes.AddRange(new[] {
                cbColCType1, cbColCType2, cbColCType3, cbColCType4,
                cbRowCType1, cbRowCType2, cbRowCType3, cbRowCType4 });

            // Load Adaptive Configuration from server
            LoadAdaptiveConfig(true);

            // Populate date format combobox for parsing of date-values
            Util.SetComboBoxDS(cbStatDatumFormat, DateFormats.List);

            // Populate and set default selection for CellContentType combos
            foreach (var mComboBox in CellContentTypeComboBoxes)
            {
                var mCellContentTypes = CellContentType.GetComboBoxItems();
                Util.SetComboBoxDS(mComboBox, mCellContentTypes);
                mComboBox.SelectedValue = CellContentType.Values;
            }

            // Set default state of CellContentType combos
            SetCellContentTypeComboBoxEnabledState();

            // Set data source of Preview DataGridView
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
            //Util.SetComboBoxDS(cbSettings.ComboBox, UploadFormStates.GetComboBoxItems());

            //if (mTmp != null)
            //{
            //    cbSettings.ComboBox.Text = mTmp;
            //}
        }

        /// <summary>
        /// Load existing measurement units (presently loaded from config f)
        /// TODO: Connect to web service
        /// </summary>
        public void LoadExistingMeasurementUnits()
        {
            var mColumn = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["enhet"];
            mColumn.AddItemsFromDataTable(ConfigProvider.AsDataTable(this.AdaptiveConf.measurementUnitTypes));
        }

        [Obsolete("No dataset concept in v2")]
        private void PopulateDatasetCategories()
        {
            if (this.AdaptiveDatasets == null) return;

            var mDatasetCategories = new List<ComboBoxItem>();
            mDatasetCategories.Add(new ComboBoxItem("Vel ein kategori...", ""));

            foreach (AASDataset mDataset in this.AdaptiveDatasets)
            {
                mDatasetCategories.Add(new ComboBoxItem(mDataset.maincategory));
            }

            mDatasetCategories = ComboBoxItem.MakeUniqueList(mDatasetCategories);

            Util.SetComboBoxDS(cbDatasetCategory.ComboBox, mDatasetCategories);

            this.cbDatasetCategory.ComboBox.ValueMember = "value";
            this.cbDatasetCategory.ComboBox.DisplayMember = "key";

            this.cbDatasetCategory.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            this.cbDatasetCategory.ComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbDatasetCategory.ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        [Obsolete("No dataset concept in v2")]
        private void PopulateDatasets()
        {
            if (this.AdaptiveDatasets == null) return;

            var mDatasets = new List<ComboBoxItem>();
            mDatasets.Add(new ComboBoxItem("Vel eitt datasett...", ""));
            foreach (AASDataset mDataset in this.AdaptiveDatasets)
            {
                if (mDataset.maincategory == Util.GetComboBoxSelectedValueString(cbDatasetCategory.ComboBox))
                    mDatasets.Add(new ComboBoxItem(mDataset.name, mDataset.id));
            }

            mDatasets = ComboBoxItem.MakeUniqueList(mDatasets);
            Util.SetComboBoxDS(cbDataset.ComboBox, mDatasets);
            this.cbDataset.ComboBox.ValueMember = "value";
            this.cbDataset.ComboBox.DisplayMember = "key";
            this.cbDataset.ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            this.cbDataset.ComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.cbDataset.ComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            // Set default selection
            if (mDatasets.Count() >= 1)
            {
                this.cbDataset.ComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Load existing datasets from server
        /// </summary>
        [Obsolete("No dataset concept in v2")]
        private void LoadExistingDatasets()
        {
            var mUrl = String.Format("{0}/WebServices/administrator/modules/statistics/DataDownload.asmx/DownloadDatasetId", Properties.Settings.Default.adaptiveUri);
            try
            {
                var mWebClient = new WebClient();
                var mByteArray = mWebClient.DownloadData(mUrl);
                var mReader = new MemoryStream(mByteArray);
                var mSerializer = new XmlSerializer(typeof(AASDatasets));
                this.AdaptiveDatasets = (AASDatasets)mSerializer.Deserialize(mReader);
                mReader.Close();
            }
            catch (Exception)
            {
                this.Log("Feil: Kunne ikkje laste eksisterande datasett frå " + mUrl);
            }

        }

        /// <summary>
        /// Read configuration from Adaptive (statistical area types, measurement units, etc)
        /// </summary>
        /// <param name="pUpdateFromWeb">Refresh from server</param>
        private void LoadAdaptiveConfig(bool pUpdateFromWeb = false)
        {

            // Set data source for statistical unit types
            this.AdaptiveConf = WsDataSources.DownloadAdaptiveConfig(pUpdateFromWeb);

            // Download list of existing datasets that can be added to
            //this.LoadSavedUploadFormStates();

            // Download list of existing statistical variables
            this.LoadExistingStatVars2();

            // Set data source for statareatypes
            if (this.AdaptiveConf != null)
            {
                // Load statistical area unit types
                Util.SetComboBoxDS(cbStatUnitType, this.AdaptiveConf.statUnitTypes);

                // Load existing measurement unit values
                this.LoadExistingMeasurementUnits();
            }

        }

        void dgvStatVarProperties_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            // You could also check here to see if the currentCell in question is the combobox
            if (dgvStatVarProperties.IsCurrentCellDirty)
            {
                dgvStatVarProperties.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvManualStatVarProps_CellValidating(object sender,
                DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvStatVarProperties.Columns["StatVarCol1"].Index ||
                e.ColumnIndex == dgvStatVarProperties.Columns["StatVarCol2"].Index ||
                e.ColumnIndex == dgvStatVarProperties.Columns["StatVarCol3"].Index ||
                e.ColumnIndex == dgvStatVarProperties.Columns["StatVarCol4"].Index ||
                e.ColumnIndex == dgvStatVarProperties.Columns["StatVarCol5"].Index ||
                e.ColumnIndex == dgvStatVarProperties.Columns["enhet"].Index)
            {
                DataGridViewComboBoxCell mDGVComboBoxCell = dgvStatVarProperties[e.ColumnIndex, e.RowIndex] as DataGridViewComboBoxCell;
                string mUserEnteredValue = e.FormattedValue.ToString();
                ComboBoxItem mNewItem = ComboBoxItem.GetNewItem(mUserEnteredValue.ToString());
                mDGVComboBoxCell.AddItemIfNotExists(mNewItem);
            }
        }

        /// <summary>
        /// Determine how many rows and cols to offset the selection to get *only* the data cells, omitting any column
        /// or row headers
        /// </summary>
        /// <param name="pFirstDataRow"></param>
        /// <param name="pFirstDataCol"></param>
        public void GetRowColOffset(ref int pFirstDataRow, ref int pFirstDataCol)
        {
            // Increment if row types are set
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType1) != CellContentType.Values) pFirstDataRow = 2;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType2) != CellContentType.Values) pFirstDataRow = 3;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType3) != CellContentType.Values) pFirstDataRow = 4;
            if (Util.GetComboBoxSelectedValueString(this.cbRowCType4) != CellContentType.Values) pFirstDataRow = 5;

            // Increment if column types are set
            if (Util.GetComboBoxSelectedValueString(this.cbColCType1) != CellContentType.Values) pFirstDataCol = 2;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType2) != CellContentType.Values) pFirstDataCol = 3;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType3) != CellContentType.Values) pFirstDataCol = 4;
            if (Util.GetComboBoxSelectedValueString(this.cbColCType4) != CellContentType.Values) pFirstDataCol = 5;

        }

        /// <summary>
        /// Add a log message to the log pane
        /// </summary>
        /// <param name="pMsg">The message to log</param>
        /// <param name="pClear">A boolean flag that determines if the log pane is to be cleared before adding the new info</param>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopyDateToAll_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tpStatisticsVariables;

            foreach (DataGridViewRow mRow in dgvStatVarProperties.Rows)
            {
                mRow.Cells["ar"].Value = tbStatDatumYear.Text;
                var m = mRow.Cells["kvartal"] as DataGridViewComboBoxCell;
                m.Value = cbStatDatumQuarter.Text;
                mRow.Cells["mnd"].Value = tbStatDatumMonth.Text;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void updateConfigFromServer(object sender, EventArgs e)
        {
            LoadAdaptiveConfig(true);
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
                if (Util.GetComboBoxSelectedValueString(CellContentTypeComboBoxes[i]) != CellContentType.Values)
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
                if (Util.GetComboBoxSelectedValueString(CellContentTypeComboBoxes[i]) != CellContentType.Values)
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = true;
                }
                else
                {
                    CellContentTypeComboBoxes[i + 1].Enabled = false;
                }
            }

        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            this.Log("Startar eksport");

            this.ParseSelectionWithCurrentSettings();

            dlgSaveCsvFile.FileName = Util.GetFilenameTemplate("csv");

            if (dlgSaveCsvFile.ShowDialog() == DialogResult.OK)
            {
                Export.WriteCSVFile(this.ParsedData, dlgSaveCsvFile.FileName);
            }

            this.Log("Ferdig med eksport");

            //this.SaveUploadFormState();
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

        public void OnCellContenTypeComboBoxChangeCommit(ComboBox pChangedComboBox, DataOrientation pDataOrientation, int pIndex)
        {

            // Get the new value of the changed CB
            var mNewCellContentType = Util.GetComboBoxSelectedValueString(pChangedComboBox);

            // Create a list to store all currently selected CB values
            var mAssignedCellContentTypes = new List<string>();

            // For each of the comboboxes with data layout info
            foreach (ComboBox mComboBox in this.CellContentTypeComboBoxes)
            {
                // Get the current contents of col/row
                var mCellContentType = Util.GetComboBoxSelectedValueString(mComboBox);

                // For all but the current control
                if (mComboBox != pChangedComboBox &&
                    (mCellContentType != CellContentType.Values && mCellContentType != CellContentType.Ignore))
                {
                    if (mCellContentType == mNewCellContentType ||
                        mAssignedCellContentTypes.Contains(mCellContentType))
                    {
                        mComboBox.SelectedValue = CellContentType.Values;
                    }
                    mAssignedCellContentTypes.Add(mCellContentType);
                }
            }

            // Add the new type to the list of used types
            if (!mAssignedCellContentTypes.Contains(mNewCellContentType) &&
                (mNewCellContentType != CellContentType.Values && mNewCellContentType != CellContentType.Ignore))
            {
                mAssignedCellContentTypes.Add(mNewCellContentType);
            }

            // Based on the new value of the changed CB, do something
            SetStatVarProperties(mNewCellContentType, pIndex, pDataOrientation);

            // Set conditional visibility of manual statdatum settings
            if (mAssignedCellContentTypes.Contains(CellContentType.StatDatum) && mAssignedCellContentTypes.Contains(CellContentType.StatVars))
            {
                this.grpStatDatumSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = true;
                this.dgvStatVarProperties.Columns["ar"].Visible = false;
                this.dgvStatVarProperties.Columns["kvartal"].Visible = false;
                this.dgvStatVarProperties.Columns["mnd"].Visible = false;
                this.dgvStatVarProperties.Columns["Day"].Visible = false;
            }
            else if (!mAssignedCellContentTypes.Contains(CellContentType.StatDatum) && mAssignedCellContentTypes.Contains(CellContentType.StatVars))
            {
                this.grpStatDatumSettings.Enabled = true;
                this.grpAutoDateSettings.Enabled = false;
                this.dgvStatVarProperties.Columns["ar"].Visible = true;
                this.dgvStatVarProperties.Columns["kvartal"].Visible = true;
                this.dgvStatVarProperties.Columns["mnd"].Visible = true;
                this.dgvStatVarProperties.Columns["Day"].Visible = true;
            }
            else
            {
                this.grpStatDatumSettings.Enabled = false;
                this.grpAutoDateSettings.Enabled = false;
            }

            // Set conditional visibility of manual stat area settings
            if (!mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDs) && !mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDsAndNames))
            {
                this.grpStatAreaSettings.Enabled = true;
            }
            else if (mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDs) || mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDsAndNames))
            {
                this.grpStatAreaSettings.Enabled = false;
            }
            else
            {
                this.grpStatAreaSettings.Enabled = false;
            }

            // Reset parsed values if no longer present in layout combos
            // Reset statvars
            if (!mAssignedCellContentTypes.Contains(CellContentType.StatVars))
            {
                this.StatVarProperties = null;
                this.dgvStatVarProperties.DataSource = null;
                this.dgvStatVarProperties.Refresh();
            }

            // Reset statareaids
            if (!mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDs) &&
                !mAssignedCellContentTypes.Contains(CellContentType.StatAreaIDsAndNames))
            {
                this.StatAreaIDsProperties = null;
            }

            // Reset statdatum
            if (!mAssignedCellContentTypes.Contains(CellContentType.StatDatum))
            {
                this.StatDatumProperties = null;
            }

            // Rebind statvarprops to grid
            if (this.StatVarProperties != null)
            {
                // Load statvars to manual settings for statvars if not already done
                // or if change in content of perpendicular rows/columns
                if (dgvStatVarProperties.DataSource == null ||
                    mNewCellContentType == CellContentType.StatVars ||
                    mNewCellContentType == CellContentType.StatVars2 ||
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
                case CellContentType.StatVars:
                    this.StatVarProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat dates
                case CellContentType.StatVars2:
                    this.StatVarProperties2 = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat dates
                case CellContentType.StatDatum:
                    this.StatDatumProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area IDs and names concatenated - note that this takes presedent over other stat area attributes
                case CellContentType.StatAreaIDsAndNames:
                    // Create three statvar props,
                    // One for ids and names concatenated
                    StatProps mIDsAndNames = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    // One for ids alone
                    this.StatAreaIDsProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    // And one areas alone
                    this.StatAreaNameProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);

                    // Loop through the values
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
                case CellContentType.StatAreaIDs:
                    this.StatAreaIDsProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area names
                case CellContentType.StatAreaNames:
                    this.StatAreaNameProperties = Table.GetIndex(this.SelectedRange.Cells.Value, pIndex, pDataOrientation);
                    break;
                // Load stat area groups
                case CellContentType.StatAreaGroups:
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

                // Add logic to rebind columns here
                this.LoadExistingMeasurementUnits();
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
        }

        #region CellContentType ComboBox handlers

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


        private void btnCopyFirstRowAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            string mYear = "", mQuarter = "", mMonth = "", mDay = "", mMeasurementUnit = "",
                mStatVar1 = "", mStatVar2 = "", mStatVar3 = "", mStatVar4 = "", mStatVar5 = "";

            foreach (DataGridViewRow mRow in dgvStatVarProperties.Rows)
            {
                var mQuarterCell = mRow.Cells["kvartal"] as DataGridViewComboBoxCell;
                var mStatVarCell1 = mRow.Cells["StatVarCol1"] as DataGridViewComboBoxCell;
                var mStatVarCell2 = mRow.Cells["StatVarCol2"] as DataGridViewComboBoxCell;
                var mStatVarCell3 = mRow.Cells["StatVarCol3"] as DataGridViewComboBoxCell;
                var mStatVarCell4 = mRow.Cells["StatVarCol4"] as DataGridViewComboBoxCell;
                var mStatVarCell5 = mRow.Cells["StatVarCol5"] as DataGridViewComboBoxCell;
                var mMeasurementUnitCell = mRow.Cells["enhet"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    mYear = Table.GetNullOrString(mRow.Cells["ar"].Value);
                    mQuarter = Table.GetNullOrString(mQuarterCell.Value);
                    mMonth = Table.GetNullOrString(mRow.Cells["mnd"].Value);
                    mDay = Table.GetNullOrString(mRow.Cells["Day"].Value);
                    mStatVar1 = Table.GetNullOrString(mStatVarCell1.Value);
                    mStatVar2 = Table.GetNullOrString(mStatVarCell2.Value);
                    mStatVar3 = Table.GetNullOrString(mStatVarCell3.Value);
                    mStatVar4 = Table.GetNullOrString(mStatVarCell4.Value);
                    mStatVar5 = Table.GetNullOrString(mStatVarCell5.Value);
                    mMeasurementUnit = Table.GetNullOrString(mMeasurementUnitCell.Value);
                }
                else
                {
                    mRow.Cells["ar"].Value = mYear;
                    mQuarterCell.Value = mQuarter;
                    mRow.Cells["mnd"].Value = mMonth;
                    mRow.Cells["Day"].Value = mDay;

                    mStatVarCell1.Value = mStatVar1;
                    mStatVarCell2.Value = mStatVar2;
                    mStatVarCell3.Value = mStatVar3;
                    mStatVarCell4.Value = mStatVar4;
                    mStatVarCell5.Value = mStatVar5;

                    mMeasurementUnitCell.Value = mMeasurementUnit;
                }
                i++;
            }

            this.ParseSelectionWithCurrentSettings();

        }

        private void btnCopyFirstMeasurementUnitToAll_Click(object sender, EventArgs e)
        {
            int i = 1;
            DataGridViewComboBoxCell firstMeasurementUnitCell = null;
            foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            {
                var currentMeasurementUnitCell = currentRow.Cells["enhet"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    firstMeasurementUnitCell = currentRow.Cells["enhet"] as DataGridViewComboBoxCell;
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

            foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            {
                var currentVar1 = currentRow.Cells["StatVarCol1"] as DataGridViewComboBoxCell;
                var currentVar2 = currentRow.Cells["StatVarCol2"] as DataGridViewComboBoxCell;
                var currentVar3 = currentRow.Cells["StatVarCol3"] as DataGridViewComboBoxCell;
                var currentVar4 = currentRow.Cells["StatVarCol4"] as DataGridViewComboBoxCell;
                var currentVar5 = currentRow.Cells["StatVarCol5"] as DataGridViewComboBoxCell;

                if (i == 1)
                {
                    firstVar1 = currentVar1;
                    firstVar2 = currentVar2;
                    firstVar3 = currentVar3;
                    firstVar4 = currentVar4;
                    firstVar5 = currentVar5;
                }
                else
                {
                    currentVar1.CopyValueFrom(firstVar1);
                    currentVar2.CopyValueFrom(firstVar2);
                    currentVar3.CopyValueFrom(firstVar3);
                    currentVar4.CopyValueFrom(firstVar4);
                    currentVar5.CopyValueFrom(firstVar5);
                }
                i++;
            }

            this.ParseSelectionWithCurrentSettings();

        }

        //private void btnSaveSettings_Click(object sender, EventArgs e)
        //{
        //    //this.SaveUploadFormState(true);
        //}

        [Obsolete("No saving of form states from now on")]
        private void SaveUploadFormState(bool pConfirmOverwrite = false)
        {
            if (Util.GetComboBoxSelectedValueString(cbDataset.ComboBox) != "")
            {
                var mUploadFormStates = UploadFormStates.Load();
                var mUploadFormState = UploadFormState.RecordState(this);
                mUploadFormStates.AddState(Util.GetComboBoxSelectedValueString(cbDataset.ComboBox), cbDataset.ComboBox.Text, mUploadFormState, pConfirmOverwrite);
                this.LoadSavedUploadFormStates();
            }
            else
            {
                this.Log("Du må velje eitt datasett for å kunne lagre oppsett.");
            }
        }

        private void btnUploadToAdaptive_Click(object sender, EventArgs e)
        {
            var mConfirm = MessageBox.Show("Vil du laste opp tabellen til Adaptive med gjeldande innstillingar?", "Åtvaring", MessageBoxButtons.YesNo);
            if (mConfirm == DialogResult.No) return;

            //ComboBoxItem mDataset = cbDataset.SelectedItem as ComboBoxItem;

            //if (mDataset == null)
            //{
            //    this.Log("Merknad: Det er ikkje valt noko datasett å laste opp til");
            //    return;
            //}

            try
            {
                tabControl.SelectedTab = tabPageLogOutput;
                Log("Byrjar opplasting...");

                var mCsvFileName = Path.GetTempFileName();
                if (Export.WriteCSVFile(this.ParsedData, mCsvFileName))
                {
                    var mJSON = RequestHelper.PostMultipart(
                        String.Format("{0}/Webservices/administrator/modules/statistics/DataTableUpload.ashx", Properties.Settings.Default.adaptiveUri),
                        new Dictionary<string, object>() {
        //{ "dataset_id", mDataset.value },   
        //{ "deleteOldData", "false" },
        { "f", new FormFile() { Name = "statistikk.csv", ContentType = "application/octet-stream", FilePath = mCsvFileName } },
    });
                    var mRes = WSRetVal.ParseJSON(mJSON);
                    if (mRes.success == "true")
                    {
                        this.Log("Opplasting ferdig");
                    }
                    else
                    {
                        this.Log("Opplastinga misslukkast");
                    }
                }

                //this.SaveUploadFormState();

            }
            catch (System.Net.WebException ex)
            {
                this.Log("Feil: Noko gjekk gale og det sv ikkje mogleg å laste opp tabellen (" + ex.Message + ")");
                tabControl.SelectedTab = tabPageLogOutput;
            }

        }

        private void RestoreSettingsForDataset()
        {
            var mSelectedSetting = cbDataset.ComboBox.SelectedValue;
            if (mSelectedSetting != null)
            {
                UploadFormState mState = UploadFormStates.GetState(mSelectedSetting.ToString());
                if (mState != null)
                {
                    UploadFormState.RestoreState(this, mState);
                }
            }
        }

        private void btnRestoreSettings_Click(object sender, EventArgs e)
        {
            this.RestoreSettingsForDataset();
        }

        private void btnDeleteSettings_Click(object sender, EventArgs e)
        {
            //sv mSelectedSetting = cbSettings.ComboBox.SelectedValue;
            //if (mSelectedSetting != null)
            //{
            //sv mConfirm = MessageBox.Show("Er du sikker på at du vil slette importoppsettet: " + cbSettings.ComboBox.Text + "?", "Åtvaring", MessageBoxButtons.YesNo);
            //if (mConfirm == DialogResult.No) return;

            //UploadFormStates.RemoveState(mSelectedSetting.ToString());
            //}
            //this.LoadSavedUploadFormStates();
        }

        //private void cbDatasetCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.PopulateDatasets();
        //}

        //private void cbDataset_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.RestoreSettingsForDataset();
        //}


        private void tsBtnTest_Click(object sender, EventArgs e)
        {
        }

        private void btnAddEditVariables_Click(object sender, EventArgs e)
        {
            var frm = new StatVarForm();
            frm.ShowDialog();
        }

    }
}
