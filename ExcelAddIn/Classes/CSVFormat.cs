using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class CsvFile : List<CsvLine>
    {
        public string Serialize() {
            var mStringBuilder = new StringBuilder();
            foreach (CsvLine mCsvLine in this)
            {
                mStringBuilder.AppendLine(mCsvLine.Serialize());
            }
            return mStringBuilder.ToString();
        }

    }

    public class CsvLine
    {
        public string variable1;
        public string variable2;
        public string variable3;
        public string variable4;
        public string variable5;
        public string description;
        public string dataset_id;
        public string krets_id;
        public string krets_name;
        public string kretstype_id;
        public string region;
        public string month;
        public string day;
        public string quarter;
        public string year;
        public double value;
        public string unit;

        public string GetHeaderRow()
        {
            return "\"krets_id\";\"krets_navn\";\"region\";\"år\";\"kvartal\"; \"mnd\";\"variable1\";\"variable2\";\"variable3\";\"variable4\";\"variable5\";\"verdi\";\"enhet\"";
        }

        public string Serialize()
        {
            var mStringFormat = "\"{0}\";\"{1}\";\"{2}\";\"{3}\";\"{4}\";\"{5}\";\"{6}\";\"{7}\";\"{8}\";\"{9}\";\"{10}\";{11};\"{12}\"";

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
                this.unit
                );
        }
    }
}
