using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    public class RequestHelper
    {

        public static string PostMultipart(string url, Dictionary<string, object> parameters)
        {

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            ServicePointManager.DefaultConnectionLimit = 100;
            ServicePointManager.MaxServicePointIdleTime = 12000;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.KeepAlive = true;
            request.Proxy = null;
            //request.AllowWriteStreamBuffering = false;

            if (parameters != null && parameters.Count > 0)
            {

                using (Stream requestStream = request.GetRequestStream())
                {

                    foreach (KeyValuePair<string, object> pair in parameters)
                    {

                        requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);
                        if (pair.Value is FormFile)
                        {
                            FormFile file = pair.Value as FormFile;
                            string header = "Content-Disposition: form-data; name=\"" + pair.Key + "\"; filename=\"" + file.Name + "\"\r\nContent-Type: " + file.ContentType + "\r\n\r\n";
                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(header);
                            requestStream.Write(bytes, 0, bytes.Length);
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            if (file.Stream == null)
                            {
                                // upload from file
                                using (FileStream fileStream = File.OpenRead(file.FilePath))
                                {
                                    fileStream.Position = Encoding.UTF8.GetPreamble().Length;
                                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                    {
                                        requestStream.Write(buffer, 0, bytesRead);
                                    }
                                    fileStream.Close();
                                }
                            }
                            else
                            {
                                // upload from given stream
                                while ((bytesRead = file.Stream.Read(buffer, 0, buffer.Length)) != 0)
                                    requestStream.Write(buffer, 0, bytesRead);
                            }
                        }
                        else
                        {
                            string data = "Content-Disposition: form-data; name=\"" + pair.Key + "\"\r\n\r\n" + pair.Value;
                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
                            requestStream.Write(bytes, 0, bytes.Length);
                        }
                    }

                    byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                    requestStream.Write(trailer, 0, trailer.Length);
                    requestStream.Close();
                }
            }

            using (WebResponse response = request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                    return reader.ReadToEnd();
            }
        }
    }
}
