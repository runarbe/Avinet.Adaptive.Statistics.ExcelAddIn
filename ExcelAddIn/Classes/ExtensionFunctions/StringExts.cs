using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class StringExts
    {
        public static int AsInt(this String s, int defaultValue = -1)
        {
            return (int)s.AsNullableInt(defaultValue);
        }

        public static int AsIntOrDefault(this String s, int defaultValue = -1)
        {
            int i;
            if (int.TryParse(s, out i)) {
                return i;
            } else {
                return defaultValue;
            }
        }

        public static int? AsNullableInt(this String s, int? defaultValue = null)
        {
            int i;
            if (int.TryParse(s, out i))
            {
                return (int?)i;
            }
            else
            {
                return defaultValue;
            }
        }

        public static double? AsNullableDouble(this String s, double? defaultValue = null)
        {
            double d;
            if (double.TryParse(s, out d))
            {
                return d;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Return null if string is '' or null
        /// </summary>
        /// <param title="s"></param>
        /// <returns></returns>
        public static string NullIfEmpty(this String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Return empty string if null
        /// </summary>
        /// <param title="s"></param>
        /// <returns></returns>
        public static string EmptyIfNull(this String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            else
            {
                return s;
            }
        }


        /// <summary>
        /// Checks wheter a string is null or empty
        /// </summary>
        /// <param title="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String s)
        {
            return !IsNotNullOrEmpty(s);
        }

        public static bool IsWellFormedUrl(this String url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute);
        }

        public static bool IsWellFormedAbsoluteUrl(this String url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        /// <summary>
        /// This method will check a url to see that it does not return server or protocol errors
        /// </summary>
        /// <param title="url">The path to check</param>
        /// <returns></returns>
        public static bool CheckIfUrlExists(this String url)
        {
            if (!url.IsWellFormedAbsoluteUrl()) {
                return false;
            }
            HttpWebRequest request;

            try
            {
                request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 5000; //set the timeout to 5 seconds to keep the emailAddress from waiting too long for the page to load
                request.Method = "HEAD"; //Get only the header information -- no need to download any content

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                int statusCode = (int)response.StatusCode;
                response.Close();
                if (statusCode >= 100 && statusCode < 400) //Good requests
                {
                    return true;
                }
                else if (statusCode >= 500 && statusCode <= 510) //Server Errors
                {
                    return false;
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError) //400 errors
                {
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        public static string UrlCombine(this String urlString, string relativeUrl)
        {
            if (urlString.Length == 0)
            {
                return relativeUrl;
            }

            if (relativeUrl.Length == 0)
            {
                return urlString;
            }

            urlString = urlString.TrimEnd('/', '\\');
            relativeUrl = relativeUrl.TrimStart('/', '\\');

            return string.Format("{0}/{1}", urlString, relativeUrl);

        }

        /// <summary>
        /// Return true if string is not null, empty or consists exclusively of whitespace
        /// </summary>
        /// <param title="s"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this String s)
        {
            if (s != null && s.Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
