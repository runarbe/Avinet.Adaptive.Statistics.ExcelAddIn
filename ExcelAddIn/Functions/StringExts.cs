using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Functions
{
    public static class StringExts
    {

        /// <summary>
        /// Return null if string is '' or null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string nullIfEmpty(this string s)
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
        /// <param name="s"></param>
        /// <returns></returns>
        public static string emptyIfNull(this string s)
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
        /// Return true if string is not null, empty or consists exclusively of whitespace
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool isNotNullOrEmpty(this String s)
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
