using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class StatTreeNode : TreeNode
    {
        /// <summary>
        /// Id of node
        /// </summary>
        public int id;

        /// <summary>
        /// Parent id of node
        /// </summary>
        public int? parent_id;

        /// <summary>
        /// What type of node it is
        /// </summary>
        public TreeNodeType TreeNodeType = TreeNodeType.Folder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param title="s"></param>
        public StatTreeNode(string s = null)
            : base()
        {
            if (s != null)
            {
                this.Text = s;
            }
        }

    }
}
