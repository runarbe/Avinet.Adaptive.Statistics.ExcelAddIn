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
            this.TabAdaptiveStatistics = this.Factory.CreateRibbonTab();
            this.GroupUploadTools = this.Factory.CreateRibbonGroup();
            this.GroupInformation = this.Factory.CreateRibbonGroup();
            this.BtnUploadSelection = this.Factory.CreateRibbonButton();
            this.ButtonHelp = this.Factory.CreateRibbonButton();
            this.ButtonAbout = this.Factory.CreateRibbonButton();
            this.btnConfig = this.Factory.CreateRibbonButton();
            this.TabAdaptiveStatistics.SuspendLayout();
            this.GroupUploadTools.SuspendLayout();
            this.GroupInformation.SuspendLayout();
            // 
            // TabAdaptiveStatistics
            // 
            this.TabAdaptiveStatistics.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabAdaptiveStatistics.Groups.Add(this.GroupUploadTools);
            this.TabAdaptiveStatistics.Groups.Add(this.GroupInformation);
            this.TabAdaptiveStatistics.Label = "Adaptive 3.0 Statistikkmodul";
            this.TabAdaptiveStatistics.Name = "TabAdaptiveStatistics";
            // 
            // GroupUploadTools
            // 
            this.GroupUploadTools.Items.Add(this.btnConfig);
            this.GroupUploadTools.Items.Add(this.BtnUploadSelection);
            this.GroupUploadTools.Label = "Opplastingsverktøy";
            this.GroupUploadTools.Name = "GroupUploadTools";
            // 
            // GroupInformation
            // 
            this.GroupInformation.Items.Add(this.ButtonHelp);
            this.GroupInformation.Items.Add(this.ButtonAbout);
            this.GroupInformation.Label = "Information";
            this.GroupInformation.Name = "GroupInformation";
            // 
            // BtnUploadSelection
            // 
            this.BtnUploadSelection.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BtnUploadSelection.Image = ((System.Drawing.Image)(resources.GetObject("BtnUploadSelection.Image")));
            this.BtnUploadSelection.Label = "Last opp utvalg";
            this.BtnUploadSelection.Name = "BtnUploadSelection";
            this.BtnUploadSelection.ShowImage = true;
            this.BtnUploadSelection.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BtnUploadSelection_Click);
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ButtonHelp.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHelp.Image")));
            this.ButtonHelp.Label = "Hjelp til opplasting";
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.ShowImage = true;
            this.ButtonHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonHelp_Click);
            // 
            // ButtonAbout
            // 
            this.ButtonAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.ButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAbout.Image")));
            this.ButtonAbout.Label = "Om Adaptive Excel Addin";
            this.ButtonAbout.Name = "ButtonAbout";
            this.ButtonAbout.ShowImage = true;
            this.ButtonAbout.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ButtonAbout_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Label = "Konfigurer";
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.ShowImage = true;
            this.btnConfig.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnConfig_Click);
            // 
            // AdaptiveRibbon
            // 
            this.Name = "AdaptiveRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TabAdaptiveStatistics);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.TabAdaptiveStatistics.ResumeLayout(false);
            this.TabAdaptiveStatistics.PerformLayout();
            this.GroupUploadTools.ResumeLayout(false);
            this.GroupUploadTools.PerformLayout();
            this.GroupInformation.ResumeLayout(false);
            this.GroupInformation.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabAdaptiveStatistics;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GroupUploadTools;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BtnUploadSelection;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup GroupInformation;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ButtonHelp;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ButtonAbout;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnConfig;
    }

    partial class ThisRibbonCollection
    {
        internal AdaptiveRibbon Ribbon1
        {
            get { return this.GetRibbon<AdaptiveRibbon>(); }
        }
    }
}
