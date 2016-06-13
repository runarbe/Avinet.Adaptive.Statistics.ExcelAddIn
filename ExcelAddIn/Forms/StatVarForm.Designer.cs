namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    partial class StatVarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param title="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.svTree = new System.Windows.Forms.TreeView();
            this.formPanel = new System.Windows.Forms.Panel();
            this.tbVarName = new System.Windows.Forms.TextBox();
            this.tbVarLevel = new System.Windows.Forms.TextBox();
            this.tbParentVariable = new System.Windows.Forms.TextBox();
            this.lblVarLevel = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblVarName = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnRefreshTree = new System.Windows.Forms.Button();
            this.panelTree = new System.Windows.Forms.Panel();
            this.lblLog = new System.Windows.Forms.Label();
            this.formPanel.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // svTree
            // 
            this.svTree.Location = new System.Drawing.Point(8, 11);
            this.svTree.Name = "svTree";
            this.svTree.Size = new System.Drawing.Size(383, 403);
            this.svTree.TabIndex = 0;
            this.svTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.svTree_AfterSelect);
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.tbVarName);
            this.formPanel.Controls.Add(this.tbVarLevel);
            this.formPanel.Controls.Add(this.tbParentVariable);
            this.formPanel.Controls.Add(this.lblVarLevel);
            this.formPanel.Controls.Add(this.lblParent);
            this.formPanel.Controls.Add(this.lblVarName);
            this.formPanel.Controls.Add(this.btnCreateNew);
            this.formPanel.Location = new System.Drawing.Point(421, 13);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(296, 174);
            this.formPanel.TabIndex = 1;
            // 
            // tbVarName
            // 
            this.tbVarName.Location = new System.Drawing.Point(114, 84);
            this.tbVarName.Name = "tbVarName";
            this.tbVarName.Size = new System.Drawing.Size(166, 22);
            this.tbVarName.TabIndex = 0;
            // 
            // tbVarLevel
            // 
            this.tbVarLevel.Enabled = false;
            this.tbVarLevel.Location = new System.Drawing.Point(114, 50);
            this.tbVarLevel.Name = "tbVarLevel";
            this.tbVarLevel.Size = new System.Drawing.Size(38, 22);
            this.tbVarLevel.TabIndex = 1;
            this.tbVarLevel.TabStop = false;
            // 
            // tbParentVariable
            // 
            this.tbParentVariable.Enabled = false;
            this.tbParentVariable.Location = new System.Drawing.Point(114, 17);
            this.tbParentVariable.Name = "tbParentVariable";
            this.tbParentVariable.Size = new System.Drawing.Size(166, 22);
            this.tbParentVariable.TabIndex = 0;
            this.tbParentVariable.TabStop = false;
            // 
            // lblVarLevel
            // 
            this.lblVarLevel.AutoSize = true;
            this.lblVarLevel.Location = new System.Drawing.Point(8, 53);
            this.lblVarLevel.Name = "lblVarLevel";
            this.lblVarLevel.Size = new System.Drawing.Size(71, 17);
            this.lblVarLevel.TabIndex = 17;
            this.lblVarLevel.Text = "Nivå (1-5)";
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(8, 20);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(64, 17);
            this.lblParent.TabIndex = 16;
            this.lblParent.Text = "Tilhøyrer";
            // 
            // lblVarName
            // 
            this.lblVarName.AutoSize = true;
            this.lblVarName.Location = new System.Drawing.Point(8, 87);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(45, 17);
            this.lblVarName.TabIndex = 17;
            this.lblVarName.Text = "Namn";
            this.lblVarName.Click += new System.EventHandler(this.lblVarName_Click);
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(11, 125);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(269, 33);
            this.btnCreateNew.TabIndex = 5;
            this.btnCreateNew.Text = "Opprett ny variabel";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(421, 234);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(296, 244);
            this.tbLog.TabIndex = 5;
            // 
            // btnRefreshTree
            // 
            this.btnRefreshTree.Location = new System.Drawing.Point(8, 420);
            this.btnRefreshTree.Name = "btnRefreshTree";
            this.btnRefreshTree.Size = new System.Drawing.Size(383, 33);
            this.btnRefreshTree.TabIndex = 24;
            this.btnRefreshTree.Text = "Last variablar på nytt";
            this.btnRefreshTree.UseVisualStyleBackColor = true;
            this.btnRefreshTree.Click += new System.EventHandler(this.btnRefreshTree_Click);
            // 
            // panelTree
            // 
            this.panelTree.Controls.Add(this.svTree);
            this.panelTree.Controls.Add(this.btnRefreshTree);
            this.panelTree.Location = new System.Drawing.Point(12, 13);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(403, 465);
            this.panelTree.TabIndex = 24;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(423, 199);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(70, 17);
            this.lblLog.TabIndex = 17;
            this.lblLog.Text = "Meldingar";
            this.lblLog.Click += new System.EventHandler(this.lblVarName_Click);
            // 
            // StatVarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 490);
            this.Controls.Add(this.panelTree);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblLog);
            this.Name = "StatVarForm";
            this.Text = "Legg til statistikkvariablar";
            this.Load += new System.EventHandler(this.StatVarTreeForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.panelTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView svTree;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox tbParentVariable;
        private System.Windows.Forms.TextBox tbVarLevel;
        private System.Windows.Forms.Label lblVarLevel;
        private System.Windows.Forms.Button btnRefreshTree;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblVarName;
        private System.Windows.Forms.TextBox tbVarName;
    }
}