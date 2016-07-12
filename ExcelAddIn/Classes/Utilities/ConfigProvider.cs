using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Static class that holds configuration data including variable definitions and code lists
    /// </summary>
    public static class ConfigProvider
    {
        public static IEnumerable<Kretstyper> kretstyper { get; set; }
        public static Dictionary<string, string> units { get; set; }
        public static Dictionary<string, string> timeUnits { get; set; }
        public static IEnumerable<Variable> variables { get; set; }
        public static IEnumerable<StatTreeNode> variableTree { get; set; }
        public static IEnumerable<NamedUploadFormState> savedUploadFormStates { get; set; }
        public static bool IsLoaded { get; set; }

        static ConfigProvider()
        {
            IsLoaded = false;
        }

        public static bool IsConfigured()
        {
            if (Properties.Settings.Default.adaptiveUri.IsNotNullOrEmpty()
                && Uri.IsWellFormedUriString(Properties.Settings.Default.adaptiveUri, UriKind.Absolute)
                && Properties.Settings.Default.adaptiveUri.CheckIfUrlExists()
                && Properties.Settings.Default.adaptiveUser.IsNotNullOrEmpty()
                && Properties.Settings.Default.adaptivePwd.IsNotNullOrEmpty())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Kunne ikkje kontakte tenaren. Sjekk at du er tilkopla internett og at du har oppgjeve rett addresse til Adaptive.", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get time unit by value
        /// </summary>
        /// <param title="timeUnitValue"></param>
        /// <returns></returns>
        public static string GetTimeUnitByValue(string timeUnitValue)
        {
            if (ConfigProvider.timeUnits != null)
            {
                foreach (var kvp in ConfigProvider.timeUnits)
                {
                    if (kvp.Value == timeUnitValue)
                    {
                        return kvp.Key;
                    }
                }
            }

            return timeUnitValue;
        }

        /// <summary>
        /// Get unit by value
        /// </summary>
        /// <param title="unitValue"></param>
        /// <returns></returns>
        public static string GetUnitByValue(string unitValue)
        {
            if (ConfigProvider.units != null)
            {
                foreach (var kvp in ConfigProvider.units)
                {
                    if (kvp.Value == unitValue)
                    {
                        return kvp.Key;
                    }
                }
            }

            return unitValue;
        }

        /// <summary>
        /// GetKretstypeByValue
        /// </summary>
        /// <param title="id"></param>
        /// <returns></returns>
        public static string GetKretstypeByValue(string id)
        {
            if (ConfigProvider.kretstyper != null)
            {
                foreach (var kvp in ConfigProvider.kretstyper)
                {
                    if (kvp.id == id)
                    {
                        return kvp.name;
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// Reload configuration from server
        /// </summary>
        public static void Reload()
        {
            Load();
        }


        public static void ReloadVariables()
        {
            LoadVariables();
        }

        public static void LoadVariables()
        {
            if (AdaptiveClient.GetVariable() != null)
            {
                IsLoaded = true;
            };
        }

        /// <summary>
        /// Load configuration from server
        /// </summary>
        public static void Load()
        {
            try
            {
                kretstyper = AdaptiveClient.GetKretstyper();
                units = AdaptiveClient.GetUnits();
                timeUnits = AdaptiveClient.GetTimeUnits();
                UploadFormState.LoadSavedStates();
                ConfigProvider.LoadVariables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunne ikkje laste kodelister, variablar eller laste lagra oppsett frå Adaptive. Sjekk tilkoplingsinnstillingar", "Feil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dbg.WriteLine(ex.Message, ex);
            }
        }


    }
}
