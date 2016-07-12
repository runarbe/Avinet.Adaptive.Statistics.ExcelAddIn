using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    [Obsolete("Not in use")]
    public class StatVarTreeNode
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string label { get; set; }
        public string fk_kretstyper { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public bool showunit { get; set; }
        public string var_name { get; set; }
        public string time_unit { get; set; }
        public IEnumerable<StatVarTreeNode> children { get; set; }

        public TreeNode AsTreeNode(IEnumerable<TreeNode> children = null)
        {
            var t = new TreeNode();
            t.Text = this.label;
            t.Tag = this;
            if (children != null)
            {
                foreach (var child in children)
                {
                    t.Nodes.Add(child);
                }
            }

            return t;
        }

    }
}
