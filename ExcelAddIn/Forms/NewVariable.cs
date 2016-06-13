using System;
using System.Linq;
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
        }

        /// <summary>
        /// Create a new variable and return it (or null on close/exit)
        /// </summary>
        /// <param title="parentVariable"></param>
        /// <returns></returns>
        public static Variable NewVariablePopup(Variable parentVariable, string variableName = "")
        {
            var frm = new NewVariable();
            frm.ParentVariable = parentVariable;
            frm.tbParentVariable.Text = parentVariable.title;
            frm.tbVarLevel.Text = (parentVariable.level + 1).ToString();
            frm.tbVarName.Text = variableName;
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

            varDef.CopyNamesFrom(ParentVariable, ParentVariable.level + 1);
            varDef.level = tbVarLevel.Text.AsInt();
            varDef.title = tbVarName.Text;
            varDef.SetNameAtLevel(varDef.level, tbVarName.Text);


            var request = new AddVariableRequest();
            request.data = varDef;
            request.data.parent_id = ParentVariable.id;

            var res = AdaptiveClient.AddVariable(request);

            if (res.d.success == true)
            {
                ConfigProvider.ReloadVariables();
                this.Variable = varDef;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.Variable = null;
                this.DialogResult = DialogResult.None;
                DebugToFile.Json(varDef);
                MessageBox.Show("Kunne ikkje opprette variabel: " + res.d.exception.msg, "Feil");
            }
        }

    }
}
