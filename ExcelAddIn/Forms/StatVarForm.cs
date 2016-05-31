using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes;

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
        /// Reset the form values
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
        /// Log message to log text area
        /// </summary>
        /// <param name="pObj"></param>
        public void Log(Object pObj)
        {
            tbLog.AppendText(pObj.ToString() + Environment.NewLine);
        }

        /// <summary>
        /// Reload the statistical variables
        /// </summary>
        public void ReloadTree(int? parentNode = null)
        {
            svTree.Nodes.Clear();
            ConfigProvider.variableTree = PortalClient.GetVariable();
            svTree.Nodes.AddIEnum(ConfigProvider.variableTree);
            if (parentNode != null)
            {
                var foundNodes = svTree.Nodes.Find(parentNode.ToString(), true);
                foreach (var tn in foundNodes)
                {
                    tn.EnsureVisible();
                    tn.Expand();
                }
            }

        }

        /// <summary>
        /// Load data on startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatVarTreeForm_Load(object sender, EventArgs e)
        {
            ReloadTree();
            svTree.ExpandAll();

            //Log(DebugToFile.LogFileName);

            var mKretstyper = PortalClient.GetKretstyper();

            cbKretstyper.DataSource = new BindingSource(mKretstyper.ToDictionary(t => t.name, c => c.uuid), null);
            cbKretstyper.DisplayMember = "key";
            cbKretstyper.ValueMember = "value";

        }

        /// <summary>
        /// Create a new tree node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (level == 5)
            {
                req.data.var5 = cbVarName.Text.emptyIfNull();
                req.data.var4 = selectedParentTreeNode.Text.emptyIfNull();
                req.data.var3 = selectedParentTreeNode.Parent.Text.emptyIfNull();
                req.data.var2 = selectedParentTreeNode.Parent.Parent.Text.emptyIfNull();
                req.data.var1 = selectedParentTreeNode.Parent.Parent.Parent.Text.emptyIfNull();
            }
            else if (level == 4)
            {
                req.data.var4 = cbVarName.Text.emptyIfNull();
                req.data.var3 = selectedParentTreeNode.Text.emptyIfNull();
                req.data.var2 = selectedParentTreeNode.Parent.Text.emptyIfNull();
                req.data.var1 = selectedParentTreeNode.Parent.Parent.Text.emptyIfNull();
            }
            else if (level == 3)
            {
                req.data.var3 = cbVarName.Text.emptyIfNull();
                req.data.var2 = selectedParentTreeNode.Text.emptyIfNull();
                req.data.var1 = selectedParentTreeNode.Parent.Text.emptyIfNull();
            }
            else if (level == 2)
            {
                req.data.var2 = cbVarName.Text.emptyIfNull();
                req.data.var1 = selectedParentTreeNode.Text.emptyIfNull();
            }
            else if (level == 1)
            {
                req.data.var1 = cbVarName.Text.emptyIfNull();
            }

            req.data.description = tbDescription.Text;
            req.data.name = cbVarName.Text.nullIfEmpty();
            req.data.unit = (string)cbUnit.SelectedValue;
            req.data.showunit = chkbShowUnit.Checked;
            req.data.time_unit = (string)cbTimeUnit.SelectedValue;
            req.data.fk_kretstyper = (string)cbKretstyper.SelectedValue;
            req.data.parent_id = selectedParentVariable == null ? null : (int?)selectedParentVariable.id;

            try
            {
                var res = PortalClient.AddVariable(req);
                if (!res.d.success)
                {
                    this.Log("Kunne ikkje legge til variabel: " +  req.data.getNameAtLevel(level));
                }
                else
                {
                    this.Log("La til ny variabel: " + req.data.getNameAtLevel(level));
                    var scrollOffset = svTree.AutoScrollOffset;
                    ReloadTree(selectedParentTreeNode.id);
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
            if (cbKretstyper.SelectedValue == null)
            {
                valid = false;
            }

            if (!cbVarName.Text.isNotNullOrEmpty())
            {
                valid = false;
            }

            if (selectedParentTreeNode == null || selectedParentTreeNode.Level >= 4)
            {
                valid = false;
            }

            if (selectedParentVariable == null)
            {
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Populate form with values from an existing tree node
        /// </summary>
        /// <param name="node"></param>
        private void populateForm(StatTreeNode node)
        {
            if (node == null)
            {
                return;
            }

            // Disable editing if node selected parent level is greater than 3
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

            // Set level of NEW node
            tbVarLevel.Text = (node.Level + 2).ToString();

            // Get the name of the selected node
            tbParentVariable.Text = sv.getNameAtLevel(node.Level + 1);
            
            // Populate text and comboboxes
            cbKretstyper.SelectedValue = sv.fk_kretstyper;
            cbTimeUnit.SelectedValue = sv.time_unit;
            cbUnit.SelectedValue = sv.unit;
            chkbShowUnit.Checked = sv.showunit;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
