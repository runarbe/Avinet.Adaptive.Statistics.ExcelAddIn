using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn.Classes
{
    [Serializable]
    class UploadFormState
    {
        public string Col1;
        public string Col2;
        public string Col3;
        public string Col4;
        public string Row1;
        public string Row2;
        public string Row3;
        public string Row4;
        public List<UploadFormFieldState> Fields;
    }

    class UploadFormFieldState
    {
        public string FieldName;
        public string StatVarLevel1;
        public string StatVarLevel2;
        public string StatVarLevel3;
        public string StatVarLevel4;
        public string StatVarLevel5;
        public string MeasurementUnit;
        public int Year;
        public string Quarter;
        public int Month;
        public int Day;
    }

}
