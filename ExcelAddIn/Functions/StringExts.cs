using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Functions
{
    public static class StringExts
    {
        public static int? AsNullableInt(this string s, int? defaultValue = null)
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

        /// <summary>
        /// Return null if string is '' or null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string NullIfEmpty(this string s)
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
        public static string EmptyIfNull(this string s)
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
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String s)
        {
            return !IsNotNullOrEmpty(s);
        }

        /// <summary>
        /// Return true if string is not null, empty or consists exclusively of whitespace
        /// </summary>
        /// <param name="s"></param>
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
