    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    [Serializable()]
    [XmlRoot(ElementName = "variableset", IsNullable=true, Namespace="http://tempuri.org/")]
    [XmlType("variableset")]
    public class AASStatVar
    {
        [XmlElement(ElementName="var1", IsNullable=true)]
        public string var1 { get; set; }
        [XmlElement(ElementName = "var2", IsNullable = true)]
        public string var2 { get; set; }
        [XmlElement(ElementName = "var3", IsNullable = true)]
        public string var3 { get; set; }
        [XmlElement(ElementName = "var4", IsNullable = true)]
        public string var4 { get; set; }
        [XmlElement(ElementName = "var5", IsNullable = true)]
        public string var5 { get; set; }
    }
}
