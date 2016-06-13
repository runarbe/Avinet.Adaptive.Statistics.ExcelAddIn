using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class MessagesErrors
    {
        public static string AutoDateParseError = "Feil: Kan ikkje lese dato frå feltverdiar.";
        public static string MUnitNotSet = "Feil: Kan ikkje lese eigenskapen 'Måleeining' under arkfana 'Innstillingar for Statistikkvariablar'";
        public static string ManualDateNotSet = "Feil: Det er ikkje oppgjeve datering for verdiane i utvalet. Du må anten velje ei rad eller kolonne som inneheld dateringsinformasjon eller du må fylle inn verdiane under arkfana 'Innstillingar for statistikkvariablar'";
    }

}
