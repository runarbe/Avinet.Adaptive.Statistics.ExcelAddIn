using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// A single multi-dimensional statistics value to be loaded into Adaptive
    /// </summary>
    public class AdaptiveValue
    
    {
        /// <summary>
        /// The id of the statistical area, currentRow.e. a "kommunenummer"
        /// </summary>
        public string krets_id = null;

        /// <summary>
        /// The four-digit year that the value is valid for
        /// </summary>
        public string ar = null;

        /// <summary>
        /// The part of the year that the value is valid for, currentRow.e. 1st quarter, 2nd tertiary etc.
        /// </summary>
        public string kvartal = null;

        /// <summary>
        /// The numeric month of the year that the value is valid for, currentRow.e. 1-12
        /// </summary>
        public string mnd = null;

        /// <summary>
        /// The numeric day of the month that the value is valid for, currentRow.e. 1-28/29/30/31
        /// </summary>
        [Obsolete("Not used anywhere in application")]
        public string Day = null;

        /// <summary>
        /// The first level of the statistical variable definition hierarchy
        /// </summary>
        public string variable1 = null;

        /// <summary>
        /// The second level of the statistical variable definition hierarchy
        /// </summary>
        public string variable2 = null;

        /// <summary>
        /// The third level of the statistical variable definition hierarchy
        /// </summary>
        public string variable3 = null;

        /// <summary>
        /// The fourth level of the statistical variable definition hierarchy
        /// </summary>
        public string variable4 = null;

        /// <summary>
        /// The fifth level of the statistical variable definition hierarchy
        /// </summary>
        public string variable5 = null;

        /// <summary>
        /// The group of areas that the current value belongs to, currentRow.e. "Vestlandet" for "Rogaland" or "Sogn og Fjordane".
        /// </summary>
        public string region = null;

        /// <summary>
        /// The name of the statistical area that is identified by the statistical area id, currentRow.e. "Gloppen" for "kommunenummer = 1445"
        /// </summary>
        public string krets_navn = null;

        /// <summary>
        /// The actual statistical value expressed as a double precision number
        /// </summary>
        public string verdi = null;

        /// <summary>
        /// The measurement unit in which the value is expressed
        /// </summary>
        public string enhet = null;

        /// <summary>
        /// The id of the selected statistical variable (represented as string)
        /// </summary>
        public string fk_variable = null;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public AdaptiveValue(string pValue)
        {
            this.verdi = pValue;
            
        }

        /// <summary>
        /// Overridden class to convert an Adaptive value to a human readable string;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Statistikkvariabel: {0}, Måleeining: {1}, Verdi: {2}, År: {3}, År: {4}, Månad: {5}, Krins ID: {6}, Krinsnamn: {7}, Krinsgruppe: {8}",
                this.variable1 + " / " + this.variable2 + " / " +this.variable3 + " / " +this.variable4 + " / " +this.variable5,
                this.verdi,
                this.enhet,
                this.ar,
                this.kvartal,
                this.mnd,
                this.krets_id,
                this.krets_navn,
                this.region);
        }

        public string ToCSV()
        {
            var mStringFormat = "\"{13}\";\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\";\"{6}\";\"{7}\";\"{8}\";\"{9}\";\"{10}\";{11};\"{12}\"";

            return String.Format(mStringFormat,
                this.krets_id,
                this.krets_navn,
                this.region,
                this.ar,
                this.kvartal,
                this.mnd,
                this.variable1,
                this.variable2,
                this.variable3,
                this.variable4,
                this.variable5,
                this.verdi,
                this.enhet,
                this.fk_variable);
        }

    }
}
