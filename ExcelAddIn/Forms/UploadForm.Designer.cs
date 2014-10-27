namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    partial class UploadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param pVariable="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.tbStatDatumDay = new System.Windows.Forms.TextBox();
            this.tbStatDatumMonth = new System.Windows.Forms.TextBox();
            this.tbStatDatumYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblQuarter = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbStatDatumQuarter = new System.Windows.Forms.ComboBox();
            this.grpStatDatumSettings = new System.Windows.Forms.GroupBox();
            this.btnCopyDateToAll = new System.Windows.Forms.Button();
            this.lblStatAreaType = new System.Windows.Forms.Label();
            this.cbStatUnitType = new System.Windows.Forms.ComboBox();
            this.grpAutoDateSettings = new System.Windows.Forms.GroupBox();
            this.cbStatDatumFormat = new System.Windows.Forms.ComboBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopFill = new System.Windows.Forms.Panel();
            this.grpStatAreaSettings = new System.Windows.Forms.GroupBox();
            this.btnSetStatAreaInfo = new System.Windows.Forms.Button();
            this.tbStatUnitGroup = new System.Windows.Forms.TextBox();
            this.tbStatUnitName = new System.Windows.Forms.TextBox();
            this.tbStatUnitID = new System.Windows.Forms.TextBox();
            this.lblStatAreaGroup = new System.Windows.Forms.Label();
            this.lblStatAreaName = new System.Windows.Forms.Label();
            this.lblStatAreaId = new System.Windows.Forms.Label();
            this.grpCellContentTypeSettings = new System.Windows.Forms.GroupBox();
            this.lblStatVarRow4 = new System.Windows.Forms.Label();
            this.lblStatVarCol4 = new System.Windows.Forms.Label();
            this.cbRowCType4 = new System.Windows.Forms.ComboBox();
            this.cbColCType4 = new System.Windows.Forms.ComboBox();
            this.lblStatVarCol3 = new System.Windows.Forms.Label();
            this.cbColCType3 = new System.Windows.Forms.ComboBox();
            this.lblStatVarCol2 = new System.Windows.Forms.Label();
            this.cbColCType2 = new System.Windows.Forms.ComboBox();
            this.cbRowCType3 = new System.Windows.Forms.ComboBox();
            this.lblStatVarRow3 = new System.Windows.Forms.Label();
            this.cbRowCType2 = new System.Windows.Forms.ComboBox();
            this.lblStatVarRow2 = new System.Windows.Forms.Label();
            this.cbRowCType1 = new System.Windows.Forms.ComboBox();
            this.lblStatVarRow1 = new System.Windows.Forms.Label();
            this.lblStatVarCol1 = new System.Windows.Forms.Label();
            this.cbColCType1 = new System.Windows.Forms.ComboBox();
            this.topToolBar = new System.Windows.Forms.ToolStrip();
            this.btnValidate = new System.Windows.Forms.ToolStripButton();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDataset = new System.Windows.Forms.ToolStripLabel();
            this.cbDatasetCategory = new System.Windows.Forms.ToolStripComboBox();
            this.cbDataset = new System.Windows.Forms.ToolStripComboBox();
            this.btnSaveSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAsCSV = new System.Windows.Forms.ToolStripButton();
            this.btnUpload = new System.Windows.Forms.ToolStripButton();
            this.panelTopTopMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReloadAdaptiveConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemShowDocumentation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFill = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpPreviewSelection = new System.Windows.Forms.TabPage();
            this.dgvPreviewSelection = new System.Windows.Forms.DataGridView();
            this.tpStatisticsVariables = new System.Windows.Forms.TabPage();
            this.dgvStatVarProperties = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatVarCol1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StatVarCol2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StatVarCol3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StatVarCol4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StatVarCol5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MeasurementUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quarter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsStatVarPropertiesDGV = new System.Windows.Forms.ToolStrip();
            this.btnCopyStatVarAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyMeasurementUnitToAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopyTitleToStatVarColN = new System.Windows.Forms.ToolStripButton();
            this.cbSelectedStatVarCol = new System.Windows.Forms.ToolStripComboBox();
            this.tabPageLogOutput = new System.Windows.Forms.TabPage();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.ssStatusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dlgSaveCsvFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.grpStatDatumSettings.SuspendLayout();
            this.grpAutoDateSettings.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopFill.SuspendLayout();
            this.grpStatAreaSettings.SuspendLayout();
            this.grpCellContentTypeSettings.SuspendLayout();
            this.topToolBar.SuspendLayout();
            this.panelTopTopMenu.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpPreviewSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewSelection)).BeginInit();
            this.tpStatisticsVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatVarProperties)).BeginInit();
            this.tsStatVarPropertiesDGV.SuspendLayout();
            this.tabPageLogOutput.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.ssStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbStatDatumDay
            // 
            this.tbStatDatumDay.Location = new System.Drawing.Point(63, 101);
            this.tbStatDatumDay.Name = "tbStatDatumDay";
            this.tbStatDatumDay.Size = new System.Drawing.Size(195, 20);
            this.tbStatDatumDay.TabIndex = 3;
            // 
            // tbStatDatumMonth
            // 
            this.tbStatDatumMonth.Location = new System.Drawing.Point(63, 75);
            this.tbStatDatumMonth.Name = "tbStatDatumMonth";
            this.tbStatDatumMonth.Size = new System.Drawing.Size(195, 20);
            this.tbStatDatumMonth.TabIndex = 2;
            // 
            // tbStatDatumYear
            // 
            this.tbStatDatumYear.Location = new System.Drawing.Point(63, 23);
            this.tbStatDatumYear.Name = "tbStatDatumYear";
            this.tbStatDatumYear.Size = new System.Drawing.Size(195, 20);
            this.tbStatDatumYear.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(11, 26);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(17, 13);
            this.lblYear.TabIndex = 13;
            this.lblYear.Text = "År";
            // 
            // lblQuarter
            // 
            this.lblQuarter.AutoSize = true;
            this.lblQuarter.Location = new System.Drawing.Point(11, 52);
            this.lblQuarter.Name = "lblQuarter";
            this.lblQuarter.Size = new System.Drawing.Size(40, 13);
            this.lblQuarter.TabIndex = 14;
            this.lblQuarter.Text = "Kvartal";
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(11, 78);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(40, 13);
            this.lblMonth.TabIndex = 14;
            this.lblMonth.Text = "Månad";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(11, 104);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(27, 13);
            this.lblDay.TabIndex = 14;
            this.lblDay.Text = "Dag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            // 
            // cbStatDatumQuarter
            // 
            this.cbStatDatumQuarter.FormattingEnabled = true;
            this.cbStatDatumQuarter.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.cbStatDatumQuarter.Location = new System.Drawing.Point(63, 49);
            this.cbStatDatumQuarter.Name = "cbStatDatumQuarter";
            this.cbStatDatumQuarter.Size = new System.Drawing.Size(195, 21);
            this.cbStatDatumQuarter.TabIndex = 1;
            // 
            // grpStatDatumSettings
            // 
            this.grpStatDatumSettings.Controls.Add(this.cbStatDatumQuarter);
            this.grpStatDatumSettings.Controls.Add(this.tbStatDatumYear);
            this.grpStatDatumSettings.Controls.Add(this.tbStatDatumMonth);
            this.grpStatDatumSettings.Controls.Add(this.tbStatDatumDay);
            this.grpStatDatumSettings.Controls.Add(this.label5);
            this.grpStatDatumSettings.Controls.Add(this.lblDay);
            this.grpStatDatumSettings.Controls.Add(this.btnCopyDateToAll);
            this.grpStatDatumSettings.Controls.Add(this.lblMonth);
            this.grpStatDatumSettings.Controls.Add(this.lblQuarter);
            this.grpStatDatumSettings.Controls.Add(this.lblYear);
            this.grpStatDatumSettings.Enabled = false;
            this.grpStatDatumSettings.Location = new System.Drawing.Point(338, 84);
            this.grpStatDatumSettings.Name = "grpStatDatumSettings";
            this.grpStatDatumSettings.Size = new System.Drawing.Size(264, 161);
            this.grpStatDatumSettings.TabIndex = 12;
            this.grpStatDatumSettings.TabStop = false;
            this.grpStatDatumSettings.Text = "Manuell datering";
            // 
            // btnCopyDateToAll
            // 
            this.btnCopyDateToAll.Location = new System.Drawing.Point(14, 127);
            this.btnCopyDateToAll.Name = "btnCopyDateToAll";
            this.btnCopyDateToAll.Size = new System.Drawing.Size(244, 23);
            this.btnCopyDateToAll.TabIndex = 4;
            this.btnCopyDateToAll.Text = "Kopier til alle statistikkvariablar";
            this.btnCopyDateToAll.UseVisualStyleBackColor = true;
            this.btnCopyDateToAll.Click += new System.EventHandler(this.btnCopyDateToAll_Click);
            // 
            // lblStatAreaType
            // 
            this.lblStatAreaType.AutoSize = true;
            this.lblStatAreaType.Location = new System.Drawing.Point(13, 23);
            this.lblStatAreaType.Name = "lblStatAreaType";
            this.lblStatAreaType.Size = new System.Drawing.Size(56, 13);
            this.lblStatAreaType.TabIndex = 17;
            this.lblStatAreaType.Text = "Type krins";
            // 
            // cbStatUnitType
            // 
            this.cbStatUnitType.FormattingEnabled = true;
            this.cbStatUnitType.Location = new System.Drawing.Point(92, 20);
            this.cbStatUnitType.Name = "cbStatUnitType";
            this.cbStatUnitType.Size = new System.Drawing.Size(168, 21);
            this.cbStatUnitType.TabIndex = 0;
            // 
            // grpAutoDateSettings
            // 
            this.grpAutoDateSettings.Controls.Add(this.cbStatDatumFormat);
            this.grpAutoDateSettings.Enabled = false;
            this.grpAutoDateSettings.Location = new System.Drawing.Point(338, 9);
            this.grpAutoDateSettings.Name = "grpAutoDateSettings";
            this.grpAutoDateSettings.Size = new System.Drawing.Size(264, 62);
            this.grpAutoDateSettings.TabIndex = 20;
            this.grpAutoDateSettings.TabStop = false;
            this.grpAutoDateSettings.Text = "Datoformat for autodatering";
            // 
            // cbStatDatumFormat
            // 
            this.cbStatDatumFormat.FormattingEnabled = true;
            this.cbStatDatumFormat.Location = new System.Drawing.Point(14, 20);
            this.cbStatDatumFormat.Name = "cbStatDatumFormat";
            this.cbStatDatumFormat.Size = new System.Drawing.Size(244, 21);
            this.cbStatDatumFormat.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopFill);
            this.panelTop.Controls.Add(this.topToolBar);
            this.panelTop.Controls.Add(this.panelTopTopMenu);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(886, 313);
            this.panelTop.TabIndex = 22;
            // 
            // panelTopFill
            // 
            this.panelTopFill.Controls.Add(this.grpStatAreaSettings);
            this.panelTopFill.Controls.Add(this.grpStatDatumSettings);
            this.panelTopFill.Controls.Add(this.grpAutoDateSettings);
            this.panelTopFill.Controls.Add(this.grpCellContentTypeSettings);
            this.panelTopFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopFill.Location = new System.Drawing.Point(0, 57);
            this.panelTopFill.Name = "panelTopFill";
            this.panelTopFill.Size = new System.Drawing.Size(886, 256);
            this.panelTopFill.TabIndex = 23;
            // 
            // grpStatAreaSettings
            // 
            this.grpStatAreaSettings.Controls.Add(this.btnSetStatAreaInfo);
            this.grpStatAreaSettings.Controls.Add(this.tbStatUnitGroup);
            this.grpStatAreaSettings.Controls.Add(this.tbStatUnitName);
            this.grpStatAreaSettings.Controls.Add(this.tbStatUnitID);
            this.grpStatAreaSettings.Controls.Add(this.lblStatAreaGroup);
            this.grpStatAreaSettings.Controls.Add(this.lblStatAreaName);
            this.grpStatAreaSettings.Controls.Add(this.lblStatAreaId);
            this.grpStatAreaSettings.Controls.Add(this.lblStatAreaType);
            this.grpStatAreaSettings.Controls.Add(this.cbStatUnitType);
            this.grpStatAreaSettings.Enabled = false;
            this.grpStatAreaSettings.Location = new System.Drawing.Point(608, 9);
            this.grpStatAreaSettings.Name = "grpStatAreaSettings";
            this.grpStatAreaSettings.Size = new System.Drawing.Size(266, 236);
            this.grpStatAreaSettings.TabIndex = 25;
            this.grpStatAreaSettings.TabStop = false;
            this.grpStatAreaSettings.Text = "Manuell stadfesting";
            // 
            // btnSetStatAreaInfo
            // 
            this.btnSetStatAreaInfo.Location = new System.Drawing.Point(16, 127);
            this.btnSetStatAreaInfo.Name = "btnSetStatAreaInfo";
            this.btnSetStatAreaInfo.Size = new System.Drawing.Size(244, 23);
            this.btnSetStatAreaInfo.TabIndex = 4;
            this.btnSetStatAreaInfo.Text = "Bestem stadfesting";
            this.btnSetStatAreaInfo.UseVisualStyleBackColor = true;
            this.btnSetStatAreaInfo.Click += new System.EventHandler(this.btnSetStatAreaInfo_Click);
            // 
            // tbStatUnitGroup
            // 
            this.tbStatUnitGroup.Location = new System.Drawing.Point(92, 99);
            this.tbStatUnitGroup.Name = "tbStatUnitGroup";
            this.tbStatUnitGroup.Size = new System.Drawing.Size(168, 20);
            this.tbStatUnitGroup.TabIndex = 3;
            // 
            // tbStatUnitName
            // 
            this.tbStatUnitName.Location = new System.Drawing.Point(92, 72);
            this.tbStatUnitName.Name = "tbStatUnitName";
            this.tbStatUnitName.Size = new System.Drawing.Size(168, 20);
            this.tbStatUnitName.TabIndex = 2;
            // 
            // tbStatUnitID
            // 
            this.tbStatUnitID.Location = new System.Drawing.Point(92, 46);
            this.tbStatUnitID.Name = "tbStatUnitID";
            this.tbStatUnitID.Size = new System.Drawing.Size(168, 20);
            this.tbStatUnitID.TabIndex = 1;
            // 
            // lblStatAreaGroup
            // 
            this.lblStatAreaGroup.AutoSize = true;
            this.lblStatAreaGroup.Location = new System.Drawing.Point(13, 102);
            this.lblStatAreaGroup.Name = "lblStatAreaGroup";
            this.lblStatAreaGroup.Size = new System.Drawing.Size(76, 13);
            this.lblStatAreaGroup.TabIndex = 17;
            this.lblStatAreaGroup.Text = "Gruppe/region";
            // 
            // lblStatAreaName
            // 
            this.lblStatAreaName.AutoSize = true;
            this.lblStatAreaName.Location = new System.Drawing.Point(13, 75);
            this.lblStatAreaName.Name = "lblStatAreaName";
            this.lblStatAreaName.Size = new System.Drawing.Size(56, 13);
            this.lblStatAreaName.TabIndex = 17;
            this.lblStatAreaName.Text = "Krinsnamn";
            // 
            // lblStatAreaId
            // 
            this.lblStatAreaId.AutoSize = true;
            this.lblStatAreaId.Location = new System.Drawing.Point(13, 49);
            this.lblStatAreaId.Name = "lblStatAreaId";
            this.lblStatAreaId.Size = new System.Drawing.Size(44, 13);
            this.lblStatAreaId.TabIndex = 17;
            this.lblStatAreaId.Text = "Krins ID";
            // 
            // grpCellContentTypeSettings
            // 
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarRow4);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarCol4);
            this.grpCellContentTypeSettings.Controls.Add(this.cbRowCType4);
            this.grpCellContentTypeSettings.Controls.Add(this.cbColCType4);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarCol3);
            this.grpCellContentTypeSettings.Controls.Add(this.cbColCType3);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarCol2);
            this.grpCellContentTypeSettings.Controls.Add(this.cbColCType2);
            this.grpCellContentTypeSettings.Controls.Add(this.cbRowCType3);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarRow3);
            this.grpCellContentTypeSettings.Controls.Add(this.cbRowCType2);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarRow2);
            this.grpCellContentTypeSettings.Controls.Add(this.cbRowCType1);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarRow1);
            this.grpCellContentTypeSettings.Controls.Add(this.lblStatVarCol1);
            this.grpCellContentTypeSettings.Controls.Add(this.cbColCType1);
            this.grpCellContentTypeSettings.Location = new System.Drawing.Point(12, 9);
            this.grpCellContentTypeSettings.Name = "grpCellContentTypeSettings";
            this.grpCellContentTypeSettings.Size = new System.Drawing.Size(320, 236);
            this.grpCellContentTypeSettings.TabIndex = 24;
            this.grpCellContentTypeSettings.TabStop = false;
            this.grpCellContentTypeSettings.Text = "Korleis data er organiserte";
            // 
            // lblStatVarRow4
            // 
            this.lblStatVarRow4.AutoSize = true;
            this.lblStatVarRow4.Location = new System.Drawing.Point(10, 205);
            this.lblStatVarRow4.Name = "lblStatVarRow4";
            this.lblStatVarRow4.Size = new System.Drawing.Size(94, 13);
            this.lblStatVarRow4.TabIndex = 10;
            this.lblStatVarRow4.Text = "Innhald i fjerde rad";
            // 
            // lblStatVarCol4
            // 
            this.lblStatVarCol4.AutoSize = true;
            this.lblStatVarCol4.Location = new System.Drawing.Point(10, 101);
            this.lblStatVarCol4.Name = "lblStatVarCol4";
            this.lblStatVarCol4.Size = new System.Drawing.Size(117, 13);
            this.lblStatVarCol4.TabIndex = 9;
            this.lblStatVarCol4.Text = "Innhald i fjerde kolonne";
            // 
            // cbRowCType4
            // 
            this.cbRowCType4.FormattingEnabled = true;
            this.cbRowCType4.Location = new System.Drawing.Point(133, 202);
            this.cbRowCType4.Name = "cbRowCType4";
            this.cbRowCType4.Size = new System.Drawing.Size(172, 21);
            this.cbRowCType4.TabIndex = 7;
            this.cbRowCType4.SelectionChangeCommitted += new System.EventHandler(this.cbRowCType4_SelectedIndexChanged);
            // 
            // cbColCType4
            // 
            this.cbColCType4.FormattingEnabled = true;
            this.cbColCType4.Location = new System.Drawing.Point(133, 98);
            this.cbColCType4.Name = "cbColCType4";
            this.cbColCType4.Size = new System.Drawing.Size(172, 21);
            this.cbColCType4.TabIndex = 3;
            this.cbColCType4.SelectionChangeCommitted += new System.EventHandler(this.cbColCType4_SelectedIndexChanged);
            // 
            // lblStatVarCol3
            // 
            this.lblStatVarCol3.AutoSize = true;
            this.lblStatVarCol3.Location = new System.Drawing.Point(9, 75);
            this.lblStatVarCol3.Name = "lblStatVarCol3";
            this.lblStatVarCol3.Size = new System.Drawing.Size(117, 13);
            this.lblStatVarCol3.TabIndex = 5;
            this.lblStatVarCol3.Text = "Innhald i tredje kolonne";
            // 
            // cbColCType3
            // 
            this.cbColCType3.FormattingEnabled = true;
            this.cbColCType3.Location = new System.Drawing.Point(133, 72);
            this.cbColCType3.Name = "cbColCType3";
            this.cbColCType3.Size = new System.Drawing.Size(172, 21);
            this.cbColCType3.TabIndex = 2;
            this.cbColCType3.SelectionChangeCommitted += new System.EventHandler(this.cbThirdColCType_SelectedIndexChanged);
            // 
            // lblStatVarCol2
            // 
            this.lblStatVarCol2.AutoSize = true;
            this.lblStatVarCol2.Location = new System.Drawing.Point(9, 49);
            this.lblStatVarCol2.Name = "lblStatVarCol2";
            this.lblStatVarCol2.Size = new System.Drawing.Size(118, 13);
            this.lblStatVarCol2.TabIndex = 3;
            this.lblStatVarCol2.Text = "Innhald i andre kolonne";
            // 
            // cbColCType2
            // 
            this.cbColCType2.FormattingEnabled = true;
            this.cbColCType2.Location = new System.Drawing.Point(133, 46);
            this.cbColCType2.Name = "cbColCType2";
            this.cbColCType2.Size = new System.Drawing.Size(172, 21);
            this.cbColCType2.TabIndex = 1;
            this.cbColCType2.SelectionChangeCommitted += new System.EventHandler(this.cbSecondColCType_SelectedIndexChanged);
            // 
            // cbRowCType3
            // 
            this.cbRowCType3.FormattingEnabled = true;
            this.cbRowCType3.Location = new System.Drawing.Point(133, 176);
            this.cbRowCType3.Name = "cbRowCType3";
            this.cbRowCType3.Size = new System.Drawing.Size(172, 21);
            this.cbRowCType3.TabIndex = 6;
            this.cbRowCType3.SelectionChangeCommitted += new System.EventHandler(this.cbRowCType3_SelectedIndexChanged);
            // 
            // lblStatVarRow3
            // 
            this.lblStatVarRow3.AutoSize = true;
            this.lblStatVarRow3.Location = new System.Drawing.Point(9, 179);
            this.lblStatVarRow3.Name = "lblStatVarRow3";
            this.lblStatVarRow3.Size = new System.Drawing.Size(94, 13);
            this.lblStatVarRow3.TabIndex = 0;
            this.lblStatVarRow3.Text = "Innhald i tredje rad";
            // 
            // cbRowCType2
            // 
            this.cbRowCType2.FormattingEnabled = true;
            this.cbRowCType2.Location = new System.Drawing.Point(133, 150);
            this.cbRowCType2.Name = "cbRowCType2";
            this.cbRowCType2.Size = new System.Drawing.Size(172, 21);
            this.cbRowCType2.TabIndex = 5;
            this.cbRowCType2.SelectionChangeCommitted += new System.EventHandler(this.cbSecondRowCType_SelectedIndexChanged);
            // 
            // lblStatVarRow2
            // 
            this.lblStatVarRow2.AutoSize = true;
            this.lblStatVarRow2.Location = new System.Drawing.Point(9, 153);
            this.lblStatVarRow2.Name = "lblStatVarRow2";
            this.lblStatVarRow2.Size = new System.Drawing.Size(95, 13);
            this.lblStatVarRow2.TabIndex = 0;
            this.lblStatVarRow2.Text = "Innhald i andre rad";
            // 
            // cbRowCType1
            // 
            this.cbRowCType1.FormattingEnabled = true;
            this.cbRowCType1.Location = new System.Drawing.Point(133, 124);
            this.cbRowCType1.Name = "cbRowCType1";
            this.cbRowCType1.Size = new System.Drawing.Size(172, 21);
            this.cbRowCType1.TabIndex = 4;
            this.cbRowCType1.SelectionChangeCommitted += new System.EventHandler(this.cbFirstRowCType_SelectedIndexChanged);
            // 
            // lblStatVarRow1
            // 
            this.lblStatVarRow1.AutoSize = true;
            this.lblStatVarRow1.Location = new System.Drawing.Point(9, 127);
            this.lblStatVarRow1.Name = "lblStatVarRow1";
            this.lblStatVarRow1.Size = new System.Drawing.Size(93, 13);
            this.lblStatVarRow1.TabIndex = 0;
            this.lblStatVarRow1.Text = "Innhald i fyrste rad";
            // 
            // lblStatVarCol1
            // 
            this.lblStatVarCol1.AutoSize = true;
            this.lblStatVarCol1.Location = new System.Drawing.Point(9, 23);
            this.lblStatVarCol1.Name = "lblStatVarCol1";
            this.lblStatVarCol1.Size = new System.Drawing.Size(116, 13);
            this.lblStatVarCol1.TabIndex = 0;
            this.lblStatVarCol1.Text = "Innhald i fyrste kolonne";
            // 
            // cbColCType1
            // 
            this.cbColCType1.FormattingEnabled = true;
            this.cbColCType1.Location = new System.Drawing.Point(133, 20);
            this.cbColCType1.Name = "cbColCType1";
            this.cbColCType1.Size = new System.Drawing.Size(172, 21);
            this.cbColCType1.TabIndex = 0;
            this.cbColCType1.SelectionChangeCommitted += new System.EventHandler(this.cbFirstColumn_SelectedIndexChanged);
            // 
            // topToolBar
            // 
            this.topToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnValidate,
            this.tss2,
            this.lblDataset,
            this.cbDatasetCategory,
            this.cbDataset,
            this.btnSaveSettings,
            this.toolStripSeparator1,
            this.btnSaveAsCSV,
            this.btnUpload});
            this.topToolBar.Location = new System.Drawing.Point(0, 24);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Padding = new System.Windows.Forms.Padding(5);
            this.topToolBar.Size = new System.Drawing.Size(886, 33);
            this.topToolBar.TabIndex = 0;
            this.topToolBar.Text = "toolStripTop";
            // 
            // btnValidate
            // 
            this.btnValidate.Image = ((System.Drawing.Image)(resources.GetObject("btnValidate.Image")));
            this.btnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(87, 20);
            this.btnValidate.Text = "Valider/test";
            this.btnValidate.Click += new System.EventHandler(this.btnTestParsing_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(6, 23);
            // 
            // lblDataset
            // 
            this.lblDataset.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataset.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblDataset.Name = "lblDataset";
            this.lblDataset.Size = new System.Drawing.Size(51, 20);
            this.lblDataset.Text = "Datasett";
            // 
            // cbDatasetCategory
            // 
            this.cbDatasetCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.cbDatasetCategory.Name = "cbDatasetCategory";
            this.cbDatasetCategory.Size = new System.Drawing.Size(150, 23);
            this.cbDatasetCategory.ToolTipText = "Vel ein datasettkategori";
            this.cbDatasetCategory.SelectedIndexChanged += new System.EventHandler(this.cbDatasetCategory_SelectedIndexChanged);
            // 
            // cbDataset
            // 
            this.cbDataset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cbDataset.Name = "cbDataset";
            this.cbDataset.Size = new System.Drawing.Size(150, 23);
            this.cbDataset.ToolTipText = "Vel eitt datasett frå kategorien";
            this.cbDataset.SelectedIndexChanged += new System.EventHandler(this.cbDataset_SelectedIndexChanged);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveSettings.Image")));
            this.btnSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(99, 20);
            this.btnSaveSettings.Text = "Lagre oppsett";
            this.btnSaveSettings.ToolTipText = "Lagre/oppdater oppsett";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSaveAsCSV
            // 
            this.btnSaveAsCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAsCSV.Image")));
            this.btnSaveAsCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAsCSV.Name = "btnSaveAsCSV";
            this.btnSaveAsCSV.Size = new System.Drawing.Size(100, 20);
            this.btnSaveAsCSV.Text = "Eksporter CSV";
            this.btnSaveAsCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(72, 20);
            this.btnUpload.Text = "Last opp";
            this.btnUpload.Click += new System.EventHandler(this.btnUploadToAdaptive_Click);
            // 
            // panelTopTopMenu
            // 
            this.panelTopTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileMenu,
            this.tsmiHelp});
            this.panelTopTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTopTopMenu.Name = "panelTopTopMenu";
            this.panelTopTopMenu.Size = new System.Drawing.Size(886, 24);
            this.panelTopTopMenu.TabIndex = 22;
            this.panelTopTopMenu.Text = "menuStrip1";
            this.panelTopTopMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.panelTopTopMenu_ItemClicked);
            // 
            // tsmiFileMenu
            // 
            this.tsmiFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReloadAdaptiveConfiguration,
            this.tsmiCloseWindow});
            this.tsmiFileMenu.Name = "tsmiFileMenu";
            this.tsmiFileMenu.Size = new System.Drawing.Size(31, 20);
            this.tsmiFileMenu.Text = "Fil";
            // 
            // tsmiReloadAdaptiveConfiguration
            // 
            this.tsmiReloadAdaptiveConfiguration.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.refresh_icon_24;
            this.tsmiReloadAdaptiveConfiguration.Name = "tsmiReloadAdaptiveConfiguration";
            this.tsmiReloadAdaptiveConfiguration.Size = new System.Drawing.Size(251, 22);
            this.tsmiReloadAdaptiveConfiguration.Text = "Oppdater konfigurasjon frå server";
            this.tsmiReloadAdaptiveConfiguration.Click += new System.EventHandler(this.updateConfigFromServer);
            // 
            // tsmiCloseWindow
            // 
            this.tsmiCloseWindow.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.on_off_icon_24;
            this.tsmiCloseWindow.Name = "tsmiCloseWindow";
            this.tsmiCloseWindow.Size = new System.Drawing.Size(251, 22);
            this.tsmiCloseWindow.Text = "Steng opplastingsvindauge";
            this.tsmiCloseWindow.Click += new System.EventHandler(this.tsmiCloseWindow_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemShowDocumentation,
            this.mnuItemAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(47, 20);
            this.tsmiHelp.Text = "Hjelp";
            // 
            // mnuItemShowDocumentation
            // 
            this.mnuItemShowDocumentation.Name = "mnuItemShowDocumentation";
            this.mnuItemShowDocumentation.Size = new System.Drawing.Size(175, 22);
            this.mnuItemShowDocumentation.Text = "Vis dokumentasjon";
            // 
            // mnuItemAbout
            // 
            this.mnuItemAbout.Name = "mnuItemAbout";
            this.mnuItemAbout.Size = new System.Drawing.Size(175, 22);
            this.mnuItemAbout.Text = "Om ";
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tabControl);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 313);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(886, 237);
            this.panelFill.TabIndex = 24;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpPreviewSelection);
            this.tabControl.Controls.Add(this.tpStatisticsVariables);
            this.tabControl.Controls.Add(this.tabPageLogOutput);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(886, 237);
            this.tabControl.TabIndex = 25;
            // 
            // tpPreviewSelection
            // 
            this.tpPreviewSelection.Controls.Add(this.dgvPreviewSelection);
            this.tpPreviewSelection.Location = new System.Drawing.Point(4, 22);
            this.tpPreviewSelection.Name = "tpPreviewSelection";
            this.tpPreviewSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tpPreviewSelection.Size = new System.Drawing.Size(878, 211);
            this.tpPreviewSelection.TabIndex = 1;
            this.tpPreviewSelection.Text = "Førehandsvisning av utval";
            this.tpPreviewSelection.UseVisualStyleBackColor = true;
            // 
            // dgvPreviewSelection
            // 
            this.dgvPreviewSelection.AllowUserToAddRows = false;
            this.dgvPreviewSelection.AllowUserToDeleteRows = false;
            this.dgvPreviewSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreviewSelection.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPreviewSelection.Location = new System.Drawing.Point(3, 3);
            this.dgvPreviewSelection.MultiSelect = false;
            this.dgvPreviewSelection.Name = "dgvPreviewSelection";
            this.dgvPreviewSelection.ReadOnly = true;
            this.dgvPreviewSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPreviewSelection.Size = new System.Drawing.Size(872, 205);
            this.dgvPreviewSelection.TabIndex = 0;
            this.dgvPreviewSelection.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPreviewSelection_DataBindingComplete);
            // 
            // tpStatisticsVariables
            // 
            this.tpStatisticsVariables.Controls.Add(this.dgvStatVarProperties);
            this.tpStatisticsVariables.Controls.Add(this.tsStatVarPropertiesDGV);
            this.tpStatisticsVariables.Location = new System.Drawing.Point(4, 22);
            this.tpStatisticsVariables.Name = "tpStatisticsVariables";
            this.tpStatisticsVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatisticsVariables.Size = new System.Drawing.Size(878, 211);
            this.tpStatisticsVariables.TabIndex = 0;
            this.tpStatisticsVariables.Text = "Innstillingar for statistikkvariablar";
            this.tpStatisticsVariables.UseVisualStyleBackColor = true;
            // 
            // dgvStatVarProperties
            // 
            this.dgvStatVarProperties.AllowUserToAddRows = false;
            this.dgvStatVarProperties.AllowUserToDeleteRows = false;
            this.dgvStatVarProperties.AllowUserToResizeRows = false;
            this.dgvStatVarProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStatVarProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatVarProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Title,
            this.StatVarCol1,
            this.StatVarCol2,
            this.StatVarCol3,
            this.StatVarCol4,
            this.StatVarCol5,
            this.MeasurementUnit,
            this.Year,
            this.Quarter,
            this.Month,
            this.Day});
            this.dgvStatVarProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatVarProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvStatVarProperties.Location = new System.Drawing.Point(3, 28);
            this.dgvStatVarProperties.Name = "dgvStatVarProperties";
            this.dgvStatVarProperties.Size = new System.Drawing.Size(872, 180);
            this.dgvStatVarProperties.TabIndex = 0;
            this.dgvStatVarProperties.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvStatVarProperties_CurrentCellDirtyStateChanged);
            this.dgvStatVarProperties.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvStatVarProperties_DataError);
            // 
            // Index
            // 
            this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Index.DataPropertyName = "Index";
            this.Index.FillWeight = 25F;
            this.Index.Frozen = true;
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Index.Width = 39;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Title.DataPropertyName = "Title";
            this.Title.Frozen = true;
            this.Title.HeaderText = "Tittel";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Title.Width = 36;
            // 
            // StatVarCol1
            // 
            this.StatVarCol1.AutoComplete = false;
            this.StatVarCol1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatVarCol1.DataPropertyName = "StatVarCol1";
            this.StatVarCol1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatVarCol1.HeaderText = "Stat.var. nivå 1";
            this.StatVarCol1.Items.AddRange(new object[] {
            "",
            "Folketal",
            "Miljø",
            "Trafikk",
            "Næring"});
            this.StatVarCol1.MinimumWidth = 100;
            this.StatVarCol1.Name = "StatVarCol1";
            // 
            // StatVarCol2
            // 
            this.StatVarCol2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatVarCol2.DataPropertyName = "StatVarCol2";
            this.StatVarCol2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatVarCol2.HeaderText = "Nivå 2";
            this.StatVarCol2.MinimumWidth = 100;
            this.StatVarCol2.Name = "StatVarCol2";
            // 
            // StatVarCol3
            // 
            this.StatVarCol3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatVarCol3.DataPropertyName = "StatVarCol3";
            this.StatVarCol3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatVarCol3.HeaderText = "Nivå 3";
            this.StatVarCol3.MinimumWidth = 100;
            this.StatVarCol3.Name = "StatVarCol3";
            // 
            // StatVarCol4
            // 
            this.StatVarCol4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatVarCol4.DataPropertyName = "StatVarCol4";
            this.StatVarCol4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatVarCol4.HeaderText = "Nivå 4";
            this.StatVarCol4.MinimumWidth = 75;
            this.StatVarCol4.Name = "StatVarCol4";
            this.StatVarCol4.Width = 75;
            // 
            // StatVarCol5
            // 
            this.StatVarCol5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatVarCol5.DataPropertyName = "StatVarCol5";
            this.StatVarCol5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatVarCol5.HeaderText = "Nivå 5";
            this.StatVarCol5.MinimumWidth = 75;
            this.StatVarCol5.Name = "StatVarCol5";
            this.StatVarCol5.Width = 75;
            // 
            // MeasurementUnit
            // 
            this.MeasurementUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MeasurementUnit.DataPropertyName = "MeasurementUnit";
            this.MeasurementUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MeasurementUnit.HeaderText = "Måleeining";
            this.MeasurementUnit.MinimumWidth = 75;
            this.MeasurementUnit.Name = "MeasurementUnit";
            this.MeasurementUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "År";
            this.Year.MinimumWidth = 50;
            this.Year.Name = "Year";
            this.Year.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Year.Width = 50;
            // 
            // Quarter
            // 
            this.Quarter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quarter.DataPropertyName = "Quarter";
            this.Quarter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quarter.HeaderText = "Kvartal";
            this.Quarter.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4"});
            this.Quarter.MinimumWidth = 45;
            this.Quarter.Name = "Quarter";
            this.Quarter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Quarter.Width = 45;
            // 
            // Month
            // 
            this.Month.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Month.DataPropertyName = "Month";
            this.Month.HeaderText = "Månad";
            this.Month.MinimumWidth = 45;
            this.Month.Name = "Month";
            this.Month.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Month.Width = 45;
            // 
            // Day
            // 
            this.Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "Dag";
            this.Day.MinimumWidth = 30;
            this.Day.Name = "Day";
            this.Day.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Day.Width = 30;
            // 
            // tsStatVarPropertiesDGV
            // 
            this.tsStatVarPropertiesDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopyStatVarAll,
            this.toolStripSeparator3,
            this.btnCopyMeasurementUnitToAll,
            this.toolStripSeparator2,
            this.btnCopyTitleToStatVarColN,
            this.cbSelectedStatVarCol});
            this.tsStatVarPropertiesDGV.Location = new System.Drawing.Point(3, 3);
            this.tsStatVarPropertiesDGV.Name = "tsStatVarPropertiesDGV";
            this.tsStatVarPropertiesDGV.Size = new System.Drawing.Size(872, 25);
            this.tsStatVarPropertiesDGV.TabIndex = 1;
            this.tsStatVarPropertiesDGV.Text = "Tools";
            // 
            // btnCopyStatVarAll
            // 
            this.btnCopyStatVarAll.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.clipboard_copy_icon_16;
            this.btnCopyStatVarAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyStatVarAll.Name = "btnCopyStatVarAll";
            this.btnCopyStatVarAll.Size = new System.Drawing.Size(194, 22);
            this.btnCopyStatVarAll.Text = "Kopier fyrste variabeltype til alle";
            this.btnCopyStatVarAll.Click += new System.EventHandler(this.btnCopyStatVarAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyMeasurementUnitToAll
            // 
            this.btnCopyMeasurementUnitToAll.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.clipboard_copy_icon_16;
            this.btnCopyMeasurementUnitToAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyMeasurementUnitToAll.Name = "btnCopyMeasurementUnitToAll";
            this.btnCopyMeasurementUnitToAll.Size = new System.Drawing.Size(189, 22);
            this.btnCopyMeasurementUnitToAll.Text = "Kopier fyrste måleeining til alle";
            this.btnCopyMeasurementUnitToAll.Click += new System.EventHandler(this.btnCopyFirstMeasurementUnitToAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCopyTitleToStatVarColN
            // 
            this.btnCopyTitleToStatVarColN.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.clipboard_copy_icon_16;
            this.btnCopyTitleToStatVarColN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyTitleToStatVarColN.Name = "btnCopyTitleToStatVarColN";
            this.btnCopyTitleToStatVarColN.Size = new System.Drawing.Size(135, 22);
            this.btnCopyTitleToStatVarColN.Text = "Kopier tittel til nivå...";
            this.btnCopyTitleToStatVarColN.Click += new System.EventHandler(this.btnCopyTitleToStatVarColN_Click);
            // 
            // cbSelectedStatVarCol
            // 
            this.cbSelectedStatVarCol.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbSelectedStatVarCol.Name = "cbSelectedStatVarCol";
            this.cbSelectedStatVarCol.Size = new System.Drawing.Size(75, 25);
            this.cbSelectedStatVarCol.Text = "3";
            // 
            // tabPageLogOutput
            // 
            this.tabPageLogOutput.Controls.Add(this.tbLog);
            this.tabPageLogOutput.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogOutput.Name = "tabPageLogOutput";
            this.tabPageLogOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogOutput.Size = new System.Drawing.Size(878, 211);
            this.tabPageLogOutput.TabIndex = 2;
            this.tabPageLogOutput.Text = "Logg/meldingar";
            this.tabPageLogOutput.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 3);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(872, 205);
            this.tbLog.TabIndex = 14;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.ssStatusStrip);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 550);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(886, 23);
            this.panelBottom.TabIndex = 25;
            // 
            // ssStatusStrip
            // 
            this.ssStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.tspbProgressBar});
            this.ssStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ssStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.ssStatusStrip.Name = "ssStatusStrip";
            this.ssStatusStrip.Size = new System.Drawing.Size(886, 23);
            this.ssStatusStrip.TabIndex = 13;
            this.ssStatusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 18);
            this.lblStatus.Text = "Ok";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspbProgressBar
            // 
            this.tspbProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbProgressBar.Name = "tspbProgressBar";
            this.tspbProgressBar.Size = new System.Drawing.Size(200, 17);
            // 
            // dlgSaveCsvFile
            // 
            this.dlgSaveCsvFile.FileName = "*.csv";
            this.dlgSaveCsvFile.Filter = "CSV-files|*.csv";
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 573);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MainMenuStrip = this.panelTopTopMenu;
            this.Name = "UploadForm";
            this.Text = "Last opp tabell";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.grpStatDatumSettings.ResumeLayout(false);
            this.grpStatDatumSettings.PerformLayout();
            this.grpAutoDateSettings.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopFill.ResumeLayout(false);
            this.grpStatAreaSettings.ResumeLayout(false);
            this.grpStatAreaSettings.PerformLayout();
            this.grpCellContentTypeSettings.ResumeLayout(false);
            this.grpCellContentTypeSettings.PerformLayout();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.panelTopTopMenu.ResumeLayout(false);
            this.panelTopTopMenu.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpPreviewSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewSelection)).EndInit();
            this.tpStatisticsVariables.ResumeLayout(false);
            this.tpStatisticsVariables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatVarProperties)).EndInit();
            this.tsStatVarPropertiesDGV.ResumeLayout(false);
            this.tsStatVarPropertiesDGV.PerformLayout();
            this.tabPageLogOutput.ResumeLayout(false);
            this.tabPageLogOutput.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ssStatusStrip.ResumeLayout(false);
            this.ssStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblQuarter;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpStatDatumSettings;
        private System.Windows.Forms.Label lblStatAreaType;
        public System.Windows.Forms.ComboBox cbStatUnitType;
        public System.Windows.Forms.TextBox tbStatDatumDay;
        public System.Windows.Forms.TextBox tbStatDatumMonth;
        public System.Windows.Forms.TextBox tbStatDatumYear;
        public System.Windows.Forms.ComboBox cbStatDatumQuarter;
        private System.Windows.Forms.GroupBox grpAutoDateSettings;
        private System.Windows.Forms.Button btnCopyDateToAll;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFill;
        public System.Windows.Forms.DataGridView dgvStatVarProperties;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar tspbProgressBar;
        private System.Windows.Forms.SaveFileDialog dlgSaveCsvFile;
        private System.Windows.Forms.Panel panelTopFill;
        private System.Windows.Forms.MenuStrip panelTopTopMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadAdaptiveConfiguration;
        private System.Windows.Forms.ToolStrip topToolBar;
        private System.Windows.Forms.ToolStripButton btnSaveAsCSV;
        private System.Windows.Forms.ToolStripButton btnUpload;
        private System.Windows.Forms.ToolStripButton btnValidate;
        private System.Windows.Forms.GroupBox grpCellContentTypeSettings;
        private System.Windows.Forms.Label lblStatVarRow1;
        private System.Windows.Forms.Label lblStatVarCol1;
        private System.Windows.Forms.Label lblStatVarCol3;
        private System.Windows.Forms.Label lblStatVarCol2;
        private System.Windows.Forms.Label lblStatVarRow3;
        private System.Windows.Forms.Label lblStatVarRow2;
        public System.Windows.Forms.ComboBox cbStatDatumFormat;
        public System.Windows.Forms.ComboBox cbRowCType1;
        public System.Windows.Forms.ComboBox cbColCType1;
        public System.Windows.Forms.ComboBox cbColCType3;
        public System.Windows.Forms.ComboBox cbColCType2;
        public System.Windows.Forms.ComboBox cbRowCType3;
        public System.Windows.Forms.ComboBox cbRowCType2;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpPreviewSelection;
        private System.Windows.Forms.TabPage tpStatisticsVariables;
        private System.Windows.Forms.DataGridView dgvPreviewSelection;
        private System.Windows.Forms.Label lblStatVarRow4;
        private System.Windows.Forms.Label lblStatVarCol4;
        public System.Windows.Forms.ComboBox cbRowCType4;
        public System.Windows.Forms.ComboBox cbColCType4;
        private System.Windows.Forms.GroupBox grpStatAreaSettings;
        private System.Windows.Forms.Label lblStatAreaId;
        private System.Windows.Forms.Label lblStatAreaGroup;
        private System.Windows.Forms.Label lblStatAreaName;
        private System.Windows.Forms.ToolStrip tsStatVarPropertiesDGV;
        public System.Windows.Forms.TextBox tbStatUnitGroup;
        public System.Windows.Forms.TextBox tbStatUnitName;
        public System.Windows.Forms.TextBox tbStatUnitID;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.TabPage tabPageLogOutput;
        private System.Windows.Forms.ToolStripButton btnCopyMeasurementUnitToAll;
        private System.Windows.Forms.Button btnSetStatAreaInfo;
        private System.Windows.Forms.ToolStripButton btnCopyStatVarAll;
        private System.Windows.Forms.ToolStripButton btnSaveSettings;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ToolStripComboBox cbDataset;
        private System.Windows.Forms.ToolStripLabel lblDataset;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowDocumentation;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAbout;
        private System.Windows.Forms.ToolStripComboBox cbDatasetCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCopyTitleToStatVarColN;
        private System.Windows.Forms.ToolStripComboBox cbSelectedStatVarCol;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatVarCol1;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatVarCol2;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatVarCol3;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatVarCol4;
        private System.Windows.Forms.DataGridViewComboBoxColumn StatVarCol5;
        private System.Windows.Forms.DataGridViewComboBoxColumn MeasurementUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewComboBoxColumn Quarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
    }
}