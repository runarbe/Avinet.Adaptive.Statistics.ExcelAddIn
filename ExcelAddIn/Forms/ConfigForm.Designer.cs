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
            this.tbAdaptiveURI = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFormCaption = new System.Windows.Forms.Label();
            this.tbAdaptiveUser = new System.Windows.Forms.TextBox();
            this.tbAdaptivePwd = new System.Windows.Forms.TextBox();
            this.lblAdaptiveUri = new System.Windows.Forms.Label();
            this.lblAdaptiveUser = new System.Windows.Forms.Label();
            this.lblAdaptivePwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbAdaptiveURI
            // 
            this.tbAdaptiveURI.Location = new System.Drawing.Point(183, 39);
            this.tbAdaptiveURI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAdaptiveURI.Name = "tbAdaptiveURI";
            this.tbAdaptiveURI.Size = new System.Drawing.Size(296, 22);
            this.tbAdaptiveURI.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(337, 144);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 28);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Lagre";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnectToAdaptive_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(182, 144);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFormCaption
            // 
            this.lblFormCaption.AutoSize = true;
            this.lblFormCaption.Location = new System.Drawing.Point(10, 10);
            this.lblFormCaption.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormCaption.Name = "lblFormCaption";
            this.lblFormCaption.Size = new System.Drawing.Size(362, 17);
            this.lblFormCaption.TabIndex = 3;
            this.lblFormCaption.Text = "Oppgje fullstendig addresse til rota av ein Adaptivetenar";
            // 
            // tbAdaptiveUser
            // 
            this.tbAdaptiveUser.Location = new System.Drawing.Point(183, 73);
            this.tbAdaptiveUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAdaptiveUser.Name = "tbAdaptiveUser";
            this.tbAdaptiveUser.Size = new System.Drawing.Size(297, 22);
            this.tbAdaptiveUser.TabIndex = 4;
            // 
            // tbAdaptivePwd
            // 
            this.tbAdaptivePwd.Location = new System.Drawing.Point(183, 105);
            this.tbAdaptivePwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAdaptivePwd.Name = "tbAdaptivePwd";
            this.tbAdaptivePwd.Size = new System.Drawing.Size(296, 22);
            this.tbAdaptivePwd.TabIndex = 5;
            this.tbAdaptivePwd.UseSystemPasswordChar = true;
            // 
            // lblAdaptiveUri
            // 
            this.lblAdaptiveUri.AutoSize = true;
            this.lblAdaptiveUri.Location = new System.Drawing.Point(10, 42);
            this.lblAdaptiveUri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdaptiveUri.Name = "lblAdaptiveUri";
            this.lblAdaptiveUri.Size = new System.Drawing.Size(156, 17);
            this.lblAdaptiveUri.TabIndex = 6;
            this.lblAdaptiveUri.Text = "URL (inkludert http://...)";
            // 
            // lblAdaptiveUser
            // 
            this.lblAdaptiveUser.AutoSize = true;
            this.lblAdaptiveUser.Location = new System.Drawing.Point(10, 76);
            this.lblAdaptiveUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdaptiveUser.Name = "lblAdaptiveUser";
            this.lblAdaptiveUser.Size = new System.Drawing.Size(85, 17);
            this.lblAdaptiveUser.TabIndex = 7;
            this.lblAdaptiveUser.Text = "Brukarnamn";
            // 
            // lblAdaptivePwd
            // 
            this.lblAdaptivePwd.AutoSize = true;
            this.lblAdaptivePwd.Location = new System.Drawing.Point(10, 108);
            this.lblAdaptivePwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdaptivePwd.Name = "lblAdaptivePwd";
            this.lblAdaptivePwd.Size = new System.Drawing.Size(60, 17);
            this.lblAdaptivePwd.TabIndex = 7;
            this.lblAdaptivePwd.Text = "Passord";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 183);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbAdaptivePwd);
            this.Controls.Add(this.tbAdaptiveUser);
            this.Controls.Add(this.tbAdaptiveURI);
            this.Controls.Add(this.lblAdaptivePwd);
            this.Controls.Add(this.lblAdaptiveUser);
            this.Controls.Add(this.lblAdaptiveUri);
            this.Controls.Add(this.lblFormCaption);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ConfigForm";
            this.Text = "Tilkoplingsinnstillingar";
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
    }
}