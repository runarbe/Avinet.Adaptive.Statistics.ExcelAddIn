using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Export
    {

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

        public static void CheckDgvCell(DataGridViewCheckBoxCell mCell)
        {
            mCell.Value = mCell.TrueValue;
        }

        public static void UnchekDgvCell(DataGridViewCheckBoxCell mCell)
        {
            mCell.Value = mCell.FalseValue;
        }

        public static void CheckAllDataGridView(DataGridView mDgv, string mColName)
        {
            foreach (DataGridViewRow mRow in mDgv.Rows)
            {
                var mCell = mRow.Cells[mColName] as DataGridViewCheckBoxCell;
                Export.CheckDgvCell(mCell);
            }
        }

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
                int mIncludeRow;

                // Check if the row is to be included in the export
                if (!int.TryParse(Export.GetDGVVal(mFieldProperties, "Include"), out mIncludeRow))
                {
                    pForm.Log(String.Format("Kunne ikkje avgjere om rad #{0} skal vere med i eksporten", mIncludeRow));
                    return null;
                }

                // If it is to be included, proceed
                if (mIncludeRow == 1)
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
                    string mYearPart = Export.GetDGVVal(mFieldProperties, "YearPart");
                    string mMonth = Export.GetDGVVal(mFieldProperties, "Month");
                    string mDay = Export.GetDGVVal(mFieldProperties, "Day");
                    string mVariableType = Export.GetDGVVal(mFieldProperties, "VariableType");
                    var mSplitVariableType = mVariableType.Split('#').ToList<string>();

                    // Then, loop through all the data values and write them to the CSV
                    foreach (KeyValuePair<int, AdaptiveRow> mRow2 in pValues3D)
                    {
                        // If the 
                        double mValue;
                        if (double.TryParse(mRow2.Value[mFieldPropertyIndex].Value, out mValue))
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
                            mLine.quarter = mYearPart;
                            mLine.month = mMonth;
                            mLine.day = mDay;

                            // Set the actual statistical value
                            mLine.value = mValue;

                            // Set the statistical variable type
                            var numVariableLevels = mSplitVariableType.Count();

                            if (numVariableLevels >= 5)
                            {
                                mLine.variable5 = mSplitVariableType[4];
                            }
                            if (numVariableLevels >= 4)
                            {
                                mLine.variable4 = mSplitVariableType[3];
                            }
                            if (numVariableLevels >= 3)
                            {
                                mLine.variable3 = mSplitVariableType[2];
                            }
                            if (numVariableLevels >= 2)
                            {
                                mLine.variable2 = mSplitVariableType[1];
                            }
                            if (numVariableLevels >= 1)
                            {
                                mLine.variable1 = mSplitVariableType[0];
                            }

                            // Add the line to the CSV file
                            mCsv.Add(mLine);
                        }
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

        }
    }
}