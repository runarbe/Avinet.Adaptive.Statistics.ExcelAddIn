using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avinet.Adaptive.Statistics.ExcelAddIn.Functions;
using System.Windows.Forms;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Adaptive;

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

        public Variable()
        {
            var1 = "";
            var2 = "";
            var3 = "";
            var4 = "";
            var5 = "";
            fk_kretstyper = "e8009aaf-4475-4397-b01a-86584dcadcb1";
            unit = "";
            showunit = false;
            time_unit = "Year";
        }

        /// <summary>
        /// Copy names from a parent variable
        /// </summary>
        /// <param name="parent"></param>
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Check if a the current variable  belongs at a sepecific varLevel
        /// (1-5) in the variable hierarchy
        /// </summary>
        /// <param name="i">An integer between 1 and 5</param>
        /// <returns>True if is specified varLevel, false otherwise</returns>
        public bool IsLevel(int i)
        {
            int l = 0;

            if (this.var5.IsNotNullOrEmpty())
            {
                l = 5;
            }
            else if (this.var4.IsNotNullOrEmpty())
            {
                l = 4;
            }
            else if (this.var3.IsNotNullOrEmpty())
            {
                l = 3;
            }
            else if (this.var2.IsNotNullOrEmpty())
            {
                l = 2;
            }
            else if (this.var1.IsNotNullOrEmpty())
            {
                l = 1;
            }
            return i == l ? true : false;

        }


        /// <summary>
        /// Return the current collection as a stat tree node
        /// </summary>
        /// <param name="children"></param>
        /// <returns></returns>
        public StatTreeNode AsStatTreeNode(IEnumerable<StatTreeNode> children = null)
        {
            var s = new StatTreeNode();
            s.Text = this.GetNameAtLevel(GetLevel());
            s.id = this.id;
            s.Tag = this;
            s.Name = this.GetConcatId();
            
            if (children != null)
            {
                s.Nodes.AddIEnum(children);
            }

            if (s.id == -2)
            {
                s.ImageKey = "closedFolder";
                s.SelectedImageKey = "openFolder";
                s.TreeNodeType = TreeNodeType.Folder;
            }
            else
            {
                s.ImageKey = "variable";
                s.SelectedImageKey = "selectedVariable";
                s.TreeNodeType = TreeNodeType.Variable;
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

        private List<string> GetIdParts()
        {
            var idParts = new List<string>();

            int varLevel = GetLevel();

            if (varLevel >= 1)
            {
                idParts.Add(var1);
            }

            if (varLevel >= 2)
            {
                idParts.Add(var2);
            }

            if (varLevel >= 3)
            {
                idParts.Add(var3);
            }
            if (varLevel >= 4)
            {
                idParts.Add(var4);
            }
            if (varLevel >= 5)
            {
                idParts.Add(var5);
            }

            return idParts;

        }

        public string GetConcatParentId()
        {
            if (GetLevel() == 1)
            {
                return null;
            }
            else
            {
                var idParts = GetIdParts();
                idParts.RemoveAt(idParts.Count() - 1);
                return String.Join("-", idParts.ToArray());
            }
        }

        public string GetConcatId()
        {
            var idParts = GetIdParts();
            return String.Join("-", idParts.ToArray());
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
            if (id == -2)
            {
                return retVal;
            }
            else
            {
                return String.Format("{0} - ({1}, {2}, {3})",
                    retVal,
                    ConfigProvider.GetUnitByValue(this.unit).ToLower(),
                    ConfigProvider.GetTimeUnitByValue(this.time_unit).ToLower(),
                    ConfigProvider.GetKretstypeByValue(this.fk_kretstyper).ToLower()
                    );
            }
        }

        /// <summary>
        /// Copy names 
        /// </summary>
        /// <returns></returns>
        public string GetLeafName()
        {
            if (var5.IsNotNullOrEmpty())
            {
                return var5;
            }
            else if (var4.IsNotNullOrEmpty())
            {
                return var4;
            }
            else if (var3.IsNotNullOrEmpty())
            {
                return var3;
            }
            else if (var2.IsNotNullOrEmpty())
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
