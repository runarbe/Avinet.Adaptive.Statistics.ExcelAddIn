namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    partial class AdaptiveRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AdaptiveRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdaptiveRibbon));
            this.TabDefault = this.Factory.CreateRibbonTab();
            this.TabAdaptive3 = this.Factory.CreateRibbonTab();
            this.grpTools = this.Factory.CreateRibbonGroup();
            this.lblSelectedState = this.Factory.CreateRibbonLabel();
            this.lblNameOfSelectedState = this.Factory.CreateRibbonLabel();
            this.grpSettings = this.Factory.CreateRibbonGroup();
            this.grpInfo = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btnEditStatVar = this.Factory.CreateRibbonButton();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.btnRestoreData = this.Factory.CreateRibbonButton();
            this.btnUploadWithState = this.Factory.CreateRibbonButton();
            this.btnConfig = this.Factory.CreateRibbonButton();
            this.btnExportSavedStates = this.Factory.CreateRibbonButton();
            this.btnImportSavedStates = this.Factory.CreateRibbonButton();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.btnOpenLogFileDir = this.Factory.CreateRibbonButton();
            this.TabDefault.SuspendLayout();
            this.TabAdaptive3.SuspendLayout();
            this.grpTools.SuspendLayout();
            this.grpSettings.SuspendLayout();
            this.grpInfo.SuspendLayout();
            // 
            // TabDefault
            // 
            this.TabDefault.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabDefault.Label = "Default";
            this.TabDefault.Name = "TabDefault";
            // 
            // TabAdaptive3
            // 
            this.TabAdaptive3.Groups.Add(this.grpTools);
            this.TabAdaptive3.Groups.Add(this.grpSettings);
            this.TabAdaptive3.Groups.Add(this.grpInfo);
            this.TabAdaptive3.Label = "ADAPTIVE 3.0";
            this.TabAdaptive3.Name = "TabAdaptive3";
            // 
            // grpTools
            // 
            this.grpTools.Items.Add(this.btnEditStatVar);
            this.grpTools.Items.Add(this.btnUpload);
            this.grpTools.Items.Add(this.btnRestoreData);
            this.grpTools.Items.Add(this.lblSelectedState);
            this.grpTools.Items.Add(this.lblNameOfSelectedState);
            this.grpTools.Items.Add(this.btnUploadWithState);
            this.grpTools.Label = "Verkty";
            this.grpTools.Name = "grpTools";
            // 
            // lblSelectedState
            // 
            this.lblSelectedState.Label = "Valt oppsett";
            this.lblSelectedState.Name = "lblSelectedState";
            this.lblSelectedState.Visible = false;
            // 
            // lblNameOfSelectedState
            // 
            this.lblNameOfSelectedState.Label = "N/A";
            this.lblNameOfSelectedState.Name = "lblNameOfSelectedState";
            this.lblNameOfSelectedState.Visible = false;
            // 
            // grpSettings
            // 
            this.grpSettings.Items.Add(this.btnConfig);
            this.grpSettings.Items.Add(this.btnExportSavedStates);
            this.grpSettings.Items.Add(this.btnImportSavedStates);
            this.grpSettings.Label = "Innstillingar";
            this.grpSettings.Name = "grpSettings";
            // 
            // grpInfo
            // 
            this.grpInfo.Items.Add(this.btnHelp);
            this.grpInfo.Items.Add(this.btnAbout);
            this.grpInfo.Items.Add(this.btnOpenLogFileDir);
            this.grpInfo.Items.Add(this.button1);
            this.grpInfo.Label = "Informasjon";
            this.grpInfo.Name = "grpInfo";
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Visible = false;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btnEditStatVar
            // 
            this.btnEditStatVar.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnEditStatVar.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.hierarchy;
            this.btnEditStatVar.Label = "Legg til variablar";
            this.btnEditStatVar.Name = "btnEditStatVar";
            this.btnEditStatVar.ShowImage = true;
            this.btnEditStatVar.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEditStatVar_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUpload.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.cloud_icon_24;
            this.btnUpload.Label = "Last opp utval";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.ShowImage = true;
            this.btnUpload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpload_Click);
            // 
            // btnRestoreData
            // 
            this.btnRestoreData.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnRestoreData.Image = ((System.Drawing.Image)(resources.GetObject("btnRestoreData.Image")));
            this.btnRestoreData.Label = "Hent data frå lagra oppsett";
            this.btnRestoreData.Name = "btnRestoreData";
            this.btnRestoreData.ShowImage = true;
            this.btnRestoreData.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnRestoreData_Click);
            // 
            // btnUploadWithState
            // 
            this.btnUploadWithState.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUploadWithState.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.cloud_icon_24;
            this.btnUploadWithState.Label = "Last opp utval med oppsett...";
            this.btnUploadWithState.Name = "btnUploadWithState";
            this.btnUploadWithState.ShowImage = true;
            this.btnUploadWithState.Visible = false;
            // 
            // btnConfig
            // 
            this.btnConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Label = "Konfigurer Adaptive";
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.ShowImage = true;
            this.btnConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfig_Click);
            // 
            // btnExportSavedStates
            // 
            this.btnExportSavedStates.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnExportSavedStates.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.export_bw;
            this.btnExportSavedStates.Label = "Eksporter lagra oppsett";
            this.btnExportSavedStates.Name = "btnExportSavedStates";
            this.btnExportSavedStates.ShowImage = true;
            this.btnExportSavedStates.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnExportSavedStates_Click);
            // 
            // btnImportSavedStates
            // 
            this.btnImportSavedStates.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnImportSavedStates.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.import_bw;
            this.btnImportSavedStates.Label = "Importer lagra oppsett";
            this.btnImportSavedStates.Name = "btnImportSavedStates";
            this.btnImportSavedStates.ShowImage = true;
            this.btnImportSavedStates.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnImportSavedStates_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Label = "Hjelp til opplasting";
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ShowImage = true;
            this.btnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHelp_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.Label = "Om Adaptive Excel Addin";
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ShowImage = true;
            this.btnAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAbout_Click);
            // 
            // btnOpenLogFileDir
            // 
            this.btnOpenLogFileDir.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnOpenLogFileDir.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.win_explorer;
            this.btnOpenLogFileDir.Label = "Åpne loggfilkatalog";
            this.btnOpenLogFileDir.Name = "btnOpenLogFileDir";
            this.btnOpenLogFileDir.ShowImage = true;
            this.btnOpenLogFileDir.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnOpenLogFileDir_Click);
            // 
            // AdaptiveRibbon
            // 
            this.Name = "AdaptiveRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabDefault);
            this.Tabs.Add(this.TabAdaptive3);
            this.TabDefault.ResumeLayout(false);
            this.TabDefault.PerformLayout();
            this.TabAdaptive3.ResumeLayout(false);
            this.TabAdaptive3.PerformLayout();
            this.grpTools.ResumeLayout(false);
            this.grpTools.PerformLayout();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabDefault;
        private Microsoft.Office.Tools.Ribbon.RibbonTab TabAdaptive3;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfig;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUpload;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpInfo;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditStatVar;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRestoreData;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnUploadWithState;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel lblSelectedState;
        internal Microsoft.Office.Tools.Ribbon.RibbonLabel lblNameOfSelectedState;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnExportSavedStates;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnImportSavedStates;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnOpenLogFileDir;
    }

    partial class ThisRibbonCollection
    {
        internal AdaptiveRibbon Ribbon1
        {
            get { return this.GetRibbon<AdaptiveRibbon>(); }
        }
    }
}
