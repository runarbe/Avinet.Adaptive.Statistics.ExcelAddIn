using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Export
    {

        public static Boolean WriteCSVFile(Values3D pData, string pFileName, string pEncoding = "UTF-8")
        {
            try
            {
                // Setup the two encoding objects
                var mSourceEncoding = Encoding.GetEncoding("UTF-8");
                var mTargetEncoding = Encoding.GetEncoding(pEncoding);

                // Determine whether transcoding is necessary
                bool mTranscode = false;
                if (mSourceEncoding != mTargetEncoding)
                {
                    mTranscode = true;
                }

                // Create a new streamwriter with the required output encoding
                var mStreamWriter = new StreamWriter(pFileName, false, mTargetEncoding);

                string mCsvHeader;

                if (mTranscode)
                {
                    mCsvHeader = mTargetEncoding.GetString(mSourceEncoding.GetBytes(pData.GetCSVHeader()));
                }
                else
                {
                    mStreamWriter.Write(mSourceEncoding.GetPreamble());
                    mCsvHeader = pData.GetCSVHeader();
                }

                mStreamWriter.WriteLine(mCsvHeader);
                foreach (var mRow in pData.Keys)
                {
                    foreach (var mCol in pData[mRow].Keys)
                    {
                        string mLine;
                        if (mTranscode)
                        {
                            mLine = mTargetEncoding.GetString(mSourceEncoding.GetBytes(pData[mRow][mCol].ToCSV()));
                        }
                        else
                        {
                            mLine = pData[mRow][mCol].ToCSV();
                        }
                        mStreamWriter.WriteLine(mLine);
                    }
                }
                mStreamWriter.Flush();
                mStreamWriter.Close();
                mStreamWriter = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [Obsolete]
        public static string GetDGVVal(DataGridViewRow pRow, string pColName)
        {
            DataGridViewCell mCell = pRow.Cells[pColName];

            if (mCell.GetType() == typeof(DataGridViewCheckBoxCell))
            {
                var mDCell = mCell as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(mDCell.Value) == true)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            if (mCell.GetType() == typeof(DataGridViewComboBoxCell))
            {
                var mDCell = mCell as DataGridViewComboBoxCell;
                if (mDCell.Value != null)
                {
                    return (string)mDCell.Value;
                }
                else
                {
                    return "";
                }
            }
            if (mCell.GetType() == typeof(DataGridViewTextBoxCell))
            {
                var mDCell = mCell as DataGridViewTextBoxCell;
                if (mDCell != null)
                {
                    return (string)mDCell.Value;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

        [Obsolete]
        public static void CheckDgvCell(DataGridViewCheckBoxCell mCell)
        {
            mCell.Value = mCell.TrueValue;
        }

        [Obsolete]
        public static void UnchekDgvCell(DataGridViewCheckBoxCell mCell)
        {
            mCell.Value = mCell.FalseValue;
        }

        [Obsolete]
        /*public static void CheckAllDataGridView(DataGridView mDgv, string mColName)
        {
            foreach (DataGridViewRow mRow in mDgv.Rows)
            {
                var mCell = mRow.Cells[mColName] as DataGridViewCheckBoxCell;
                Export.CheckDgvCell(mCell);
            }
        }*/

        public static string GetVal(DataGridViewRow pRow, string pName)
        {
            if (pRow.Cells[pName].Value == null) return null;
            return pRow.Cells[pName].Value.ToString();
        }

        public static string GetCheckedVal(DataGridViewRow pRow, string pName)
        {
            var mCell = pRow.Cells[pName] as DataGridViewCheckBoxCell;
            if (Convert.ToBoolean(mCell.Value) == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public static string GetSelVal(ComboBox pCb)
        {
            return pCb.SelectedValue.ToString();
        }

        /*[Obsolete]
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="pDataGridView"></param>
        /// <param name="pValues3D"></param>
        /// <param name="pForm"></param>
        public static CsvFile Do(DataGridView pDataGridView, Values3D pValues3D, UploadForm pForm)
        {
            // Create a new CSV file
            var mCsv = new CsvFile();

            // For each field in the data grid view
            foreach (DataGridViewRow mFieldProperties in pDataGridView.Rows)
            {

                // First, parse the values of the row and the form
                int mFieldPropertyIndex;

                if (!int.TryParse(Export.GetDGVVal(mFieldProperties, "FieldIndex"), out mFieldPropertyIndex))
                {
                    pForm.Log("Feil: kunne ikkje omsetje feltindeksen til eitt heiltal");
                    return null;
                }


                string mStatUnitType = Export.GetSelVal(pForm.cbStatUnitType);

                string mTitle = Export.GetDGVVal(mFieldProperties, "Title");
                string mMeasurementUnit = Export.GetDGVVal(mFieldProperties, "MeasurementUnit");
                string mYear = Export.GetDGVVal(mFieldProperties, "Year");
                string mQuarter = Export.GetDGVVal(mFieldProperties, "Quarter");
                string mMonth = Export.GetDGVVal(mFieldProperties, "Month");
                string mDay = Export.GetDGVVal(mFieldProperties, "Day");
                string mStatVar1 = Export.GetDGVVal(mFieldProperties, "StatVarCol1");
                string mStatVar2 = Export.GetDGVVal(mFieldProperties, "StatVarCol2");
                string mStatVar3 = Export.GetDGVVal(mFieldProperties, "StatVarCol3");
                string mStatVar4 = Export.GetDGVVal(mFieldProperties, "StatVarCol4");
                string mStatVar5 = Export.GetDGVVal(mFieldProperties, "StatVarCol5");

                // Then, loop through all the data values and write them to the CSV
                foreach (KeyValuePair<int, AdaptiveRow> mRow2 in pValues3D)
                {
                    // If the 
                    double mUserEnteredValue;
                    if (double.TryParse(mRow2.Value[mFieldPropertyIndex].Value, out mUserEnteredValue))
                    {
                        // Create a new line for the CSV file
                        var mLine = new CsvLine();

                        mLine.krets_name = "";

                        mLine.region = "";

                        // Set the StatUnitType
                        mLine.kretstype_id = mStatUnitType;

                        // Set the StatUnitId
                        mLine.krets_id = "1";

                        // Set the measurement unit used
                        mLine.unit = mMeasurementUnit;

                        // Set time metadata
                        mLine.year = mYear;
                        mLine.quarter = mQuarter;
                        mLine.month = mMonth;
                        mLine.day = mDay;

                        // Set the actual statistical value
                        mLine.value = mUserEnteredValue;

                        mLine.variable5 = mStatVar5;
                        mLine.variable4 = mStatVar4;
                        mLine.variable3 = mStatVar3;
                        mLine.variable2 = mStatVar2;
                        mLine.variable1 = mStatVar1;
                        // Add the line to the CSV file
                        mCsv.Add(mLine);
                    }

                }

            }

            if (mCsv.Count() > 0)
            {
                pForm.Log("Informasjon: ferdig - skreiv " + mCsv.Count() + " rader til fil...");
            }
            else
            {
                pForm.Log("Informasjon: tom fil.");
            }

            return mCsv;

        }*/
    }
}