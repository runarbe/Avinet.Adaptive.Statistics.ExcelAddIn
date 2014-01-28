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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDataInCols = new System.Windows.Forms.RadioButton();
            this.rbDataInRows = new System.Windows.Forms.RadioButton();
            this.tbDay = new System.Windows.Forms.TextBox();
            this.tbMonth = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbYearPart = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopyFirstRowToAll = new System.Windows.Forms.Button();
            this.btnCopyDateToAll = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbStatUnitType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbStatUnitGroupField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatUnitNameField = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatUnitField = new System.Windows.Forms.ComboBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelTopFill = new System.Windows.Forms.Panel();
            this.lblStatVariables = new System.Windows.Forms.Label();
            this.panelTopTopMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stengToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFill = new System.Windows.Forms.Panel();
            this.dgvFieldProperties = new System.Windows.Forms.DataGridView();
            this.FieldIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Include = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.topToolBar = new System.Windows.Forms.ToolStrip();
            this.btnSaveAsCSV = new System.Windows.Forms.ToolStripButton();
            this.btnUploadToAdaptive = new System.Windows.Forms.ToolStripButton();
            this.btnTestParsing = new System.Windows.Forms.ToolStripButton();
            this.lagreSomCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelTopFill.SuspendLayout();
            this.panelTopTopMenu.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldProperties)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.topToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDataInCols);
            this.groupBox1.Controls.Add(this.rbDataInRows);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type utval";
            // 
            // rbDataInCols
            // 
            this.rbDataInCols.AutoSize = true;
            this.rbDataInCols.Location = new System.Drawing.Point(25, 43);
            this.rbDataInCols.Name = "rbDataInCols";
            this.rbDataInCols.Size = new System.Drawing.Size(258, 17);
            this.rbDataInCols.TabIndex = 1;
            this.rbDataInCols.TabStop = true;
            this.rbDataInCols.Text = "Statistikkvariablar i kolonner, kretsar/namn i rader";
            this.rbDataInCols.UseVisualStyleBackColor = true;
            this.rbDataInCols.CheckedChanged += new System.EventHandler(this.rbFirstColumn_CheckedChanged);
            // 
            // rbDataInRows
            // 
            this.rbDataInRows.AutoSize = true;
            this.rbDataInRows.Location = new System.Drawing.Point(25, 20);
            this.rbDataInRows.Name = "rbDataInRows";
            this.rbDataInRows.Size = new System.Drawing.Size(258, 17);
            this.rbDataInRows.TabIndex = 0;
            this.rbDataInRows.TabStop = true;
            this.rbDataInRows.Text = "Statistikkvariablar i rader, kretsar/namn i kolonner";
            this.rbDataInRows.UseVisualStyleBackColor = true;
            this.rbDataInRows.CheckedChanged += new System.EventHandler(this.rbFirstRow_CheckedChanged);
            // 
            // tbDay
            // 
            this.tbDay.Location = new System.Drawing.Point(255, 32);
            this.tbDay.Name = "tbDay";
            this.tbDay.Size = new System.Drawing.Size(81, 20);
            this.tbDay.TabIndex = 9;
            // 
            // tbMonth
            // 
            this.tbMonth.Location = new System.Drawing.Point(172, 32);
            this.tbMonth.Name = "tbMonth";
            this.tbMonth.Size = new System.Drawing.Size(78, 20);
            this.tbMonth.TabIndex = 8;
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(6, 31);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(78, 20);
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
            this.label3.Location = new System.Drawing.Point(86, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Periode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Månad";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(252, 16);
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
            this.cbYearPart.Location = new System.Drawing.Point(89, 31);
            this.cbYearPart.Name = "cbYearPart";
            this.cbYearPart.Size = new System.Drawing.Size(78, 21);
            this.cbYearPart.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbYearPart);
            this.groupBox2.Controls.Add(this.tbYear);
            this.groupBox2.Controls.Add(this.tbMonth);
            this.groupBox2.Controls.Add(this.tbDay);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnCopyFirstRowToAll);
            this.groupBox2.Controls.Add(this.btnCopyDateToAll);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(384, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 193);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datering";
            // 
            // btnCopyFirstRowToAll
            // 
            this.btnCopyFirstRowToAll.Location = new System.Drawing.Point(6, 87);
            this.btnCopyFirstRowToAll.Name = "btnCopyFirstRowToAll";
            this.btnCopyFirstRowToAll.Size = new System.Drawing.Size(330, 23);
            this.btnCopyFirstRowToAll.TabIndex = 4;
            this.btnCopyFirstRowToAll.Text = "Kopier fyrste rad til alle";
            this.btnCopyFirstRowToAll.UseVisualStyleBackColor = true;
            this.btnCopyFirstRowToAll.Click += new System.EventHandler(this.btnCopyFirstRowToAll_Click);
            // 
            // btnCopyDateToAll
            // 
            this.btnCopyDateToAll.Location = new System.Drawing.Point(6, 58);
            this.btnCopyDateToAll.Name = "btnCopyDateToAll";
            this.btnCopyDateToAll.Size = new System.Drawing.Size(330, 23);
            this.btnCopyDateToAll.TabIndex = 16;
            this.btnCopyDateToAll.Text = "Kopier dato til alle rader";
            this.btnCopyDateToAll.UseVisualStyleBackColor = true;
            this.btnCopyDateToAll.Click += new System.EventHandler(this.btnCopyDateToAll_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 21);
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
            this.cbStatUnitType.Location = new System.Drawing.Point(9, 37);
            this.cbStatUnitType.Name = "cbStatUnitType";
            this.cbStatUnitType.Size = new System.Drawing.Size(179, 21);
            this.cbStatUnitType.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbStatUnitGroupField);
            this.groupBox3.Controls.Add(this.cbStatUnitNameField);
            this.groupBox3.Controls.Add(this.cbStatUnitField);
            this.groupBox3.Controls.Add(this.cbStatUnitType);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(3, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 112);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metadata";
            // 
            // cbStatUnitGroupField
            // 
            this.cbStatUnitGroupField.FormattingEnabled = true;
            this.cbStatUnitGroupField.Items.AddRange(new object[] {
            "1. kvartal",
            "2. kvartal",
            "3. kvartal",
            "4. kvartal",
            "1. tertial",
            "2. tertial",
            "3. tertial",
            "1. halvår",
            "2. halvår"});
            this.cbStatUnitGroupField.Location = new System.Drawing.Point(193, 79);
            this.cbStatUnitGroupField.Name = "cbStatUnitGroupField";
            this.cbStatUnitGroupField.Size = new System.Drawing.Size(179, 21);
            this.cbStatUnitGroupField.TabIndex = 20;
            this.cbStatUnitGroupField.SelectedIndexChanged += new System.EventHandler(this.cbStatUnitGroupField_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Felt med kretsnamn (td kommune)";
            // 
            // cbStatUnitNameField
            // 
            this.cbStatUnitNameField.FormattingEnabled = true;
            this.cbStatUnitNameField.Items.AddRange(new object[] {
            "1. kvartal",
            "2. kvartal",
            "3. kvartal",
            "4. kvartal",
            "1. tertial",
            "2. tertial",
            "3. tertial",
            "1. halvår",
            "2. halvår"});
            this.cbStatUnitNameField.Location = new System.Drawing.Point(193, 37);
            this.cbStatUnitNameField.Name = "cbStatUnitNameField";
            this.cbStatUnitNameField.Size = new System.Drawing.Size(179, 21);
            this.cbStatUnitNameField.TabIndex = 18;
            this.cbStatUnitNameField.SelectedIndexChanged += new System.EventHandler(this.cbStatUnitNameField_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Felt med gruppeverdi (td region)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Felt med krets-IDar (td kommunenr)";
            // 
            // cbStatUnitField
            // 
            this.cbStatUnitField.FormattingEnabled = true;
            this.cbStatUnitField.Items.AddRange(new object[] {
            "1. kvartal",
            "2. kvartal",
            "3. kvartal",
            "4. kvartal",
            "1. tertial",
            "2. tertial",
            "3. tertial",
            "1. halvår",
            "2. halvår"});
            this.cbStatUnitField.Location = new System.Drawing.Point(8, 79);
            this.cbStatUnitField.Name = "cbStatUnitField";
            this.cbStatUnitField.Size = new System.Drawing.Size(179, 21);
            this.cbStatUnitField.TabIndex = 15;
            this.cbStatUnitField.SelectedIndexChanged += new System.EventHandler(this.cbStatisticalUnitField_SelectedIndexChanged);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelTopFill);
            this.panelTop.Controls.Add(this.topToolBar);
            this.panelTop.Controls.Add(this.panelTopTopMenu);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(732, 284);
            this.panelTop.TabIndex = 22;
            // 
            // panelTopFill
            // 
            this.panelTopFill.Controls.Add(this.lblStatVariables);
            this.panelTopFill.Controls.Add(this.groupBox2);
            this.panelTopFill.Controls.Add(this.groupBox1);
            this.panelTopFill.Controls.Add(this.groupBox3);
            this.panelTopFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopFill.Location = new System.Drawing.Point(0, 49);
            this.panelTopFill.Name = "panelTopFill";
            this.panelTopFill.Size = new System.Drawing.Size(732, 235);
            this.panelTopFill.TabIndex = 23;
            // 
            // lblStatVariables
            // 
            this.lblStatVariables.AutoSize = true;
            this.lblStatVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatVariables.Location = new System.Drawing.Point(3, 215);
            this.lblStatVariables.Name = "lblStatVariables";
            this.lblStatVariables.Size = new System.Drawing.Size(200, 13);
            this.lblStatVariables.TabIndex = 23;
            this.lblStatVariables.Text = "Eigenskapar for statistikkvariablar";
            // 
            // panelTopTopMenu
            // 
            this.panelTopTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.panelTopTopMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTopTopMenu.Name = "panelTopTopMenu";
            this.panelTopTopMenu.Size = new System.Drawing.Size(732, 24);
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
            // stengToolStripMenuItem
            // 
            this.stengToolStripMenuItem.Name = "stengToolStripMenuItem";
            this.stengToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.stengToolStripMenuItem.Text = "Steng vindauge";
            this.stengToolStripMenuItem.Click += new System.EventHandler(this.stengToolStripMenuItem_Click);
            // 
            // oppdaterKonfigurasjonFråServerToolStripMenuItem
            // 
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Name = "oppdaterKonfigurasjonFråServerToolStripMenuItem";
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Text = "Oppdater konfigurasjon frå server";
            this.oppdaterKonfigurasjonFråServerToolStripMenuItem.Click += new System.EventHandler(this.updateConfigFromServer);
            // 
            // panelFill
            // 
            this.panelFill.Controls.Add(this.dgvFieldProperties);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 284);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(732, 184);
            this.panelFill.TabIndex = 24;
            // 
            // dgvFieldProperties
            // 
            this.dgvFieldProperties.AllowUserToAddRows = false;
            this.dgvFieldProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFieldProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldIndex,
            this.Include,
            this.Title,
            this.VariableType,
            this.MeasurementUnit,
            this.Year,
            this.YearPart,
            this.Month,
            this.Day});
            this.dgvFieldProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFieldProperties.Location = new System.Drawing.Point(0, 0);
            this.dgvFieldProperties.Name = "dgvFieldProperties";
            this.dgvFieldProperties.Size = new System.Drawing.Size(732, 184);
            this.dgvFieldProperties.TabIndex = 0;
            // 
            // FieldIndex
            // 
            this.FieldIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.FieldIndex.DataPropertyName = "RowIndex";
            this.FieldIndex.HeaderText = "Feltnr";
            this.FieldIndex.Name = "FieldIndex";
            this.FieldIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FieldIndex.Width = 5;
            // 
            // Include
            // 
            this.Include.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Include.DataPropertyName = "Include";
            this.Include.FalseValue = "false";
            this.Include.HeaderText = "Inkluder";
            this.Include.IndeterminateValue = "false";
            this.Include.MinimumWidth = 20;
            this.Include.Name = "Include";
            this.Include.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Include.TrueValue = "true";
            this.Include.Width = 20;
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
            this.panelBottom.Size = new System.Drawing.Size(732, 107);
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
            this.tbLog.Size = new System.Drawing.Size(732, 85);
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
            this.statusStrip1.Size = new System.Drawing.Size(732, 22);
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
            // topToolBar
            // 
            this.topToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveAsCSV,
            this.btnUploadToAdaptive,
            this.btnTestParsing});
            this.topToolBar.Location = new System.Drawing.Point(0, 24);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Size = new System.Drawing.Size(732, 25);
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
            // lagreSomCSVToolStripMenuItem
            // 
            this.lagreSomCSVToolStripMenuItem.Name = "lagreSomCSVToolStripMenuItem";
            this.lagreSomCSVToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.lagreSomCSVToolStripMenuItem.Text = "Lagre som CSV";
            this.lagreSomCSVToolStripMenuItem.Click += new System.EventHandler(this.lagreSomCSVToolStripMenuItem_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 575);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MainMenuStrip = this.panelTopTopMenu;
            this.Name = "UploadForm";
            this.Text = "Last opp tabell";
            this.Load += new System.EventHandler(this.UploadForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTopFill.ResumeLayout(false);
            this.panelTopFill.PerformLayout();
            this.panelTopTopMenu.ResumeLayout(false);
            this.panelTopTopMenu.PerformLayout();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFieldProperties)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.topToolBar.ResumeLayout(false);
            this.topToolBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox cbStatUnitType;
        public System.Windows.Forms.RadioButton rbDataInCols;
        public System.Windows.Forms.RadioButton rbDataInRows;
        public System.Windows.Forms.TextBox tbDay;
        public System.Windows.Forms.TextBox tbMonth;
        public System.Windows.Forms.TextBox tbYear;
        public System.Windows.Forms.ComboBox cbYearPart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbStatUnitField;
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
        private System.Windows.Forms.Label lblStatVariables;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbStatUnitNameField;
        public System.Windows.Forms.ComboBox cbStatUnitGroupField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem oppdaterKonfigurasjonFråServerToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Include;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewComboBoxColumn VariableType;
        private System.Windows.Forms.DataGridViewComboBoxColumn MeasurementUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewComboBoxColumn YearPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.ToolStrip topToolBar;
        private System.Windows.Forms.ToolStripButton btnSaveAsCSV;
        private System.Windows.Forms.ToolStripButton btnUploadToAdaptive;
        private System.Windows.Forms.ToolStripButton btnTestParsing;
        private System.Windows.Forms.ToolStripMenuItem lagreSomCSVToolStripMenuItem;
    }
}