using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    public partial class VariableListForm : Form
    {
        public DataGridViewComboBoxCell ParentStatVarCell = null;

        public String Query = null;

        public String CategoryFilter = null;

        public String SubCategoryFilter = null;

        public Variable SelectedVariable = null;

        public VariableListForm()
        {
            InitializeComponent();
        }

        public void SetParentStatVarCell(DataGridViewComboBoxCell parentStatVarCell)
        {
            this.ParentStatVarCell = parentStatVarCell;
        }

        private void VariableListForm_Load(object sender, EventArgs e)
        {

            var ds = (from c in ConfigProvider.variables
                      where c.level == 1
                      orderby c.var1
                      select new ComboBoxItem
                      {
                          key = c.var1,
                          value = c.id
                      }).ToList();

            if (ds == null || ds.Count == 0) return;

            ds.Insert(0, new ComboBoxItem { key = "Not filtered", value = null });

            cbCategory.DataSource = ds;
            cbCategory.DisplayMember = "key";
            cbCategory.ValueMember = "value";
            cbCategory.Text = ds[0].key;

            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            cbSubCategory.SelectedIndexChanged += cbSubCategory_SelectedIndexChanged;

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue == null)
            {
                cbSubCategory.Enabled = false;
                cbSubCategory.DataSource = null;
                CategoryFilter = null;
                ExecuteQuery();
                return;
            }
            else
            {
                CategoryFilter = cbCategory.Text.NullIfEmpty();
            }

            int? categoryId = cbCategory.SelectedValue as int?;


            var ds = (from c in ConfigProvider.variables
                      where c.parent_id == categoryId
                      orderby c.var2
                      select new ComboBoxItem
                      {
                          key = c.var2,
                          value = c.var2
                      }).ToList();

            if (ds == null || ds.Count() == 0)
            {
                cbSubCategory.Enabled = false;
                cbSubCategory.DataSource = null;
                ExecuteQuery();
                return;
            }

            ds.Insert(0, new ComboBoxItem { key = "Not filtered", value = null });
            cbSubCategory.Enabled = true;
            cbSubCategory.DataSource = ds;
            cbSubCategory.DisplayMember = "key";
            cbSubCategory.ValueMember = "value";
            cbSubCategory.Text = ds[0].key;

            ExecuteQuery();
        }

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubCategory.SelectedValue == null)
            {
                SubCategoryFilter = null;
                ExecuteQuery();
                return;
            }
            else
            {
                SubCategoryFilter = cbSubCategory.Text.NullIfEmpty();
                ExecuteQuery();
            }
        }

        /// <summary>
        /// Set parent control and display the form
        /// </summary>
        /// <param name="parentStatVarCell"></param>
        public void Display(DataGridViewComboBoxCell parentStatVarCell)
        {
            SetParentStatVarCell(parentStatVarCell);
            Show();
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <param name="query"></param>
        private void ExecuteQuery()
        {
            var matches = (from d in ConfigProvider.variables
                           where d.level >= 2 && d.GetHierarhicalName().ToLower().Contains(Query.ToLower())
                           orderby d.GetHierarhicalName()
                           select new
                           {
                               key = d.GetHierarhicalName(),
                               value = d
                           }).ToList();

            if (CategoryFilter.IsNotNullOrEmpty())
            {
                //Dbg.WriteLine(CategoryFilter);
                matches = (from m in matches where m.value.var1 == CategoryFilter select m).ToList();

                if (SubCategoryFilter.IsNotNullOrEmpty())
                {
                    //Dbg.WriteLine(SubCategoryFilter);

                    matches = (from m in matches where m.value.var2 == SubCategoryFilter select m).ToList();
                }
            }

            lbVariables.DataSource = matches;
            lbVariables.DisplayMember = "key";
            lbVariables.ValueMember = "value";
            lbVariables.Refresh();

        }

        /// <summary>
        /// Set query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="executeQuery"></param>
        public void SetQuery(string query, bool executeQuery = true)
        {
            Query = query;
            tbQuery.Text = query;
            if (executeQuery) ExecuteQuery();
        }

        public void SetSelectedStatVarText(string selectedText)
        {
            lbVariables.Text = selectedText;
        }

        private bool SetSelectedStatVar()
        {
            if (lbVariables.SelectedValue == null && ParentStatVarCell != null) return false;

            var ds = new List<NamedVariable>();
            var variable = lbVariables.SelectedValue as Variable;

            if (variable == null || variable.level < 3) return false;

            ds.Add(new NamedVariable()
            {
                Key = variable.GetHierarhicalName(),
                Value = variable
            });

            ParentStatVarCell.DataSource = ds;
            ParentStatVarCell.DisplayMember = "Key";
            ParentStatVarCell.ValueMember = "Value";
            ParentStatVarCell.Selected = true;
            ParentStatVarCell.Value = variable;

            return true;
        }

        private void lbVariables_DoubleClick(object sender, EventArgs e)
        {
            if (SetSelectedStatVar())
            {
                Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (SetSelectedStatVar())
            {
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var selectedText = lbVariables.Text;
            this.TopMost = false;
            var newVariable = NewVariable.NewVariablePopup(this.SelectedVariable, Query);
            this.TopMost = true;
            this.SetQuery(Query);
            SetSelectedStatVarText(selectedText);
        }

        private void lbVariables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVariables.SelectedValue != null)
            {
                this.SelectedVariable = lbVariables.SelectedValue as Variable;

                if (this.SelectedVariable == null) return;

                this.btnAddNew.Enabled = this.SelectedVariable.level >= 2 ? true : false;
                this.btnConfirm.Enabled = this.SelectedVariable.level >= 3 ? true : false;
            }
            else
            {
                this.SelectedVariable = null;
                this.btnAddNew.Enabled = false;
                this.btnConfirm.Enabled = false;
            }
        }

        private void tbQuery_TextChanged(object sender, EventArgs e)
        {
            Query = tbQuery.Text;
            ExecuteQuery();
        }

    }
}
