using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Util
    {

        [Obsolete]
        /// <summary>
        /// Return a stream from a string
        /// </summary>
        /// <param name="pString">Any string</param>
        /// <returns>Stream</returns>
        public static Stream StreamFromString(String pString)
        {
            var mEncoding = new UTF8Encoding();
            Byte[] mBytes = mEncoding.GetBytes(pString);
            MemoryStream mStream = new MemoryStream();
            mStream.Write(mBytes, 0, mBytes.Length);
            return mStream;
        }

        public static string GetFilenameTemplate(string pExt)
        {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + pExt;
        }

        public static int GetComboBoxSelectedTextAsInt(ComboBox pComboBox)
        {
            int mStatus = -1;
            if (pComboBox.Text != null && pComboBox.Text != "")
            {
                int.TryParse(pComboBox.Text, out mStatus);
            }
            return mStatus;
        }

        public static int GetComboBoxSelectedValueInt(ComboBox pComboBox)
        {
            int mStatus = -1;
            if (pComboBox.SelectedValue != null)
            {
                Debug.WriteLine(pComboBox.SelectedValue);
                int.TryParse(pComboBox.SelectedValue.ToString(), out mStatus);
            }
            return mStatus;
        }

        public static string GetComboBoxSelectedValueString(ComboBox pComboBox)
        {
            string mStatus = CellContentType.Values;
            if (pComboBox.SelectedValue != null && pComboBox.SelectedValue.GetType() == typeof(string))
            {
                var mSelectedValue = (string)pComboBox.SelectedValue;
                mStatus = mSelectedValue;
            }
            return mStatus;
        }

        public static string ReadResourceFile(string pFilename)
        {
            var mFileContent = string.Empty;
            mFileContent = File.ReadAllText(Util.GetFullResourceFilename(pFilename));
            return mFileContent;
        }

        public static string GetFullResourceFilename(string pFilename)
        {
            // Get the assembly information
            System.Reflection.Assembly assemblyInfo = System.Reflection.Assembly.GetExecutingAssembly();

            // Location is where the assembly is run from 
            string assemblyLocation = assemblyInfo.Location;

            // CodeBase is the location of the ClickOnce deployment files
            Uri uriCodeBase = new Uri(assemblyInfo.CodeBase);

            // The location of any resource files
            string ClickOnceLocation = Path.GetDirectoryName(uriCodeBase.LocalPath.ToString());

            return ClickOnceLocation + "\\" + pFilename;

        }

        public static bool SaveResourceFile(string pFilename, string pFileContent)
        {
            File.WriteAllText(Util.GetFullResourceFilename(pFilename), pFileContent);
            return true;
        }

        public static void DebugFields(Object pObj)
        {
            foreach (FieldInfo mFld in pObj.GetType().GetFields())
            {
                Debug.Write(mFld.Name + " ");
                Debug.WriteLine(mFld.GetValue(pObj));
            }
        }


        public static string CheckNullOrEmpty(object pObj)
        {
            string pString;
            if (pObj != null)
            {
                pString = pObj.ToString();
            }
            else
            {
                return null;
            }
            if (!String.IsNullOrWhiteSpace(pString))
            {
                return pString;
            }
            else
            {
                return null;
            }
        }

        public static bool IsJsonString(string pJsonString)
        {
            if (
                pJsonString.Length >= 2 &&
                pJsonString.Substring(0, 1) == "{" &&
                pJsonString.Substring(pJsonString.Length - 1) == "}"
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetComboBoxDS(ComboBox pComboBox, IEnumerable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {
            var tmp = pComboBox.SelectedValue;
            pComboBox.DataSource = pDataSource;
            pComboBox.ValueMember = pValueMember;
            pComboBox.DisplayMember = pDisplayMember;
            if (tmp != null)
            {
                pComboBox.SelectedValue = tmp;
            }
        }

        [Obsolete]
        public static void AddItemstoComboBox(ComboBox pComboBox, List<ComboBoxItem> pItems)
        {
            pComboBox.DataSource = pItems;
            pComboBox.DisplayMember = "key";
            pComboBox.ValueMember = "value";
            pComboBox.Refresh();
        }

        [Obsolete]
        public static void DebugDataGridView(DataGridView pDGV)
        {
            for (int k = 0, l = pDGV.RowCount; k < l; k++)
            {
                foreach (DataGridViewColumn mCol in pDGV.Columns)
                {
                    Debug.WriteLine(k + " " + mCol.Name + " " + pDGV[mCol.Name, k].Value, "Debug");
                }
            }

        }

    }
}