using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class JsonLoader
    {
        public static ConfigList LoadConfigFromSettings(string mConfigListJson)
        {
            try
            {
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Deserialize<ConfigList>(mConfigListJson);
            }
            catch (Exception)
            {
                throw new Exception("Feil: kunne ikkje lese lokal konfigurasjonsfil");
            }
        }

        public static ConfigList LoadConfigFromWeb()
        {
            var webClient = new WebClient();
            
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add("Content-Type", "application/json");
            var jsonSerializer = new JavaScriptSerializer();
            string mUrl;

            if (Properties.Settings.Default.testMode == "true")
            {
                mUrl = String.Format("http://projects.europetech.eu/adaptive/getAdaptiveConfiguration.php", Properties.Settings.Default.adaptiveUri);
            }
            else
            {
                mUrl = String.Format("{0}/WebServices/administrator/modules/statistics/GetStatConfig.asmx/Read", Properties.Settings.Default.adaptiveUri);
            }

            try
            {

                Debug.WriteLine("Loading from" + mUrl);
                var mJson = webClient.DownloadString(mUrl);
                mJson = mJson.Replace("\"__type\"", "\"type\"");
                Debug.WriteLine(mJson);

                Properties.Settings.Default.configJson = mJson;
                Properties.Settings.Default.Save();
                AsmxConfigListResponse mRes = jsonSerializer.Deserialize<AsmxConfigListResponse>(mJson);
                return mRes.d;
            }
            catch (Exception ex)
            
            {
                Debug.WriteLine("Something went horribly wrong...");
                throw new Exception(String.Format("Kunne ikkje laste ned konfigurasjon frå URL: {0}", mUrl));
            }
        }

    }

    public class AsmxConfigListResponse
    {
        public ConfigList d { get; set; }
        public AsmxConfigListResponse()
        {
        }
    }


    public class ConfigList
    {
        public List<configListEntry> statUnitTypes { get; set; }
        public List<configListEntry> measurementUnitTypes { get; set; }
        public List<configListEntry> statVariableTypes { get; set; }
        public string type { get; set; }
        public ConfigList()
        {
        }        

    }

    public class ConfigListOffline
    {
        public List<configListEntry> list { get; set; }

        public ConfigListOffline()
        {
            this.list = new List<configListEntry>();
        }

        public void Add(string pKey, string pValue)
        {
            this.list.Add(new configListEntry(pKey, pValue));
        }

        public void Insert(string pKey, string pValue)
        {
            this.list.Insert(0, new configListEntry(pKey, pValue));
        }


    }

    public class configListEntry
    {
        public string key { get; set; }
        public string value { get; set; }

        public configListEntry()
        {
        }

        public configListEntry(string pKey, string pValue)
        {
            this.key = pKey;
            this.value = pValue;
        }

    }

}

