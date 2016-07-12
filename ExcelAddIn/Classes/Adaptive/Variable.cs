using System;
using System.Collections.Generic;
using System.Linq;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class Variable
    {
        public int id { get; set; }
        public string var1 { get; set; }
        public string var2 { get; set; }
        public string var3 { get; set; }
        public string var4 { get; set; }
        public string var5 { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int level { get; set; }
        public int? parent_id { get; set; }

        public Variable()
        {
            var1 = "";
            var2 = "";
            var3 = "";
            var4 = "";
            var5 = "";
        }

        /// <summary>
        /// Copy names from a parent variable
        /// </summary>
        /// <param title="parent"></param>
        public void CopyNamesFrom(Variable parent, int toLevel)
        {
            try
            {
                if (!toLevel.Between(1, 5))
                {
                    throw new Exception("toLevel should be an integer between 1 and 5");
                }
                if (toLevel >= 1)
                {
                    var1 = parent.var1.EmptyIfNull();
                }
                if (toLevel >= 2)
                {
                    var2 = parent.var2.EmptyIfNull();
                }
                if (toLevel >= 3)
                {
                    var3 = parent.var3.EmptyIfNull();
                }
                if (toLevel >= 4)
                {
                    var4 = parent.var4.EmptyIfNull();
                }
                if (toLevel == 5)
                {
                    var5 = parent.var5.EmptyIfNull();
                }

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Return the hierarchical name of the variable
        /// </summary>
        /// <returns></returns>
        public string GetHierarhicalName()
        {

            var nameComponents = new List<string>();

            if (level >= 1)
            {
                nameComponents.Add(var1);
            }
            
            if (level >= 2)
            {
                nameComponents.Add(var2);
            }
            
            if (level >= 3)
            {
                nameComponents.Add(var3);
            }
            
            if (level >= 4)
            {
                nameComponents.Add(var4);
            }

            if (level >= 5)
            {
                nameComponents.Add(var5);
            }

            return String.Join(" > ", nameComponents);

        }

        /// <summary>
        /// Check if a the current variable  belongs at a sepecific varLevel
        /// (1-5) in the variable hierarchy
        /// </summary>
        /// <param title="rowIndex">An integer between 1 and 5</param>
        /// <returns>True if is specified varLevel, false otherwise</returns>
        public bool IsLevel(int i)
        {
            return i == this.level ? true : false;
        }


        /// <summary>
        /// Return the current collection as a stat tree node
        /// </summary>
        /// <param title="children"></param>
        /// <returns></returns>
        public StatTreeNode AsStatTreeNode(IEnumerable<StatTreeNode> children = null)
        {
            var s = new StatTreeNode();

            s.Text = this.title;
            s.id = this.id;
            s.Tag = this;
            s.Name = this.id.ToString();

            if (children != null)
            {
                s.Nodes.AddIEnum(children);
                s.ImageKey = "openFolder";
                s.SelectedImageKey = "openFolder";
            }
            else
            {
                s.ImageKey = "variable";
                s.SelectedImageKey = "variable";
            }

            return s;
        }

        /// <summary>
        /// Return the level of the variable
        /// </summary>
        /// <returns>1-5 on success or -1 if none of the criteria are satisfied</returns>
        public int GetLevel()
        {
            if (var5.IsNotNullOrEmpty())
            {
                return 5;
            }
            else if (var4.IsNotNullOrEmpty())
            {
                return 4;
            }
            else if (var3.IsNotNullOrEmpty())
            {
                return 3;
            }
            else if (var2.IsNotNullOrEmpty())
            {
                return 2;
            }
            else if (var1.IsNotNullOrEmpty())
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        [Obsolete("Use parent_id property instead")]
        public string GetParentId()
        {
            return this.parent_id.ToString();
        }

        [Obsolete("Use id property instead")]
        public string GetId()
        {
            return this.id.ToString();
        }

        public void SetNameAtLevel(int level, string name)
        {
            if (!level.Between(1, 5))
            {
                return;
            }

            switch (level)
            {
                case 1:
                    this.var1 = name;
                    break;
                case 2:
                    this.var2 = name;
                    break;
                case 3:
                    this.var3 = name;
                    break;
                case 4:
                    this.var4 = name;
                    break;
                case 5:
                    this.var5 = name;
                    break;
            }

        }

        public string GetNameAtLevel(int level)
        {
            if (!level.Between(1, 5))
            {
                return "";
            }

            string retVal = "";

            switch (level)
            {
                case 1:
                    retVal = this.var1;
                    break;
                case 2:
                    retVal = this.var2;
                    break;
                case 3:
                    retVal = this.var3;
                    break;
                case 4:
                    retVal = this.var4;
                    break;
                case 5:
                    retVal = this.var5;
                    break;
            }

            return retVal;
        }

        [Obsolete("Use title property instead")]
        /// <summary>
        /// Get the leaf-title of the current variable
        /// </summary>
        /// <returns></returns>        
        public string GetLeafName()
        {
            return GetNameAtLevel(GetLevel());
        }
    }
}
