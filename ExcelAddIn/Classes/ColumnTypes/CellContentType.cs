using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    public static class CellContentType
    {
        public const string Values = "0";
        public const string StatVars = "1";
        public const string StatVars2 = "7";
        public const string StatAreaIDs = "2";
        public const string StatDatum = "3";
        public const string StatAreaNames = "4";
        public const string StatAreaGroups = "5";
        public const string StatAreaIDsAndNames = "6";
        public const string Ignore = "99";

        public static List<ComboBoxItem> GetComboBoxItems()
        {
            var mList = new List<ComboBoxItem>();
            mList.Add(new ComboBoxItem("Verdiar", CellContentType.Values));
            mList.Add(new ComboBoxItem("Statistikkvariablar", CellContentType.StatVars));
            mList.Add(new ComboBoxItem("Krinsid", CellContentType.StatAreaIDs));
            mList.Add(new ComboBoxItem("Krinsnamn", CellContentType.StatAreaNames));
            mList.Add(new ComboBoxItem("Krinsid Krinsnamn", CellContentType.StatAreaIDsAndNames));
            mList.Add(new ComboBoxItem("Region", CellContentType.StatAreaGroups));
            mList.Add(new ComboBoxItem("Datering", CellContentType.StatDatum));
            mList.Add(new ComboBoxItem("Ignorer", CellContentType.Ignore));
            mList.Sort();
            return mList;
        }
    }
}
