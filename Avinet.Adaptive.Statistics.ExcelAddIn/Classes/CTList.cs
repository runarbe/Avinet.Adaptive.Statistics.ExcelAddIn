using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    static class CTList
    {
        public static List<CTEntry> List = new List<CTEntry>();

        static CTList()
        {
            CTList.List.Add(new CTEntry("Verdiar", CType.None));
            CTList.List.Add(new CTEntry("Ignorer", CType.Ignore));
            CTList.List.Add(new CTEntry("Datering", CType.StatDatum));
            CTList.List.Add(new CTEntry("Krins IDar", CType.StatAreaIDs));
            CTList.List.Add(new CTEntry("Krinsnamn", CType.StatAreaNames));
            CTList.List.Add(new CTEntry("Krinsgruppe", CType.StatAreaGroups));
            CTList.List.Add(new CTEntry("Statistikkvariablar", CType.StatVars));
            CTList.List.Sort();
        }

    }

}
