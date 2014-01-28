using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sd = System.Data;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Diagnostics;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Table
    {

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

        public static List<string> GetFirstCol(Object[,] mSelection)
        {
            var mList = new List<string>();

            int mColNum = 1;
            for (int mRowNum = 1, mNumCols = mSelection.GetLength(0); mRowNum <= mNumCols; mRowNum++)
            {
                mList.Add(Table.CheckNullFieldName(mSelection[mRowNum, mColNum], mRowNum));
            }
            return mList;

        }

        public static List<string> GetFirstRow(Object[,] mSelection)
        {
            var mList = new List<string>();
            int mRowNum = 1;
            for (int mColNum = 1, mNumCols = mSelection.GetLength(1); mColNum <= mNumCols; mColNum++)
            {
                mList.Add(Table.CheckNullFieldName(mSelection[mRowNum, mColNum], mColNum));
            }
            return mList;
        }

        public static Values3D GetData(Object[,] pSelection, List<String> pFieldNames, SelectionType pSelectionType)
        {
            var mList = new Values3D();

            if (pSelectionType == SelectionType.DataInRows)
            {
                for (int mRowNum = 2, mNumRows = pSelection.GetLength(0); mRowNum <= mNumRows; mRowNum++)
                {
                    for (int mColNum = 1, mNumCols = pSelection.GetLength(1); mColNum <= mNumCols; mColNum++)
                    {
                        mList.AddByKey(Table.CheckNullDouble(pSelection[mRowNum, mColNum]), mColNum - 1, mRowNum);
                    }
                }

            }
            else if (pSelectionType == SelectionType.DataInCols)
            {
                for (int mColNum = 2, mNumCols = pSelection.GetLength(1); mColNum <= mNumCols; mColNum++)
                {
                    for (int mRowNum = 1, mNumRows = pSelection.GetLength(0); mRowNum <= mNumRows; mRowNum++)
                    {
                        mList.AddByKey(Table.CheckNullDouble(pSelection[mRowNum, mColNum]), mRowNum - 1, mColNum);
                    }
                }

            }
            return mList;

        }

        public static Values3D ParseSelection(Range pSelection, SelectionType pSelectionType, UploadForm mFrm)
        {
            var mFieldNames = new List<string>();
            var mData = new Values3D();
            if (pSelection.Cells.Value.GetType() == typeof(String)) {
                mFrm.Log("Feil: utvalget er for lite, prøv igjen");
                return null;
            }

            Object[,] mSelection = pSelection.Cells.Value;

            if (pSelectionType == SelectionType.DataInRows)
            {
                mFieldNames = Table.GetFirstRow(mSelection);
            }
            else if (pSelectionType == SelectionType.DataInCols)
            {
                mFieldNames = Table.GetFirstCol(mSelection);
            }
            else
            {
                return null;
            }

            mData = Table.GetData(mSelection, mFieldNames, pSelectionType);

            // Set data source for data series properties
            mFrm.dgvFieldProperties.DataSource = Table.FieldNamesToDataTable(mFieldNames);
            mFrm.dgvFieldProperties.Refresh();

            Export.CheckAllDataGridView(mFrm.dgvFieldProperties, "Include");

            // Set data source for statunitfieldnr combo
            Util.SetComboBoxDS(mFrm.cbStatUnitField, Table.FieldNamesToConfigListOffline(mFieldNames).list);

            // Set data source for statunitnamefield combo
            Util.SetComboBoxDS(mFrm.cbStatUnitNameField, Table.FieldNamesToConfigListOffline(mFieldNames).list);

            // Set data source for statunitgroup field combo
            Util.SetComboBoxDS(mFrm.cbStatUnitGroupField, Table.FieldNamesToConfigListOffline(mFieldNames).list);

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
            return mData;

        }

    }
}
