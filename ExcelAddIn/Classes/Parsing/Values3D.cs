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
                this[pRowIndex].Add(pFieldIndex, new AdaptiveValue(""));
            }

            this[pRowIndex][pFieldIndex] = pValue;
        }

        public string GetValueByFieldRow(int pFieldIndex, int pRowIndex)
        {
            if (!this.ContainsKey(pRowIndex))
            {
                //InRows doesn't exist
                return "";
            }

            if (!this[pRowIndex].ContainsKey(pFieldIndex))
            {
                // Field doesn't exist
                return "";
            }

            return this[pRowIndex][pFieldIndex].Value;
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

        public string GetCSVHeader()
        {
            return "\"krets_id\";\"krets_navn\";\"region\";\"år\";\"kvartal\"; \"mnd\";\"variable1\";\"variable2\";\"variable3\";\"variable4\";\"variable5\";\"verdi\";\"enhet\"";
        }

    }

}