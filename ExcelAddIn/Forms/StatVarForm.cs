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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatVarTreeForm_Load(object sender, EventArgs e)
        {
            var imageList = new ImageList();
            imageList.Images.Add("openFolder", Properties.Resources.openFolder);
            imageList.Images.Add("closedFolder", Properties.Resources.closedFolder);
            imageList.Images.Add("variable", Properties.Resources.variable);
            imageList.Images.Add("selectedVariable", Properties.Resources.selectedVariable);
            svTree.ImageList = imageList;

            ReloadTree();
            svTree.ExpandAll();

            cbKretstyper.DataSource = new BindingSource(AdaptiveClient.GetKretstyper(), null);
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

            req.data.unit = (string)cbUnit.SelectedValue;
            req.data.showunit = chkbShowUnit.Checked;
            req.data.time_unit = (string)cbTimeUnit.SelectedValue;
            req.data.fk_kretstyper = (string)cbKretstyper.SelectedValue;

            try
            {
                var res = AdaptiveClient.AddVariable(req);
                if (!res.d.success)
                {
                    this.Log("Kunne ikkje legge til variabel: " +  req.data.GetNameAtLevel(level));
                }
                else
                {
                    this.Log("La til ny variabel: " + req.data.GetNameAtLevel(level));
                    ReloadTree(req.data.GetConcatId());
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
            if (cbTimeUnit.SelectedValue == null)
            {
                Log("Ugyldig tidsoppløysing");
                valid = false;
            }
            if (cbUnit.SelectedValue == null)
            {
                Log("Ugyldig måleeining");
                valid = false;
            }
            if (cbKretstyper.SelectedValue == null)
            {
                Log("Ugyldig kretstype");
                valid = false;
            }

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
                Log("Ikkje i stand til å lese 'foreldrevariabel'");
                valid = false;
            }

            return valid;
        }

        /// <summary>
        /// Populate form with valuesList from an existing tree node
        /// </summary>
        /// <param name="node"></param>
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

            // Get the name of the selected node
            tbParentVariable.Text = sv.GetNameAtLevel(node.Level + 1);
            
            // Populate text and comboboxes
            if (sv == null || sv.unit == null)
            {
                cbUnit.SelectedValue = "";
                cbTimeUnit.SelectedValue = "";
                cbUnit.SelectedValue = "";
                chkbShowUnit.Checked = false;
            }
            else
            {
                cbKretstyper.SelectedValue = sv.fk_kretstyper;
                cbTimeUnit.SelectedValue = sv.time_unit;
                cbUnit.SelectedValue = sv.unit;
                chkbShowUnit.Checked = sv.showunit;
            }

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
