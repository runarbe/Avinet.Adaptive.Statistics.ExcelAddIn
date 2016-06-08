﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Table
    {
        /// <summary>
        /// Get a valuesList table from an Excel range object
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

            // Create valuesList object to hold valuesList
            var mData = new Values3D();

            // For each row
            for (int mR = mFirstDataRow; mR <= pSelection.Rows.Count; mR++)
            {
                // For each column
                for (int mC = mFirstDataCol; mC <= pSelection.Columns.Count; mC++)
                {
                    AdaptiveValue adaptiveValue;

                    // Get the value (as a double)
                    string mValueString = Table.GetNullOrDoubleString(mSelection[mR, mC]);
                    int? mValue = mValueString.AsNullableInt();

                    //Exclude null values from being stored
                    if (mValue == null)
                    {
                        mData.AddByKey(null, mR, mC);
                        continue;
                    }
                    else
                    {
                        adaptiveValue = new AdaptiveValue((int)mValue);

                        // Get manual settings for statistical variable
                        var statVarProps = StatVarProperties.Get(pFrm.dgvStatVarProperties, mR, mC, pFrm.StatVarProperties.DataOrientation);

                        // Get/set the corresponding statvar
                        if (statVarProps.StatVar1 != null)
                        {
                            adaptiveValue.variable1 = statVarProps.StatVar1.var1;

                            if (String.IsNullOrWhiteSpace(statVarProps.StatVar1.var1))
                            {
                                mMessages.AddMessage(MessagesNotices.StatVarParseUsingDefaultNotice);
                            }

                        }

                        if (statVarProps.StatVar2 != null)
                        {
                            adaptiveValue.variable2 = statVarProps.StatVar2.var2;
                        }

                        if (statVarProps.StatVar3 != null)
                        {
                            adaptiveValue.variable3 = statVarProps.StatVar3.var3;
                        }

                        if (statVarProps.StatVar4 != null)
                        {
                            adaptiveValue.variable4 = statVarProps.StatVar4.var4;
                        }

                        if (statVarProps.StatVar5 != null)
                        {
                            adaptiveValue.variable5 = statVarProps.StatVar5.var5;
                        }

                        adaptiveValue.variable_id = statVarProps.fk_variable.AsNullableInt(-1);

                        adaptiveValue.fk_variable = statVarProps.fk_variable.AsNullableInt(-1);

                        adaptiveValue.time_unit = statVarProps.time_unit;

                        adaptiveValue.kretstype_id = statVarProps.fk_kretstype;

                        // Get/set the measurement unit
                        adaptiveValue.unit = statVarProps.Unit;
                        if (adaptiveValue.unit == null)
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
                                adaptiveValue.year = mStatDatum.Year.AsNullableInt();
                                adaptiveValue.month = mStatDatum.Month.AsNullableInt();
                                adaptiveValue.quarter = mStatDatum.Quarter.AsNullableInt();
                            }
                            else
                            {
                                mMessages.AddMessage(MessagesErrors.AutoDateParseError);
                            }
                        }
                        else
                        {
                            // Get the valuesList from the datagridview with statistical variables
                            if (statVarProps.Year != null)
                            {
                                adaptiveValue.year = statVarProps.Year.AsNullableInt();
                                mMessages.AddMessage(MessagesErrors.ManualDateNotSet);
                            }

                            if (statVarProps.Quarter != null)
                            {
                                adaptiveValue.quarter = statVarProps.Quarter.AsNullableInt();
                                mMessages.AddMessage(MessagesNotices.ManualQuarterNotSet);
                            }

                            if (statVarProps.Month != null)
                            {
                                adaptiveValue.month = statVarProps.Month.AsNullableInt();
                                mMessages.AddMessage(MessagesNotices.ManualMonthNotSet);
                            }

                        }
                        if (pFrm.StatAreaIDsProperties != null || pFrm.StatAreaNameProperties != null || pFrm.StatAreaGroupProperties != null)
                        {
                            // Add statareaID if available
                            if (pFrm.StatAreaIDsProperties != null)
                            {
                                adaptiveValue.krets_id = pFrm.StatAreaIDsProperties.GetValue(mR, mC).ToString().AsNullableInt();
                            }

                            // Statareaname is only relevant if id is present
                            if (pFrm.StatAreaNameProperties != null)
                            {
                                adaptiveValue.krets_name = (string)pFrm.StatAreaNameProperties.GetValue(mR, mC);
                            }

                            // Statarea group is only relevant if id is present
                            if (pFrm.StatAreaGroupProperties != null)
                            {
                                adaptiveValue.region = (string)pFrm.StatAreaGroupProperties.GetValue(mR, mC);
                            }

                        }
                        // If no auto-properties, pick valuesList from manual form fields
                        else
                        {
                            adaptiveValue.krets_id = pFrm.tbStatUnitID.Text.AsNullableInt();
                            adaptiveValue.krets_name = pFrm.tbStatUnitName.Text;
                            adaptiveValue.region = pFrm.tbStatUnitGroup.Text;
                        }

                        mData.AddByKey(adaptiveValue, mR, mC);
                    }
                }
            }
            mTimer.Stop();
            pFrm.Log(mMessages.GetMessages());
            pFrm.Log(String.Format("Ferdig på {0} ms", mTimer.ElapsedMilliseconds));

            return mData;
        }

    }
}
