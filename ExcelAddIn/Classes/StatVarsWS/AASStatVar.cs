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
        [XmlElement(ElementName="currentVar1", IsNullable=true)]
        public string var1 { get; set; }
        [XmlElement(ElementName = "currentVar2", IsNullable = true)]
        public string var2 { get; set; }
        [XmlElement(ElementName = "currentVar3", IsNullable = true)]
        public string var3 { get; set; }
        [XmlElement(ElementName = "currentVar4", IsNullable = true)]
        public string var4 { get; set; }
        [XmlElement(ElementName = "currentVar5", IsNullable = true)]
        public string var5 { get; set; }
    }
}
