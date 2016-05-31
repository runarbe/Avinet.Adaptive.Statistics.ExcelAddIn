using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;
using System.Diagnostics;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class UploadForm : Form
    {
        [Obsolete]
        private void btnCopyTitleToStatVarColN_Click(object sender, EventArgs e)
        {
            //int i = 1;
            //string mTitle = "";
            //int mStatVarColNumber = Util.GetComboBoxSelectedTextAsInt(cbSelectedStatVarCol.ComboBox);
            //if (mStatVarColNumber.Between(1, 5))
            //{
            //    string mStatVarColName = "StatVarCol" + mStatVarColNumber.ToString();

            //    foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            //    {
            //        sv mTitleCol = currentRow.Cells["Title"] as DataGridViewTextBoxCell;
            //        sv mCopyToCol = currentRow.Cells[mStatVarColName] as DataGridViewComboBoxCell;

            //        mTitle = (string)Table.GetNullOrString(mTitleCol.verdi);
            //        mCopyToCol.AddItemIfNotExists(ComboBoxItem.GetNewItem(mTitle));
            //        mTitleCol.verdi = mTitle;
            //    }
            //    i++;

            //    this.ParseSelectionWithCurrentSettings();
            //}

        }

        private void dgvStatVarProperties_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Debug.WriteLine(e.Exception.Message);
            Debug.WriteLine(e.ColumnIndex);
            Debug.WriteLine(e.RowIndex);
            Debug.WriteLine(e.ToString());
        }

        [Obsolete]
        private void btnCopyTitle2ToStatVarColN_Click(object sender, EventArgs e)
        {
            //int i = 1;
            //string mTitle = "";
            //int mStatVarColNumber2 = Util.GetComboBoxSelectedTextAsInt(cbSelectedStatVarCol2.ComboBox);
            //if (mStatVarColNumber2 != -1 && mStatVarColNumber2 <= 5 && mStatVarColNumber2 >= 1)
            //{
            //    string mStatVarColName2 = "StatVarCol" + mStatVarColNumber2.ToString();

            //    foreach (DataGridViewRow currentRow in dgvStatVarProperties.Rows)
            //    {
            //        sv mTitleCol = currentRow.Cells["Title2"] as DataGridViewTextBoxCell;
            //        sv mCopyToCol = currentRow.Cells[mStatVarColName2] as DataGridViewComboBoxCell;

            //        mTitle = (string)Table.GetNullOrString(mTitleCol.verdi);
            //        mCopyToCol.AddItemIfNotExists(ComboBoxItem.GetNewItem(mTitle));
            //        mTitleCol.verdi = mTitle;
            //    }
            //    i++;

            //    this.ParseSelectionWithCurrentSettings();
            //}

        }

        /// <summary>
        /// Handler for when edits occur to statvarcombobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvManualStatVarProps_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox mComboBox = e.Control as ComboBox;
            if (mComboBox != null)
            {
                mComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                //mComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //mComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                mComboBox.SelectionChangeCommitted -= OnSelectStatVarLevel;
                mComboBox.SelectionChangeCommitted += OnSelectStatVarLevel;
            };
        }

        private DataGridViewComboBoxCell getChildCombo(int colIndex, int rowIndex)
        {
            if (colIndex.Between(3, 6) && rowIndex > -1)
            {
                return getComboCell(colIndex + 1, rowIndex);
            }
            return null;
        }

        /// <summary>
        /// Function that is executed when the value of one of the five variable levels are selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectStatVarLevel(object sender, EventArgs e)
        {
            var currentCell = dgvStatVarProperties.CurrentCell;

            if (!currentCell.ColumnIndex.Between(3, 7))
            {
                return;
            }

            var mComboBox = (ComboBox)sender;
            var mStatVar = (StatTreeNode)mComboBox.SelectedItem;
            if (mStatVar != null)
            {
                var treeNodeList = PortalClient.GetVariable().ToList<StatTreeNode>();
                var childCombo = getChildCombo(currentCell.ColumnIndex, currentCell.RowIndex);
                if (childCombo != null)
                {
                    childCombo.DataSource = new BindingSource(mStatVar.Nodes, null);
                    childCombo.DisplayMember = "text";
                    childCombo.ValueMember = "tag";
                }
            }
        }

        /// <summary>
        /// Load first level of statistical variable tree into comboboxes
        /// </summary>
        private void LoadExistingStatVars2()
        {
            try
            {
                var comboBox = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol1"];
                var treeNodeList = PortalClient.GetVariable().ToList<StatTreeNode>();

                var b = new BindingSource(treeNodeList, null);
                comboBox.DataSource = b;
                comboBox.DisplayMember = "text";
                comboBox.ValueMember = "tag";

                return;
            }
            catch (Exception ex)
            {
                this.Log("Feil: Kunne ikkje laste eksisterande statistikkvariablar frå server: " + ex.Message);
            }

        }

        /// <summary>
        /// Load existing statvars from server
        /// 
        /// </summary>
        [Obsolete("Should no longer load data from 'old' web service, use LoadExistingStatVars2() instead")]
        private void LoadExistingStatVars()
        {
            var mUrl = String.Format("{0}/WebServices/administrator/modules/statistics/DataDownload.asmx/ReadVariables",
                Properties.Settings.Default.adaptiveUri);
            try
            {
                var mWebClient = new WebClient();
                var mByteArray = mWebClient.DownloadData(mUrl);
                var mReader = new MemoryStream(mByteArray);
                var mSerializer = new XmlSerializer(typeof(AASStatVars));
                AASStatVars mStatVars = (AASStatVars)mSerializer.Deserialize(mReader);
                mReader.Close();
                ((DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol1"]).AddItemsFromList(mStatVars.GetLevel1());
                ((DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol2"]).AddItemsFromList(mStatVars.GetLevel2());
                ((DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol3"]).AddItemsFromList(mStatVars.GetLevel3());
                ((DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol4"]).AddItemsFromList(mStatVars.GetLevel4());
                ((DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol5"]).AddItemsFromList(mStatVars.GetLevel5());
            }
            catch (Exception ex)
            {
                this.Log("Feil: Kunne ikkje laste eksisterande statistikkvariablar frå " + mUrl + " (" + ex.Message + ")");
            }
        }

        private void SetComboCellDataSource(int rowIndex, int parentVarLevel, TreeNode[] tNodes)
        {
            try
            {
                var childCombo = getComboCell(rowIndex, parentVarLevel + 1);
                if (childCombo == null)
                {
                    throw new Exception("Cannot set data source, specified currentCell is not a comboboxcell");
                }
                childCombo.DataSource = new BindingSource(tNodes, null);
                childCombo.DisplayMember = "text";
                childCombo.ValueMember = "tag";
            }
            catch (Exception ex)
            {
                DebugToFile.Log(ex.Message);
            }
        }

        private DataGridViewComboBoxCell getComboCell(int colIndex, int rowIndex)
        {
            try
            {
                if (!colIndex.Between(3, 7) && !(rowIndex > -1))
                {
                    throw new Exception("The level index must be between 1 and 5 and the row index must be a positive integer");
                }

                DataGridViewCell cell = dgvStatVarProperties[colIndex, rowIndex];

                if (cell.GetType() == typeof(DataGridViewComboBoxCell))
                {
                    return (DataGridViewComboBoxCell)cell;
                }
                else
                {
                    throw new Exception("The currentCell does not contain a combobox");
                }
            }
            catch (Exception ex)
            {
                //DebugToFile.Log(ex.Message);
            }

            return null;

        }

        public class SelectedStatVar
        {
        }

        public Variable getStatVarLevelValue(DataGridViewCell cell)
        {
            if (cell.Value == null) {
                return null;
            }

            if (cell.Value.GetType() == typeof(Variable))
            {
                var v = (Variable)cell.Value;
                switch (cell.ColumnIndex)
                {
                    case 3:
                        return v;
                    case 4:
                        return v;
                    case 5:
                        return v;
                    case 6:
                        return v;
                    case 7:
                        return v;
                }
            }
            return null;
        }

        public StatVarProperties ParseStatVarProperties(int pRow, int pCol, DataOrientation pDataOrientation)
        {

            int mStatVarIndex;

            if (pDataOrientation == DataOrientation.InColumns)
            {
                mStatVarIndex = pRow;
            }
            else
            {
                mStatVarIndex = pCol;
            }

            var mStatVarProperties = new StatVarProperties();

            for (int i = 0, j = dgvStatVarProperties.RowCount; i < j; i++)
            {
                int mIndex = (int)dgvStatVarProperties["Index", i].Value;

                if (mIndex == mStatVarIndex)
                {
                    for (int f = 0; f < dgvStatVarProperties.ColumnCount; f++)
                    {
                        DataGridViewColumn mDGVC = dgvStatVarProperties.Columns[f];

                        switch (mDGVC.Index)
                        {
                            case 3:
                                mStatVarProperties.StatVar1 = getStatVarLevelValue(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar1 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar1.id.ToString();
                                }
                                break;
                            case 4:
                                mStatVarProperties.StatVar2 = getStatVarLevelValue(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar2 != null)
                                {
                                mStatVarProperties.fk_variable = mStatVarProperties.StatVar2.id.ToString(); 
                                }                                break;
                            case 5:
                                mStatVarProperties.StatVar3 = getStatVarLevelValue(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar3 != null)
                                {
                                mStatVarProperties.fk_variable = mStatVarProperties.StatVar3.id.ToString(); 
                                }                                break;
                            case 6:
                                mStatVarProperties.StatVar4 = getStatVarLevelValue(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar4 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar4.id.ToString();
                                }
                                break;
                            case 7:
                                mStatVarProperties.StatVar5 = getStatVarLevelValue(dgvStatVarProperties[f, i]);
                                if (mStatVarProperties.StatVar5 != null)
                                {
                                    mStatVarProperties.fk_variable = mStatVarProperties.StatVar5.id.ToString();
                                }
                                break;
                            case 8:
                                mStatVarProperties.MeasurementUnit = Util.CheckNullOrEmpty(dgvStatVarProperties[f, i].Value);
                                break;
                            case 9:
                                mStatVarProperties.Year = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case 10:
                                mStatVarProperties.Quarter = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case 11:
                                mStatVarProperties.Month = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                            case 12:
                                mStatVarProperties.Day = Table.GetNullOrDoubleString(dgvStatVarProperties[f, i].Value);
                                break;
                        }

                    }

                    break;
                }
            }
            return mStatVarProperties;
        }

    }
}
