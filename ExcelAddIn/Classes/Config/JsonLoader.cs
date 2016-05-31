using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Office.Interop.Excel;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class JsonLoader
    {
        public static ConfigProvider LoadConfigFromSettings(string mConfigListJson)
        {
            try
            {
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ConfigProvider>(mConfigListJson);
            }
            catch (Exception)
            {
                throw new Exception("Feil: kunne ikkje lese lokal konfigurasjonsfil");
            }
        }

        public static ConfigProvider LoadConfigFromWeb()
        {
            var webClient = new WebClient();
            
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add("Content-Type", "application/json");
            var jsonSerializer = new JavaScriptSerializer();
            string mUrl, mJson;

            if (Properties.Settings.Default.testMode == "true")
            {
                mJson = string.Empty;
                mJson = File.ReadAllText(Util.GetFullResourceFilename("DefaultConfig.json"));
            }
            else
            {
                mUrl = String.Format("{0}/WebServices/administrator/modules/statistics/GetStatConfig.asmx/Read",
                    Properties.Settings.Default.adaptiveUri);
                try
                {

                    mJson = webClient.DownloadString(mUrl);
                    mJson = mJson.Replace("\"__type\"", "\"type\"");

                    Properties.Settings.Default.configJson = mJson;
                    Properties.Settings.Default.Save();
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Kunne ikkje laste ned konfigurasjon frå URL: {0}. Error: {1}", mUrl, ex.Message));
                }

            }

            AsmxConfigListResponse mRes = jsonSerializer.Deserialize<AsmxConfigListResponse>(mJson);
            return mRes.d;
        }

    }
}

