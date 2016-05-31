using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal
{
    public class Variable
    {
        public int id { get; set; }
        public string var1 { get; set; }
        public string var2 { get; set; }
        public string var3 { get; set; }
        public string var4 { get; set; }
        public string var5 { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public bool showunit { get; set; }
        public string fk_kretstyper { get; set; }
        public string time_unit { get; set; }
        public DateTime create_date { get; set; }
        public int? parent_id { get; set; }

        /// <summary>
        /// Copy names from a parent variable
        /// </summary>
        /// <param name="parent"></param>
        public void copyNamesFrom(Variable parent, int toLevel)
        {
            try
            {
                if (!toLevel.Between(1, 5))
                {
                    throw new Exception("toLevel should be an integer between 1 and 5");
                }
                if (toLevel >= 1)
                {
                    var1 = parent.var1.emptyIfNull();
                }
                if (toLevel >= 2)
                {
                    var2 = parent.var2.emptyIfNull();
                }
                if (toLevel >= 3)
                {
                    var3 = parent.var3.emptyIfNull();
                }
                if (toLevel >= 4)
                {
                    var4 = parent.var4.emptyIfNull();
                }
                if (toLevel == 5)
                {
                    var5 = parent.var5.emptyIfNull();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check if a the current variable  belongs at a sepecific level
        /// (1-5) in the variable hierarchy
        /// </summary>
        /// <param name="i">An integer between 1 and 5</param>
        /// <returns>True if is specified level, false otherwise</returns>
        public bool IsLevel(int i)
        {
            int l = 0;

            if (this.var5.isNotNullOrEmpty())
            {
                l = 5;
            }
            else if (this.var4.isNotNullOrEmpty())
            {
                l = 4;
            }
            else if (this.var3.isNotNullOrEmpty())
            {
                l = 3;
            }
            else if (this.var2.isNotNullOrEmpty())
            {
                l = 2;
            }
            else if (this.var1.isNotNullOrEmpty())
            {
                l = 1;
            }
            return i == l ? true : false;

        }

        /// <summary>
        /// Get child variables
        /// </summary>
        /// <param name="parent_id"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public IEnumerable<Variable> getChildren(int? parent_id, IEnumerable<Variable> variables)
        {
            return (from v in variables where v.parent_id == parent_id select v);
        }

        /// <summary>
        /// Return the current collection as a stat tree node
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        public StatTreeNode AsStatTreeNode(IEnumerable<StatTreeNode> children = null)
        {
            var s = new StatTreeNode();
            s.Text = this.name;
            s.id = this.id;
            s.parent_id = this.parent_id;
            s.Tag = this;
            s.Name = this.id.ToString();
            if (children != null)
            {
                s.Nodes.AddIEnum(children);
            }
            return s;
        }

        public string getNameAtLevel(int nameLevel)
        {
            try
            {
                if (!nameLevel.Between(1, 5))
                {
                    throw new Exception("nameLevel must be a positive integer between 1 and 5");
                }

                switch (nameLevel)
                {
                    case 1:
                        return this.var1;
                    case 2:
                        return this.var2;
                    case 3:
                        return this.var3;
                    case 4:
                        return this.var4;
                    case 5:
                        return this.var5;
                    default:
                        throw new Exception("This should never fire");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Copy names 
        /// </summary>
        /// <returns></returns>
        public string getLeafName()
        {
            if (var5.isNotNullOrEmpty())
            {
                return var5;
            }
            else if (var4.isNotNullOrEmpty())
            {
                return var4;
            }
            else if (var3.isNotNullOrEmpty())
            {
                return var3;
            }
            else if (var2.isNotNullOrEmpty())
            {
                return var2;
            }
            else
            {
                return var1;
            }
        }
    }

}
