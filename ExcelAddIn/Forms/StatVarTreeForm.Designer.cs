namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    partial class StatVarTreeForm
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
            this.lblFilterNodes = new System.Windows.Forms.Label();
            this.tbFilterNodes = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPreviousMatch = new System.Windows.Forms.Button();
            this.btnNextMatch = new System.Windows.Forms.Button();
            this.formPanel.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // svTree
            // 
            this.svTree.Location = new System.Drawing.Point(8, 50);
            this.svTree.Name = "svTree";
            this.svTree.Size = new System.Drawing.Size(383, 364);
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
            this.panelTree.Controls.Add(this.btnNextMatch);
            this.panelTree.Controls.Add(this.btnPreviousMatch);
            this.panelTree.Controls.Add(this.lblFilterNodes);
            this.panelTree.Controls.Add(this.tbFilterNodes);
            this.panelTree.Controls.Add(this.svTree);
            this.panelTree.Controls.Add(this.btnRefreshTree);
            this.panelTree.Location = new System.Drawing.Point(12, 13);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(403, 465);
            this.panelTree.TabIndex = 24;
            // 
            // lblFilterNodes
            // 
            this.lblFilterNodes.AutoSize = true;
            this.lblFilterNodes.Location = new System.Drawing.Point(5, 17);
            this.lblFilterNodes.Name = "lblFilterNodes";
            this.lblFilterNodes.Size = new System.Drawing.Size(98, 17);
            this.lblFilterNodes.TabIndex = 18;
            this.lblFilterNodes.Text = "Søk i variablar";
            // 
            // tbFilterNodes
            // 
            this.tbFilterNodes.Location = new System.Drawing.Point(109, 14);
            this.tbFilterNodes.Name = "tbFilterNodes";
            this.tbFilterNodes.Size = new System.Drawing.Size(212, 22);
            this.tbFilterNodes.TabIndex = 18;
            this.tbFilterNodes.TabStop = false;
            this.tbFilterNodes.TextChanged += new System.EventHandler(this.tbFilterNodes_TextChanged);
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
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMsg});
            this.statusBar.Location = new System.Drawing.Point(0, 486);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(729, 22);
            this.statusBar.TabIndex = 25;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusMsg
            // 
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(0, 17);
            // 
            // btnPreviousMatch
            // 
            this.btnPreviousMatch.Location = new System.Drawing.Point(327, 13);
            this.btnPreviousMatch.Name = "btnPreviousMatch";
            this.btnPreviousMatch.Size = new System.Drawing.Size(30, 26);
            this.btnPreviousMatch.TabIndex = 25;
            this.btnPreviousMatch.Text = "<";
            this.btnPreviousMatch.UseVisualStyleBackColor = true;
            this.btnPreviousMatch.Click += new System.EventHandler(this.btnPreviousMatch_Click);
            // 
            // btnNextMatch
            // 
            this.btnNextMatch.Location = new System.Drawing.Point(363, 13);
            this.btnNextMatch.Name = "btnNextMatch";
            this.btnNextMatch.Size = new System.Drawing.Size(28, 26);
            this.btnNextMatch.TabIndex = 26;
            this.btnNextMatch.Text = ">";
            this.btnNextMatch.UseVisualStyleBackColor = true;
            this.btnNextMatch.Click += new System.EventHandler(this.btnNextMatch_Click);
            // 
            // StatVarTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 508);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.panelTree);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.lblLog);
            this.Name = "StatVarTreeForm";
            this.Text = "Legg til statistikkvariablar";
            this.Load += new System.EventHandler(this.StatVarTreeForm_Load);
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.panelTree.ResumeLayout(false);
            this.panelTree.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
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
        private System.Windows.Forms.Label lblFilterNodes;
        private System.Windows.Forms.TextBox tbFilterNodes;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusMsg;
        private System.Windows.Forms.Button btnNextMatch;
        private System.Windows.Forms.Button btnPreviousMatch;
    }
}