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

        public static void SetDgvComboBoxDS(DataGridViewComboBoxColumn pDataGridViewComboBoxCol, IEnumerable pEnumerable, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.DataSource = pEnumerable;
            pDataGridViewComboBoxCol.ValueType = typeof(string);
            pDataGridViewComboBoxCol.ValueMember = pValueMember;
            pDataGridViewComboBoxCol.DisplayMember = pDisplayMember;
        }

        /// <summary>
        /// Add items to a DataGridViewComboBox (permits editing of values once datasource is not bound)
        /// </summary>
        /// <param name="pNameOfColumn">Name of the column in the DataGridView</param>
        /// <param name="pComboBoxItems">A List<> of ComboBoxItem objects</param>
        /// <param name="pDisplayMember">The property of the ComboBoxItem to use for display</param>
        /// <param name="pValueMember">The property of the ComboBoxItem to use as value</param>
        public static void AddItemsToDGVComboBox(
            DataGridViewColumn pNameOfColumn,
            List<ComboBoxItem> pComboBoxItems,
            string pDisplayMember = "key",
            string pValueMember = "value")
        {
            var mCol = pNameOfColumn as DataGridViewComboBoxColumn;
            mCol.Items.Clear();
            foreach (var mItem in pComboBoxItems)
            {
                mCol.Items.Add(mItem);
            }
            mCol.ValueType = typeof(string);
            mCol.ValueMember = pValueMember;
            mCol.DisplayMember = pDisplayMember;
        }

        public static void AddItemstoComboBoxFromDataTable(DataGridViewComboBoxColumn pDataGridViewComboBoxCol, DataTable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.Items.Clear();
            foreach (DataRow mDataRow in pDataSource.Rows)
            {
                pDataGridViewComboBoxCol.Items.Add(new ComboBoxItem(mDataRow[pDisplayMember].ToString(), mDataRow[pValueMember].ToString()));
            }
            pDataGridViewComboBoxCol.ValueMember = pValueMember;
            pDataGridViewComboBoxCol.DisplayMember = pDisplayMember;
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