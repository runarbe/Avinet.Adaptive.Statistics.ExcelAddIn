using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    /// <summary>
    /// Methods to interact with portal web service
    /// </summary>
    public static class PortalClient
    {

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

                var j = JsonConvert.DeserializeObject<GetVariableResponse>(responsebody);

                var mr = j.d.records;

                ConfigProvider.variableDefinitions = j.d.records;                

                tree = (from m1 in mr
                        where m1.parent_id == null
                        orderby m1.var1
                        select m1.AsStatTreeNode (
                            from m2 in mr
                            where m2.parent_id == m1.id
                            orderby m2.var2
                            select m2.AsStatTreeNode (
                                from m3 in mr
                                where m3.parent_id == m2.id
                                orderby m3.var3
                                select m3.AsStatTreeNode (
                                    from m4 in mr
                                    where m4.parent_id == m3.id
                                    orderby m4.var4
                                    select m4.AsStatTreeNode (
                                        from m5 in mr
                                        where m5.parent_id == m4.id
                                        orderby m5.var5
                                        select m5.AsStatTreeNode(
                                        ))))));
                                
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
                //DebugToFile.Log(json);
                return JsonConvert.DeserializeObject<ServiceOutput>(json);
            }
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
                    String uri = Properties.Settings.Default.adaptiveUri + "/WebServices/geostat/Portal.asmx/GetKretstyper";
                    byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes("{}"));
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                    var wrapper = JsonConvert.DeserializeObject<GetKretstyperResponse>(responsebody);
                    var records = wrapper.d.records;
                    kretstyper = (from r in records select r);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error loading 'kretstyper' from server"); ;
            }
            return kretstyper;
        }
    }
}
