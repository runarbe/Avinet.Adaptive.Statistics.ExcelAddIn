using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnectToAdaptive_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.adaptiveUri = this.tbAdaptiveURI.Text;
            Properties.Settings.Default.adaptiveUser = this.tbAdaptiveUser.Text;
            Properties.Settings.Default.adaptivePwd = this.tbAdaptivePwd.Text;

            if (this.chbTest.Checked == true)
            {
                Properties.Settings.Default.testMode = "true";
            } else
            {
                Properties.Settings.Default.testMode = "false";
            };

            Properties.Settings.Default.Save();

            ConfigList mConfig;
            if (null != (mConfig = WsDataSources.DownloadAdaptiveConfig(true)))
            {
                this.Close();
            }
            else
            {
            }
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.tbAdaptiveURI.Text = Properties.Settings.Default.adaptiveUri;
            this.tbAdaptiveUser.Text = Properties.Settings.Default.adaptiveUser;
            this.tbAdaptivePwd.Text = Properties.Settings.Default.adaptivePwd;

            if (Properties.Settings.Default.testMode == "true")
            {
                this.chbTest.Checked = true;
            }
            else
            {
                this.chbTest.Checked = false;
            }
        }


    }
}
