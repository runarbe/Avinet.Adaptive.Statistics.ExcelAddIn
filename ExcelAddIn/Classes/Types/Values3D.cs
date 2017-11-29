using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using Microsoft.Office.Interop.Excel;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class Values3D : AdaptiveMatrix
    {

        public void AddByKey(AdaptiveValue pValue, int pFieldIndex, int pRowIndex)
        {
            if (!this.ContainsKey(pRowIndex))
            {
                this.Add(pRowIndex, new AdaptiveRow());
            }

            if (!this[pRowIndex].ContainsKey(pFieldIndex))
            {
                this[pRowIndex].Add(pFieldIndex, null);
            }

            this[pRowIndex][pFieldIndex] = pValue;
        }

        public double? GetValueByFieldRow(int pFieldIndex, int pRowIndex)
        {
            if (!this.ContainsKey(pRowIndex))
            {
                //InRows doesn't exist
                return null;
            }

            if (!this[pRowIndex].ContainsKey(pFieldIndex))
            {
                // Field doesn't exist
                return null;
            }

            return this[pRowIndex][pFieldIndex].value;
        }

        public Dictionary<int, AdaptiveValue> GetRow(int pRowIndex)
        {
            return this[pRowIndex];
        }

        public Dictionary<int, AdaptiveValue> GetCol(int pColIndex)
        {
            var mRetVal = new Dictionary<int, AdaptiveValue>();
            foreach (int mRow in this.Keys)
            {
                mRetVal.Add(mRow, this[mRow][pColIndex]);
            }
            return mRetVal;
        }

        public Dictionary<int, string> GetRowsCols()
        {
            var mRetVal = new Dictionary<int, string>();
            foreach (int mRowIndex in this.Keys) {
                mRetVal.Add(mRowIndex, String.Format("Row #{0}", mRowIndex));
            }
            if (this.Count() > 0)
            {
                foreach (int mColIndex in this.Keys)
                {
                    mRetVal.Add(mColIndex, String.Format("Col #{0}", mColIndex));
                }
            }
            return mRetVal;
        }

        /// <summary>
        /// Structure all valuesList from the selected upload valuesList into a list
        /// </summary>
        /// <param title="pData"></param>
        /// <returns>List of AdaptiveValue objects</returns>
        public List<AdaptiveValue> AsAdaptiveValuesList()
        {
            var valueList = new List<AdaptiveValue>();

            foreach (var mRow in this.Keys)
            {
                foreach (var mCol in this[mRow].Keys)
                {
                    var dataItem = this[mRow][mCol];
                    if (dataItem != null)
                    {
                        var validation = dataItem.Validate();

                        if (validation.IsValid)
                        {
                            valueList.Add(this[mRow][mCol]);
                        }
                        else
                        {
                            return null;
                        }

                    }
                }
            }
            return valueList;
        }


    }

}