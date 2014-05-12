using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Class with methods to retrieve codelist values from Adaptive web services
    /// </summary>
    public static class WsDataSources
    {
        public static ConfigList DownloadAdaptiveConfig(bool pRefresh = false)
        {
            ConfigList mRetVal;

            if (Util.CheckNullOrEmpty(Properties.Settings.Default.configJson) != null && Util.IsJsonString(Properties.Settings.Default.configJson) && pRefresh == false)
            {
                mRetVal = JsonLoader.LoadConfigFromSettings(Properties.Settings.Default.configJson);
            }
            else
            {
                try
                {
                    mRetVal = JsonLoader.LoadConfigFromWeb();
                }
                catch (Exception)
                {
                    mRetVal = null;
                }
            }
            return mRetVal;
        }

    }
}
