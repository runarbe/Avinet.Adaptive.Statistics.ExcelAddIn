namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    partial class ConfigForm
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
            this.tbAdaptiveURI = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFormCaption = new System.Windows.Forms.Label();
            this.tbAdaptiveUser = new System.Windows.Forms.TextBox();
            this.tbAdaptivePwd = new System.Windows.Forms.TextBox();
            this.lblAdaptiveUri = new System.Windows.Forms.Label();
            this.lblAdaptiveUser = new System.Windows.Forms.Label();
            this.lblAdaptivePwd = new System.Windows.Forms.Label();
            this.chbTest = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbAdaptiveURI
            // 
            this.tbAdaptiveURI.Location = new System.Drawing.Point(93, 33);
            this.tbAdaptiveURI.Name = "tbAdaptiveURI";
            this.tbAdaptiveURI.Size = new System.Drawing.Size(134, 20);
            this.tbAdaptiveURI.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(182, 113);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(98, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Test og koble til";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnectToAdaptive_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(101, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AutoSize = true;
            this.lblFormCaption.Location = new System.Drawing.Point(16, 9);
            this.lblFormCaption.Name = "lblFormCaption";
            this.lblFormCaption.Size = new System.Drawing.Size(246, 13);
            this.lblFormCaption.TabIndex = 3;
            this.lblFormCaption.Text = "Konfigurer kva Adaptive-instans du vil arbeide mot:";
            // 
            // tbAdaptiveUser
            // 
            this.tbAdaptiveUser.Location = new System.Drawing.Point(93, 61);
            this.tbAdaptiveUser.Name = "tbAdaptiveUser";
            this.tbAdaptiveUser.Size = new System.Drawing.Size(187, 20);
            this.tbAdaptiveUser.TabIndex = 4;
            // 
            // tbAdaptivePwd
            // 
            this.tbAdaptivePwd.Location = new System.Drawing.Point(93, 87);
            this.tbAdaptivePwd.Name = "tbAdaptivePwd";
            this.tbAdaptivePwd.Size = new System.Drawing.Size(186, 20);
            this.tbAdaptivePwd.TabIndex = 5;
            this.tbAdaptivePwd.UseSystemPasswordChar = true;
            // 
            // lblAdaptiveUri
            // 
            this.lblAdaptiveUri.AutoSize = true;
            this.lblAdaptiveUri.Location = new System.Drawing.Point(16, 36);
            this.lblAdaptiveUri.Name = "lblAdaptiveUri";
            this.lblAdaptiveUri.Size = new System.Drawing.Size(71, 13);
            this.lblAdaptiveUri.TabIndex = 6;
            this.lblAdaptiveUri.Text = "Adaptive URI";
            // 
            // lblAdaptiveUser
            // 
            this.lblAdaptiveUser.AutoSize = true;
            this.lblAdaptiveUser.Location = new System.Drawing.Point(16, 64);
            this.lblAdaptiveUser.Name = "lblAdaptiveUser";
            this.lblAdaptiveUser.Size = new System.Drawing.Size(64, 13);
            this.lblAdaptiveUser.TabIndex = 7;
            this.lblAdaptiveUser.Text = "Brukarnamn";
            // 
            // lblAdaptivePwd
            // 
            this.lblAdaptivePwd.AutoSize = true;
            this.lblAdaptivePwd.Location = new System.Drawing.Point(16, 90);
            this.lblAdaptivePwd.Name = "lblAdaptivePwd";
            this.lblAdaptivePwd.Size = new System.Drawing.Size(45, 13);
            this.lblAdaptivePwd.TabIndex = 7;
            this.lblAdaptivePwd.Text = "Passord";
            // 
            // chbTest
            // 
            this.chbTest.AutoSize = true;
            this.chbTest.Location = new System.Drawing.Point(233, 35);
            this.chbTest.Name = "chbTest";
            this.chbTest.Size = new System.Drawing.Size(47, 17);
            this.chbTest.TabIndex = 9;
            this.chbTest.Text = "Test";
            this.chbTest.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 147);
            this.Controls.Add(this.chbTest);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbAdaptivePwd);
            this.Controls.Add(this.tbAdaptiveUser);
            this.Controls.Add(this.tbAdaptiveURI);
            this.Controls.Add(this.lblAdaptivePwd);
            this.Controls.Add(this.lblAdaptiveUser);
            this.Controls.Add(this.lblAdaptiveUri);
            this.Controls.Add(this.lblFormCaption);
            this.Name = "ConfigForm";
            this.Text = "Konfigurer";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAdaptiveURI;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFormCaption;
        private System.Windows.Forms.TextBox tbAdaptiveUser;
        private System.Windows.Forms.TextBox tbAdaptivePwd;
        private System.Windows.Forms.Label lblAdaptiveUri;
        private System.Windows.Forms.Label lblAdaptiveUser;
        private System.Windows.Forms.Label lblAdaptivePwd;
        private System.Windows.Forms.CheckBox chbTest;
    }
}