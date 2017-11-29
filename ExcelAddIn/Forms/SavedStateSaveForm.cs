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
    public partial class SavedStateSaveForm : Form
    {
        public UploadFormState State = null;

        public IEnumerable<UploadFormState> loadedStates = UploadFormState.LoadSavedStates().AsEnumerable<UploadFormState>();

        public SavedStateSaveForm()
        {
            InitializeComponent();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (tbTitle.Text.IsNotNullOrEmpty())
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.IsNullOrEmpty())
            {
                return;
            }
            State.StateName = tbTitle.Text;
            State.Category = cbCategory.Text;
            State.SubCategory = cbSubCategory.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveUploadFormStateForm_Load(object sender, EventArgs e)
        {
            if (!ConfigProvider.IsLoaded)
            {
                return;
            }

            var ds = ConfigProvider.variables
                .Where(c => c.level == 1)
                .OrderBy(ob => ob.var1)
                .Select(c => new ComboBoxItem
                {
                    key = c.var1,
                    value = c.id
                })
                .ToList();


            if (ds != null && ds.Count > 0)
            {
                ds.Insert(0, new ComboBoxItem("Alle kategoriar", null));
                cbCategory.DataSource = ds;
                cbCategory.DisplayMember = "key";
                cbCategory.ValueMember = "value";
                cbCategory.Text = ds[0].key;

                cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
                cbSubCategory.SelectedIndexChanged += cbSubCategory_SelectedIndexChanged;

            }
            lbExistingStates.Click += lbExistingStates_SelectedIndexChanged;
            QueryStates();

        }

        private void lbExistingStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb == null) return;

            UploadFormState uf = lb.SelectedValue as UploadFormState;
            if (uf == null) return;

            tbTitle.Text = uf.StateName;
            cbCategory.Text = uf.Category;
            cbSubCategory.Text = uf.SubCategory;
        }

        private void QueryStates()
        {
            this.loadedStates = UploadFormState.LoadSavedStates().AsEnumerable<UploadFormState>();

            if (!String.IsNullOrEmpty(tbTitle.Text) && tbTitle.Text != "Nytt opplastingsoppsett")
            {
                loadedStates = loadedStates.Where(s => s.StateDisplayName.ToLower().Contains(tbTitle.Text.ToLower()));
            }

            if (!String.IsNullOrEmpty(cbCategory.Text) && cbCategory.Text != "Alle kategoriar")
            {
                loadedStates = loadedStates.Where(s => s.Category == cbCategory.Text);
            }

            if (!String.IsNullOrEmpty(cbSubCategory.Text) && cbSubCategory.Text != "Alle underkategoriar")
            {
                loadedStates = loadedStates.Where(s => s.SubCategory == cbSubCategory.Text);
            }

            loadedStates = loadedStates.OrderBy(d => d.StateDisplayName);

            lbExistingStates.DisplayMember = "StateDisplayName";
            lbExistingStates.DataSource = loadedStates.ToList<UploadFormState>();

        }

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSubCategory.SelectedValue == null)
            {
                return;
            }
            else
            {
                QueryStates();
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue == null)
            {
                cbSubCategory.Enabled = false;
                cbSubCategory.DataSource = null;
            }
            else
            {
                int? categoryId = cbCategory.SelectedValue as int?;

                var ds = (from c in ConfigProvider.variables
                          where c.parent_id == categoryId && !String.IsNullOrEmpty(c.var2)
                          orderby c.var2
                          select new ComboBoxItem(c.var2,c.var2)
                          )
                          .Distinct()
                          .OrderBy(s => s.key)
                          .ToList();

                if (ds == null || ds.Count() == 0)
                {
                    cbSubCategory.Enabled = false;
                    cbSubCategory.DataSource = null;
                }
                else
                {
                    ds.Insert(0, new ComboBoxItem("Alle underkategoriar", null));
                    cbSubCategory.Enabled = true;
                    cbSubCategory.DataSource = ds;
                    cbSubCategory.DisplayMember = "key";
                    cbSubCategory.ValueMember = "value";
                    cbSubCategory.Text = ds[0].key;
                }

            }

            QueryStates();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static UploadFormState GetNameAndCategory(UploadFormState state, string title = "", string category = "", string subCategory = "")
        {
            if (state == null) return null;

            var frm = new SavedStateSaveForm();

            frm.tbTitle.Text = title;
            frm.State = state;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.State;
            }
            else
            {
                return null;
            }
        }
    }
}
