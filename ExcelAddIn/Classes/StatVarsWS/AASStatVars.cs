using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    [Serializable()]
    [XmlRoot(ElementName = "ArrayOfVariableset", IsNullable = true, Namespace = "http://tempuri.org/")]
    [XmlType("ArrayOfVariableset")]
    public class AASStatVars : List<AASStatVar>
    {
        public List<ComboBoxItem> GetLevel1()
        {
            var mList = new List<ComboBoxItem>();
            foreach (AASStatVar mStatVar in this)
            {
                mList.Add(new ComboBoxItem(mStatVar.var1));
            }
            return ComboBoxItem.MakeUniqueList(mList);
        }

        public List<ComboBoxItem> GetLevel2(string pLevel1 = null)
        {
            var mList = new List<ComboBoxItem>();
            foreach (AASStatVar mStatVar in this)
            {
                mList.Add(new ComboBoxItem(mStatVar.var2));
            }
            return ComboBoxItem.MakeUniqueList(mList);
        }

        public List<ComboBoxItem> GetLevel3(string pLevel2 = null)
        {
            var mList = new List<ComboBoxItem>();
            foreach (AASStatVar mStatVar in this)
            {
                mList.Add(new ComboBoxItem(mStatVar.var3));
            }
            return ComboBoxItem.MakeUniqueList(mList);
        }

        public List<ComboBoxItem> GetLevel4(string pLevel3 = null)
        {
            var mList = new List<ComboBoxItem>();
            foreach (AASStatVar mStatVar in this)
            {
                mList.Add(new ComboBoxItem(mStatVar.var4));
            }
            return ComboBoxItem.MakeUniqueList(mList);
        }

        public List<ComboBoxItem> GetLevel5(string pLevel4 = null)
        {
            var mList = new List<ComboBoxItem>();
            foreach (AASStatVar mStatVar in this)
            {
                mList.Add(new ComboBoxItem(mStatVar.var5));
            }
            return ComboBoxItem.MakeUniqueList(mList);
        }

    }

}
