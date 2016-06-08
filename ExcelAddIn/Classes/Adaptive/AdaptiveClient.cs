using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;
using System.IO;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    /// <summary>
    /// Methods to interact with portal web service
    /// </summary>
    public static class AdaptiveClient
    {
        /// <summary>
        /// Upload data to Adaptive
        /// </summary>
        /// <param name="valuesList"></param>
        /// <returns></returns>
        public static ServiceOutput AddData(List<AdaptiveValue> valuesList)
        {
            var req = new AddDataRequest(valuesList);

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                    String uri = Properties.Settings.Default.adaptiveUri + "/WebServices/geostat/ExcelAddin.asmx/AddData";
                    byte[] respBytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                    var jsonString = Encoding.UTF8.GetString(respBytes);
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
            IEnumerable<StatTreeNode> tree;

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                String uri = Properties.Settings.Default.adaptiveUri + "/WebServices/geostat/Portal.asmx/GetVariable";
                byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes("{}"));
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                var response = JsonConvert.DeserializeObject<GetVariableResponse>(responsebody);

                var mr = response.d.records;

                var lvl1Folders = from m1 in mr
                                  where m1.var1.IsNotNullOrEmpty()
                                  group m1 by new { m1.var1 }
                                      into grp
                                      select new Variable()
                                      {
                                          id = -2,
                                          var1 = grp.Key.var1,
                                      };

                var lvl1 = from m1 in mr
                           where m1.var1.IsNotNullOrEmpty() && m1.var2.IsNotNullOrEmpty()
                           group m1 by new {m1.id, m1.var1, m1.fk_kretstyper, m1.time_unit, m1.unit }
                               into grp
                               select new Variable()
                               {
                                   id = grp.Key.id,
                                   var1 = grp.Key.var1,
                                   fk_kretstyper = grp.Key.fk_kretstyper,
                                   time_unit = grp.Key.time_unit,
                                   unit = grp.Key.unit
                               };

                var lvl2Folders = from m1 in mr
                                  where m1.var2.IsNotNullOrEmpty()
                                  group m1 by new { m1.var1, m1.var2 }
                                      into grp
                                      select new Variable()
                                      {
                                          id = -2,
                                          var1 = grp.Key.var1,
                                          var2 = grp.Key.var2,
                                      };

                var lvl2 = from m1 in mr
                           where m1.var2.IsNotNullOrEmpty() && m1.var3.IsNullOrEmpty()
                           group m1 by new { m1.id, m1.var1, m1.var2, m1.fk_kretstyper, m1.time_unit, m1.unit }
                               into grp
                               select new Variable()
                               {
                                   id = grp.Key.id,
                                   var1 = grp.Key.var1,
                                   var2 = grp.Key.var2,
                                   fk_kretstyper = grp.Key.fk_kretstyper,
                                   time_unit = grp.Key.time_unit,
                                   unit = grp.Key.unit
                               };
                var lvl3Folders = from m1 in mr
                                  where m1.var3.IsNotNullOrEmpty()
                                  group m1 by new { m1.var1, m1.var2, m1.var3 }
                                      into grp
                                      select new Variable()
                                      {
                                          id = -2,
                                          var1 = grp.Key.var1,
                                          var2 = grp.Key.var2,
                                          var3 = grp.Key.var3
                                      };

                var lvl3 = from m1 in mr
                           where m1.var3.IsNotNullOrEmpty() && !m1.var4.IsNotNullOrEmpty() && m1.id > 0
                           group m1 by new { m1.id, m1.var1, m1.var2, m1.var3, m1.fk_kretstyper, m1.time_unit, m1.unit }
                               into grp
                               select new Variable()
                               {
                                   id = grp.Key.id,
                                   var1 = grp.Key.var1,
                                   var2 = grp.Key.var2,
                                   var3 = grp.Key.var3,
                                   fk_kretstyper = grp.Key.fk_kretstyper,
                                   time_unit = grp.Key.time_unit,
                                   unit = grp.Key.unit
                               };

                var lvl4Folders = from m1 in mr
                                  where m1.var4.IsNotNullOrEmpty()
                                  group m1 by new { m1.var1, m1.var2, m1.var3, m1.var4 }
                                      into grp
                                      select new Variable()
                                      {
                                          id = -2,
                                          var1 = grp.Key.var1,
                                          var2 = grp.Key.var2,
                                          var3 = grp.Key.var3,
                                          var4 = grp.Key.var4
                                      };

                var lvl4 = from m1 in mr
                           where m1.var4.IsNotNullOrEmpty() && m1.var5.IsNullOrEmpty()
                           group m1 by new { m1.id, m1.var1, m1.var2, m1.var3, m1.var4, m1.fk_kretstyper, m1.time_unit, m1.unit }
                               into grp
                               select new Variable()
                               {
                                   id = grp.Key.id,
                                   var1 = grp.Key.var1,
                                   var2 = grp.Key.var2,
                                   var3 = grp.Key.var3,
                                   var4 = grp.Key.var4,
                                   fk_kretstyper = grp.Key.fk_kretstyper,
                                   time_unit = grp.Key.time_unit,
                                   unit = grp.Key.unit
                               };

                var lvl5 = from m1 in mr
                           where m1.var5.IsNotNullOrEmpty()
                           group m1 by new {m1.id, m1.var1, m1.var2, m1.var3, m1.var4, m1.var5, m1.fk_kretstyper, m1.time_unit, m1.unit }
                               into grp
                               select new Variable()
                               {
                                   id = grp.Key.id,
                                   var1 = grp.Key.var1,
                                   var2 = grp.Key.var2,
                                   var3 = grp.Key.var3,
                                   var4 = grp.Key.var4,
                                   var5 = grp.Key.var5,
                                   fk_kretstyper = grp.Key.fk_kretstyper,
                                   time_unit = grp.Key.time_unit,
                                   unit = grp.Key.unit
                               };

                mr = lvl1Folders
                    .Concat(lvl2Folders)
                    .Concat(lvl3Folders)
                    .Concat(lvl3)
                    .Concat(lvl4Folders)
                    .Concat(lvl4)
                    .Concat(lvl5)
                    .ToList<Variable>();

                tree = (from m1 in mr
                        where m1.GetConcatParentId() == null
                        orderby m1.var1
                        select m1.AsStatTreeNode(
                            from m2 in mr
                            where m2.GetConcatParentId() == m1.GetConcatId() && m1.id == -2
                            orderby m2.var2
                            select m2.AsStatTreeNode(
                                from m3 in mr
                                where m3.GetConcatParentId() == m2.GetConcatId() && m2.id == -2
                                orderby m3.var3
                                select m3.AsStatTreeNode(
                                    from m4 in mr
                                    where m4.GetConcatParentId() == m3.GetConcatId() && m3.id == -2
                                    orderby m4.var4
                                    select m4.AsStatTreeNode(
                                        from m5 in mr
                                        where m5.GetConcatParentId() == m4.GetConcatId() && m4.id == -2
                                        orderby m5.var5
                                        select m5.AsStatTreeNode(
                                        ))))));

                //ConfigProvider.variables = response.d.records;
                ConfigProvider.variables = mr;
                ConfigProvider.variableTree = tree;

                return tree;
            }
        }

        /// <summary>
        /// Add a new variable to the server
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static ServiceOutput AddVariable(AddVariableRequest req)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                String uri = Properties.Settings.Default.adaptiveUri + "/WebServices/geostat/Portal.asmx/AddVariable";
                byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                var json = Encoding.UTF8.GetString(responsebytes);
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
                    String uri = Properties.Settings.Default.adaptiveUri + "/WebServices/geostat/ExcelAddin.asmx/GetKretstyper";
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
