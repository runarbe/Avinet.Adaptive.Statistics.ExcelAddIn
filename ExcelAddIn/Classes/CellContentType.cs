using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    public static class CellContentTypes
    {
        public const string Values = "0";
        public const string StatVars = "1";
        // Long-term remove this
        //public const string StatVars2 = "7";
        public const string StatAreaIDs = "2";
        public const string StatDatum = "3";
        public const string StatAreaNames = "4";
        public const string StatAreaGroups = "5";
        public const string StatAreaIDsAndNames = "6";
        public const string Ignore = "99";

        public static List<ComboBoxItem> AsComboBoxItems()
        {
            var mList = new List<ComboBoxItem>();
            mList.Add(new ComboBoxItem("Verdiar", CellContentTypes.Values));
            mList.Add(new ComboBoxItem("Statistikkvariablar", CellContentTypes.StatVars));
            // Long-term remove this 
            //mList.Add(new ComboBoxItem("Statistikkvariablar2", CellContentTypes.StatVars2));
            mList.Add(new ComboBoxItem("Krinsid", CellContentTypes.StatAreaIDs));
            mList.Add(new ComboBoxItem("Krinsnamn", CellContentTypes.StatAreaNames));
            mList.Add(new ComboBoxItem("Krinsid Krinsnamn", CellContentTypes.StatAreaIDsAndNames));
            mList.Add(new ComboBoxItem("Region", CellContentTypes.StatAreaGroups));
            mList.Add(new ComboBoxItem("Datering", CellContentTypes.StatDatum));
            mList.Add(new ComboBoxItem("Ignorer", CellContentTypes.Ignore));
            mList.Sort();
            return mList;
        }
    }
}
