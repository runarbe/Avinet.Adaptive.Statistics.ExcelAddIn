using System;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    public partial class StatVarForm : Form
    {
        /// <summary>
        /// The currently selected parent variable (from tree)
        /// </summary>
        public Variable selectedParentVariable;

        /// <summary>
        /// The currently selected parent tree node (from tree)
        /// </summary>
        public StatTreeNode selectedParentTreeNode;

        public StatVarForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reset the form valuesList
        /// </summary>
        public void ResetForm()
        {
            selectedParentVariable = null;
            selectedParentTreeNode = null;

            foreach (Control field in this.Controls)
            {
                if (field is TextBox)
                {
                    ((TextBox)field).Clear();
                }
                else if (field is ComboBox)
                {
                    ((ComboBox)field).SelectedIndex = 0;
                }
            }

        }

        /// <summary>
        /// WriteLine message to log text area
        /// </summary>
        /// <param title="pObj"></param>
        public void Log(Object pObj)
        {
            tbLog.AppendText(pObj.ToString() + Environment.NewLine);
        }

        /// <summary>
        /// Reload the statistical variables
        /// </summary>
        public void ReloadTree(string parentNode = null)
        {
            svTree.Nodes.Clear();
            ConfigProvider.variableTree = AdaptiveClient.GetVariable();
            svTree.Nodes.AddIEnum(ConfigProvider.variableTree);
            if (parentNode != null)
            {
                var foundNodes = svTree.Nodes.Find(parentNode, true);
                foreach (var tn in foundNodes)
                {
                    tn.EnsureVisible();
                    tn.Expand();
                }
            }

        }

        /// <summary>
        /// Load valuesList on startup
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void StatVarTreeForm_Load(object sender, EventArgs e)
        {
            if (!ConfigProvider.IsLoaded)
            {
                ConfigProvider.Load();
            }

            var imageList = new ImageList();
            imageList.Images.Add("openFolder", Properties.Resources.openFolder);
            imageList.Images.Add("closedFolder", Properties.Resources.closedFolder);
            imageList.Images.Add("variable", Properties.Resources.variable);
            imageList.Images.Add("selectedVariable", Properties.Resources.selectedVariable);
            svTree.ImageList = imageList;

            ReloadTree();
            svTree.ExpandAll();
        }

        /// <summary>
        /// Create a new tree node
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            if (!isValid())
            {
                this.Log("Ugyldige verdiar, kontroller skjema");
                return;
            }

            var req = new AddVariableRequest();

            int level;
            int.TryParse(tbVarLevel.Text, out level);

            req.data.CopyNamesFrom(selectedParentVariable, level);

            if (level == 5)
            {
                req.data.var5 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 4)
            {
                req.data.var4 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 3)
            {
                req.data.var3 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 2)
            {
                req.data.var2 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 1)
            {
                req.data.var1 = tbVarName.Text.EmptyIfNull();
            }

            req.data.title = tbVarName.Text;

            req.data.level = tbVarLevel.Text.AsInt();

            req.data.parent_id = selectedParentVariable.id;

            try
            {
                var res = AdaptiveClient.AddVariable(req);
                if (!res.d.success)
                {
                    this.Log("Kunne ikkje legge til variabel: " +  req.data.title);
                }
                else
                {
                    this.Log("La til ny variabel: " + req.data.title);
                    ReloadTree(req.data.parent_id.ToString());
                }
            }
            catch (Exception ex)
            {
                this.Log(ex.Message);
            }
        }

        private bool isValid()
        {
            bool valid = true;

            if (!tbVarName.Text.IsNotNullOrEmpty())
            {
                Log("Ugyldig variabelnamn");
                valid = false;
            }

            if (selectedParentTreeNode == null || selectedParentTreeNode.Level >= 4)
            {
                Log("'Foreldrenode' ikkje valt");
                valid = false;
            }

            if (selectedParentVariable == null)
            {
                Log("Ikkje rowIndex stand til å lese 'foreldrevariabel'");
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Populate form with values from an existing tree node
        /// </summary>
        /// <param title="node"></param>
        private void populateForm(StatTreeNode node)
        {
            if (node == null)
            {
                return;
            }

            // Disable editing if node selected parent varLevel is greater than 3
            if (node.Level > 3)
            {
                formPanel.Enabled = false;
                return;
            }
            else
            {
                formPanel.Enabled = true;
            }

            // Get variable from selected node
            Variable sv = (Variable)node.Tag;

            // Set selected parent nodes
            selectedParentTreeNode = node;
            selectedParentVariable = sv;

            // Set varLevel of NEW node
            tbVarLevel.Text = (node.Level + 2).ToString();

            // Get the title of the selected node
            tbParentVariable.Text = sv.GetNameAtLevel(node.Level + 1);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param title="sender"></param>
        /// <param title="e"></param>
        private void svTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = svTree.SelectedNode;
            if (tn != null)
            {
                populateForm((StatTreeNode)tn);
            }
        }

        private void btnRefreshTree_Click(object sender, EventArgs e)
        {
            ReloadTree();
            svTree.ExpandAll();
            ResetForm();
        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }

        private void chkbShowUnit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblVarName_Click(object sender, EventArgs e)
        {

        }
    }

}
