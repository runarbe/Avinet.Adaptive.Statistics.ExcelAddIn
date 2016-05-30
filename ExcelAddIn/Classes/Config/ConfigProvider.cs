using Avinet.Adaptive.Statistics.ExcelAddIn.Classes;
using Avinet.Adaptive.Statistics.ExcelAddIn.Classes.Portal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ConfigProvider
    {
        public List<ConfigSetting> statUnitTypes { get; set; }
        public List<ConfigSetting> measurementUnitTypes { get; set; }
        public List<ConfigSetting> statVariableTypes { get; set; }

        public static IEnumerable<Variable> variableDefinitions { get; set; }

        public static IEnumerable<StatTreeNode> variableTree { get; set; }

        public string type { get; set; }
        
        public ConfigProvider()
        {
        }

        public static DataTable AsDataTable(List<ConfigSetting> mList)
        {
            DataTable mDataTable = new DataTable();
            mDataTable.Columns.Add(new DataColumn("key", typeof(string)));
            mDataTable.Columns.Add(new DataColumn("value", typeof(string)));
            foreach (var mConfigListEntry in mList)
            {
                var mRow = mDataTable.NewRow();
                mRow["key"] = mConfigListEntry.key;
                mRow["value"] = mConfigListEntry.value;
                mDataTable.Rows.Add(mRow);
            }
            return mDataTable;
        }

    }
}
