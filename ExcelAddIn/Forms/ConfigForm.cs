using Newtonsoft.Json;
using System;
using System.IO;
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

                if (!ConfigProvider.IsConfigured())
                {
                    DialogBoxes.Error("Gjeldande verdiar gjer det ikkje mogleg å kople til ein Adaptive server, sjekk at verdiane og prøv på nytt");
                    this.Close();
                }

                try
                {
                    var serverConfig = new ServerConfig();
                    serverConfig.url = this.tbAdaptiveURI.Text;
                    serverConfig.username = this.tbAdaptiveUser.Text;
                    serverConfig.password = this.tbAdaptivePwd.Text;
                    var serverConfigFileContent = JsonConvert.SerializeObject(serverConfig);
                    if (File.Exists(ThisAddIn.ServerConfigFilename)) {
                        File.Delete(ThisAddIn.ServerConfigFilename);
                    }
                    File.WriteAllText(ThisAddIn.ServerConfigFilename, serverConfigFileContent);
                }
                catch (Exception ex)
                {
                    DialogBoxes.Error("Det oppstod ein feil ved lagring av serverkonfigurasjonen: " + ex.Message);
                }
                this.Close();
            }
            else
            {
                DialogBoxes.Error("Kunne ikkje kople til spesifisert URL");
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
