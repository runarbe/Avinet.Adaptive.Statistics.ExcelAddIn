using System;
using System.Collections.Generic;
using System.Linq;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    /// <summary>
    /// A single multi-dimensional statistics value to be loaded into Adaptive.
    /// This class "shadows" the Adaptive3 class StatisticalData
    /// </summary>
    public class AdaptiveValue
    {
        /// <summary>
        /// The id of the statistical area, currentRow.e. a "kommunenummer"
        /// </summary>
        public int? krets_id;

        /// <summary>
        /// The four-digit year that the value is valid for
        /// </summary>
        public int? year;

        /// <summary>
        /// The part of the year that the value is valid for, currentRow.e. 1st quarter, 2nd tertiary etc.
        /// </summary>
        public int? quarter;

        /// <summary>
        /// The numeric month of the year that the value is valid for, currentRow.e. 1-12
        /// </summary>
        public int? month;

        /// <summary>
        /// The first varLevel of the statistical variable definition hierarchy
        /// </summary>
        public string variable1 = null;

        /// <summary>
        /// The second varLevel of the statistical variable definition hierarchy
        /// </summary>
        public string variable2 = null;

        /// <summary>
        /// The third varLevel of the statistical variable definition hierarchy
        /// </summary>
        public string variable3 = null;

        /// <summary>
        /// The fourth varLevel of the statistical variable definition hierarchy
        /// </summary>
        public string variable4 = null;

        /// <summary>
        /// The fifth varLevel of the statistical variable definition hierarchy
        /// </summary>
        public string variable5 = null;

        /// <summary>
        /// The group of areas that the current value belongs to, currentRow.e. "Vestlandet" for "Rogaland" or "Sogn og Fjordane".
        /// </summary>
        public string region = null;

        /// <summary>
        /// The title of the statistical area that is identified by the statistical area id, currentRow.e. "Gloppen" for "kommunenummer = 1445"
        /// </summary>
        public string krets_name = null;

        /// <summary>
        /// The actual statistical value expressed as a double precision number
        /// </summary>
        public int value;

        /// <summary>
        /// The measurement unit in which the value is expressed
        /// </summary>
        public string unit = null;

        /// <summary>
        /// The id of the selected statistical variable (represented as string)
        /// </summary>
        public int? fk_variable;

        /// <summary>
        /// Duplicate of fk_variable
        /// TODO: Resolve which one to keep
        /// </summary>
        public int? variable_id;

        /// <summary>
        /// Id of kretstype, e.g. uuid of "kommune", uuid of "fylke" etc.
        /// </summary>
        public string kretstype_id = null;

        /// <summary>
        /// Keyword to define the time-resolution of the dataset, one of Year, Quarter or Month
        /// </summary>
        public string time_unit = null;

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param title="pValue">The value</param>
        public AdaptiveValue(int pValue)
        {
            this.value = pValue;
        }

        public ValidationResult Validate()
        {
            var msg = new List<String>();

            if (variable1.IsNullOrEmpty() || variable2.IsNullOrEmpty() || variable3.IsNullOrEmpty())
            {
                msg.Add("Minst tre variabelnivå må spesifiserast");
            }

            if (kretstype_id.IsNullOrEmpty())
            {
                msg.Add("Kretstype ID er ikkje spesifisert");
            }

            var validationResult = new ValidationResult();

            if (msg.Count() == 0)
            {
                validationResult.IsValid = true;
            }
            else
            {
                validationResult.IsValid = false;
                validationResult.Message = String.Join(", ", msg);
            }

            return validationResult;

        }

        public string LogValidate()
        {
            var mStringFormat = "Status: {16} -- kretstype_id: {17}, krets_id:{0}, krets_name:{1}, region:{2}, year:{3}, quarter:{4}, month:{5}, var1:{6}, var2:{7}, var3:{8}, var4:{9}, var5:{10}, value:{11}, unit:{12}, variable_id{13}, fk_variable:{14}, time_unit:{15}";

            var checkValid = this.Validate();

            return String.Format(mStringFormat,
                this.krets_id,
                this.krets_name,
                this.region,
                this.year,
                this.quarter,
                this.month,
                this.variable1,
                this.variable2,
                this.variable3,
                this.variable4,
                this.variable5,
                this.value,
                this.unit,
                this.variable_id,
                this.fk_variable,
                this.time_unit,
                checkValid.IsValid == true ? "OK" : "Error:" + checkValid.Message,
                this.kretstype_id
                );
        }
        public static string GetCSVHeader()
        {
            return "\"fk_variable\";\"krets_id\";\"krets_name\";\"region\";\"år\";\"quarter\"; \"month\";\"variable1\";\"variable2\";\"variable3\";\"variable4\";\"variable5\";\"value\";\"unit\"";
        }

        public string ToCSV()
        {
            var mStringFormat = "\"{13}\";\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\";\"{6}\";\"{7}\";\"{8}\";\"{9}\";\"{10}\";{11};\"{12}\"";

            return String.Format(mStringFormat,
                this.krets_id,
                this.krets_name,
                this.region,
                this.year,
                this.quarter,
                this.month,
                this.variable1,
                this.variable2,
                this.variable3,
                this.variable4,
                this.variable5,
                this.value,
                this.unit,
                this.fk_variable);
        }

    }
}
