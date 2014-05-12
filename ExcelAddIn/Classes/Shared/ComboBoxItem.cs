using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ComboBoxItem : IComparable
    {
        public string key { get; set; }
        public string value { get; set; }

        public ComboBoxItem(string pKey, string pValue = null)
        {
            this.key = pKey;
            this.value = pValue != null ? pValue : pKey;
        }

        public static ComboBoxItem GetNewItem(string pItem)
        {
            return new ComboBoxItem(pItem, pItem);
        }

        public static List<ComboBoxItem> MakeUniqueList(List<ComboBoxItem> pComboBoxItems)
        {
            return pComboBoxItems.Distinct(new ComboBoxItemComparer()).ToList<ComboBoxItem>();
        }

        // Implement IComparable CompareTo method - provide default sort order.
        int IComparable.CompareTo(object pComboBoxItem)
        {
            var mComboBoxItem = (ComboBoxItem)pComboBoxItem;
            return String.Compare(this.key, mComboBoxItem.key);
        }

    }

    public class ComboBoxItemComparer : IEqualityComparer<ComboBoxItem>
    {
        public bool Equals(ComboBoxItem x, ComboBoxItem y)
        {
            return x.key == y.key;
        }

        public int GetHashCode(ComboBoxItem obj)
        {
            return obj.key.GetHashCode();
        }
    }
}
