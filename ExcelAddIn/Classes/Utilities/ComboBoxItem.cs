using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class ComboBoxItem : IComparable, IEquatable<ComboBoxItem>
    {
        public string key { get; set; }
        public object value { get; set; }

        public ComboBoxItem()
        {
        }

        public override bool Equals(object obj)
        {
            ComboBoxItem otherCb = obj as ComboBoxItem;
            return otherCb != null && key != otherCb.key;
        }

        public override int GetHashCode()
        {
            return key.GetHashCode();
        }

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


        bool IEquatable<ComboBoxItem>.Equals(ComboBoxItem other)
        {
            if (key == other.key)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }

    public class ComboBoxItemComparer : IEqualityComparer<ComboBoxItem>
    {
        public bool Equals(ComboBoxItem x, ComboBoxItem y)
        {
            return x.key.Trim() == y.key.Trim();
        }

        public int GetHashCode(ComboBoxItem obj)
        {
            return obj.key.Trim().GetHashCode();
        }
    }
}
