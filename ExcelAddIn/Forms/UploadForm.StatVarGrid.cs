using System;
using System.Linq;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Forms;
using System.Drawing;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public partial class UploadForm : Form
    {
        private void OnDataErrorInStatVarPropertiesGrid(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        /// <summary>
        /// Handler for when edits occur to statvarcombobox
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void OnShowEditingControlsInStatVarPropertiesGrid(object sender,
        DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.White;
        }

        private void OnClickOnSelectedStatVarCell(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1
                && e.RowIndex > -1
                && dgvStatVarProperties.Columns[e.ColumnIndex].Name == "SelectedStatVar")
            {
                var frm = new StatVarSelectForm();
                var tb = dgvStatVarProperties["Title", e.RowIndex] as DataGridViewTextBoxCell;
                if (tb == null) return;
                var cb = dgvStatVarProperties[e.ColumnIndex, e.RowIndex].AsComboBox();
                if (cb != null)
                {
                    frm.Display(cb);

                    string q;

                    var variable = cb.Value as Variable;
                    if (variable != null)
                    {
                        q = variable.title;
                        frm.SetQuery(q);
                        frm.SetSelectedStatVarText(variable.GetHierarhicalName());
                    }
                    else
                    {
                        q = tb.Value.ToString();
                        frm.SetQuery(q);
                    }

                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param title="colIndex"></param>
        /// <param title="rowIndex"></param>
        /// <returns></returns>
        private DataGridViewComboBoxCell GetChildCombo(string colName, int rowIndex)
        {
            return getComboCell(colName, rowIndex);
        }

        /// <summary>
        /// Load first varLevel of statistical variable tree into comboboxes
        /// </summary>
        private void PopulateComboBoxes()
        {
            var units = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["Unit"];
            var timeUnits = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["TimeUnit"];
            var kretstyper = (DataGridViewComboBoxColumn)dgvStatVarProperties.Columns["Kretstype"];

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
            kretstyper.ValueMember = "id";

            // Populate kretstyper in manual section of form
            Util.SetComboBoxDS(cbStatUnitType, ConfigProvider.kretstyper.ToList(), "name", "id");

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

        private DataGridViewComboBoxCell getComboCell(string colIndex, int rowIndex)
        {
            try
            {
                if (!(rowIndex > -1))
                {
                    throw new Exception("The rowIndex statVarIndex must be a positive integer");
                }

                DataGridViewCell cell = dgvStatVarProperties[colIndex, rowIndex];

                if (cell.GetType() == typeof(DataGridViewComboBoxCell))
                {
                    return (DataGridViewComboBoxCell)cell;
                }
                else
                {
                    throw new Exception("The parentStatVarCell does not contain a combobox");
                }
            }
            catch (Exception)
            {
                //Dbg.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
