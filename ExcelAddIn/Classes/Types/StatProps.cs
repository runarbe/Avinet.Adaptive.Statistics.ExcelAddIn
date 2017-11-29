using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    /// <summary>
    /// Temporary storage for n-dimensional properties of each single statistical variable value included
    /// in the current selection
    /// </summary>
    public class StatProps : Dictionary<int, object>
    {
        /// <summary>
        /// Determine whether the valuesList shall be accessed by rowIndex or by columnIndex
        /// </summary>
        public DataOrientation DataOrientation = DataOrientation.InRows;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param title="pType">Set whether valuesList are in rows or in columns</param>
        public StatProps(DataOrientation pType = DataOrientation.InRows)
        {
            this.DataOrientation = pType;
        }

        /// <summary>
        /// Add a property at the specified statVarIndex
        /// </summary>
        /// <param title="pIndex">The rowIndex or columnIndex statVarIndex</param>
        /// <param title="pValue">The property value to store</param>
        public void AddValue(int pIndex, string pValue)
        {
            this[pIndex] = pValue;
        }

        public System.Data.DataTable AsDataTable(int pFirstDataRow = 1, int pFirstDataCol = 1, StatProps pStatProps = null)
        {
            int mStartIndex;
            if (this.DataOrientation == DataOrientation.InRows)
            {
                mStartIndex = pFirstDataCol;
            }
            else
            {
                mStartIndex = pFirstDataRow;
            }

            var mDataTable = new System.Data.DataTable();

            mDataTable.Columns.Add(new System.Data.DataColumn("Index", typeof(int)));
            mDataTable.Columns.Add(new System.Data.DataColumn("Title", typeof(string)));

            if (pStatProps != null && pStatProps.Count() == this.Count())
            {
                mDataTable.Columns.Add(new System.Data.DataColumn("Title2", typeof(string)));
            }

            for (int i = mStartIndex, j = this.Values.Count; i <= j; i++)
            {
                var mRow = mDataTable.NewRow();
                mRow["Index"] = i;
                mRow["Title"] = this[i];
                if (pStatProps != null && pStatProps.Count() == this.Count())
                {
                    mRow["Title2"] = pStatProps[i];
                }
                mDataTable.Rows.Add(mRow);
            }

            return mDataTable;

        }

        /// <summary>
        /// Return a property value for a rowIndex,srcCol pair
        /// </summary>
        /// <param title="pRow">Row statVarIndex</param>
        /// <param title="pCol">Column statVarIndex</param>
        /// <returns>A value as a string</returns>
        public object GetValue(int pRow, int pCol)
        {
            if (this.DataOrientation == DataOrientation.InColumns)
            {
                if (this.Keys.Contains(pRow))
                {
                    return this[pRow];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (this.Keys.Contains(pCol))
                {
                    return this[pCol];
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
