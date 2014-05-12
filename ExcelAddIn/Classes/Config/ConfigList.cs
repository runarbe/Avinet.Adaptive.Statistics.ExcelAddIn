using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ConfigList
    {
        public List<ConfigListEntry> statUnitTypes { get; set; }
        public List<ConfigListEntry> measurementUnitTypes { get; set; }
        public List<ConfigListEntry> statVariableTypes { get; set; }
        public string type { get; set; }
        
        public ConfigList()
        {
        }

        public static System.Data.DataTable AsDataTable(List<ConfigListEntry> mList)
        {
            System.Data.DataTable mDataTable = new System.Data.DataTable();
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
