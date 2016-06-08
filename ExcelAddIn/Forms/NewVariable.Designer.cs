namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    partial class NewVariable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.tbVarName = new System.Windows.Forms.TextBox();
            this.tbVarLevel = new System.Windows.Forms.TextBox();
            this.tbParentVariable = new System.Windows.Forms.TextBox();
            this.chkbShowUnit = new System.Windows.Forms.CheckBox();
            this.cbKretstyper = new System.Windows.Forms.ComboBox();
            this.cbTimeUnit = new System.Windows.Forms.ComboBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.lblKrinstype = new System.Windows.Forms.Label();
            this.lblTimeUnit = new System.Windows.Forms.Label();
            this.lblVarLevel = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblVarName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbVarName
            // 
            this.tbVarName.Location = new System.Drawing.Point(168, 84);
            this.tbVarName.Name = "tbVarName";
            this.tbVarName.Size = new System.Drawing.Size(166, 22);
            this.tbVarName.TabIndex = 0;
            // 
            // tbVarLevel
            // 
            this.tbVarLevel.Enabled = false;
            this.tbVarLevel.Location = new System.Drawing.Point(168, 50);
            this.tbVarLevel.Name = "tbVarLevel";
            this.tbVarLevel.ReadOnly = true;
            this.tbVarLevel.Size = new System.Drawing.Size(38, 22);
            this.tbVarLevel.TabIndex = 30;
            // 
            // tbParentVariable
            // 
            this.tbParentVariable.Enabled = false;
            this.tbParentVariable.Location = new System.Drawing.Point(168, 17);
            this.tbParentVariable.Name = "tbParentVariable";
            this.tbParentVariable.ReadOnly = true;
            this.tbParentVariable.Size = new System.Drawing.Size(166, 22);
            this.tbParentVariable.TabIndex = 31;
            // 
            // chkbShowUnit
            // 
            this.chkbShowUnit.AutoSize = true;
            this.chkbShowUnit.Location = new System.Drawing.Point(285, 155);
            this.chkbShowUnit.Name = "chkbShowUnit";
            this.chkbShowUnit.Size = new System.Drawing.Size(49, 21);
            this.chkbShowUnit.TabIndex = 3;
            this.chkbShowUnit.Text = "Vis";
            this.chkbShowUnit.UseVisualStyleBackColor = true;
            // 
            // cbKretstyper
            // 
            this.cbKretstyper.FormattingEnabled = true;
            this.cbKretstyper.Location = new System.Drawing.Point(168, 118);
            this.cbKretstyper.Name = "cbKretstyper";
            this.cbKretstyper.Size = new System.Drawing.Size(166, 24);
            this.cbKretstyper.TabIndex = 1;
            // 
            // cbTimeUnit
            // 
            this.cbTimeUnit.FormattingEnabled = true;
            this.cbTimeUnit.Location = new System.Drawing.Point(168, 188);
            this.cbTimeUnit.Name = "cbTimeUnit";
            this.cbTimeUnit.Size = new System.Drawing.Size(166, 24);
            this.cbTimeUnit.TabIndex = 4;
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(168, 153);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(111, 24);
            this.cbUnit.TabIndex = 2;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(5, 231);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(329, 33);
            this.btnCreateNew.TabIndex = 5;
            this.btnCreateNew.Text = "Opprett ny variabel";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // lblKrinstype
            // 
            this.lblKrinstype.AutoSize = true;
            this.lblKrinstype.Location = new System.Drawing.Point(12, 122);
            this.lblKrinstype.Name = "lblKrinstype";
            this.lblKrinstype.Size = new System.Drawing.Size(67, 17);
            this.lblKrinstype.TabIndex = 38;
            this.lblKrinstype.Text = "Krinstype";
            // 
            // lblTimeUnit
            // 
            this.lblTimeUnit.AutoSize = true;
            this.lblTimeUnit.Location = new System.Drawing.Point(12, 192);
            this.lblTimeUnit.Name = "lblTimeUnit";
            this.lblTimeUnit.Size = new System.Drawing.Size(103, 17);
            this.lblTimeUnit.TabIndex = 34;
            this.lblTimeUnit.Text = "Tidsoppløysing";
            // 
            // lblVarLevel
            // 
            this.lblVarLevel.AutoSize = true;
            this.lblVarLevel.Location = new System.Drawing.Point(12, 53);
            this.lblVarLevel.Name = "lblVarLevel";
            this.lblVarLevel.Size = new System.Drawing.Size(71, 17);
            this.lblVarLevel.TabIndex = 35;
            this.lblVarLevel.Text = "Nivå (1-5)";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(12, 157);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(76, 17);
            this.lblUnit.TabIndex = 36;
            this.lblUnit.Text = "Måleeining";
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Location = new System.Drawing.Point(12, 20);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(130, 17);
            this.lblParent.TabIndex = 33;
            this.lblParent.Text = "Overordna variabel";
            // 
            // lblVarName
            // 
            this.lblVarName.AutoSize = true;
            this.lblVarName.Location = new System.Drawing.Point(12, 87);
            this.lblVarName.Name = "lblVarName";
            this.lblVarName.Size = new System.Drawing.Size(45, 17);
            this.lblVarName.TabIndex = 37;
            this.lblVarName.Text = "Namn";
            // 
            // NewVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 276);
            this.Controls.Add(this.lblKrinstype);
            this.Controls.Add(this.lblTimeUnit);
            this.Controls.Add(this.lblVarLevel);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblVarName);
            this.Controls.Add(this.tbVarName);
            this.Controls.Add(this.tbVarLevel);
            this.Controls.Add(this.tbParentVariable);
            this.Controls.Add(this.chkbShowUnit);
            this.Controls.Add(this.cbKretstyper);
            this.Controls.Add(this.cbTimeUnit);
            this.Controls.Add(this.cbUnit);
            this.Controls.Add(this.btnCreateNew);
            this.Name = "NewVariable";
            this.Text = "Opprett ny statistikk variabel";
            this.Load += new System.EventHandler(this.NewVariable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbParentVariable;
        private System.Windows.Forms.CheckBox chkbShowUnit;
        private System.Windows.Forms.ComboBox cbKretstyper;
        private System.Windows.Forms.ComboBox cbTimeUnit;
        private System.Windows.Forms.ComboBox cbUnit;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label lblKrinstype;
        private System.Windows.Forms.Label lblTimeUnit;
        private System.Windows.Forms.Label lblVarLevel;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblVarName;
        public System.Windows.Forms.TextBox tbVarName;
        public System.Windows.Forms.TextBox tbVarLevel;
    }
}