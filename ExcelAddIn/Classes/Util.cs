using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Util
    {

        public static string GetFilenameTemplate(string pExt)
        {
            return DateTime.Now.ToString("yyyyMMdd-HHmmss") + "." + pExt;
        }

        public static CType GetSelCType(ComboBox pComboBox)
        {
            CType mStatus = CType.None;
            if (pComboBox.SelectedValue != null)
            {
                Enum.TryParse<CType>(pComboBox.SelectedValue.ToString(), out mStatus);
            }
            return mStatus;
        }

        public static void DebugFields(Object pObj) {
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

        public static void SetDgvComboBoxDS(DataGridViewComboBoxColumn pDataGridViewComboBoxCol, DataTable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.DataSource = pDataSource;
            pDataGridViewComboBoxCol.ValueType = typeof(string);
            pDataGridViewComboBoxCol.ValueMember = pValueMember;
            pDataGridViewComboBoxCol.DisplayMember = pDisplayMember;
        }

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