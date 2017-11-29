using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Forms
{
    public partial class StatVarTreeForm : Form
    {
        /// <summary>
        /// The currently selected parent variable (from tree)
        /// </summary>
        public Variable selectedParentVariable;

        /// <summary>
        /// The currently selected parent tree node (from tree)
        /// </summary>
        public StatTreeNode selectedParentTreeNode;

        public List<TreeNode> matchingNodes;

        public int currentMatchingNode = 0;

        public int numMatchingNodes = 0;

        public StatVarTreeForm()
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
            svTree.HideSelection = false;
            ReloadTree();
            svTree.CollapseAll();
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

            req.variable.CopyNamesFrom(selectedParentVariable, level);

            if (level == 5)
            {
                req.variable.var5 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 4)
            {
                req.variable.var4 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 3)
            {
                req.variable.var3 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 2)
            {
                req.variable.var2 = tbVarName.Text.EmptyIfNull();
            }
            else if (level == 1)
            {
                req.variable.var1 = tbVarName.Text.EmptyIfNull();
            }

            req.variable.title = tbVarName.Text;

            req.variable.level = tbVarLevel.Text.AsInt();

            req.variable.parent_id = selectedParentVariable.id;

            try
            {
                var res = AdaptiveClient.AddVariable(req);

                if (res == null)
                {
                    this.Log("Kunne ikkje legge til variabel: " + req.variable.title);
                    return;
                }

                if (!res.d.success)
                {
                    this.Log("Kunne ikkje legge til variabel: " + req.variable.title);
                }
                else
                {
                    this.Log("La til ny variabel: " + req.variable.title);
                    ReloadTree(req.variable.parent_id.ToString());
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
        /// Populate form with rows from an existing tree node
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

        private TreeNode FindTreeNode(TreeNodeCollection nodes, string q)
        {
            foreach (TreeNode child in nodes)
            {
                if (child.Text.Contains(q))
                {
                    return child;
                }

                if (child.Nodes.Count > 0)
                {
                    TreeNode found = FindTreeNode(child.Nodes, q);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }
            return null;
        }

        private List<TreeNode> FindTreeNodes(TreeNodeCollection nodes, string q, List<TreeNode> list = null)
        {
            if (list == null)
            {
                list = new List<TreeNode>();
            }

            foreach (TreeNode child in nodes)
            {
                if (child.Text.ToLower().Contains(q.ToLower()))
                {
                    list.Add(child);
                }

                if (child.Nodes.Count > 0)
                {
                    list = FindTreeNodes(child.Nodes, q, list);
                }
            }
            return list;
        }

        private void tbFilterNodes_TextChanged(object sender, EventArgs e)
        {
            svTree.BeginUpdate();

            svTree.Nodes.Clear();
            svTree.Nodes.AddIEnum(ConfigProvider.variableTree);

            TreeNode n = null;
            if (tbFilterNodes.Text.Length >= 3)
            {
                matchingNodes = FindTreeNodes(svTree.Nodes, tbFilterNodes.Text);
                numMatchingNodes = matchingNodes.Count();
                currentMatchingNode = 0;

                if (numMatchingNodes > 0)
                {
                    n = matchingNodes[currentMatchingNode];
                    statusMsg.Text= "Viser treff " + (currentMatchingNode + 1) + " av "  + numMatchingNodes + " for '" + tbFilterNodes.Text + "'";
                    if (numMatchingNodes > 1)
                    {
                        btnNextMatch.Enabled = true;
                        btnPreviousMatch.Enabled = false;
                    }
                    else
                    {
                        btnNextMatch.Enabled = false;
                        btnPreviousMatch.Enabled = false;
                    }
                }
            }
            else
            {
                n = null;
            }

            if (n != null)
            {
                svTree.CollapseAll();
                svTree.SelectedNode = n;
            }
            svTree.EndUpdate();
        }

        private void btnPreviousMatch_Click(object sender, EventArgs e)
        {
            if (currentMatchingNode > 0)
            {
                currentMatchingNode--;
                if (currentMatchingNode == 0)
                {
                    btnPreviousMatch.Enabled = false;
                }

                if (currentMatchingNode < numMatchingNodes - 1)
                {
                    btnNextMatch.Enabled = true;
                }
            }
            svTree.CollapseAll();
            svTree.SelectedNode = matchingNodes[currentMatchingNode];
            statusMsg.Text = "Viser treff " + (currentMatchingNode + 1) + " av " + numMatchingNodes;
        }

        private void btnNextMatch_Click(object sender, EventArgs e)
        {
            if (currentMatchingNode < numMatchingNodes - 1)
            {
                currentMatchingNode++;

                if (currentMatchingNode == numMatchingNodes - 1)
                {
                    btnNextMatch.Enabled = false;
                }

                if (currentMatchingNode > 0)
                {
                    btnPreviousMatch.Enabled = true;
                }

            }
            svTree.CollapseAll();
            svTree.SelectedNode = matchingNodes[currentMatchingNode];
            statusMsg.Text = "Viser treff " + (currentMatchingNode + 1) + " av " + numMatchingNodes;
        }
    }

}
