using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class AdaptiveValue
    {
        public string StatAreaID = null;
        public string StatYear = null;
        public string StatYearPart = null;
        public string StatMonth = null;
        public string StatDay = null;
        public string StatVar = null;
        public string StatAreaGroup = null;
        public string StatAreaName = null;
        public string Value = null;
        public string MeasureMentUnit = null;

        public AdaptiveValue(string pValue, string pStatAreaId = null, string pStatYear = null)
        {
            this.Value = pValue;
        }

        public override string ToString()
        {
            return String.Format("Statistikkvariabel: {0}, Verdi: {1}, År: {2}, Månad: {3}, Dag: {4}, Krins ID: {5}",
                this.StatVar,
                this.Value,
                this.StatYear,
                this.StatMonth,
                this.StatDay,
                this.StatAreaID);
        }

    }
}
