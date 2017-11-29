using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    public partial class SavedStateSelectForm : Form
    {
        private IEnumerable<UploadFormState> loadedStates;

        public UploadFormState SelectedState = null;

        public SavedStateSelectForm()
        {
            InitializeComponent();
        }

        private void UploadFormStateListForm_Load(object sender, EventArgs e)
        {
            //Reset form
            OnCategoryFilterChangeReQuerySavedStates(null, null);

            // Add event handlers
            tbTitle.TextChanged += OnQueryTextChangeReQuerySavedStates;
            cbCategory.SelectedValueChanged += OnCategoryFilterChangeReQuerySavedStates;
            cbSubCategory.SelectedValueChanged += OnSubCategoryFilterChangeReQuerySavedStates;

            // Populate main categories
            var categories = this.loadedStates
                .Select(s => new ComboBoxItem(s.Category, s.Category))
                .Distinct()
                .ToList();

            if (categories.Count() > 0)
            {
                categories.Insert(0, new ComboBoxItem("Alle kategoriar", null));
                cbCategory.DataSource = categories;
                cbCategory.ValueMember = "value";
                cbCategory.DisplayMember = "key";
            }

        }

        private void OnSubCategoryFilterChangeReQuerySavedStates(object sender, EventArgs e)
        {
            QueryStates();
        }

        private void OnQueryTextChangeReQuerySavedStates(object sender, EventArgs e)
        {
            QueryStates();
        }

        private void OnCategoryFilterChangeReQuerySavedStates(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(cbCategory.Text))
            {

                Debug.WriteLine("Got here with category: " + cbCategory.Text);
                var subCategories = this.loadedStates
                    .Where(s => s.Category == cbCategory.Text
                        && !String.IsNullOrEmpty(s.SubCategory))
                    .Select(s => new ComboBoxItem(s.SubCategory, s.SubCategory))
                    .OrderBy(s => s.key)
                    .Distinct()
                    .ToList();

                if (subCategories.Count() > 0)
                {
                        subCategories.Insert(0, new ComboBoxItem("Alle underkategoriar", null));
                        cbSubCategory.DataSource = subCategories;
                        cbSubCategory.ValueMember = "value";
                        cbSubCategory.DisplayMember = "key";
                        cbSubCategory.Enabled = true;
                }
                else
                {
                    cbSubCategory.DataSource = null;
                    cbSubCategory.Enabled = false;
                }

            }
            else
            {
                cbSubCategory.Enabled = false;
                cbSubCategory.DataSource = null;
            }
            QueryStates();
        }

        private void QueryStates()
        {
            this.loadedStates = UploadFormState.LoadSavedStates().AsEnumerable<UploadFormState>();

            if (!String.IsNullOrEmpty(tbTitle.Text))
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

            lbSavedStates.DisplayMember = "StateDisplayName";
            lbSavedStates.DataSource = loadedStates.ToList<UploadFormState>();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.SelectedState = lbSavedStates.SelectedValue as UploadFormState;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lbSavedStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSavedStates.SelectedItem != null)
            {
                btnRestore.Enabled = true;
            }
            else
            {
                btnRestore.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var s = lbSavedStates.SelectedValue as UploadFormState;
            if (UploadFormState.DeleteState(s) == true)
            {
                UploadFormStateListForm_Load(null, null);
            };
        }


    }
}
