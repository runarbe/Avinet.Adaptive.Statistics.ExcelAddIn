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

        public void AddByKey(string pValue, int pFieldIndex, int pRowIndex)
        {
            if (!this.ContainsKey(pRowIndex)) {
                this.Add(pRowIndex, new AdaptiveRow());
            }

            if (!this[pRowIndex].ContainsKey(pFieldIndex)) {
                this[pRowIndex].Add(pFieldIndex, "");
            }

            this[pRowIndex][pFieldIndex] = pValue;
        }

        public string GetValueByFieldRow(int pFieldIndex, int pRowIndex)
        {
            if (!this.ContainsKey(pRowIndex))
            {
                //Row doesn't exist
                return "";
            }

            if (!this[pRowIndex].ContainsKey(pFieldIndex))
            {
                // Field doesn't exist
                return "";
            }

            return this[pRowIndex][pFieldIndex];
        }

        public Dictionary<int, string> GetRow(int pRowIndex)
        {
            return this[pRowIndex];
        }

    }

    public class Values3DOld : Dictionary<Key, string>
    {
        public void AddByKey(string pValue, int pFieldIndex, int pRowIndex)
        {
            var mKey = new Key(pFieldIndex, pRowIndex);
            this.Add(mKey, pValue);
        }

        public string GetValueByFieldRow(int pFieldIndex, int pRowIndex)
        {
            foreach (KeyValuePair<Key, string> mEntry in this)
            {
                if (mEntry.Key.RowIndex == pRowIndex && mEntry.Key.FieldIndex == pFieldIndex)
                {
                    return mEntry.Value;
                }
            }
            return "";
        }

        public Values3DOld GetRow(int pRowIndex)
        {
            var m = new Values3DOld();
            foreach (KeyValuePair<Key, string> mval in this)
            {
                if (mval.Key.RowIndex == pRowIndex)
                {
                    m.Add(mval.Key, mval.Value);
                }
            }
            return m;
        }

    }
}