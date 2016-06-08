using Avinet.Adaptive.Statistics.ExcelAddIn.Classes;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ConfigProvider
    {
        public static IEnumerable<Kretstyper> kretstyper { get; set; }
        public static Dictionary<string, string> units { get; set; }
        public static Dictionary<string, string> timeUnits { get; set; }
        public static IEnumerable<Variable> variables { get; set; }
        public static IEnumerable<StatTreeNode> variableTree { get; set; }

        public ConfigProvider()
        {
        }

        /// <summary>
        /// Get time unit by value
        /// </summary>
        /// <param name="timeUnitValue"></param>
        /// <returns></returns>
        public static string GetTimeUnitByValue(string timeUnitValue)
        {
            if (ConfigProvider.timeUnits != null)
            {
                foreach (var kvp in ConfigProvider.timeUnits)
                {
                    if (kvp.Value == timeUnitValue)
                    {
                        return kvp.Key;
                    }
                }
            }

            return timeUnitValue;
        }

        /// <summary>
        /// Get unit by value
        /// </summary>
        /// <param name="unitValue"></param>
        /// <returns></returns>
        public static string GetUnitByValue(string unitValue)
        {
            if (ConfigProvider.units != null)
            {
                foreach (var kvp in ConfigProvider.units)
                {
                    if (kvp.Value == unitValue)
                    {
                        return kvp.Key;
                    }
                }
            }

            return unitValue;
        }
        
        /// <summary>
        /// GetKretstypeByValue
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static string GetKretstypeByValue(string uuid) {
            if (ConfigProvider.kretstyper != null)
            {
                foreach (var kvp in ConfigProvider.kretstyper)
                {
                    if (kvp.uuid == uuid)
                    {
                        return kvp.name;
                    }
                }
            }
            return uuid;
        }
        
        /// <summary>
        /// Reload configuration from server
        /// </summary>
        public static void Reload() {
            Load();
        }


        public static void ReloadVariables()
        {
            LoadVariables();
        }

        public static TreeNodeCollection GetChildNodes(Variable parentVariable)
        {
            var root = new TreeNode("root");

            if (parentVariable == null)
            {
                //DebugToFile.Log("No parent variable");
                return root.Nodes;
            }

            var children = from ch in variables where
                           ch.GetConcatParentId() == parentVariable.GetConcatId()
                           select ch.AsStatTreeNode();
            root.Nodes.AddRange(children.ToArray());
            return root.Nodes;
        }

        public static void LoadVariables()
        {
            AdaptiveClient.GetVariable();
        }

        /// <summary>
        /// Load configuration from server
        /// </summary>
        public static void Load() {
            kretstyper = AdaptiveClient.GetKretstyper();
            units = AdaptiveClient.GetUnits();
            timeUnits = AdaptiveClient.GetTimeUnits();
            ConfigProvider.LoadVariables();
        }


    }
}
