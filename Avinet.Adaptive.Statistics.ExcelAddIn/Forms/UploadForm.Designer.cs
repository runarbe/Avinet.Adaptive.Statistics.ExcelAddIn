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
            this.tbDay = new System.Windows.Forms.TextBox();
            this.tbMonth = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbYearPart = new System.Windows.Forms.ComboBox();
            this.grpManualDateSettings = new System.Windows.Forms.GroupBox();
            this.btnCopyFirstRowToAll = new System.Windows.Forms.Button();
            this.btnCopyDateToAll = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbStatUnitType = new System.Windows.Forms.ComboBox();
            this.grpAutoDateSettings = new System.Windows.Forms.GroupBox();
            this.cbDateFormats = new System.Windows.Forms.ComboBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopFill = new System.Windows.Forms.Panel();
            this.grpManualStatAreaSettings = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.groupLayoutOfData = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbRowCType4 = new System.Windows.Forms.ComboBox();
            this.cbColCType4 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbColCType3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbColCType2 = new System.Windows.Forms.ComboBox();
            this.cbRowCType3 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbRowCType2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbRowCType1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbColCType1 = new System.Windows.Forms.ComboBox();
            this.topToolBar = new System.Windows.Forms.ToolStrip();
            this.btnSaveAsCSV = new System.Windows.Forms.ToolStripButton();
            this.btnUploadToAdaptive = new System.Windows.Forms.ToolStripButton();
            this.btnTestParsing = new System.Windows.Forms.ToolStripButton();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.panelTopTopMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lagreSomCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stengToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFill = new System.Windows.Forms.Panel();
            this.tabSelectPreview = new System.Windows.Forms.TabControl();
            this.tabPreviewSelection = new System.Windows.Forms.TabPage();
            this.dgvPreviewSelection = new System.Windows.Forms.DataGridView();
            this.tabStatisticsVariables = new System.Windows.Forms.TabPage();
            this.dgvFieldProperties = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariableType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MeasurementUnit = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearPart = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dlgSaveCsvFile = new System.Windows.Forms.SaveFileDialog();
            this.grpManualDateSettings.SuspendLayout();
            this.grpAutoDateSettings.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopFill.SuspendLayout();
            this.grpManualStatAreaSettings.SuspendLayout();
            this.groupLayoutOfData.SuspendLayout();
            this.topToolBar.SuspendLayout();
            this.panelTopTopMenu.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.tabSelectPreview.SuspendLayout();
            this.tabPreviewSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewSelection)).BeginInit();
            this.tabStatisticsVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldProperties)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDay
            // 
            this.tbDay.Location = new System.Drawing.Point(186, 31);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(35, 20);
            this.tbDay.TabIndex = 9;
            // 
            // tbMonth
            // 
            this.tbMonth.Location = new System.Drawing.Point(139, 31);
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(41, 20);
            this.tbMonth.TabIndex = 8;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(6, 31);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(43, 20);
            this.tbYear.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "År";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Periode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Månad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Dag";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 14;
            // 
            // cbYearPart
            // 
            this.cbYearPart.FormattingEnabled = true;
            this.cbYearPart.Items.AddRange(new object[] {
            "Q1",
            "Q2",
            "Q3",
            "Q4",
            "T1",
            "T2",
            "T3",
            "H1",
            "H2"});
            this.cbYearPart.Location = new System.Drawing.Point(55, 31);
            this.cbYearPart.Name = "cbYearPart";
            this.cbYearPart.Size = new System.Drawing.Size(78, 21);
            this.cbYearPart.TabIndex = 15;
            // 
            // grpManualDateSettings
            // 
            this.grpManualDateSettings.Controls.Add(this.cbYearPart);
            this.grpManualDateSettings.Controls.Add(this.tbYear);
            this.grpManualDateSettings.Controls.Add(this.tbMonth);
            this.grpManualDateSettings.Controls.Add(this.tbDay);
            this.grpManualDateSettings.Controls.Add(this.label5);
            this.grpManualDateSettings.Controls.Add(this.label8);
            this.grpManualDateSettings.Controls.Add(this.btnCopyFirstRowToAll);
            this.grpManualDateSettings.Controls.Add(this.btnCopyDateToAll);
            this.grpManualDateSettings.Controls.Add(this.label4);
            this.grpManualDateSettings.Controls.Add(this.label3);
            this.grpManualDateSettings.Controls.Add(this.label2);
            this.grpManualDateSettings.Enabled = false;
            this.grpManualDateSettings.Location = new System.Drawing.Point(393, 7);
            this.grpManualDateSettings.Name = "grpManualDateSettings";
            this.grpManualDateSettings.Size = new System.Drawing.Size(234, 119);
            this.grpManualDateSettings.TabIndex = 12;
            this.grpManualDateSettings.TabStop = false;
            this.grpManualDateSettings.Text = "Bestem datering manuelt";
            // 
            // btnCopyFirstRowToAll
            // 
            this.btnCopyFirstRowToAll.Location = new System.Drawing.Point(6, 87);
            this.btnCopyFirstRowToAll.Name = "btnCopyFirstRowToAll";
            this.btnCopyFirstRowToAll.Size = new System.Drawing.Size(215, 23);
            this.btnCopyFirstRowToAll.TabIndex = 4;
            this.btnCopyFirstRowToAll.Text = "Kopier fyrste rad til alle";
            this.btnCopyFirstRowToAll.UseVisualStyleBackColor = true;
            this.btnCopyFirstRowToAll.Click += new System.EventHandler(this.btnCopyFirstRowToAll_Click);
            // 
            // btnCopyDateToAll
            // 
            this.btnCopyDateToAll.Location = new System.Drawing.Point(6, 58);
            this.btnCopyDateToAll.Name = "btnCopyDateToAll";
            this.btnCopyDateToAll.Size = new System.Drawing.Size(215, 23);
            this.btnCopyDateToAll.TabIndex = 16;
            this.btnCopyDateToAll.Text = "Kopier dato til alle statistikkvariablar";
            this.btnCopyDateToAll.UseVisualStyleBackColor = true;
            this.btnCopyDateToAll.Click += new System.EventHandler(this.btnCopyDateToAll_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Type kretsar (td kommune)";
            // 
            // cbStatUnitType
            // 
            this.cbStatUnitType.FormattingEnabled = true;
            this.cbStatUnitType.Items.AddRange(new object[] {
            "1. kvartal",
            "2. kvartal",
            "3. kvartal",
            "4. kvartal",
            "1. tertial",
            "2. tertial",
            "3. tertial",
            "1. halvår",
            "2. halvår"});
            this.cbStatUnitType.Location = new System.Drawing.Point(9, 36);
            this.cbStatUnitType.Name = "cbStatUnitType";
            this.cbStatUnitType.Size = new System.Drawing.Size(229, 21);
            this.cbStatUnitType.TabIndex = 15;
            // 
            // grpAutoDateSettings
            // 
            this.grpAutoDateSettings.Controls.Add(this.cbDateFormats);
            this.grpAutoDateSettings.Enabled = false;
            this.grpAutoDateSettings.Location = new System.Drawing.Point(393, 132);
            this.grpAutoDateSettings.Name = "grpAutoDateSettings";
            this.grpAutoDateSettings.Size = new System.Drawing.Size(234, 71);
            this.grpAutoDateSettings.TabIndex = 20;
            this.grpAutoDateSettings.TabStop = false;
            this.grpAutoDateSettings.Text = "Datoformat for autodatering";
            // 
            // cbDateFormats
            // 
            this.cbDateFormats.FormattingEnabled = true;
            this.cbDateFormats.Items.AddRange(new object[] {
            "1. kvartal",
            "2. kvartal",
            "3. kvartal",
            "4. kvartal",
            "1. tertial",
            "2. tertial",
            "3. tertial",
            "1. halvår",
            "2. halvår"});
            this.cbDateFormats.Location = new System.Drawing.Point(9, 28);
            this.cbDateFormats.Name = "cbDateFormats";
            this.cbDateFormats.Size = new System.Drawing.Size(212, 21);
            this.cbDateFormats.TabIndex = 18;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopFill);
            this.panelTop.Controls.Add(this.topToolBar);
            this.panelTop.Controls.Add(this.panelTopTopMenu);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(922, 313);
            this.panelTop.TabIndex = 22;
            // 
            // panelTopFill
            // 
            this.panelTopFill.Controls.Add(this.grpManualStatAreaSettings);
            this.panelTopFill.Controls.Add(this.lblSettings);
            this.panelTopFill.Controls.Add(this.grpManualDateSettings);
            this.panelTopFill.Controls.Add(this.grpAutoDateSettings);
            this.panelTopFill.Controls.Add(this.groupLayoutOfData);
            this.panelTopFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopFill.Location = new System.Drawing.Point(0, 49);
            this.panelTopFill.Name = "panelTopFill";
            this.panelTopFill.Size = new System.Drawing.Size(922, 264);
            this.panelTopFill.TabIndex = 23;
            // 
            // grpManualStatAreaSettings
            // 
            this.grpManualStatAreaSettings.Controls.Add(this.textBox3);
            this.grpManualStatAreaSettings.Controls.Add(this.textBox2);
            this.grpManualStatAreaSettings.Controls.Add(this.textBox1);
            this.grpManualStatAreaSettings.Controls.Add(this.label18);
            this.grpManualStatAreaSettings.Controls.Add(this.label17);
            this.grpManualStatAreaSettings.Controls.Add(this.label16);
            this.grpManualStatAreaSettings.Controls.Add(this.label12);
            this.grpManualStatAreaSettings.Controls.Add(this.cbStatUnitType);
            this.grpManualStatAreaSettings.Enabled = false;
            this.grpManualStatAreaSettings.Location = new System.Drawing.Point(642, 7);
            this.grpManualStatAreaSettings.Name = "grpManualStatAreaSettings";
            this.grpManualStatAreaSettings.Size = new System.Drawing.Size(249, 196);
            this.grpManualStatAreaSettings.TabIndex = 25;
            this.grpManualStatAreaSettings.TabStop = false;
            this.grpManualStatAreaSettings.Text = "Bestem krins manuelt";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(92, 115);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 89);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Krinsgruppering";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 13);
            this.label17.TabIndex = 17;
            this.label17.Text = "Krinsnamn";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 17;
            this.label16.Text = "Krins ID";
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettings.Location = new System.Drawing.Point(3, 248);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(72, 13);
            this.lblSettings.TabIndex = 23;
            this.lblSettings.Text = "Innstillingar";
            // 
            // groupLayoutOfData
            // 
            this.groupLayoutOfData.Controls.Add(this.label7);
            this.groupLayoutOfData.Controls.Add(this.label6);
            this.groupLayoutOfData.Controls.Add(this.cbRowCType4);
            this.groupLayoutOfData.Controls.Add(this.cbColCType4);
            this.groupLayoutOfData.Controls.Add(this.label13);
            this.groupLayoutOfData.Controls.Add(this.cbColCType3);
            this.groupLayoutOfData.Controls.Add(this.label11);
            this.groupLayoutOfData.Controls.Add(this.cbColCType2);
            this.groupLayoutOfData.Controls.Add(this.cbRowCType3);
            this.groupLayoutOfData.Controls.Add(this.label15);
            this.groupLayoutOfData.Controls.Add(this.cbRowCType2);
            this.groupLayoutOfData.Controls.Add(this.label14);
            this.groupLayoutOfData.Controls.Add(this.cbRowCType1);
            this.groupLayoutOfData.Controls.Add(this.label10);
            this.groupLayoutOfData.Controls.Add(this.label9);
            this.groupLayoutOfData.Controls.Add(this.cbColCType1);
            this.groupLayoutOfData.Location = new System.Drawing.Point(3, 7);
            this.groupLayoutOfData.Name = "groupLayoutOfData";
            this.groupLayoutOfData.Size = new System.Drawing.Size(378, 238);
            this.groupLayoutOfData.TabIndex = 24;
            this.groupLayoutOfData.TabStop = false;
            this.groupLayoutOfData.Text = "Datalayout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Innhald i fjerde rad";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Innhald i fjerde kolonne";
            // 
            // cbRowCType4
            // 
            this.cbRowCType4.FormattingEnabled = true;
            this.cbRowCType4.Location = new System.Drawing.Point(144, 208);
            this.cbRowCType4.Name = "cbRowCType4";
            this.cbRowCType4.Size = new System.Drawing.Size(228, 21);
            this.cbRowCType4.TabIndex = 8;
            this.cbRowCType4.SelectedIndexChanged += new System.EventHandler(this.cbRowCType4_SelectedIndexChanged);
            // 
            // cbColCType4
            // 
            this.cbColCType4.FormattingEnabled = true;
            this.cbColCType4.Location = new System.Drawing.Point(144, 98);
            this.cbColCType4.Name = "cbColCType4";
            this.cbColCType4.Size = new System.Drawing.Size(228, 21);
            this.cbColCType4.TabIndex = 7;
            this.cbColCType4.SelectedIndexChanged += new System.EventHandler(this.cbColCType4_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Innhald i tredje kolonne";
            // 
            // cbColCType3
            // 
            this.cbColCType3.FormattingEnabled = true;
            this.cbColCType3.Location = new System.Drawing.Point(144, 72);
            this.cbColCType3.Name = "cbColCType3";
            this.cbColCType3.Size = new System.Drawing.Size(228, 21);
            this.cbColCType3.TabIndex = 6;
            this.cbColCType3.SelectedIndexChanged += new System.EventHandler(this.cbThirdColCType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(22, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Innhald i andre kolonne";
            // 
            // cbColCType2
            // 
            this.cbColCType2.FormattingEnabled = true;
            this.cbColCType2.Location = new System.Drawing.Point(144, 44);
            this.cbColCType2.Name = "cbColCType2";
            this.cbColCType2.Size = new System.Drawing.Size(228, 21);
            this.cbColCType2.TabIndex = 4;
            this.cbColCType2.SelectedIndexChanged += new System.EventHandler(this.cbSecondColCType_SelectedIndexChanged);
            // 
            // cbRowCType3
            // 
            this.cbRowCType3.FormattingEnabled = true;
            this.cbRowCType3.Location = new System.Drawing.Point(144, 181);
            this.cbRowCType3.Name = "cbRowCType3";
            this.cbRowCType3.Size = new System.Drawing.Size(228, 21);
            this.cbRowCType3.TabIndex = 0;
            this.cbRowCType3.SelectedIndexChanged += new System.EventHandler(this.cbRowCType3_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Innhald i tredje rad";
            // 
            // cbRowCType2
            // 
            this.cbRowCType2.FormattingEnabled = true;
            this.cbRowCType2.Location = new System.Drawing.Point(144, 153);
            this.cbRowCType2.Name = "cbRowCType2";
            this.cbRowCType2.Size = new System.Drawing.Size(228, 21);
            this.cbRowCType2.TabIndex = 0;
            this.cbRowCType2.SelectedIndexChanged += new System.EventHandler(this.cbSecondRowCType_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 157);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Innhald i andre rad";
            // 
            // cbRowCType1
            // 
            this.cbRowCType1.FormattingEnabled = true;
            this.cbRowCType1.Location = new System.Drawing.Point(144, 125);
            this.cbRowCType1.Name = "cbRowCType1";
            this.cbRowCType1.Size = new System.Drawing.Size(228, 21);
            this.cbRowCType1.TabIndex = 0;
            this.cbRowCType1.SelectedIndexChanged += new System.EventHandler(this.cbFirstRowCType_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Innhald i fyrste rad";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Innhald i fyrste kolonne";
            // 
            // cbColCType1
            // 
            this.cbColCType1.FormattingEnabled = true;
            this.cbColCType1.Location = new System.Drawing.Point(144, 16);
            this.cbColCType1.Name = "cbColCType1";
            this.cbColCType1.Size = new System.Drawing.Size(228, 21);
            this.cbColCType1.TabIndex = 2;
            this.cbColCType1.SelectedIndexChanged += new System.EventHandler(this.cbFirstColumn_SelectedIndexChanged);
            // 
            // topToolBar
            // 
            this.topToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveAsCSV,
            this.btnUploadToAdaptive,
            this.btnTestParsing,
            this.btnTest});
            this.topToolBar.Location = new System.Drawing.Point(0, 24);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Size = new System.Drawing.Size(922, 25);
            this.topToolBar.TabIndex = 2;
            this.topToolBar.Text = "toolStripTop";
            // 
            // btnSaveAsCSV
            // 
            this.btnSaveAsCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAsCSV.Image")));
            this.btnSaveAsCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAsCSV.Name = "btnSaveAsCSV";
            this.btnSaveAsCSV.Size = new System.Drawing.Size(98, 22);
            this.btnSaveAsCSV.Text = "Lagre som CSV";
            this.btnSaveAsCSV.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnUploadToAdaptive
            // 
            this.btnUploadToAdaptive.Image = ((System.Drawing.Image)(resources.GetObject("btnUploadToAdaptive.Image")));
            this.btnUploadToAdaptive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUploadToAdaptive.Name = "btnUploadToAdaptive";
            this.btnUploadToAdaptive.Size = new System.Drawing.Size(125, 22);
            this.btnUploadToAdaptive.Text = "Last opp til Adaptive";
            // 
            // btnTestParsing
            // 
            this.btnTestParsing.Image = ((System.Drawing.Image)(resources.GetObject("btnTestParsing.Image")));
            this.btnTestParsing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTestParsing.Name = "btnTestParsing";
            this.btnTestParsing.Size = new System.Drawing.Size(177, 22);
            this.btnTestParsing.Text = "Test med gjeldande innstillingar";
            this.btnTestParsing.Click += new System.EventHandler(this.btnTestParsing_Click);
            // 
            // btnTest
            // 
            this.btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(32, 22);
            this.btnTest.Text = "Test";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click_1);
            // 
            // panelTopTopMenu
            // 
            this.panelTopTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.panelTopTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTopTopMenu.Name = "panelTopTopMenu";
            this.panelTopTopMenu.Size = new System.Drawing.Size(922, 24);
            this.panelTopTopMenu.TabIndex = 22;
            this.panelTopTopMenu.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lagreSomCSVToolStripMenuItem,
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem,
            this.stengToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(29, 20);
            this.toolStripMenuItem1.Text = "Fil";
            // 
            // lagreSomCSVToolStripMenuItem
            // 
            this.lagreSomCSVToolStripMenuItem.Name = "lagreSomCSVToolStripMenuItem";
            this.lagreSomCSVToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.lagreSomCSVToolStripMenuItem.Text = "Lagre som CSV";
            this.lagreSomCSVToolStripMenuItem.Click += new System.EventHandler(this.lagreSomCSVToolStripMenuItem_Click);
            // 
            // oppdaterKonfigurasjonFråServerToolStripMenuItem
            // 
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Name = "oppdaterKonfigurasjonFråServerToolStripMenuItem";
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Text = "Oppdater konfigurasjon frå server";
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Click += new System.EventHandler(this.updateConfigFromServer);
            // 
            // stengToolStripMenuItem
            // 
            this.stengToolStripMenuItem.Name = "stengToolStripMenuItem";
            this.stengToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.stengToolStripMenuItem.Text = "Steng opplastingsvindauge";
            this.stengToolStripMenuItem.Click += new System.EventHandler(this.stengToolStripMenuItem_Click);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.tabSelectPreview);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 313);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(922, 155);
            this.panelFill.TabIndex = 24;
            // 
            // tabSelectPreview
            // 
            this.tabSelectPreview.Controls.Add(this.tabPreviewSelection);
            this.tabSelectPreview.Controls.Add(this.tabStatisticsVariables);
            this.tabSelectPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSelectPreview.Location = new System.Drawing.Point(0, 0);
            this.tabSelectPreview.Name = "tabSelectPreview";
            this.tabSelectPreview.SelectedIndex = 0;
            this.tabSelectPreview.Size = new System.Drawing.Size(922, 155);
            this.tabSelectPreview.TabIndex = 25;
            // 
            // tabPreviewSelection
            // 
            this.tabPreviewSelection.Controls.Add(this.dgvPreviewSelection);
            this.tabPreviewSelection.Location = new System.Drawing.Point(4, 22);
            this.tabPreviewSelection.Name = "tabPreviewSelection";
            this.tabPreviewSelection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreviewSelection.Size = new System.Drawing.Size(914, 129);
            this.tabPreviewSelection.TabIndex = 1;
            this.tabPreviewSelection.Text = "Førehandsvisning av utval";
            this.tabPreviewSelection.UseVisualStyleBackColor = true;
            // 
            // dgvPreviewSelection
            // 
            this.dgvPreviewSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreviewSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreviewSelection.Location = new System.Drawing.Point(3, 3);
            this.dgvPreviewSelection.MultiSelect = false;
            this.dgvPreviewSelection.Name = "dgvPreviewSelection";
            this.dgvPreviewSelection.ReadOnly = true;
            this.dgvPreviewSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPreviewSelection.Size = new System.Drawing.Size(908, 123);
            this.dgvPreviewSelection.TabIndex = 0;
            this.dgvPreviewSelection.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPreviewSelection_DataBindingComplete);
            // 
            // tabStatisticsVariables
            // 
            this.tabStatisticsVariables.Controls.Add(this.dgvFieldProperties);
            this.tabStatisticsVariables.Location = new System.Drawing.Point(4, 22);
            this.tabStatisticsVariables.Name = "tabStatisticsVariables";
            this.tabStatisticsVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatisticsVariables.Size = new System.Drawing.Size(914, 129);
            this.tabStatisticsVariables.TabIndex = 0;
            this.tabStatisticsVariables.Text = "Innstillingar for statistikkvariablar";
            this.tabStatisticsVariables.UseVisualStyleBackColor = true;
            // 
            // dgvFieldProperties
            // 
            this.dgvFieldProperties.AllowUserToAddRows = false;
            this.dgvFieldProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFieldProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.VariableType,
            this.MeasurementUnit,
            this.Year,
            this.YearPart,
            this.Month,
            this.Day});
            this.dgvFieldProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFieldProperties.Location = new System.Drawing.Point(3, 3);
            this.dgvFieldProperties.Name = "dgvFieldProperties";
            this.dgvFieldProperties.Size = new System.Drawing.Size(908, 123);
            this.dgvFieldProperties.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "Tittel";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 55;
            // 
            // VariableType
            // 
            this.VariableType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VariableType.DataPropertyName = "VariableType";
            this.VariableType.HeaderText = "Statistikkvariabeltype";
            this.VariableType.Name = "VariableType";
            this.VariableType.Width = 113;
            // 
            // MeasurementUnit
            // 
            this.MeasurementUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MeasurementUnit.DataPropertyName = "MeasurementUnit";
            this.MeasurementUnit.HeaderText = "Måleeining";
            this.MeasurementUnit.Name = "MeasurementUnit";
            this.MeasurementUnit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MeasurementUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MeasurementUnit.Width = 83;
            // 
            // Year
            // 
            this.Year.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "År";
            this.Year.Name = "Year";
            this.Year.Width = 42;
            // 
            // YearPart
            // 
            this.YearPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.YearPart.DataPropertyName = "YearPart";
            this.YearPart.HeaderText = "Kvartal";
            this.YearPart.Name = "YearPart";
            this.YearPart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.YearPart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.YearPart.Width = 65;
            // 
            // Month
            // 
            this.Month.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Month.DataPropertyName = "Month";
            this.Month.HeaderText = "Månad";
            this.Month.Name = "Month";
            this.Month.Width = 65;
            // 
            // Day
            // 
            this.Day.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "Dag";
            this.Day.Name = "Day";
            this.Day.Width = 52;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.tbLog);
            this.panelBottom.Controls.Add(this.statusStrip1);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 468);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(922, 107);
            this.panelBottom.TabIndex = 25;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 0);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(922, 85);
            this.tbLog.TabIndex = 14;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.pgBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 85);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(922, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(20, 17);
            this.toolStripStatusLabel1.Text = "Ok";
            // 
            // pgBar
            // 
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(100, 16);
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
            this.ClientSize = new System.Drawing.Size(922, 575);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MainMenuStrip = this.panelTopTopMenu;
            this.Name = "UploadForm";
            this.Text = "Last opp tabell";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.grpManualDateSettings.ResumeLayout(false);
            this.grpManualDateSettings.PerformLayout();
            this.grpAutoDateSettings.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopFill.ResumeLayout(false);
            this.panelTopFill.PerformLayout();
            this.grpManualStatAreaSettings.ResumeLayout(false);
            this.grpManualStatAreaSettings.PerformLayout();
            this.groupLayoutOfData.ResumeLayout(false);
            this.groupLayoutOfData.PerformLayout();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.panelTopTopMenu.ResumeLayout(false);
            this.panelTopTopMenu.PerformLayout();
            this.panelFill.ResumeLayout(false);
            this.tabSelectPreview.ResumeLayout(false);
            this.tabPreviewSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreviewSelection)).EndInit();
            this.tabStatisticsVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldProperties)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpManualDateSettings;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbStatUnitType;
        public System.Windows.Forms.TextBox tbDay;
        public System.Windows.Forms.TextBox tbMonth;
        public System.Windows.Forms.TextBox tbYear;
        public System.Windows.Forms.ComboBox cbYearPart;
        private System.Windows.Forms.GroupBox grpAutoDateSettings;
        private System.Windows.Forms.Button btnCopyDateToAll;
        private System.Windows.Forms.Button btnCopyFirstRowToAll;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelFill;
        public System.Windows.Forms.DataGridView dgvFieldProperties;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar pgBar;
        private System.Windows.Forms.SaveFileDialog dlgSaveCsvFile;
        private System.Windows.Forms.Panel panelTopFill;
        private System.Windows.Forms.MenuStrip panelTopTopMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stengToolStripMenuItem;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.ToolStripMenuItem oppdaterKonfigurasjonFråServerToolStripMenuItem;
        private System.Windows.Forms.ToolStrip topToolBar;
        private System.Windows.Forms.ToolStripButton btnSaveAsCSV;
        private System.Windows.Forms.ToolStripButton btnUploadToAdaptive;
        private System.Windows.Forms.ToolStripButton btnTestParsing;
        private System.Windows.Forms.ToolStripMenuItem lagreSomCSVToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupLayoutOfData;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cbDateFormats;
        private System.Windows.Forms.ToolStripButton btnTest;
        public System.Windows.Forms.ComboBox cbRowCType1;
        public System.Windows.Forms.ComboBox cbColCType1;
        public System.Windows.Forms.ComboBox cbColCType3;
        public System.Windows.Forms.ComboBox cbColCType2;
        public System.Windows.Forms.ComboBox cbRowCType3;
        public System.Windows.Forms.ComboBox cbRowCType2;
        private System.Windows.Forms.TabControl tabSelectPreview;
        private System.Windows.Forms.TabPage tabPreviewSelection;
        private System.Windows.Forms.TabPage tabStatisticsVariables;
        private System.Windows.Forms.DataGridView dgvPreviewSelection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbRowCType4;
        public System.Windows.Forms.ComboBox cbColCType4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewComboBoxColumn VariableType;
        private System.Windows.Forms.DataGridViewComboBoxColumn MeasurementUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewComboBoxColumn YearPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.GroupBox grpManualStatAreaSettings;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
    }
}