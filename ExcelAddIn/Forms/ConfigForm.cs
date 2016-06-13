using System;
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
            if (this.tbAdaptiveURI.Text.IsNotNullOrEmpty()
                && Uri.IsWellFormedUriString(this.tbAdaptiveURI.Text, UriKind.Absolute)
                && tbAdaptiveURI.Text.CheckIfUrlExists())
            {
                Properties.Settings.Default.adaptiveUri = this.tbAdaptiveURI.Text;
                Properties.Settings.Default.adaptiveUser = this.tbAdaptiveUser.Text;
                Properties.Settings.Default.adaptivePwd = this.tbAdaptivePwd.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Kunne ikkje kople til spesifisert URL", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            this.tbAdaptiveURI.Text = Properties.Settings.Default.adaptiveUri;
            this.tbAdaptiveUser.Text = Properties.Settings.Default.adaptiveUser;
            this.tbAdaptivePwd.Text = Properties.Settings.Default.adaptivePwd;
        }


    }
}
