using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn;
using System.IO;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Methods to interact with portal web service
    /// </summary>
    public static class AdaptiveClient
    {
        /// <summary>
        /// Upload data to Adaptive
        /// </summary>
        /// <param title="valuesList"></param>
        /// <returns></returns>
        public static ServiceOutput AddData(List<AdaptiveValue> valuesList)
        {
            var req = new AddDataRequest(valuesList);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/ExcelAddin.asmx/AddData");
                    byte[] respBytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                    var jsonString = Encoding.UTF8.GetString(respBytes);
                    DebugToFile.Log(jsonString);
                    return JsonConvert.DeserializeObject<ServiceOutput>(jsonString);
                }
                catch (WebException ex)
                {
                    var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new Exception(ex.Message + ": " + resp);
                }
            }
        }

        /// <summary>
        /// Load all variable from the server and construct a kretstyper
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<StatTreeNode> GetVariable()
        {
            // Declare collection of tree nodes to return
            IEnumerable<StatTreeNode> tree = null;

            using (WebClient client = new WebClient())
            {
                try
                {

                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/Portal.asmx/GetVariable");
                    byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes("{}"));
                    string responsebody = Encoding.UTF8.GetString(responsebytes);

                    var response = JsonConvert.DeserializeObject<GetVariableResponse>(responsebody);
                    DebugToFile.Log(responsebody);

                    var mr = response.d.records;

                    var lvl1 = from m1 in mr
                               where m1.level == 1
                               orderby m1.title
                               select m1;
                    var lvl2 = from m1 in mr
                               where m1.level == 2
                               orderby m1.title
                               select m1;
                    var lvl3 = from m1 in mr
                               where m1.level == 3
                               orderby m1.title
                               select m1;
                    var lvl4 = from m1 in mr
                               where m1.level == 4
                               orderby m1.title
                               select m1;
                    var lvl5 = from m1 in mr
                               where m1.level == 5
                               orderby m1.title
                               select m1;

                    mr = lvl1
                        .Concat(lvl2)
                        .Concat(lvl3)
                        .Concat(lvl4)
                        .Concat(lvl5)
                        .ToList<Variable>();

                    DebugToFile.Json(mr);

                    tree = (from m1 in mr
                            where !m1.parent_id.HasValue
                            select m1.AsStatTreeNode(
                                from m2 in mr
                                where m2.parent_id == m1.id
                                select m2.AsStatTreeNode(
                                    from m3 in mr
                                    where m3.parent_id == m2.id
                                    select m3.AsStatTreeNode(
                                        from m4 in mr
                                        where m4.parent_id == m3.id
                                        select m4.AsStatTreeNode(
                                            from m5 in mr
                                            where m5.parent_id == m4.id
                                            select m5.AsStatTreeNode(
                                            ))))));

                    ConfigProvider.variables = mr;
                    ConfigProvider.variableTree = tree;
                }
                catch (Exception ex )
                {
                    DebugToFile.Json(ex);
                }

                return tree;
            }
        }

        /// <summary>
        /// Add a new variable to the server
        /// </summary>
        /// <param title="req"></param>
        /// <returns></returns>
        public static ServiceOutput AddVariable(AddVariableRequest req)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/Portal.asmx/AddVariable");
                byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                var json = Encoding.UTF8.GetString(responsebytes);
                DebugToFile.Log(json);
                return JsonConvert.DeserializeObject<ServiceOutput>(json);
            }
        }

        public static Dictionary<string, string> GetTimeUnits()
        {
            return new Dictionary<string, string>() {
                { "År", "Year" },
                { "Kvartal", "Quarter" },
                { "Månad", "Month" }
            };
        }

        public static Dictionary<string, string> GetUnits()
        {
            return new Dictionary<string, string>() {
                { "Absolutte tal", "" },
                { "Prosent", "%" },
                { "Kvadratmeter", "m2" },
                { "Ar", "ar" },
                { "Dekar", "daa" },
                { "Hektar", "ha" },
                { "Kvadratkilometer", "km2" },
                { "Miligram", "mg" },
                { "Kilo", "kg" },
                { "Tonn", "t" },
                { "Liter", "t" },
                { "Kubikkmeter", "t" }
            };
        }
        /// <summary>
        /// Return all kretstyper from the server
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Kretstyper> GetKretstyper()
        {
            IEnumerable<Kretstyper> kretstyper = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/ExcelAddin.asmx/GetKretstyper");
                    byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes("{}"));
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                    var wrapper = JsonConvert.DeserializeObject<GetKretstyperResponse>(responsebody);
                    var records = wrapper.d.records;
                    kretstyper = (from r in records select r);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading 'kretstyper' from server: " + ex.Message); ;
            }
            return kretstyper;
        }
    }
}
