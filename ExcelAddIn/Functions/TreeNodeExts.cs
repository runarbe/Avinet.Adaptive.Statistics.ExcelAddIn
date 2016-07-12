using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Functions
{
    public static class TreeNodeExts
    {
        /// <summary>
        /// Add child nodes to a TreeNode
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="childNodes"></param>
        /// <returns></returns>
        public static TreeNode AddChildNodes(this TreeNode treeNode, IEnumerable<TreeNode> childNodes = null)
        {
            if (childNodes != null)
            {
                treeNode.Nodes.AddIEnum(childNodes);
            }
            return treeNode;
        }
    }
}
