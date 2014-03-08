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
            string mUrl, mJson;

            if (Properties.Settings.Default.testMode == "true")
            {
                mJson = string.Empty;
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "Avinet.Adaptive.Statistics.ExcelAddIn.DefaultConfig.json";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    mJson = reader.ReadToEnd();
                }
            }
            else
            {
                mUrl = String.Format("{0}/WebServices/administrator/modules/statistics/GetStatConfig.asmx/Read", Properties.Settings.Default.adaptiveUri);
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

        public static System.Data.DataTable AsDataTable(List<configListEntry> mList) 
        {
            System.Data.DataTable mDataTable = new System.Data.DataTable();
            mDataTable.Columns.Add(new DataColumn("key", typeof(string)));
            mDataTable.Columns.Add(new DataColumn("value", typeof(string)));
            foreach (var mConfigListEntry in mList)
            {
                var mRow = mDataTable.NewRow();
                mRow["key"] = mConfigListEntry.key;
                mRow["value"] = mConfigListEntry.value;
                mDataTable.Rows.Add(mRow);
            }
            return mDataTable;
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

