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
        /// Determine whether the data shall be accessed by row or by column
        /// </summary>
        public DataOrientation Type = DataOrientation.InRows;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="pType">Set whether data are in rows or in columns</param>
        public StatProps(DataOrientation pType = DataOrientation.InRows)
        {
            this.Type = pType;
        }

        /// <summary>
        /// Add a property at the specified index
        /// </summary>
        /// <param name="pIndex">The row or column index</param>
        /// <param name="pValue">The property value to store</param>
        public void AddValue(int pIndex, string pValue)
        {
            this[pIndex] = pValue;
        }

        public System.Data.DataTable AsDataTable()
        {
            var mDataTable = new System.Data.DataTable();
            mDataTable.Columns.Add(new System.Data.DataColumn("Title",typeof(string)));
            foreach (var mVar in this.Values)
            {
                var mRow = mDataTable.NewRow();
                mRow[0] = mVar;
                mDataTable.Rows.Add(mRow);
            }

            return mDataTable;

        }

        /// <summary>
        /// Return a property value for a row,col pair
        /// </summary>
        /// <param name="pRow">Row index</param>
        /// <param name="pCol">Column index</param>
        /// <returns>A value as a string</returns>
        public object GetValue(int pRow, int pCol)
        {
            if (this.Type == DataOrientation.InColumns)
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
