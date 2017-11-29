using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn;
using System.IO;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Types;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// Methods to interact with portal web service
    /// </summary>
    public static class AdaptiveClient
    {

        /// <summary>
        /// Add the authentication tokens to the http header of the request
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static WebClient AddAuth(this WebClient client)
        {
            client.Headers.Add(ConfigProvider.httpHeaderSessionKey, ConfigProvider.httpHeaderSessionValue);
            return client;
        }

        /// <summary>
        /// Add conetnt type
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static WebClient AddContentTypeApplicationJson(this WebClient client)
        {
            client.Headers.Add("Content-Type", "application/json; charset=utf-8");
            return client;
        }

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <returns></returns>
        public static bool DoAuth()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.adaptiveUri)
                && !String.IsNullOrEmpty(Properties.Settings.Default.adaptiveUser)
                  && !String.IsNullOrEmpty(Properties.Settings.Default.adaptivePwd))
            {
                var a = AdaptiveClient.Authenticate(Properties.Settings.Default.adaptiveUser, Properties.Settings.Default.adaptivePwd);
                if (a != null)
                {
                    ConfigProvider.httpHeaderSessionKey = a.key;
                    ConfigProvider.httpHeaderSessionValue = a.value;
                    return true;
                }
            }
            return false;
        }

        public static void PerformAuthIfNecessary()
        {
            if (!IsSessionValid())
            {
                DoAuth();
            }
        }

        public static bool IsSessionValid()
        {
            using (WebClient client = new WebClient())
            {
                try 
	                {	        
		                client.AddAuth();
                        client.AddContentTypeApplicationJson();

                        String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/generic/Authentication.asmx/GetUserDetails");
                        byte[] respBytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes("{}"));
                        var jsonString = Encoding.UTF8.GetString(respBytes);
                        var serviceOutput = JsonConvert.DeserializeObject<GetUserDetailsResponse>(jsonString);
                        if (serviceOutput != null && serviceOutput.sessionExpired == false)
                        {
                            return true;
                        }
	                }
	                catch (Exception)
	                {
	                }            
            }
            return false;
        }

        /// <summary>
        /// Authenticate using Adaptive
        /// </summary>
        /// <param title="valuesList"></param>
        /// <returns>A key value pair where the key is the name of the HTTP-header to be passed with each subsequent request and the value is the session id</returns>
        public static AuthenticateResponse.AuthenticateKeyValue Authenticate(string emailAddress, string password)
        {
            using (WebClient client = new WebClient())
            {
                var req = new AuthenticateRequest();

                req.email = emailAddress;
                req.pass = AdaptiveCrypto.SHA512EncryptPassword(password);

                try
                {
                    client.AddContentTypeApplicationJson();

                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/generic/Authentication.asmx/Authenticate");
                    byte[] respBytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                    var jsonString = Encoding.UTF8.GetString(respBytes);
                    var serviceOutput = JsonConvert.DeserializeObject<AuthenticateResponse>(jsonString);

                    if (serviceOutput.d.success == false)
                    {
                        Dbg.WriteLine("Authentication failed", req.email);
                    }
                    else
                    {
                        if (serviceOutput.d.data.Count() > 0)
                        {
                            return serviceOutput.d.data[0];
                        }
                        else
                        {
                            Dbg.WriteLine("Authentication succeeded but no session id was returned");
                        }
                    }
                }
                catch (WebException ex)
                {
                    var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    ex.Response.Close();
                    Dbg.WriteLine(ex.Message, resp);
                }
                return null;
            }
        }

        /// <summary>
        /// Upload data to Adaptive
        /// </summary>
        /// <param title="valuesList"></param>
        /// <returns></returns>
        public static ServiceOutput AddData(List<AdaptiveValue> valuesList)
        {
            PerformAuthIfNecessary();

            var requestData = new AddDataRequest(valuesList);

            using (CustomWebClient client = new CustomWebClient())
            {
                client.Timeout = 360000;
                try
                {
                    client.AddAuth();
                    client.AddContentTypeApplicationJson();
                    
                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/ExcelAddin.asmx/AddData");
                    byte[] respBytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(requestData)));
                    var jsonString = Encoding.UTF8.GetString(respBytes);
                    var response = JsonConvert.DeserializeObject<ServiceOutput>(jsonString);
                    return response;
                }
                catch (WebException ex)
                {
                    var respData = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    throw new Exception(ex.Message + " - request data: " + JsonConvert.SerializeObject(requestData) + " / " + " response data: " + respData);
                }
            }
        }

        /// <summary>
        /// Load all variable from the server and construct a collection of StatTreeNodes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<StatTreeNode> GetVariable()
        {
            PerformAuthIfNecessary();

            // Declare collection of tree nodes to return
            IEnumerable<StatTreeNode> tree = null;

            using (WebClient client = new WebClient())
            {
                try
                {

                    client.AddContentTypeApplicationJson();
                    client.AddAuth();

                    String wsUri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/geostat/Portal.asmx/GetVariable");
                    byte[] resBytes = client.UploadData(wsUri, "POST", Encoding.UTF8.GetBytes("{}"));
                    string resBody = Encoding.UTF8.GetString(resBytes);
                    var response = JsonConvert.DeserializeObject<GetVariableResponse>(resBody);

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
                catch (Exception ex)
                {
                    Dbg.WriteLine("Could not load variable hierarchy");
                    Dbg.WriteJson(ex);
                }

                return tree;
            }
        }

        /// <summary>
        /// Add a new variable to the server
        /// </summary>
        /// <param title="requestData"></param>
        /// <returns></returns>
        public static ServiceOutput AddVariable(AddVariableRequest req)
        {
            PerformAuthIfNecessary();

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.AddContentTypeApplicationJson();
                    client.AddAuth();
                    String uri = Properties.Settings.Default.adaptiveUri.UrlCombine("/WebServices/administrator/modules/statistics/Variable.asmx/Create");
                    byte[] responsebytes = client.UploadData(uri, "POST", Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(req)));
                    var json = Encoding.UTF8.GetString(responsebytes);
                    var s = JsonConvert.DeserializeObject<ServiceOutput>(json);
                    Dbg.WriteJson(s);
                    return s;
                }
            }
            catch (Exception ex)
            {
                Dbg.WriteLine(ex.Message);
                return null;
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
                { "Kroner", "kr" },
                { "Tusen kroner", "tusen-kr" },
                { "Millionar kroner", "mill-kr" },
                { "Milliardar kroner", "mrd-kr" },
                { "Meter", "m" },
                { "Millimeter", "mm" },
                { "Centimeter", "cm" },
                { "Kilometer", "km" },
                { "Mil", "mil" },
                { "Kvadratmeter", "m2" },
                { "Ar", "ar" },
                { "Dekar", "daa" },
                { "Hektar", "ha" },
                { "Kvadratkilometer", "km2" },
                { "Kubikkmeter", "m3" },
                { "Liter", "l" },
                { "Hektoliter", "hl" },
                { "Fat", "fat" },
                { "Kilogram", "kg" },
                { "Tonn", "t" },
                { "Tonnkilometer", "tkm" },
                { "Miligram", "mg" },
                { "Sekund", "s" },
                { "Minutt", "min" },
                { "Time", "t" },
                { "Døgn", "d" },
                { "Veke", "vk" },
                { "Månad", "mnd" },
                { "Kvartal", "kv" },
                { "År", "år" },
                { "Grad celsius", "C" },
                { "Ampere", "a" },
                { "Joule", "j" },
                { "Gigajoule", "Gj" },
                { "Terajoule", "Tj" },
                { "Petajoule", "Pj" },
                { "Wattsekund", "Ws" },
                { "Tonn oljeekvivalent", "toe" },
                { "Kilowattime", "kWh" },
                { "Megawattime", "MWh" },
                { "Gigwattime", "Gwh" },
                { "Terawattime", "Twh" },
                { "Watt", "W" },
                { "Kilowatt", "kW" },
                { "Megawatt", "MW" },
                { "Megavolt ampere", "MVA" },
                { "Bruttotonn", "BT" }
            };
        }
        /// <summary>
        /// Return all kretstyper from the server
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Kretstyper> GetKretstyper()
        {
            PerformAuthIfNecessary();

            IEnumerable<Kretstyper> kretstyper = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.AddContentTypeApplicationJson();
                    client.AddAuth();
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
