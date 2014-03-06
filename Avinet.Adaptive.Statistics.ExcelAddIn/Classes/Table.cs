using System;
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

        public static System.Data.DataTable RangeToDataTable(Range pSelection)
        {
            Object[,] mSelection = pSelection.Cells.Value;

            var mDataTable = new System.Data.DataTable();
            for (int i = 1, j = pSelection.Columns.Count; i < j; i++)
            {
                mDataTable.Columns.Add(new DataColumn("Kolonne " + i, typeof(string)));
            }

            for (int mRowNum = 1, mNumRows = pSelection.Rows.Count; mRowNum < mNumRows; mRowNum++)
            {
                var mRow = mDataTable.NewRow();

                for (int mColNum = 1, mNumCols = pSelection.Columns.Count; mColNum < mNumCols; mColNum++)
                {
                    mRow[mColNum - 1] = Table.CheckNullDouble(mSelection[mRowNum, mColNum]);
                }
                mDataTable.Rows.Add(mRow);
            }

            return mDataTable;
        }

        public static List<String> Obj2List(object[,] pObj)
        {

            var mList = new List<String>();

            Debug.WriteLine("Length: " + pObj.GetLength(0));

            for (int i = 1, j = pObj.GetLength(0); i < j; i++)
            {
                for (int k = 1, l = pObj.GetLength(1); k < l; k++)
                {
                    mList.Add(pObj[i, j].ToString());
                }
            }

            return mList;
        }

        public static ConfigListOffline FieldNamesToConfigListOffline(List<string> pFieldNames, int pExcludeFieldIndex = -1)
        {
            var mList = new ConfigListOffline();

            int i = 0;
            foreach (string mElement in pFieldNames)
            {
                if (pExcludeFieldIndex != i)
                {
                    mList.Add(mElement, i.ToString());
                }
                i++;
            }
            mList.Insert("Vel eitt felt", "");
            return mList;
        }

        public static sd.DataTable FieldNamesToDataTable(List<string> pFieldNames, int pExcludeFieldIndex = -1)
        {
            var mDataTable = new sd.DataTable();

            mDataTable.Columns.Add(new sd.DataColumn("Title"));
            mDataTable.Columns.Add(new sd.DataColumn("RowIndex"));

            int i = 0;
            foreach (string mElement in pFieldNames)
            {
                if (pExcludeFieldIndex != i)
                {
                    var mRow = mDataTable.NewRow();
                    mRow["RowIndex"] = i.ToString();
                    mRow["Title"] = mElement;
                    mDataTable.Rows.Add(mRow);
                }
                i++;
            }
            return mDataTable;
        }

        public static string CheckNullFieldName(object pVar, int pNum)
        {
            if (pVar != null)
            {
                var mVar = pVar.ToString();

                if (mVar != "")
                {
                    return mVar;
                }
                else
                {
                    return String.Format("Field{0}", pNum);
                }

            }
            else
            {
                return String.Format("Field{0}", pNum);
            }
        }

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


        public static string CheckNullDouble(object pVar)
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
                    return mVar;
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
            var mStatProps = new StatProps(pDataOrientation);

            for (int mRowNum = 1, mNumRows = mSelection.GetLength(0); mRowNum < mNumRows; mRowNum++)
            {
                mStatProps.AddValue(mRowNum, Table.CheckNullDouble(mSelection[mRowNum, pColNum]));
            }
            return mStatProps;

        }

        public static StatProps GetRowNum(Object[,] mSelection, int pRowNum = 1, DataOrientation pDataOrientation = DataOrientation.InRows)
        {
            var mStatProps = new StatProps(pDataOrientation);
            for (int mColNum = 1, mNumCols = mSelection.GetLength(1); mColNum < mNumCols; mColNum++)
            {
                mStatProps.Add(mColNum, Table.CheckNullDouble(mSelection[pRowNum, mColNum]));
            }
            return mStatProps;
        }

        public static Values3D GetData(Object[,] pSelection, List<String> pFieldNames, List<string> pStatDates, List<string> pStatAreaIds, SelectionType pSelectionType, CType p1stDim)
        {
            int m2ndDimStart = (p1stDim == CType.None) ? 1 : 2;

            var mList = new Values3D();

            if (pSelectionType == SelectionType.StatisticalVariabesInFirstCol)
            {
                for (int mRowNum = 2, mNumRows = pSelection.GetLength(0); mRowNum <= mNumRows; mRowNum++)
                {
                    for (int mColNum = m2ndDimStart, mNumCols = pSelection.GetLength(1); mColNum <= mNumCols; mColNum++)
                    {
                        var mAdaptiveValue = new AdaptiveValue(
                            Table.CheckNullDouble(
                            pSelection[mRowNum, mColNum]));
                        mList.AddByKey(mAdaptiveValue, mColNum, mRowNum);
                    }
                }

            }
            else if (pSelectionType == SelectionType.StatisticalVariablesInFirstRow)
            {
                for (int mColNum = 2, mNumCols = pSelection.GetLength(1);
                    mColNum <= mNumCols;
                    mColNum++)
                {
                    for (int mRowNum = m2ndDimStart, mNumRows = pSelection.GetLength(0);
                        mRowNum <= mNumRows;
                        mRowNum++)
                    {
                        var mAdaptiveValue = new AdaptiveValue(
                            Table.CheckNullDouble(
                            pSelection[mRowNum, mColNum]));
                        mList.AddByKey(
                            mAdaptiveValue, mRowNum - 1,
                            mColNum);
                    }
                }

            }
            return mList;

        }

        public static Values3D ParseSelection2(Range pSelection, UploadForm pFrm)
        {

            int mFirstDataRow = 1, mFirstDataCol = 1;

            var mSelection = pSelection.Cells.Value;

            // Increment if col value is set
            if (Util.GetSelCType(pFrm.cbRowCType1) != CType.None) mFirstDataRow = 2;
            if (Util.GetSelCType(pFrm.cbRowCType2) != CType.None) mFirstDataRow = 3;
            if (Util.GetSelCType(pFrm.cbRowCType3) != CType.None) mFirstDataRow = 4;
            if (Util.GetSelCType(pFrm.cbRowCType4) != CType.None) mFirstDataRow = 5;

            // Increment if column is set
            if (Util.GetSelCType(pFrm.cbColCType1) != CType.None) mFirstDataCol = 2;
            if (Util.GetSelCType(pFrm.cbColCType2) != CType.None) mFirstDataCol = 3;
            if (Util.GetSelCType(pFrm.cbColCType3) != CType.None) mFirstDataCol = 4;
            if (Util.GetSelCType(pFrm.cbColCType4) != CType.None) mFirstDataCol = 5;

            var mData = new Values3D();

            for (int mR = mFirstDataRow; mR < pSelection.Rows.Count; mR++)
            {
                for (int mC = mFirstDataCol; mC < pSelection.Columns.Count; mC++)
                {
                    var mAdaptiveValue = new AdaptiveValue(Table.CheckNullDouble(mSelection[mR, mC]));
                    mAdaptiveValue.StatVar = (string)pFrm.StatVarProps.GetValue(mR, mC);

                    if (pFrm.StatDatumProps != null)
                    {
                        // Add logic to parse the date value into its individual parts here
                        mAdaptiveValue.StatYear = (string)pFrm.StatDatumProps.GetValue(mR, mC);
                    }

                    if (pFrm.StatAreaIDsProps != null)
                    {
                        mAdaptiveValue.StatAreaID = (string)pFrm.StatAreaIDsProps.GetValue(mR, mC);
                    }

                    if (pFrm.StatAreaNameProps != null)
                    {
                        mAdaptiveValue.StatAreaName = (string)pFrm.StatAreaNameProps.GetValue(mR, mC);
                    }

                    if (pFrm.StatAreaGroupProps != null)
                    {
                        mAdaptiveValue.StatAreaGroup = (string)pFrm.StatAreaGroupProps.GetValue(mR, mC);
                    }

                    mData.AddByKey(mAdaptiveValue, mR, mC);
                    pFrm.Log(mAdaptiveValue.ToString());
                }
            }
            return mData;
        }

        public static Values3D ParseSelection(Range pSelection, SelectionType pSelectionType, CType pSecondDimension, UploadForm mFrm)
        {
            StatProps mStatVariableNames = new StatProps();
            StatProps mStatDates = null;
            StatProps mStatAreaIds = null;

            var mData = new Values3D();
            if (pSelection.Cells.Value.GetType() == typeof(String))
            {
                mFrm.Log("Feil: utvalget er for lite, prøv igjen");
                return null;
            }

            Object[,] mSelection = pSelection.Cells.Value;

            // Get statistical variables
            if (pSelectionType == SelectionType.StatisticalVariabesInFirstCol)
            {
                mStatVariableNames = Table.GetRowNum(mSelection);
            }
            else if (pSelectionType == SelectionType.StatisticalVariablesInFirstRow)
            {
                mStatVariableNames = Table.GetColNum(mSelection);
            }
            else
            {
                return null;
            }

            // Get statistics dates, if available
            if (pSecondDimension == CType.StatDatum)
            {
                mStatDates = (pSelectionType == SelectionType.StatisticalVariabesInFirstCol) ? Table.GetRowNum(mSelection) : Table.GetColNum(mSelection);

            }

            // Get statistical areas, if available
            if (pSecondDimension == CType.StatAreaIDs)
            {
                mStatAreaIds = (pSelectionType == SelectionType.StatisticalVariabesInFirstCol) ? Table.GetRowNum(mSelection) : Table.GetColNum(mSelection);
            }

            /*mData = Table.GetData(mSelection, mStatVariableNames, mStatDates, mStatAreaIds, pSelectionType, pSecondDimension);

            // Set data source for data series properties
            mFrm.dgvFieldProperties.DataSource = Table.FieldNamesToDataTable(mStatVariableNames);
            mFrm.dgvFieldProperties.Refresh();

            Export.CheckAllDataGridView(mFrm.dgvFieldProperties, "Include");

            // Set data source for year parts in the datagridview
            DataGridViewComboBoxColumn mYearPart = mFrm.dgvFieldProperties.Columns["YearPart"] as DataGridViewComboBoxColumn;
            mYearPart.DataSource = WsDataSources.GetYearParts().list;
            mYearPart.DisplayMember = "key";
            mYearPart.ValueMember = "value";

            // Set data source for year parts in the dataset date 
            mFrm.cbYearPart.DataSource = WsDataSources.GetYearParts().list;
            mFrm.cbYearPart.DisplayMember = "key";
            mFrm.cbYearPart.ValueMember = "value";

            mFrm.Show();
            */
            return mData;

        }

    }
}
