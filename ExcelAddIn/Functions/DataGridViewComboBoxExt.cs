﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Functions
{

    public static class DataGridViewComboBoxExt
    {
        /// <summary>
        /// Set the data source of a combobox to values read from a data table
        /// </summary>
        /// <param name="pDataGridViewComboBoxCol"></param>
        /// <param name="pDataSource"></param>
        /// <param name="pDisplayMember"></param>
        /// <param name="pValueMember"></param>
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

        /// <summary>
        /// Set data source of combo box to IEnumerable collection
        /// </summary>
        /// <param name="pDataGridViewComboBoxCol"></param>
        /// <param name="pEnumerable"></param>
        /// <param name="pDisplayMember"></param>
        /// <param name="pValueMember"></param>
        public static void SetDataSource(this DataGridViewComboBoxColumn pDataGridViewComboBoxCol, IEnumerable pEnumerable, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.DataSource = new BindingSource(pEnumerable, null);
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


        /// <summary>
        /// Adds an item to a combobox collection if it does not already exist there
        /// </summary>
        /// <param name="pComboBoxCell"></param>
        /// <param name="pItem"></param>
        [Obsolete("All statvars to be predefined")]
        public static void AddItemIfNotExists(this DataGridViewComboBoxCell pComboBoxCell, ComboBoxItem pItem)
        {
            if (pComboBoxCell != null && pItem != null && pComboBoxCell.DataSource == null && !pComboBoxCell.HasItem(pItem))
            {
                Debug.WriteLine("verdi added: " + pItem.value);
                pComboBoxCell.Items.Add(pItem);

                pComboBoxCell.DisplayMember = "key";
                pComboBoxCell.ValueMember = "value";
                pComboBoxCell.Value = pItem.key;
            }

            return;
        }

        /// <summary>
        /// Checks if a combobox has an item with teh same key name
        /// </summary>
        /// <param name="pCell"></param>
        /// <param name="pNewItem"></param>
        /// <returns></returns>
        public static bool HasItem(this DataGridViewComboBoxCell pCell, ComboBoxItem pNewItem)
        {
            try
            {
                if (pCell == null)
                {
                    throw new Exception("ComboBoxCell is null");
                }

                if (pCell.Items != null)
                {
                    throw new Exception("ComboBoxItems is null");
                }

                foreach (ComboBoxItem mItem in pCell.Items)
                {
                    if (mItem.key == pNewItem.key)
                    {
                        return true;
                    };
                }

                throw new Exception("Could not find key in array");

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Copy value and data source binding from a DataGridViewComboBoxCell object
        /// </summary>
        /// <param name="tgtCell"></param>
        /// <param name="srcCell"></param>
        public static void CopyValueFrom(this DataGridViewComboBoxCell tgtCell, DataGridViewComboBoxCell srcCell)
        {
            if (srcCell.DataSource != null)
            {
                tgtCell.DataSource = new BindingSource(srcCell.DataSource, null);
                tgtCell.ValueMember = srcCell.ValueMember;
                tgtCell.DisplayMember = srcCell.DisplayMember;
            }
            tgtCell.Value = srcCell.Value;
        }

    }
}
