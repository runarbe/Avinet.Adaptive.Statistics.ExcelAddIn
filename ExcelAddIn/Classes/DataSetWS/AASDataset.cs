using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    [Serializable()]
    [XmlRoot(ElementName = "dataset", IsNullable=true, Namespace="http://tempuri.org/")]
    [XmlType("dataset")]
    public class AASDataset
    {
        [XmlElement("name")]
        public string name { get; set; }
        [XmlElement("id")]
        public string id { get; set; }
    }
}
