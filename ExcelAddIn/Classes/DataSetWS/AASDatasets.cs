using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{

    [Serializable()]
    [XmlRoot(ElementName="ArrayOfDataset", IsNullable=true, Namespace="http://tempuri.org/")]
    [XmlType("ArrayOfDataset")]
    public class AASDatasets : List<AASDataset>
    {

    }
}