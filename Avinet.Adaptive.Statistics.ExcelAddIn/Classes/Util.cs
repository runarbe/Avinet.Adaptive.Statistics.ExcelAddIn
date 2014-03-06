using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public static class Util
    {
        
        public static CType GetSelCType(ComboBox pComboBox)
        {
            CType mStatus = CType.None;
            if (pComboBox.SelectedValue != null)
            {
                Enum.TryParse<CType>(pComboBox.SelectedValue.ToString(), out mStatus);
            }
            return mStatus;
        }


        public static string CheckNullOrEmpty(string pString)
        {
            if (pString != null && pString.Trim() != "")
            {
                return pString;
            }
            else
            {
                return null;
            }
        }

        public static bool IsJsonString(string pJsonString)
        {
            if (
                pJsonString.Length >= 2 &&
                pJsonString.Substring(0, 1) == "{" &&
                pJsonString.Substring(pJsonString.Length - 1) == "}"
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void SetComboBoxDS(ComboBox pComboBox, IEnumerable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {

            var tmp = pComboBox.SelectedValue;
            pComboBox.DataSource = pDataSource;
            pComboBox.ValueMember = pValueMember;
            pComboBox.DisplayMember = pDisplayMember;
            if (tmp != null)
            {
                pComboBox.SelectedValue = tmp;
            }
        }

        public static void SetDgvComboBoxDS(DataGridViewComboBoxColumn pDataGridViewComboBoxCol, IEnumerable pDataSource, string pDisplayMember = "key", string pValueMember = "value")
        {
            pDataGridViewComboBoxCol.DataSource = pDataSource;
            pDataGridViewComboBoxCol.DisplayMember = pDisplayMember;
            pDataGridViewComboBoxCol.ValueMember = pValueMember;
        }

        public static string Dump(object obj, int recursion = 2)
        {
            StringBuilder result = new StringBuilder();

            // Protect the method against endless recursion
            if (recursion < 5)
            {
                // Determine object type
                Type t = obj.GetType();

                // Get array with properties for this object
                PropertyInfo[] properties = t.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    try
                    {
                        // Get the property Value
                        object value = property.GetValue(obj, null);

                        // Create indenting string to put in front of properties of a deeper level
                        // We'll need this when we display the property pVariable and Value
                        string indent = String.Empty;
                        string spaces = "|   ";
                        string trail = "|...";

                        if (recursion > 0)
                        {
                            indent = new StringBuilder(trail).Insert(0, spaces, recursion - 1).ToString();
                        }

                        if (value != null)
                        {
                            // If the Value is a string, Add quotation marks
                            string displayValue = value.ToString();
                            if (value is string) displayValue = String.Concat('"', displayValue, '"');

                            // Add property pVariable and Value to return string
                            result.AppendFormat("{0}{1} = {2}\n", indent, property.Name, displayValue);

                            try
                            {
                                if (!(value is ICollection))
                                {
                                    // Call Dump() again to list child properties
                                    // This throws an exception if the current property Value
                                    // is of an unsupported type (eg. it has not properties)
                                    result.Append(Dump(value, recursion + 1));
                                }
                                else
                                {
                                    // 2009-07-29: added support for collections
                                    // The Value is a collection (eg. it's an arraylist or generic list)
                                    // so loop through its elements and dump their properties
                                    int elementCount = 0;
                                    foreach (object element in ((ICollection)value))
                                    {
                                        string elementName = String.Format("{0}[{1}]", property.Name, elementCount);
                                        indent = new StringBuilder(trail).Insert(0, spaces, recursion).ToString();

                                        // Display the collection element pVariable and type
                                        result.AppendFormat("{0}{1} = {2}\n", indent, elementName, element.ToString());

                                        // Display the child properties
                                        result.Append(Dump(element, recursion + 2));
                                        elementCount++;
                                    }

                                    result.Append(Dump(value, recursion + 1));
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            // Add empty (null) property to return string
                            result.AppendFormat("{0}{1} = {2}\n", indent, property.Name, "null");
                        }
                    }
                    catch
                    {
                        // Some properties will throw an exception on property.GetValue()
                        // I don't know exactly why this happens, so for now mRowNum will ignore them...
                    }
                }
            }

            return result.ToString();
        }
    }
}