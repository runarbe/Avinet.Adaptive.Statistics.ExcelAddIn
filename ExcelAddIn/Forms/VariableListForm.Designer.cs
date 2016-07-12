namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    partial class VariableListForm
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
            this.lbVariables = new System.Windows.Forms.ListBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSelectVariable = new System.Windows.Forms.Label();
            this.grpFilterArea = new System.Windows.Forms.GroupBox();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.cbSubCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSubCategory = new System.Windows.Forms.Label();
            this.grpFilterArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVariables
            // 
            this.lbVariables.FormattingEnabled = true;
            this.lbVariables.ItemHeight = 16;
            this.lbVariables.Location = new System.Drawing.Point(12, 169);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.Size = new System.Drawing.Size(472, 212);
            this.lbVariables.TabIndex = 0;
            this.lbVariables.SelectedIndexChanged += new System.EventHandler(this.lbVariables_SelectedIndexChanged);
            this.lbVariables.DoubleClick += new System.EventHandler(this.lbVariables_DoubleClick);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(409, 389);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 31);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Enabled = false;
            this.btnAddNew.Location = new System.Drawing.Point(328, 389);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 31);
            this.btnAddNew.TabIndex = 2;
            this.btnAddNew.Text = "Add new";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(247, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblSelectVariable
            // 
            this.lblSelectVariable.AutoSize = true;
            this.lblSelectVariable.Location = new System.Drawing.Point(12, 146);
            this.lblSelectVariable.Name = "lblSelectVariable";
            this.lblSelectVariable.Size = new System.Drawing.Size(101, 17);
            this.lblSelectVariable.TabIndex = 4;
            this.lblSelectVariable.Text = "Select variable";
            // 
            // grpFilterArea
            // 
            this.grpFilterArea.Controls.Add(this.lblCategory);
            this.grpFilterArea.Controls.Add(this.cbCategory);
            this.grpFilterArea.Controls.Add(this.lblSubCategory);
            this.grpFilterArea.Controls.Add(this.cbSubCategory);
            this.grpFilterArea.Location = new System.Drawing.Point(15, 47);
            this.grpFilterArea.Name = "grpFilterArea";
            this.grpFilterArea.Size = new System.Drawing.Size(469, 89);
            this.grpFilterArea.TabIndex = 5;
            this.grpFilterArea.TabStop = false;
            this.grpFilterArea.Text = "Filter (optional)";
            // 
            // tbQuery
            // 
            this.tbQuery.Location = new System.Drawing.Point(100, 14);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(384, 22);
            this.tbQuery.TabIndex = 6;
            this.tbQuery.TextChanged += new System.EventHandler(this.tbQuery_TextChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(12, 17);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(82, 17);
            this.lblQuery.TabIndex = 7;
            this.lblQuery.Text = "Søkeuttrykk";
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(121, 25);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(336, 24);
            this.cbCategory.TabIndex = 0;
            // 
            // cbSubCategory
            // 
            this.cbSubCategory.Enabled = false;
            this.cbSubCategory.FormattingEnabled = true;
            this.cbSubCategory.Location = new System.Drawing.Point(121, 55);
            this.cbSubCategory.Name = "cbSubCategory";
            this.cbSubCategory.Size = new System.Drawing.Size(336, 24);
            this.cbSubCategory.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(10, 28);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 17);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "Hovudkategori";
            // 
            // lblSubCategory
            // 
            this.lblSubCategory.AutoSize = true;
            this.lblSubCategory.Location = new System.Drawing.Point(12, 58);
            this.lblSubCategory.Name = "lblSubCategory";
            this.lblSubCategory.Size = new System.Drawing.Size(98, 17);
            this.lblSubCategory.TabIndex = 9;
            this.lblSubCategory.Text = "Underkategori";
            // 
            // VariableListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 434);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.grpFilterArea);
            this.Controls.Add(this.lblSelectVariable);
            this.Controls.Add(this.lbVariables);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Name = "VariableListForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Select variable";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VariableListForm_Load);
            this.grpFilterArea.ResumeLayout(false);
            this.grpFilterArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lbVariables;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSelectVariable;
        private System.Windows.Forms.GroupBox grpFilterArea;
        private System.Windows.Forms.ComboBox cbSubCategory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSubCategory;
    }
}