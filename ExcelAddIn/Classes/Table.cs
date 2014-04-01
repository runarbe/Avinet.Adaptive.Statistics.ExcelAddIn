﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;

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
                    var mManualStatVarProps = pFrm.GetManualStatVarProps(mR, mC, pFrm.StatVarProps.DataOrientation);

                    // Get/set the corresponding statvar
                    if (!String.IsNullOrWhiteSpace(mManualStatVarProps.StatVar))
                    {
                        mAdaptiveValue.SetStatVar(mManualStatVarProps.StatVar);
                    }
                    else
                    {
                        mMessages.AddMessage(MessagesNotices.StatVarParseUsingDefaultNotice);
                        mAdaptiveValue.SetStatVar((string)pFrm.StatVarProps.GetValue(mR, mC));
                    }

                    // Get/set the measurement unit
                    mAdaptiveValue.MUnit = mManualStatVarProps.MUnit;
                    if (mAdaptiveValue.MUnit == null)
                    {
                        mMessages.AddMessage(MessagesErrors.MUnitNotSet);
                    }

                    // Add date, if available
                    if (pFrm.StatDatumProps != null)
                    {
                        // Add logic to parse the date value into its individual parts here
                        var mStatDatum = new StatDateParser((string)pFrm.StatDatumProps.GetValue(mR, mC), (string)pFrm.cbDateFormats.SelectedValue);

                        if (mStatDatum.Success == true)
                        {
                            mAdaptiveValue.Year = mStatDatum.Year;
                            mAdaptiveValue.Month = mStatDatum.Month;
                            mAdaptiveValue.Day = mStatDatum.Day;
                            mAdaptiveValue.YearPart = mStatDatum.YearPart;
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
                            mAdaptiveValue.Year = mManualStatVarProps.Year;
                            mMessages.AddMessage(MessagesErrors.ManualDateNotSet);
                        }

                        if (mManualStatVarProps.YearPart != null)
                        {
                            mAdaptiveValue.YearPart = mManualStatVarProps.YearPart;
                            mMessages.AddMessage(MessagesNotices.ManualYearPartNotSet);
                        }

                        if (mManualStatVarProps.Month != null)
                        {
                            mAdaptiveValue.Month = mManualStatVarProps.Month;
                            mMessages.AddMessage(MessagesNotices.ManualMonthNotSet);
                        }

                        if (mManualStatVarProps.Day != null)
                        {
                            mAdaptiveValue.Day = mManualStatVarProps.Day;
                            mMessages.AddMessage(MessagesNotices.ManualDayNotSet);
                        }

                    }
                    if (pFrm.StatAreaIDsProps != null || pFrm.StatAreaNameProps != null || pFrm.StatAreaGroupProps != null)
                    {
                        // Add statareaID if available
                        if (pFrm.StatAreaIDsProps != null)
                        {
                            mAdaptiveValue.StatAreaID = (string)pFrm.StatAreaIDsProps.GetValue(mR, mC);
                        }

                        // Statareaname is only relevant if id is present
                        if (pFrm.StatAreaNameProps != null)
                        {
                            mAdaptiveValue.StatAreaName = (string)pFrm.StatAreaNameProps.GetValue(mR, mC);
                        }

                        // Statarea group is only relevant if id is present
                        if (pFrm.StatAreaGroupProps != null)
                        {
                            mAdaptiveValue.StatAreaGroup = (string)pFrm.StatAreaGroupProps.GetValue(mR, mC);
                        }

                    }
                    // If no auto-properties, pick values from manual form fields
                    else
                    {
                        mAdaptiveValue.StatAreaID = pFrm.tbManualStatAreaID.Text;
                        mAdaptiveValue.StatAreaName = pFrm.tbManualStatAreaName.Text;
                        mAdaptiveValue.StatAreaGroup = pFrm.tbManualStatAreaGroup.Text;
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