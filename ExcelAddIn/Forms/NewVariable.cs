using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
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
    public partial class NewVariable : Form
    {
        public Variable ParentVariable;
        public Variable Variable;

        public NewVariable()
        {
            InitializeComponent();
        }

        private void NewVariable_Load(object sender, EventArgs e)
        {
            cbKretstyper.DataSource = new BindingSource(AdaptiveClient.GetKretstyper().ToList(), null);
            cbKretstyper.DisplayMember = "name";
            cbKretstyper.ValueMember = "uuid";

            cbTimeUnit.DataSource = new BindingSource(AdaptiveClient.GetTimeUnits(), null);
            cbTimeUnit.DisplayMember = "key";
            cbTimeUnit.ValueMember = "value";

            cbUnit.DataSource = new BindingSource(AdaptiveClient.GetUnits(), null);
            cbUnit.DisplayMember = "key";
            cbUnit.ValueMember = "value";

        }

        /// <summary>
        /// Create a new variable and return it (or null on close/exit)
        /// </summary>
        /// <param name="parentVariable"></param>
        /// <returns></returns>
        public static Variable NewVariablePopup(Variable parentVariable)
        {
            var frm = new NewVariable();
            frm.ParentVariable = parentVariable;
            frm.tbParentVariable.Text = parentVariable.GetLeafName();
            frm.tbVarLevel.Text = (parentVariable.GetLevel() + 1).ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                return frm.Variable;
            }
            else
            {
                return null;
            };
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            Variable varDef = new Variable();

            varDef.CopyNamesFrom(ParentVariable, ParentVariable.GetLevel() + 1);
            varDef.SetNameAtLevel(ParentVariable.GetLevel() + 1, tbVarName.Text);
            varDef.fk_kretstyper = cbKretstyper.SelectedValue.ToString();
            varDef.time_unit = cbTimeUnit.SelectedValue.ToString();
            varDef.unit = cbUnit.SelectedValue.ToString();

            var request = new AddVariableRequest();
            request.data = varDef;

            var res = AdaptiveClient.AddVariable(request);

            if (res.d.success == true)
            {
                //DebugToFile.Log("Reloading variable definitions");
                ConfigProvider.ReloadVariables();
                this.Variable = varDef;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Variable = null;
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Kunne ikkje opprette variabel", "Feil");
            }
        }

    }
}
