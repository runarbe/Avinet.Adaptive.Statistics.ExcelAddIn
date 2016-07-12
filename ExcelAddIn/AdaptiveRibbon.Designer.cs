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
            this.btnConfig = this.Factory.CreateRibbonButton();
            this.btnUpload = this.Factory.CreateRibbonButton();
            this.btnMergeSavedImportSettings = this.Factory.CreateRibbonButton();
            this.btnSaveImportSettings = this.Factory.CreateRibbonButton();
            this.btnEditStatVar = this.Factory.CreateRibbonButton();
            this.grpInfo = this.Factory.CreateRibbonGroup();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.btnAbout = this.Factory.CreateRibbonButton();
            this.TabDefault.SuspendLayout();
            this.TabAdaptive3.SuspendLayout();
            this.grpTools.SuspendLayout();
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
            this.TabAdaptive3.Groups.Add(this.grpInfo);
            this.TabAdaptive3.Label = "ADAPTIVE 3.0";
            this.TabAdaptive3.Name = "TabAdaptive3";
            // 
            // grpTools
            // 
            this.grpTools.Items.Add(this.btnConfig);
            this.grpTools.Items.Add(this.btnUpload);
            this.grpTools.Items.Add(this.btnMergeSavedImportSettings);
            this.grpTools.Items.Add(this.btnSaveImportSettings);
            this.grpTools.Items.Add(this.btnEditStatVar);
            this.grpTools.Label = "Verkty";
            this.grpTools.Name = "grpTools";
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
            // btnUpload
            // 
            this.btnUpload.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnUpload.Image = ((System.Drawing.Image)(resources.GetObject("btnUpload.Image")));
            this.btnUpload.Label = "Last opp utval";
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.ShowImage = true;
            this.btnUpload.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnUpload_Click);
            // 
            // btnMergeSavedImportSettings
            // 
            this.btnMergeSavedImportSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMergeSavedImportSettings.Enabled = false;
            this.btnMergeSavedImportSettings.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.merge;
            this.btnMergeSavedImportSettings.Label = "Slå saman importinnstillingar";
            this.btnMergeSavedImportSettings.Name = "btnMergeSavedImportSettings";
            this.btnMergeSavedImportSettings.ShowImage = true;
            this.btnMergeSavedImportSettings.Visible = false;
            this.btnMergeSavedImportSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnMergeSavedImportSettings_Click);
            // 
            // btnSaveImportSettings
            // 
            this.btnSaveImportSettings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSaveImportSettings.Enabled = false;
            this.btnSaveImportSettings.Image = global::Avinet.Adaptive.Statistics.ExcelAddIn.Properties.Resources.upload;
            this.btnSaveImportSettings.Label = "Eksporter oppsett for opplasting";
            this.btnSaveImportSettings.Name = "btnSaveImportSettings";
            this.btnSaveImportSettings.ShowImage = true;
            this.btnSaveImportSettings.Visible = false;
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
            // grpInfo
            // 
            this.grpInfo.Items.Add(this.btnHelp);
            this.grpInfo.Items.Add(this.btnAbout);
            this.grpInfo.Label = "Informasjon";
            this.grpInfo.Name = "grpInfo";
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
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMergeSavedImportSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSaveImportSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEditStatVar;
    }

    partial class ThisRibbonCollection
    {
        internal AdaptiveRibbon Ribbon1
        {
            get { return this.GetRibbon<AdaptiveRibbon>(); }
        }
    }
}
