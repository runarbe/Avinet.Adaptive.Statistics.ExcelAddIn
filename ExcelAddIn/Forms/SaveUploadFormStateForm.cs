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
    public partial class SaveUploadFormStateForm : Form
    {
        public UploadFormState State = null;

        public SaveUploadFormStateForm()
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

        private void cbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.IsNullOrEmpty())
            {
                return;
            }
            State.StateName = tbTitle.Text;
            State.Category = cbSubCategory.Text;
            State.SubCategory = cbSubCategory.Text;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveUploadFormStateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        public static UploadFormState GetNameAndCategory(UploadFormState state, string title = "")
        {
            if (state == null) return null;

            var frm = new SaveUploadFormStateForm();

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
