using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Table
    {
        /// <summary>
        /// Get a data table from an Excel range object
        /// </summary>
        /// <param name="pSelection">Excel range object</param>
        /// <returns>A .NET DataTable</returns>
        public static System.Data.DataTable GetTableFromExcelRange(Range pSelection)
        {
            Object[,] mSelection = pSelection.Cells.Value;

            var mDataTable = new System.Data.DataTable();
            for (int i = 1, j = pSelection.Columns.Count; i <= j; i++)
            {
                mDataTable.Columns.Add(new DataColumn("Kolonne " + i, typeof(string)));
            }

            for (int mRowNum = 1, mNumRows = pSelection.Rows.Count; mRowNum <= mNumRows; mRowNum++)
            {
                var mRow = mDataTable.NewRow();

                for (int mColNum = 1, mNumCols = pSelection.Columns.Count; mColNum <= mNumCols; mColNum++)
                {
                    mRow[mColNum - 1] = Table.GetNullOrString(mSelection[mRowNum, mColNum]);
                }
                mDataTable.Rows.Add(mRow);
            }

            return mDataTable;
        }

        /// <summary>
        /// Return a variable definition or null
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static Variable GetNullOrVariable(object pObj)
        {
            if (pObj != null && pObj.GetType() == typeof(Variable))
            {
                return (Variable)pObj;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// If the passed object can be converted into a string, return a stirng
        /// </summary>
        /// <param name="pObj">Any object</param>
        /// <returns>String if possible, otherwise null</returns>
        public static string GetNullOrString(object pObj)
        {
            if (pObj != null)
            {
                return pObj.ToString();
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// Get a string containing a double value or null
        /// </summary>
        /// <param name="pVar">Any object likely to contain a double</param>
        /// <returns>A double as a stirng or the string "null"</returns>
        public static string GetNullOrDoubleString(object pVar)
        {
            double mDouble;

            if (pVar != null)
            {
                string mVar = pVar.ToString();
                if (Double.TryParse(mVar, out mDouble))
                {
                    return mDouble.ToString();
                }
                else
                {
                    return "null";
                }
            }
            else
            {
                return "null";
            }
        }

        /// <summary>
        /// Get a row or a column from the selection
        /// </summary>
        /// <param name="mSelection">An Excel range object</param>
        /// <param name="pIndexNum">The 1-based index of the row or column to retrieve</param>
        /// <param name="pDataOrientation">Whether to get a row or a column</param>
        /// <returns></returns>
        public static StatProps GetIndex(Object[,] mSelection, int pIndexNum, DataOrientation pDataOrientation)
        {
            if (pDataOrientation == DataOrientation.InColumns)
            {
                return GetColNum(mSelection, pIndexNum, pDataOrientation);
            }
            else
            {
                return GetRowNum(mSelection, pIndexNum, pDataOrientation);
            }
        }

        public static StatProps GetColNum(Object[,] mSelection, int pColNum = 1, DataOrientation pDataOrientation = DataOrientation.InColumns)
        {
            if (pColNum <= mSelection.GetLength(1))
            {
                var mStatProps = new StatProps(pDataOrientation);
                for (int mRowNum = 1, mNumRows = mSelection.GetLength(0); mRowNum <= mNumRows; mRowNum++)
                {
                    mStatProps.AddValue(mRowNum, Table.GetNullOrString(mSelection[mRowNum, pColNum]));
                }
                return mStatProps;
            }
            else
            {
                return null;
            }

        }

        public static StatProps GetRowNum(Object[,] mSelection, int pRowNum = 1, DataOrientation pDataOrientation = DataOrientation.InRows)
        {
            if (pRowNum <= mSelection.GetLength(0))
            {
                var mStatProps = new StatProps(pDataOrientation);
                for (int mColNum = 1, mNumCols = mSelection.GetLength(1); mColNum <= mNumCols; mColNum++)
                {
                    mStatProps.Add(mColNum, Table.GetNullOrString(mSelection[pRowNum, mColNum]));
                }
                return mStatProps;
            }
            else
            {
                return null;
            }
        }


        public static Values3D ParseSelectionWithCurrentSettings(Range pSelection, UploadForm pFrm, int mFirstDataRow, int mFirstDataCol)
        {

            var mMessages = new MessageObject();

            pFrm.Log("Freistar å prosessere utvalet med gjeldande innstillingar", true);

            var mTimer = new Stopwatch();
            mTimer.Start();

            var mSelection = pSelection.Cells.Value;

            // Create data object to hold values
            var mData = new Values3D();

            // For each row
            for (int mR = mFirstDataRow; mR <= pSelection.Rows.Count; mR++)
            {
                // For each column
                for (int mC = mFirstDataCol; mC <= pSelection.Columns.Count; mC++)
                {
                    // Get the value (as a double)
                    var mAdaptiveValue = new AdaptiveValue(Table.GetNullOrDoubleString(mSelection[mR, mC]));

                    // Get manual settings for statistical variable
                    var mManualStatVarProps = pFrm.ParseStatVarProperties(mR, mC, pFrm.StatVarProperties.DataOrientation);

                    // Get/set the corresponding statvar
                    if (mManualStatVarProps.StatVar1 != null)
                    {
                        mAdaptiveValue.variable1 = mManualStatVarProps.StatVar1.var1;

                        if (String.IsNullOrWhiteSpace(mManualStatVarProps.StatVar1.var1))
                        {
                            mMessages.AddMessage(MessagesNotices.StatVarParseUsingDefaultNotice);
                        }
                        
                    }

                    if (mManualStatVarProps.StatVar2 != null)
                    {
                        mAdaptiveValue.variable2 = mManualStatVarProps.StatVar2.var2;
                    }

                    if (mManualStatVarProps.StatVar3 != null)
                    {
                        mAdaptiveValue.variable3 = mManualStatVarProps.StatVar3.var3;
                    }

                    if (mManualStatVarProps.StatVar4 != null)
                    {
                        mAdaptiveValue.variable4 = mManualStatVarProps.StatVar4.var4;
                    }

                    if (mManualStatVarProps.StatVar5 != null)
                    {
                        mAdaptiveValue.variable5 = mManualStatVarProps.StatVar5.var5;
                    }

                    mAdaptiveValue.fk_variable = mManualStatVarProps.fk_variable;

                    // Get/set the measurement unit
                    mAdaptiveValue.enhet = mManualStatVarProps.MeasurementUnit;
                    if (mAdaptiveValue.enhet == null)
                    {
                        mMessages.AddMessage(MessagesErrors.MUnitNotSet);
                    }

                    // Add date, if available
                    if (pFrm.StatDatumProperties != null)
                    {
                        // Add logic to parse the date value into its individual parts here
                        var mStatDatum = new StatDateParser((string)pFrm.StatDatumProperties.GetValue(mR, mC), (string)pFrm.cbStatDatumFormat.SelectedValue);

                        if (mStatDatum.Success == true)
                        {
                            mAdaptiveValue.ar = mStatDatum.Year;
                            mAdaptiveValue.mnd = mStatDatum.Month;
                            //mAdaptiveValue.Day = mStatDatum.Day;
                            mAdaptiveValue.kvartal = mStatDatum.Quarter;
                        }
                        else
                        {
                            mMessages.AddMessage(MessagesErrors.AutoDateParseError);
                        }
                    }
                    else
                    {
                        // Get the values from the datagridview with statistical variables
                        if (mManualStatVarProps.Year != null)
                        {
                            mAdaptiveValue.ar = mManualStatVarProps.Year;
                            mMessages.AddMessage(MessagesErrors.ManualDateNotSet);
                        }

                        if (mManualStatVarProps.Quarter != null)
                        {
                            mAdaptiveValue.kvartal = mManualStatVarProps.Quarter;
                            mMessages.AddMessage(MessagesNotices.ManualQuarterNotSet);
                        }

                        if (mManualStatVarProps.Month != null)
                        {
                            mAdaptiveValue.mnd = mManualStatVarProps.Month;
                            mMessages.AddMessage(MessagesNotices.ManualMonthNotSet);
                        }

                        if (mManualStatVarProps.Day != null)
                        {
                            mAdaptiveValue.Day = mManualStatVarProps.Day;
                            mMessages.AddMessage(MessagesNotices.ManualDayNotSet);
                        }

                    }
                    if (pFrm.StatAreaIDsProperties != null || pFrm.StatAreaNameProperties != null || pFrm.StatAreaGroupProperties != null)
                    {
                        // Add statareaID if available
                        if (pFrm.StatAreaIDsProperties != null)
                        {
                            mAdaptiveValue.krets_id = (string)pFrm.StatAreaIDsProperties.GetValue(mR, mC);
                        }

                        // Statareaname is only relevant if id is present
                        if (pFrm.StatAreaNameProperties != null)
                        {
                            mAdaptiveValue.krets_navn = (string)pFrm.StatAreaNameProperties.GetValue(mR, mC);
                        }

                        // Statarea group is only relevant if id is present
                        if (pFrm.StatAreaGroupProperties != null)
                        {
                            mAdaptiveValue.region = (string)pFrm.StatAreaGroupProperties.GetValue(mR, mC);
                        }

                    }
                    // If no auto-properties, pick values from manual form fields
                    else
                    {
                        mAdaptiveValue.krets_id = pFrm.tbStatUnitID.Text;
                        mAdaptiveValue.krets_navn = pFrm.tbStatUnitName.Text;
                        mAdaptiveValue.region = pFrm.tbStatUnitGroup.Text;
                    }

                    mData.AddByKey(mAdaptiveValue, mR, mC);
                }
            }
            mTimer.Stop();
            pFrm.Log(mMessages.GetMessages());
            pFrm.Log(String.Format("Ferdig på {0} ms", mTimer.ElapsedMilliseconds));

            return mData;
        }

    }
}
