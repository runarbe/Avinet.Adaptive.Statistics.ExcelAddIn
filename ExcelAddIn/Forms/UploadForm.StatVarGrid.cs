using System;
using System.Linq;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;

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

            //        mTitle = (string)Table.GetNullOrString(mTitleCol.value);
            //        mCopyToCol.AddItemIfNotExists(ComboBoxItem.GetNewItem(mTitle));
            //        mTitleCol.value = mTitle;
            //    }
            //    i++;

            //    this.ParseSelectionWithCurrentSettings();
            //}

        }

        private void dgvStatVarProperties_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //DebugToFile.Log("Data error in dgvstatvarproperties");
            //DebugToFile.Log(e.Exception.Message);
            //DebugToFile.Log(e.ColumnIndex.ToString());
            //DebugToFile.Log(e.RowIndex.ToString());
            //DebugToFile.Log(e.ToString());
        }

        /// <summary>
        /// Handler for when edits occur to statvarcombobox
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
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

            Log(dgvStatVarProperties.CurrentCell.ColumnIndex.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param title="colIndex"></param>
        /// <param title="rowIndex"></param>
        /// <returns></returns>
        private DataGridViewComboBoxCell GetChildCombo(int colIndex, int rowIndex)
        {
            if (colIndex.Between(2, 5) && rowIndex > -1)
            {
                return getComboCell(colIndex + 1, rowIndex);
            }
            return null;
        }

        private DataGridViewComboBoxCell GetParentCombo(int colIndex, int rowIndex)
        {
            if (colIndex.Between(3, 6) && rowIndex > -1)
            {
                return getComboCell(colIndex - 1, rowIndex);
            }
            return null;
        }

        /// <summary>
        /// Function that is executed when the value of one of the five variable levels are selected
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void OnSelectStatVarLevel(object sender, EventArgs e)
        {
            // Get the current cell (the one that was clicked)
            var currentCell = dgvStatVarProperties.CurrentCell;

            // Ensure that it is in the range of the StatVars (2-6)
            if (!currentCell.ColumnIndex.Between(2, 6))
            {
                return;
            }

            // Cast the sender object to a combobox
            var mComboBox = (ComboBox)sender;

            //If the text on the combobox is for adding a new variable
            if (mComboBox.Text == "<Ny...>"
                && currentCell.ColumnIndex.Between(3, 6))
            {
                // Get parent combobox
                var parentCombo = GetParentCombo(currentCell.ColumnIndex, currentCell.RowIndex);

                // Get parent variable
                var parentVariable = (Variable)parentCombo.Value;

                string titleOfSelectedStatVar = dgvStatVarProperties["Title", currentCell.RowIndex].FormattedValue.ToString();

                // Open form to create a new variable
                // If it closes successfully, reload variables
                // rebind control
                var newVariable = NewVariable.NewVariablePopup(parentVariable, titleOfSelectedStatVar);

                if (newVariable != null)
                {
                    var mComboBoxCell = (DataGridViewComboBoxCell)currentCell;
                    var updatedDataSource = ConfigProvider.GetChildNodes(parentVariable);
                    updatedDataSource.Add(new StatTreeNode("<Ny...>"));
                    mComboBoxCell.DataSource = new BindingSource(updatedDataSource, null);
                    mComboBoxCell.ValueMember = "Tag";
                    mComboBoxCell.DisplayMember = "Text";
                    mComboBoxCell.Value = newVariable;
                }
            }

            // See if there is a statvar behind the current selected node
            StatTreeNode mStatVar = (StatTreeNode)mComboBox.SelectedItem;

            if (mStatVar != null)
            {
                if (mStatVar.Tag != null)
                {
                    Variable mVariable = (Variable)mStatVar.Tag;

                    var mNodes = ConfigProvider.GetChildNodes(mVariable);

                    mNodes.Add(new StatTreeNode("<Ny...>"));
                    var childCombo = GetChildCombo(currentCell.ColumnIndex, currentCell.RowIndex);
                    if (childCombo != null)
                    {
                        childCombo.DataSource = new BindingSource(mNodes, null);
                        childCombo.DisplayMember = "text";
                        childCombo.ValueMember = "tag";
                    }
                    var unitCell = (DataGridViewComboBoxCell)dgvStatVarProperties["Unit", currentCell.RowIndex];
                    var timeUnitCell = (DataGridViewComboBoxCell)dgvStatVarProperties["TimeUnit", currentCell.RowIndex];
                    var kretstypeCell = (DataGridViewComboBoxCell)dgvStatVarProperties["Kretstype", currentCell.RowIndex];

                }
            }
        }

        /// <summary>
        /// Load first varLevel of statistical variable tree into comboboxes
        /// </summary>
        private void PopulateComboBoxes()
        {
            var varLevel1 = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["StatVarCol1"];
            var units = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["Unit"];
            var timeUnits = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["TimeUnit"];
            var kretstyper = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["Kretstype"];

            // Populate first level statistical variables
            varLevel1.DataSource = new BindingSource(ConfigProvider.variableTree, null);
            varLevel1.DisplayMember = "Text";
            varLevel1.ValueMember = "Tag";

            // Populate measurement units dropdown
            units.DataSource = new BindingSource(ConfigProvider.units, null);
            units.DisplayMember = "Key";
            units.ValueMember = "Value";

            // Populate time units
            timeUnits.DataSource = new BindingSource(ConfigProvider.timeUnits, null);
            timeUnits.DisplayMember = "Key";
            timeUnits.ValueMember = "Value";

            // Populate kretstyper in datagridview
            kretstyper.DataSource = new BindingSource(ConfigProvider.kretstyper, null);
            kretstyper.DisplayMember = "name";
            kretstyper.ValueMember = "uuid";

            // Populate kretstyper in manual section of form
            Util.SetComboBoxDS(cbStatUnitType, ConfigProvider.kretstyper.ToList(), "name", "uuid");

            // Populate date format combobox for parsing of date-valuesList
            Util.SetComboBoxDS(cbStatDatumFormat, DateFormats.List);

            // Populate and set default selection for CellContentTypes combos
            foreach (var mComboBox in CellContentTypeComboBoxes)
            {
                var mCellContentTypes = CellContentTypes.AsComboBoxItems();
                Util.SetComboBoxDS(mComboBox, mCellContentTypes);
                mComboBox.SelectedValue = CellContentTypes.Values;
            }

            return;
        }

        private DataGridViewComboBoxCell getComboCell(int colIndex, int rowIndex)
        {
            try
            {
                if (!colIndex.Between(3, 7) && !(rowIndex > -1))
                {
                    throw new Exception("The varLevel index must be between 1 and 5 and the row index must be a positive integer");
                }

                DataGridViewCell cell = dgvStatVarProperties[colIndex, rowIndex];

                if (cell.GetType() == typeof(DataGridViewComboBoxCell))
                {
                    return (DataGridViewComboBoxCell)cell;
                }
                else
                {
                    throw new Exception("The cell does not contain a combobox");
                }
            }
            catch (Exception)
            {
                //DebugToFile.Log(ex.Message);
            }

            return null;
        }
    }
}
