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
        /// The id of the statistical area, mRow.e. a "kommunenummer"
        /// </summary>
        public string StatAreaID = null;

        /// <summary>
        /// The four-digit year that the value is valid for
        /// </summary>
        public string Year = null;

        /// <summary>
        /// The part of the year that the value is valid for, mRow.e. 1st quarter, 2nd tertiary etc.
        /// </summary>
        public string YearPart = null;

        /// <summary>
        /// The numeric month of the year that the value is valid for, mRow.e. 1-12
        /// </summary>
        public string Month = null;

        /// <summary>
        /// The numeric day of the month that the value is valid for, mRow.e. 1-28/29/30/31
        /// </summary>
        public string Day = null;

        /// <summary>
        /// The statistical variable definition that the value represents
        /// </summary>
        private string StatVar = null;

        /// <summary>
        /// The first level of the statistical variable definition hierarchy
        /// </summary>
        private string StatVar1 = null;

        /// <summary>
        /// The second level of the statistical variable definition hierarchy
        /// </summary>
        private string StatVar2 = null;

        /// <summary>
        /// The third level of the statistical variable definition hierarchy
        /// </summary>
        private string StatVar3 = null;

        /// <summary>
        /// The fourth level of the statistical variable definition hierarchy
        /// </summary>
        private string StatVar4 = null;

        /// <summary>
        /// The fifth level of the statistical variable definition hierarchy
        /// </summary>
        private string StatVar5 = null;

        /// <summary>
        /// The group of areas that the current value belongs to, mRow.e. "Vestlandet" for "Rogaland" or "Sogn og Fjordane".
        /// </summary>
        public string StatAreaGroup = null;

        /// <summary>
        /// The name of the statistical area that is identified by the statistical area id, mRow.e. "Gloppen" for "kommunenummer = 1445"
        /// </summary>
        public string StatAreaName = null;

        /// <summary>
        /// The actual statistical value expressed as a double precision number
        /// </summary>
        public string Value = null;

        /// <summary>
        /// The measurement unit in which the value is expressed
        /// </summary>
        public string MUnit = null;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="pValue">The value</param>
        public AdaptiveValue(string pValue)
        {
            this.Value = pValue;
            
        }

        public void SetStatVar(string pStatVar) {
            
            this.StatVar = pStatVar;
            
            var mStatVarParts = pStatVar.Split('#');
            
            if (mStatVarParts.Length >= 1)
            {
                this.StatVar1 = mStatVarParts[0];
            }
            if (mStatVarParts.Length >= 2)
            {
                this.StatVar2 = mStatVarParts[1];
            }
            if (mStatVarParts.Length >= 3)
            {
                this.StatVar3 = mStatVarParts[2];
            }
            if (mStatVarParts.Length >= 4)
            {
                this.StatVar4 = mStatVarParts[3];
            }
            if (mStatVarParts.Length >= 5)
            {
                this.StatVar5 = mStatVarParts[4];
            }
        }

        /// <summary>
        /// Get the statistical variable
        /// </summary>
        /// <returns></returns>
        public string GetStatVar() {
            return this.StatVar;
        }

        /// <summary>
        /// Overridden class to convert an Adaptive value to a human readable string;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Statistikkvariabel: {0}, Måleeining: {1}, Verdi: {2}, År: {3}, År: {4}, Månad: {5}, Dag: {6}, Krins ID: {7}, Krinsnamn: {8}, Krinsgruppe: {9}",
                this.StatVar,
                this.Value,
                this.MUnit,
                this.Year,
                this.YearPart,
                this.Month,
                this.Day,
                this.StatAreaID,
                this.StatAreaName,
                this.StatAreaGroup);
        }

        public string ToCSV()
        {
            var mStringFormat = "\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\";\"{6}\";\"{7}\";\"{8}\";\"{9}\";\"{10}\";{11};\"{12}\"";

            return String.Format(mStringFormat,
                this.StatAreaID,
                this.StatAreaName,
                this.StatAreaGroup,
                this.Year,
                this.YearPart,
                this.Month,
                this.StatVar1,
                this.StatVar2,
                this.StatVar3,
                this.StatVar4,
                this.StatVar5,
                this.Value,
                this.MUnit);
        }

    }
}
