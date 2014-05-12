using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// A class to hold the current state of a field
    /// </summary>
    [Serializable]
    public class UploadFormFieldState
    {
        public string ExcelFieldName { get; set; }
        public string StatVarLevel1 { get; set; }
        public string StatVarLevel2 { get; set; }
        public string StatVarLevel3 { get; set; }
        public string StatVarLevel4 { get; set; }
        public string StatVarLevel5 { get; set; }
        public string MeasurementUnit { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public UploadFormFieldState()
        {
        }

        public static List<UploadFormFieldState> GetFieldStates(DataGridView pDgv)
        {
            var mFields = new List<UploadFormFieldState>();
            foreach (DataGridViewRow m in pDgv.Rows)
            {
                var mField = new UploadFormFieldState();
                mField.ExcelFieldName = (string)m.Cells["Title"].Value;
                mField.StatVarLevel1 = (string)m.Cells["StatVarCol1"].Value;
                mField.StatVarLevel2 = (string)m.Cells["StatVarCol2"].Value;
                mField.StatVarLevel3 = (string)m.Cells["StatVarCol3"].Value;
                mField.StatVarLevel4 = (string)m.Cells["StatVarCol4"].Value;
                mField.StatVarLevel5 = (string)m.Cells["StatVarCol5"].Value;
                mField.MeasurementUnit = (string)m.Cells["MeasurementUnit"].Value;
                mField.Year = (string)m.Cells["Year"].Value;
                mField.Quarter = (string)m.Cells["Quarter"].Value;
                mField.Month = (string)m.Cells["Month"].Value;
                mField.Day = (string)m.Cells["Day"].Value;

                mFields.Add(mField);
            }
            return mFields;
        }

    }
}
