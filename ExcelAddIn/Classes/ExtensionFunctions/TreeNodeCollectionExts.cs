using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class TreeNodeCollectionExts
    {
        public static void AddIEnum(this TreeNodeCollection coll, IEnumerable<TreeNode> m)
        {
            if (coll == null || m == null)
            {
                return;
            }

            foreach (TreeNode treeNode in m)
            {
                coll.Add(treeNode);
            }
        }
    }
}
