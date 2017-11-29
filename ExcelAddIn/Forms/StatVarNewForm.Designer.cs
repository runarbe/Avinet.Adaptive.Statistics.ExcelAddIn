namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    partial class StatVarNewForm
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
            this.tbVarName = new System.Windows.Forms.TextBox();
            this.tbVarLevel = new System.Windows.Forms.TextBox();
            this.tbParentVariable = new System.Windows.Forms.TextBox();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.lblVarLevel = new System.Windows.Forms.Label();
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
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(12, 124);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(329, 33);
            this.btnCreateNew.TabIndex = 5;
            this.btnCreateNew.Text = "Opprett ny variabel";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
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
            this.ClientSize = new System.Drawing.Size(348, 172);
            this.Controls.Add(this.lblVarLevel);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblVarName);
            this.Controls.Add(this.tbVarName);
            this.Controls.Add(this.tbVarLevel);
            this.Controls.Add(this.tbParentVariable);
            this.Controls.Add(this.btnCreateNew);
            this.Name = "NewVariable";
            this.Text = "Opprett ny statistikk variabel";
            this.Load += new System.EventHandler(this.NewVariable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbParentVariable;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Label lblVarLevel;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblVarName;
        public System.Windows.Forms.TextBox tbVarName;
        public System.Windows.Forms.TextBox tbVarLevel;
    }
}