using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Shared
{

    public static class DataGridViewComboBoxExt
    {
        public static void AddItemsFromDataTable(this DataGridViewComboBoxColumn pDataGridViewComboBoxCol, DataTable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.Items.Clear();
            foreach (DataRow mDataRow in pDataSource.Rows)
            {
                pDataGridViewComboBoxCol.Items.Add(new ComboBoxItem(mDataRow[pValueMember].ToString(), mDataRow[pValueMember].ToString()));
            }
            pDataGridViewComboBoxCol.ValueMember = pValueMember;
            pDataGridViewComboBoxCol.DisplayMember = pDisplayMember;
        }
        public static void SetDataSource(this DataGridViewComboBoxColumn pDataGridViewComboBoxCol, IEnumerable pEnumerable, string pDisplayMember = "key", string pValueMember = "value")
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
        public static void AddItemsFromList(
            this DataGridViewColumn pNameOfColumn,
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


        public static void AddItemIfNotExists(this DataGridViewComboBoxCell pComboBoxCell, ComboBoxItem pItem)
        {
            if (pItem != null && !pComboBoxCell.HasItem(pItem))
            {
                Debug.WriteLine("Value added: " + pItem.value);
                pComboBoxCell.Items.Add(pItem);
            }

            //pComboBoxCell.ValueType = typeof(string);
            pComboBoxCell.DisplayMember = "key";
            pComboBoxCell.ValueMember = "value";
            pComboBoxCell.Value = pItem.key;
            return;
        }

        public static bool HasItem(this DataGridViewComboBoxCell pCell, ComboBoxItem pNewItem)
        {
            foreach (ComboBoxItem mItem in pCell.Items)
            {
                if (mItem.key == pNewItem.key) return true;
            }
            return false;
        }

    }
}
